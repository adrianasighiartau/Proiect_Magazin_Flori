using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Adresa
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public DeleteModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Proiect_Magazin_Flori.Areas.Identity.Data.Adresa Adresa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Adresa == null)
            {
                return NotFound();
            }

            var adresa = await _context.Adresa.FirstOrDefaultAsync(m => m.ID == id);

            if (adresa == null)
            {
                return NotFound();
            }
            else 
            {
                Adresa = adresa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Adresa == null)
            {
                return NotFound();
            }
            var adresa = await _context.Adresa.FindAsync(id);

            if (adresa != null)
            {
                Adresa = adresa;
                _context.Adresa.Remove(Adresa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
