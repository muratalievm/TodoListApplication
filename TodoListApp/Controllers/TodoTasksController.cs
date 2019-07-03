using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoTasksController : Controller
    {
        private readonly TaskContext _context;

        public TodoTasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: TodoTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TodoTasks.ToListAsync());
        }
                

        // GET: TodoTasks/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new TodoTask());
            else {
                return View(_context.TodoTasks.Find(id));
            }


        }

        // POST: TodoTasks/AddOrEdit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IDTask,Description,IsDone")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                if (todoTask.IDTask == 0)
                    _context.Add(todoTask);
                else
                    _context.Update(todoTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoTask);
        }

        
        // GET: TodoTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var todotask =await _context.TodoTasks.FindAsync(id);
            _context.TodoTasks.Remove(todotask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
