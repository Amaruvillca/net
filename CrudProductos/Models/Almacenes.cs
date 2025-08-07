using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProductos.Models
{
    public class Almacenes
    {
        [Key]
        public int? id_almacen { get; set; }
        public string? nombre_almacen { get; set; }
        public string? ubicacion { get; set; }

        public ICollection<MovimientosStock>? MovimientosStock { get; set; }
    }
}