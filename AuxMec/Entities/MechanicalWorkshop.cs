using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class MechanicalWorkshop
    {
        [Key]
        public int UserId { get; set; }
    }
}
