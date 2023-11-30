using System.ComponentModel.DataAnnotations;

namespace OnlineMechanic.Entities
{
    public class Client
    {
        [Key]
        public int UserId { get; set; }
    }
}
