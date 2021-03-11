using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace SisFiespApplication.Models
{
	public class Anexo
	{
		//public IEnumerable<HttpPostedFileBase> files { get; set; }
		public string File { get; set; }
		public long Size { get; set; }
		public string Type { get; set; }
		public int CodigoAvaliacaoDetalhe { get; set; }
	}
}
