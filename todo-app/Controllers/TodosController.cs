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
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(CreateTodoRequest request)
        {
            var todo = new TodoItem
            {
                Id = _nextId,
                Title = request.Title,
                Description = request.Description
            };

            _nextId = _nextId + 1;
            Todos.Add(todo);

            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);

        }

        [HttpPut("{id}")]
        public ActionResult<TodoItem> Update(int id, UpdateTodoRequest todoData)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            todo.Title = todoData.Title;
            todo.Description = todoData.Description;
            todo.IsCompleted = todoData.IsCompleted;
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            Todos.Remove(todo);
            return NoContent();

        }
    }
}
