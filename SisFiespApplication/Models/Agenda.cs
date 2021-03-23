using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	public class Agenda
	{
		[Key]
		[Display(Name = "Codigo")]
		[Column("Codigo")]
		public int Codigo { get; set; }

		[ForeignKey("FK_agenda_aluno")]
		[Display(Name = "Aluno")]
		[Column("AlunoCodigo")]
		public int AlunoCodigo { get; set; }

		[NotMapped]
		public string AlunoNome { get; set; }

		[ForeignKey("FK_agenda_usuario")]
		[Display(Name = "Usuario")]
		[Column("UsuarioCodigo")]
		public int? UsuarioCodigo { get; set; }

		[NotMapped]
		public string UsuarioNome { get; set; }

		[Display(Name = "Data Agendamento")]
		[Column("DtAgendamento")]
		public DateTime DtAgendamento { get; set; }

		//public ICollection<Aluno> Alunos { get; set; }

	}
}
