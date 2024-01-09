using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "DeliveryPerson")]
        public int DeliveryPersonId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        [ForeignKey("DeliveryPersonId")]
        public DeliveryPerson? DeliveryPerson { get; set; }
        public OrderDetail? OrderDetail { get; set; }
        public Product? Product { get; set; }

    }
}