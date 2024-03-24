using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class ReparacionDetalle
	{
		[Key]
		public int DetalleReparcionId { get; set; }

		[ForeignKey("Reparacion")]
		public int ReparacionId { get; set; }

		[ForeignKey("Cliente")]
		public int ClienteId { get; set; }


	}
}
