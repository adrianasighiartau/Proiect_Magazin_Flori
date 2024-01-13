using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;

namespace Proiect_Magazin_Flori.Areas.Identity.Data;

public class FloriContext : IdentityDbContext<SiteUser>
{
    public FloriContext(DbContextOptions<FloriContext> options)
        : base(options)
    {
    }

    public DbSet<Proiect_Magazin_Flori.Areas.Identity.Data.Adresa>? Adresa { get; set; }

    public DbSet<Proiect_Magazin_Flori.Areas.Identity.Data.Cos>? Cos { get; set; }

    public DbSet<Proiect_Magazin_Flori.Areas.Identity.Data.Floare> Floare { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
