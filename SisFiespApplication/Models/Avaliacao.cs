using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("Avaliacao")]
	public class Avaliacao
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[ForeignKey("FK_avaliacao_aluno")]
		[Display(Name = "Aluno")]
		[Column("AlunoCodigo")]
		public int AlunoCodigo { get; set; }

		[ForeignKey("FK_avaliacao_usuario")]
		[Display(Name = "Especialista")]
		[Column("UsuarioCodigo")]
		public int UsuarioCodigo { get; set; }

		[NotMapped]
		public string EspecialistaNome { get; set; }

		[NotMapped]
		public string AlunoNome { get; set; }

		[NotMapped]
		public string EscolaNome { get; set; }

		[Display(Name = "Status")]
		[Column("Status")]
		public int Status { get; set; }

		[Display(Name = "Data Cadastro")]
		[Column("DtCadastro")]
		public string DtCadastro { get; set; }

		[Display(Name = "Data Alteracao")]
		[Column("DtAlteracao")]
		public string DtAlteracao { get; set; }
	}
}
