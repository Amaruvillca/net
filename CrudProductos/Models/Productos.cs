using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProductos.Models
{
    public class Productos
    {
        [Key]
        public int? id_producto { get; set; }
        public string? nombre_producto { get; set; }
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public int? id_categoria { get; set; }
        public decimal? precio_unitario { get; set; }
        public int? stock { get; set; }
        public DateTime? fecha_registro { get; set; }

        [ForeignKey("id_categoria")]
        public Categorias? Categoria { get; set; }
        public ICollection<MovimientosStock>? MovimientosStock { get; set; }
    }
}