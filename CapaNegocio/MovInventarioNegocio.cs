using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MovInventarioNegocio
    {
        private MovInventarioDatos datos = new MovInventarioDatos();

        //public List<MovInventario> Listar()
        //{
        //    return datos.Listar();
        //}
        public List<MovInventario> Listar(FiltroInventario filtro)
        {
            return datos.Listar(filtro);
        }
        public void Guardar(MovInventario mov)
        {
            datos.Guardar(mov);
        }

        public void Eliminar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem)
        {
            datos.Eliminar(codCia, comp, alm, tipoMov, tipoDoc, nroDoc, codItem);
        }
        public void Editar(MovInventario mov)
        {
            datos.Editar(mov);
        }
    }
}
