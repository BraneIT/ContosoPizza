using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Pages.DeliveryPerson
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoPizza.Data.ContosoPizzaContext _context;

        public DetailsModel(ContosoPizza.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public ContosoPizza.Models.DeliveryPerson DeliveryPerson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryperson = await _context.DeliveryPerson.FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryperson == null)
            {
                return NotFound();
            }
            else
            {
                DeliveryPerson = deliveryperson;
            }
            return Page();
        }
    }
}
