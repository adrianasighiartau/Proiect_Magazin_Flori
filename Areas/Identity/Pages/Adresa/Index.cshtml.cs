using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Adresa
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public IndexModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }

        public IList<Proiect_Magazin_Flori.Areas.Identity.Data.Adresa> Adresa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Adresa != null)
            {
                var user = User.Identity.GetUserId();
                Adresa = await _context.Adresa.Where ( a => a.UserID == user).ToListAsync();

            }

        }
    }
}
