using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Pages.Floare
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext _context;

        public IndexModel(Proiect_Magazin_Flori.Areas.Identity.Data.FloriContext context)
        {
            _context = context;
        }
        public string FiltruCurent { get; set; }
        public string PretSort { get; set; }
        public string StocSort { get; set; }

        public IList<Proiect_Magazin_Flori.Areas.Identity.Data.Floare> Flori { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    if (_context.Floare != null)
        //    {
        //        Flori = await _context.Floare.ToListAsync();
        //    }
        //}
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Floare != null)
            {
                Flori = await _context.Floare.ToListAsync();

                PretSort = sortOrder == "Pret" ? "Pret_desc" : "Pret"; 
                StocSort = sortOrder == "Stoc" ? "Stoc_desc" : "Stoc"; 

                FiltruCurent = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    Flori = (IList<Proiect_Magazin_Flori.Areas.Identity.Data.Floare>)Flori
                        .Where(s => s.Denumire.ToLower().Contains(searchString.ToLower())
                   || s.Culoare.ToLower().Contains(searchString.ToLower())).ToList();
                }
                    switch (sortOrder)
                    {
                        case "Pret_desc":
                            Flori = Flori.OrderByDescending(s =>
                           s.Pret).ToList();
                            break;
                        case "Stoc_desc":
                            Flori = Flori.OrderByDescending(s =>
                           s.Stoc).ToList();
                            break;
                        case "Pret":
                            Flori = Flori.OrderBy(s =>
                           s.Pret).ToList();
                            break;
                        case "Stoc":
                            Flori = Flori.OrderBy(s =>
                           s.Stoc).ToList();
                            break;
                        default:
                            Flori = Flori.OrderBy(s => s.Denumire).ToList();
                            break;
                    

                }
            }
        }
    }
}
