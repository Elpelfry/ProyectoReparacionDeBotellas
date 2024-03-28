using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{

    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [ForeignKey("Proveedores")]
        public int ProveedorId { get; set; }
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "Indique el Precio")]
        [Range(0.01, 1000000000, ErrorMessage = "El Precio debe estar 0.01 y 1000000000")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Indique la Cantidad")]
        [Range(1, 1000, ErrorMessage = "El Monto debe estar 1 y 1000")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
        public double Descuento { get; set; }
        public int ITBIS { get; set; }
        public bool EsDisponible { get; set; }
    }
}

