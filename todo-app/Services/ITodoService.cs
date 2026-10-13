using todo_app.Models;

namespace todo_app.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetAll();
        TodoItem? GetById(int id);
        TodoItem Create(CreateTodoRequest request);
        TodoItem? Update(int id, UpdateTodoRequest request);
        bool Delete(int id);
    }
}
