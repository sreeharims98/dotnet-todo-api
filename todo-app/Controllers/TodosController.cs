using Microsoft.AspNetCore.Mvc;
using todo_app.Models;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private static readonly List<TodoItem> Todos = new();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return Ok(Todos);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
                return BadRequest("Title is required");
            todo.Id = _nextId + 1;
            Todos.Add(todo);
            return StatusCode(201, todo);

        }
    }
}
