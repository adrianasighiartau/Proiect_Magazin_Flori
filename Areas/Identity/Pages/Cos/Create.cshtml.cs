using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Cos
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public CreateModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FloareID"] = new SelectList(_context.Floare, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Proiect_Magazin_Flori.Areas.Identity.Data.Cos Cos { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cos == null || Cos == null)
            {
                return Page();
            }

            _context.Cos.Add(Cos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
