using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("ApoioEscolar")]
	public class ApoioEscolar
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		public ICollection<Aluno> Alunos { get; set; }
	}
}
