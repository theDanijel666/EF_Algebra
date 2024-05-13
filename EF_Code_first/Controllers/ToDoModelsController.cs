﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_Code_first.Data;
using EF_Code_first.Models;

namespace EF_Code_first.Controllers
{
    public class ToDoModelsController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoModelsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: ToDoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoModel.ToListAsync());
        }

        // GET: ToDoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoModel = await _context.ToDoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (toDoModel == null)
            {
                return NotFound();
            }

            return View(toDoModel);
        }

        // GET: ToDoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,IsCompleted")] ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoModel);
        }

        // GET: ToDoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoModel = await _context.ToDoModel.FindAsync(id);
            if (toDoModel == null)
            {
                return NotFound();
            }
            return View(toDoModel);
        }

        // POST: ToDoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,IsCompleted")] ToDoModel toDoModel)
        {
            if (id != toDoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoModelExists(toDoModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoModel);
        }

        // GET: ToDoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoModel = await _context.ToDoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (toDoModel == null)
            {
                return NotFound();
            }

            return View(toDoModel);
        }

        // POST: ToDoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoModel = await _context.ToDoModel.FindAsync(id);
            if (toDoModel != null)
            {
                _context.ToDoModel.Remove(toDoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoModelExists(int id)
        {
            return _context.ToDoModel.Any(e => e.ID == id);
        }
    }
}
