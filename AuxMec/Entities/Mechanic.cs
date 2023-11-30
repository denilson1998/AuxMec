using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Mechanic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int RoleId { get; set; }
    }
}
