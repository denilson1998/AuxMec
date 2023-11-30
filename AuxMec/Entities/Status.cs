using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
