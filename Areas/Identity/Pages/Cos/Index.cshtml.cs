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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public IndexModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

        public IList<Proiect_Magazin_Flori.Areas.Identity.Data.Cos> Cos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var user = User.Identity.GetUserId();

            if (_context.Cos != null)
            {
                Cos = await _context.Cos.Where(c => c.UserID==user)
                .Include(c => c.Floare).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostPlaseazaComanda()
        {

            var user = User.Identity.GetUserId();
            var cos = _context.Cos.Where(c => c.UserID == user).ToList();

            foreach (var c in cos)
            {
                var floare = _context.Floare.Where(f => f.ID == c.FloareID).FirstOrDefault();
                floare.Stoc = floare.Stoc - c.Cantitate;
                _context.Cos.Remove(c);
                await _context.SaveChangesAsync();
            }

            return new RedirectToPageResult("./Comanda");

        }

    }
}
