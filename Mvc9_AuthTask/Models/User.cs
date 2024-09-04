using System.ComponentModel.DataAnnotations;

namespace Mvc9_AuthTask.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
