using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class WorkShopMechanicalMechanic
    {
        [Key]
        public int Id { get; set; }
        public int MechanicalWorkShopId { get; set; }
        public int MechanicId { get; set; }

    }
}
