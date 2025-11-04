using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class Todos : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
    }
}
