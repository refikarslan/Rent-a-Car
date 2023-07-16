using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ArabaKiralamaWebApp.Models
{
    public class Context :DbContext
    {
        //internal string WebRootPath;

        public Context(DbContextOptions<Context> options)
          
        :base(options)
        {
            
        }


        public DbSet<Musteri> Musteri { get; set; } = null!;
        public DbSet<Araba> Araba { get; set; } = null!;
        public DbSet<MusteriHareket> MusteriHareket { get; set; } = null!;

    }
}
