using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
