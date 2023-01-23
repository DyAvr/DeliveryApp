using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models {
    public class Order {
        public int Id { get; set; }
        public string OrderNumber { get; set; }

        [Required]
        public string FromCity { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string ToCity { get; set; }

        [Required]
        public string ToAddress { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }
    }
}
