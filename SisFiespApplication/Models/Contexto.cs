using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisFiespApplication.Models;

namespace SisFiespApplication.Models
{
	public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<SisFiespApplication.Models.Escola> Escola { get; set; }

    }
}
