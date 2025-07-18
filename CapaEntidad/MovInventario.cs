using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MovInventario
    {
        [Required(ErrorMessage = "El campo COD_CIA es obligatorio.")]
        public string COD_CIA { get; set; }

        [Required(ErrorMessage = "El campo COMPANIA_VENTA_3 es obligatorio.")]
        public string COMPANIA_VENTA_3 { get; set; }

        [Required(ErrorMessage = "El campo ALMACEN_VENTA es obligatorio.")]
        public string ALMACEN_VENTA { get; set; }

        [Required(ErrorMessage = "El campo TIPO_MOVIMIENTO es obligatorio.")]
        public string TIPO_MOVIMIENTO { get; set; }

        [Required(ErrorMessage = "El campo TIPO_DOCUMENTO es obligatorio.")]
        public string TIPO_DOCUMENTO { get; set; }

        [Required(ErrorMessage = "El campo NRO_DOCUMENTO es obligatorio.")]
        public string NRO_DOCUMENTO { get; set; }

        [Required(ErrorMessage = "El campo COD_ITEM_2 es obligatorio.")]
        public string COD_ITEM_2 { get; set; }
        public string PROVEEDOR { get; set; }
        public string ALMACEN_DESTINO { get; set; }
        public int? CANTIDAD { get; set; }
        public string DOC_REF_1 { get; set; }
        public string DOC_REF_2 { get; set; }
        public string DOC_REF_3 { get; set; }
        public string DOC_REF_4 { get; set; }
        public string DOC_REF_5 { get; set; }
        public DateTime? FECHA_TRANSACCION { get; set; }
    }
}
