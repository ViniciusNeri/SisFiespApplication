using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisFiespApplication.Models
{
	public class AgendaResponse
	{
		public int id { get; set; }
		public int especialistaCodigo { get; set; }		
		public int? AlunoCodigo { get; set; }
		public string title { get; set; }		
		public int? UsuarioCodigo { get; set; }
		public string especialista { get; set; }		
		public string textColor { get; set; }		
		public string borderColor { get; set; }		
		public string backgroundColor { get; set; }		
		public string description { get; set; }		
		public DateTime start { get; set; }

		//public ICollection<Aluno> Alunos { get; set; }

	}
}
