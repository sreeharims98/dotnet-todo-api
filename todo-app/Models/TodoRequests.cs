using System.ComponentModel.DataAnnotations;

namespace todo_app.Models
{
    public class CreateTodoRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

    }

    public class UpdateTodoRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
