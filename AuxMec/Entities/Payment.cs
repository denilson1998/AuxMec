using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ApplicationId {  get; set; }
    }
}
