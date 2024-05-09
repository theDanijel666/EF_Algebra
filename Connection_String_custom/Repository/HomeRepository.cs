using Microsoft.Data.SqlClient;

namespace Connection_String_custom.Repository
{
    public class HomeRepository
    {
        private readonly IConfiguration _configuration;

        public HomeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CheckExistingConnection()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Invoices")))
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
