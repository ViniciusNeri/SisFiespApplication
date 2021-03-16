using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("Usuario")]
	public class Usuario
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		[Display(Name = "Login")]
		[Column("Login")]
		public string Login { get; set; }

		[Display(Name = "Senha")]
		[Column("Senha")]
		public string Senha { get; set; }

		[Display(Name = "Email")]
		[Column("Email")]
		public string Email { get; set; }

		[Display(Name = "Status")]
		[Column("Status")]
		public int? Status { get; set; }

		[Display(Name = "Função")]
		[Column("Funcao")]
		public int? Funcao { get; set; }

		[Display(Name = "Data Cadastro")]
		[Column("DtCadastro")]
		public DateTime DtCadastro { get; set; }

		public ICollection<Escola> Escolas { get; set; }

	}
}
