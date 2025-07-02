using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItems
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
