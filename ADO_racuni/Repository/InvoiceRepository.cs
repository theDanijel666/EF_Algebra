using Microsoft.Data.SqlClient;
using ADO_racuni.Models;
using System.Numerics;

namespace ADO_racuni.Repository
{
    public class InvoiceRepository
    {
        private readonly IConfiguration _configuration;

        public InvoiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Invoices"));

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * from Invoices";

            con.Open();

            SqlDataReader read_invoices= cmd.ExecuteReader();

            while (read_invoices.Read())
            {
                Invoice invoice= new Invoice();
                invoice.InvoiceNumber = (int)read_invoices["InvoiceNumber"];
                invoice.DateOfIssue = (DateTime)read_invoices["DateOfIssue"];

                invoices.Add(invoice);
            }

            read_invoices.Close();
            con.Close();
            con.Dispose();

            return invoices;
        }

        public Invoice GetInvoiceByNumber(int invoiceNumber)
        {
            Invoice inv= new Invoice();

            using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("Invoices")))
            {
                SqlCommand cmd= new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT * from Invoices Where InvoiceNumber = " + invoiceNumber.ToString();
                cmd.CommandText = "SELECT * from Invoices Where InvoiceNumber = @invoice_num";
                cmd.Parameters.AddWithValue("@invoice_num", invoiceNumber);

                con.Open();

                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    inv.InvoiceNumber = (int)reader["InvoiceNumber"];
                    inv.DateOfIssue = (DateTime)reader["DateOfIssue"];

                    List<InvoiceItem> invoice_items = new List<InvoiceItem>();

                    SqlConnection con2 = new SqlConnection(con.ConnectionString);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con2;
                    cmd2.CommandText = "SELECT * FROM InvoiceItem where InvoiceNumber = @invoice_num";
                    cmd2.Parameters.AddWithValue("@invoice_num", inv.InvoiceNumber);

                    con2.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        invoice_items.Add(new InvoiceItem()
                        {
                            ID = (int)reader2["ID"],
                            Title= (string)reader2["Title"],
                            Quantity = (decimal)reader2["Quantity"],
                            Price = (decimal)reader2["Price"]
                        });
                    }
                    
                    reader2.Close();
                    con2.Close();

                    inv.InvoiceItems= invoice_items;
                }
            }

            return inv;
        }

        public Invoice CreateNewInvoice(Invoice new_invoice)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Invoices"));

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Invoices (DateOdIssue) VALUES (@dateofissue)";
            cmd.Parameters.AddWithValue("@dateofissue", new_invoice.DateOfIssue);

            con.Open();
            int redova=(int)cmd.ExecuteScalar();
            con.Close();

            if(redova<0) { throw new Exception("Nije ništa upisano u bazu podataka..."); }

            cmd=new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TOP 1 * FROM INVOICES ORDER BY InvoiceNumber DESC";

            var inv = cmd.ExecuteReader();
            while (inv.Read())
            {
                new_invoice.InvoiceNumber = (int)inv["InvoiceNumber"];
            }
            inv.Close();
            con.Close();
            con.Dispose();

            return new_invoice;
        }

        public InvoiceItem CreateNewInvoiceItem(InvoiceItem new_invoiceItem, int invocie_number) 
        {

            return new_invoiceItem;
        }

        public void DeleteInvoice(int invoice_num)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Invoices"));

            SqlCommand cmd_items = new SqlCommand("DELETE FROM InvoiceItem WHERE InvoiceNumber=@invoice_num", con);
            cmd_items.Parameters.AddWithValue("@invoice_num", invoice_num);

            con.Open();
            cmd_items.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd_invoice= new SqlCommand("DELETE FROM Invoices WHERE InvoiceNumber=@invoice_num",con);
            cmd_invoice.Parameters.AddWithValue("@invoice_num", invoice_num);

            con.Open();
            cmd_invoice.ExecuteNonQuery();
            con.Close();
        }


    }
}
