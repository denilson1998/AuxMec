using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarYear { get; set; }
        public int ClientId { get; set; }

    }
}
