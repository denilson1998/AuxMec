namespace OnlineMechanic.Models
{
    public class ApplicationModel
    {
        public DateTime ApplicationDateTime { get; set; }
        public string ArrivalTimeStimated { get; set; }
        public float BaseCost { get; set; }
        public int MechanicId { get; set; }
        public int AssistanceId { get; set; }
        public int StatusId { get; set; }
        public int ClientId { get; set; }
    }
}
