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

        public DbSet<SisFiespApplication.Models.Aluno> Aluno { get; set; }

        public DbSet<SisFiespApplication.Models.Diagnostico> Diagnostico { get; set; }

        public DbSet<SisFiespApplication.Models.Modalidade> Modalidade { get; set; }

        public DbSet<SisFiespApplication.Models.Avaliacao> Avaliacao { get; set; }

    }
}
