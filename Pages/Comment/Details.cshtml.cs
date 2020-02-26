using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NWI2.Data;

namespace NWI2
{
    public class DetailsModel : PageModel
    {
        private readonly NWI2.Data.ApplicationDbContext _context;

        public DetailsModel(NWI2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}