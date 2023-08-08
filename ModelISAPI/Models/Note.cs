using System.ComponentModel.DataAnnotations;

namespace ModelISAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
