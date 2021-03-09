using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	[Table("AvaliacaoDetalhe")]

	public class AvaliacaoDetalhe
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[ForeignKey("FK_avaliacao_avaliacaodetalhe")]
		[Display(Name = "Avaliacao")]
		[Column("AvaliacaoCodigo")]
		public int AvaliacaoCodigo { get; set; }

		[Display(Name = "TpAvaliacaoDetalhe")]
		[Column("TpAvaliacaoDetalhe")]
		public int TpAvaliacaoDetalhe { get; set; }

		[Display(Name = "Data Cadastro")]
		[Column("DtCadastro")]
		public string DtCadastro { get; set; }

		[NotMapped]
		public string EspecialistaNome { get; set; }

		[Display(Name = "Procedimento")]
		[Column("Procedimento")]
		public string Procedimento { get; set; }

		[Display(Name = "Conduta")]
		[Column("Conduta")]
		public string Conduta { get; set; }

		[Display(Name = "Envolvidos")]
		[Column("Envolvidos")]
		public string Envolvidos { get; set; }

		[Display(Name = "DescAcao")]
		[Column("DescAcao")]
		public string DescAcao { get; set; }

		[NotMapped]
		public string NomeAluno { get; set; }
	}
}
