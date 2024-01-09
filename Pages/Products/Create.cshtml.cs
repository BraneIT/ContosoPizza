using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ContosoPizza.Data.ContosoPizzaContext _context;
     

        public CreateModel(ContosoPizza.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           

            if (Image != null && Image.Length > 0)
            {
                try
                {
                    if (Image.ContentType.ToLower() != "image/png")
                    {
                        ModelState.AddModelError("Image", "Please upload a valid PNG file.");
                        return Page();
                    }
                    // Generate a unique name for the image
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                    // Save the image to a folder named "uploads" in the application's root path
                    string uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    string imagePath = Path.Combine(uploadsFolderPath, imageName);

                    // Create the "uploads" folder if it doesn't exist
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    // Save image asynchronously
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    // Save image path to the Product entity
                    Product.ProductPhotoPath = imageName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Image", $"Error uploading image: {ex.Message}");
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
