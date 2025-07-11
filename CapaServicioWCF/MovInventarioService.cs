using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicioWCF
{
    public class MovInventarioService : IMovInventarioService
    {
        private readonly MovInventarioNegocio negocio = new MovInventarioNegocio();

        public List<MovInventario> Listar(FiltroInventario filtro)
        {
            return negocio.Listar(filtro);
        }

        public void Guardar(MovInventario mov)
        {
            negocio.Guardar(mov);
        }

        public void Editar(MovInventario mov)
        {
            negocio.Editar(mov);
        }

        public void Eliminar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem)
        {
            negocio.Eliminar(codCia, comp, alm, tipoMov, tipoDoc, nroDoc, codItem);
        }
    }
}
