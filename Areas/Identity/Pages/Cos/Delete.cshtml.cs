using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Cos
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public DeleteModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Proiect_Magazin_Flori.Areas.Identity.Data.Cos Cos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }

            
            var cos = await _context.Cos.Include(c => c.Floare).FirstOrDefaultAsync(m => m.ID == id);

            if (cos == null)
            {
                return NotFound();
            }
            else 
            {
                Cos = cos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }
            var cos = await _context.Cos.FindAsync(id);

            if (cos != null)
            {
                Cos = cos;
                _context.Cos.Remove(Cos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
