using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProductos.Models
{
    public class MovimientosStock
    {
        [Key]
        public int? id_movimiento { get; set; }
        public int? id_producto { get; set; }
        public int? id_almacen { get; set; }
        public string? tipo_movimiento { get; set; }
        public int? cantidad { get; set; }
        public DateTime? fecha_movimiento { get; set; }
        public string? observaciones { get; set; }

        [ForeignKey("id_producto")]
        public Productos? Producto { get; set; }
        [ForeignKey("id_almacen")]
        public Almacenes? Almacen { get; set; }

    }
}