using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NWI2.Data;

namespace NWI2
{
    public class EditModel : PageModel
    {
        private readonly NWI2.Data.ApplicationDbContext _context;

        public EditModel(NWI2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GED GED { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GED = await _context.GED.FirstOrDefaultAsync(m => m.VID == id);

            if (GED == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GED).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GEDExists(GED.VID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GEDExists(int id)
        {
            return _context.GED.Any(e => e.VID == id);
        }
    }
}