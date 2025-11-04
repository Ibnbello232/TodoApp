using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TodoApp.Models.Entities
{
    public class Todo
    {
        [Key]

        public int Id { get; set; } // Primary key
        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
