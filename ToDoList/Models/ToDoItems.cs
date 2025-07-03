using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItems : IValidatableObject
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        public ToDoItems()
        {
            CreatedAt = DateTime.Now;
        }

        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Deadline.HasValue && Deadline < CreatedAt)
            {
                yield return new ValidationResult(
                    "Deadline nie może byc wcześniejszy niż data dodania.",
                    new[] { nameof(Deadline) });
            }
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult(
                    "Title jest wymagany.",
                    new[] { nameof(Title) });
            }
        }


    }
}
