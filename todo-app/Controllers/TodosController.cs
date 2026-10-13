using Microsoft.AspNetCore.Mvc;
using todo_app.Models;
using todo_app.Services;

namespace todo_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController(ITodoService todoService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            var todos = todoService.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var todo = todoService.GetById(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(CreateTodoRequest request)
        {
            var todo = todoService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public ActionResult<TodoItem> Update(int id, UpdateTodoRequest todoData)
        {
            var todo = todoService.Update(id, todoData);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = todoService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
