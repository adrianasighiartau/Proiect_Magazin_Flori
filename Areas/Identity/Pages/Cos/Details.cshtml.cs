using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Cos
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public DetailsModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

      public Proiect_Magazin_Flori.Areas.Identity.Data.Cos Cos { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }

            var cos = await _context.Cos.FirstOrDefaultAsync(m => m.ID == id);
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
        
    }
}
