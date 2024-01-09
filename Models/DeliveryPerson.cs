using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models
{
    public class DeliveryPerson
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
        public ICollection<Order>? Orders { get; set; }
        
    }
}