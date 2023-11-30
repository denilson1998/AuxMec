namespace OnlineMechanic.Entities
{
    public class Assistance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string GpsLocationLongitude { get; set; }
        public string GpsLocationLatitude { get; set; }
        public string Address { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
    }
}
