using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public DateTime ApplicationDateTime { get; set; }
        public string ArrivalTimeStimated { get; set; }
        public float BaseCost { get; set; }
        public int WorkShopMechanicalMechanicId {  get; set; }
        public int AssistanceId { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
    }
}
