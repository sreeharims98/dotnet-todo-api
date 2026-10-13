using todo_app.Models;

namespace todo_app.Services
{
    public class InMemoryTodoService : ITodoService
    {
        private readonly List<TodoItem> _todos = new();
        private readonly object _lock = new();
        private int _nextId = 1;

        public List<TodoItem> GetAll()
        {
            lock (_lock)
            {
                return _todos.ToList();
            }
        }

        public TodoItem? GetById(int id)
        {
            lock (_lock)
            {
                return _todos.FirstOrDefault(t => t.Id == id);
            }
        }

        public TodoItem Create(CreateTodoRequest request)
        {
            lock (_lock)
            {
                var todo = new TodoItem
                {
                    Id = _nextId,
                    Title = request.Title,
                    Description = request.Description
                };

                _nextId = _nextId + 1;
                _todos.Add(todo);
                return todo;
            }
        }

        public TodoItem? Update(int id, UpdateTodoRequest request)
        {
            lock (_lock)
            {
                var todo = _todos.FirstOrDefault(t => t.Id == id);
                if (todo == null) return null;

                todo.Title = request.Title;
                todo.Description = request.Description;
                todo.IsCompleted = request.IsCompleted;
                return todo;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var todo = _todos.FirstOrDefault(t => t.Id == id);
                if (todo == null) return false;

                _todos.Remove(todo);
                return true;
            }
        }
    }
}
