using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Models.Entities;

namespace TodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TodoContext dbContext;
        public TasksController(TodoContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddTodosViewModel viewModel)
        {
            var todos = new Todo
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                IsCompleted = viewModel.IsCompleted,
                CreatedAt = DateTime.UtcNow
            };

            await dbContext.Todos.AddAsync(todos);
            await dbContext.SaveChangesAsync();


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var todos = await dbContext.Todos.ToListAsync();
            return View(todos);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                dbContext.Todos.Remove(todo);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            var viewModel = new AddTodosViewModel
            {
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt
            };
            return View(viewModel);


        }



    }
}