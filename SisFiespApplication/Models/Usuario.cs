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

		[Display(Name = "Login")]
		[Column("Login")]
		public int Login { get; set; }

		[Display(Name = "Senha")]
		[Column("Senha")]
		public int Senha { get; set; }

		[Display(Name = "Email")]
		[Column("Email")]
		public int Email { get; set; }
	}
}
