using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Floare
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public DetailsModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

      public Proiect_Magazin_Flori.Areas.Identity.Data.Floare Floare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Floare == null)
            {
                return NotFound();
            }

            var floare = await _context.Floare.FirstOrDefaultAsync(m => m.ID == id);
            if (floare == null)
            {
                return NotFound();
            }
            else 
            {
                Floare = floare;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAdaugaInCos(int id)
        {
            if (id == null || _context.Floare == null)
            {
                return NotFound();
            }
            var user = User.Identity.GetUserId();
            var cos = new Proiect_Magazin_Flori.Areas.Identity.Data.Cos();
            cos.FloareID = id;
            cos.Cantitate = 1;
            cos.UserID = user;
            _context.Cos.Add(cos);
            await _context.SaveChangesAsync();
            return new RedirectToPageResult("./Index");

        }
    }
}
