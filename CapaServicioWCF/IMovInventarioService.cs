using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicioWCF
{
    [ServiceContract]
    public interface IMovInventarioService
    {
        [OperationContract]
        List<MovInventario> Listar(FiltroInventario filtro);

        [OperationContract]
        void Guardar(MovInventario mov);

        [OperationContract]
        void Editar(MovInventario mov);

        [OperationContract]
        void Eliminar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem);
    }
}
