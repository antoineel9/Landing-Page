using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NWI2.Data;

namespace NWI2
{
    public class CreateModel : PageModel
    {
        private readonly NWI2.Data.ApplicationDbContext _context;

        public CreateModel(NWI2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GED GED { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GED.Add(GED);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}