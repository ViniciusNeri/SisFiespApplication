using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("Escola")]
	public class Escola
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		[Display(Name = "Email")]
		[Column("Email")]
		public string Email { get; set; }

		[Display(Name = "Status")]
		[Column("Status")]
		public int? Status { get; set; }

		[Display(Name = "Telefone")]
		[Column("Telefone")]
		public string Telefone { get; set; }

		[Display(Name = "Telefone2")]
		[Column("Telefone2")]
		public string Telefone2 { get; set; }

		[Display(Name = "Bairro")]
		[Column("Bairro")]
		public string Bairro { get; set; }

		[Display(Name = "Endereco")]
		[Column("Endereco")]
		public string Endereco { get; set; }

		[Display(Name = "Cidade")]
		[Column("Cidade")]
		public string Cidade { get; set; }

		[Display(Name = "CaractSocioEcon")]
		[Column("CaractSocioEcon")]
		public string CaractSocioEcon { get; set; }

		[Display(Name = "RecursoRegiao")]
		[Column("RecursoRegiao")]
		public string RecursoRegiao { get; set; }

		[Display(Name = "NUE")]
		[Column("NUE")]
		public string NUE { get; set; }

		[Display(Name = "CP1")]
		[Column("CP1")]
		public string CP1 { get; set; }

		[Display(Name = "CP2")]
		[Column("CP2")]
		public string CP2 { get; set; }

		[Display(Name = "Data Cadastro")]
		[Column("DtCadastro")]
		public DateTime DtCadastro { get; set; }
				
		public Usuario Usuario { get; set; }
		
		[ForeignKey("FK_escola_usuario")]
		public int UsuarioCodigo { get; set; }

		[NotMapped]
		public String UsuarioNome { get; set; }

		public ICollection<Aluno> Alunos { get; set; }

	}
}
