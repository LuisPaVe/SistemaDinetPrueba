using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PaginacionViewModel
    {
        public IEnumerable<MovInventario> Movimientos { get; set; } // Lista de movimientos para mostrar en la vista
        public int TotalItems { get; set; } // Total de elementos sin paginación
        public int PageSize { get; set; } // Número de elementos por página
        public int CurrentPage { get; set; } // Página actual

        // Propiedad calculada para obtener el total de páginas
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
