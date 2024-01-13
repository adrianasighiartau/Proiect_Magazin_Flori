using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Cos
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public EditModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
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

            var cos =  await _context.Cos.Include(c => c.Floare).FirstOrDefaultAsync(m => m.ID == id);
            if (cos == null)
            {
                return NotFound();
            }
            Cos = cos;
           ViewData["FloareID"] = new SelectList(_context.Floare, "ID", "ID");
           ViewData["FloareDenumire"] = cos.Floare.Denumire;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosExists(Cos.ID))
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

        private bool CosExists(int id)
        {
          return (_context.Cos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
