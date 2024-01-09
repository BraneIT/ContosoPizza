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
    public class IndexModel : PageModel
    {
        private readonly ContosoPizza.Data.ContosoPizzaContext _context;

        public IndexModel(ContosoPizza.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public IList<ContosoPizza.Models.DeliveryPerson> DeliveryPerson { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DeliveryPerson = await _context.DeliveryPerson.ToListAsync();
        }
    }
}
