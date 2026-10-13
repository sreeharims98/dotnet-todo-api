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

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var todo = Todos.FirstOrDefault(todo => todo.Id == id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
                return BadRequest("Title is required");
            todo.Id = _nextId;
            _nextId = _nextId + 1;
            Todos.Add(todo);
            return StatusCode(201, todo);

        }

        [HttpPut("{id}")]
        public ActionResult<TodoItem> Update(int id, TodoItem todoData)
        {
            var todo = Todos.FirstOrDefault(todo => todo.Id == id);
            if (todo == null) return NotFound();
            todo.Title = todoData.Title;
            todo.Description = todoData.Description;
            todo.IsCompleted = todoData.IsCompleted;
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public ActionResult<TodoItem> Delete(int id)
        {
            var todo = Todos.FirstOrDefault(todo => todo.Id == id);
            if (todo == null) return NotFound();

            Todos.Remove(todo);
            return Ok();

        }
    }
}
