using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmApp.Models;

namespace FilmApp.Data
{
    public class KontekstBaze : DbContext
    {
        public KontekstBaze (DbContextOptions<KontekstBaze> options)
            : base(options)
        {
        }

        public DbSet<FilmApp.Models.film> film { get; set; }

        public DbSet<FilmApp.Models.Glumac> Glumac { get; set; }
    }
}
