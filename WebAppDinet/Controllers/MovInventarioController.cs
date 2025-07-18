using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDinet.ServicioWCF;


namespace WebAppDinet.Controllers
{
    public class MovInventarioController : Controller
    {
        // GET: MovInventario
        private MovInventarioServiceClient cliente = new MovInventarioServiceClient();

        public ActionResult Index(DateTime? FechaInicio, DateTime? FechaFin, string TipoMovimiento, string NroDocumento)
        {
            var filtro = new FiltroInventario
            {
                FechaInicio = FechaInicio,
                FechaFin = FechaFin,
                TipoMovimiento = string.IsNullOrWhiteSpace(TipoMovimiento) ? null : TipoMovimiento,
                NroDocumento = string.IsNullOrWhiteSpace(NroDocumento) ? null : NroDocumento
            };

            var lista = cliente.Listar(filtro);
            return View(lista);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(MovInventario mov)
        {
            cliente.Guardar(mov);
            TempData["Mensaje"] = "guardado";
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem)
        {
            cliente.Eliminar(codCia, comp, alm, tipoMov, tipoDoc, nroDoc, codItem);
            TempData["Mensaje"] = "eliminado";
            return RedirectToAction("Index");
        }
        public ActionResult Editar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem)
        {
            var filtro = new FiltroInventario
            {
                FechaInicio = null,
                FechaFin = null,
                TipoMovimiento = null,
                NroDocumento = null
            };
            var lista = cliente.Listar(filtro);
            var item = lista.FirstOrDefault(x =>
                x.COD_CIA == codCia &&
                x.COMPANIA_VENTA_3 == comp &&
                x.ALMACEN_VENTA == alm &&
                x.TIPO_MOVIMIENTO == tipoMov &&
                x.TIPO_DOCUMENTO == tipoDoc &&
                x.NRO_DOCUMENTO == nroDoc &&
                x.COD_ITEM_2 == codItem);

            if (item == null) return HttpNotFound();
            return View(item);
        }

        [HttpPost]
        public ActionResult Editar(MovInventario mov)
        {
            cliente.Editar(mov);
            TempData["Mensaje"] = "editado";
            return RedirectToAction("Index");
        }
      
    }
}