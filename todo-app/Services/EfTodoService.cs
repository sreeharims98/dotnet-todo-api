using todo_app.Data;
using todo_app.Models;

namespace todo_app.Services
{
    public class EfTodoService(AppDbContext db) : ITodoService
    {
        public List<TodoItem> GetAll()
        {
            return db.Todos.ToList();
        }
        public TodoItem? GetById(int id)
        {
            return db.Todos.Find(id);
        }
        public TodoItem Create(CreateTodoRequest request)
        {
            var todo = new TodoItem
            {
                Title = request.Title,
                Description = request.Description
            };
            db.Todos.Add(todo);
            db.SaveChanges();
            return todo;
        }
        public TodoItem? Update(int id, UpdateTodoRequest request)
        {
            var todo = db.Todos.Find(id);
            if (todo == null) return null;
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.IsCompleted = request.IsCompleted;
            db.SaveChanges();
            return todo;
        }

        public bool Delete(int id)
        {
            var todo = db.Todos.Find(id);
            if (todo == null) return false;
            db.Todos.Remove(todo);
            db.SaveChanges();
            return true;
        }
    }
}
