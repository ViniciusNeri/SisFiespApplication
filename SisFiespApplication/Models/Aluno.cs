using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("Aluno")]
	public class Aluno
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		[Display(Name = "Turno")]
		[Column("Turno")]
		public int Turno { get; set; }

		[Display(Name = "Data Nascimento")]
		[Column("DtNascimento")]
		public string DtNascimento { get; set; }

		[Display(Name = "Data Cadastro")]
		[Column("DtCadastro")]
		public string DtCadastro { get; set; }

		[Display(Name = "Mapeado")]
		[Column("Mapeado")]
		public int Mapeado { get; set; }

		[Display(Name = "Status")]
		[Column("Status")]
		public int Status { get; set; }

		[Display(Name = "Nome Mae")]
		[Column("NomeMae")]
		public string NomeMae { get; set; }


		[Display(Name = "Nome Pai")]
		[Column("NomePai")]
		public string NomePai { get; set; }

		[ForeignKey("FK_aluno_modalidade")]
		[Display(Name = "Modalidade")]
		[Column("ModalidadeCodigo")]
		public int? ModalidadeCodigo { get; set; }

		[NotMapped]
		public string ModalidadeNome { get; set; }

		[ForeignKey("FK_aluno_diagnostico")]
		[Display(Name = "Diagnostico")]
		[Column("DiagnosticoCodigo")]
		public int? DiagnosticoCodigo { get; set; }

		[NotMapped]
		public string DiagnosticoNome { get; set; }

		[ForeignKey("FK_aluno_escola")]
		[Display(Name = "Escola")]
		[Column("EscolaCodigo")]
		public int EscolaCodigo { get; set; }

		[NotMapped]
		public string EscolaNome { get; set; }

		[Display(Name = "Observacao")]
		[Column("Observacao")]
		public string Observacao { get; set; }
	}
}
