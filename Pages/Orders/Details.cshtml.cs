using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoPizza.Data.ContosoPizzaContext _context;

        public DetailsModel(ContosoPizza.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                                      .Include(o => o.OrderDetail)
                                      .Include(o => o.Customer)
                                      .Include(o => o.DeliveryPerson)
                                      .Include(o => o.Product)
                                      .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }


            return Page();
        }
    }
}
