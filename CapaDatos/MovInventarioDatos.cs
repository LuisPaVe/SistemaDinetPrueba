using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MovInventarioDatos
    {
        private string cadenaConexion = "Server=LUIS-PC;Database=DBDINETPRUEBA;User Id=SA;Password=123456;";

        //public List<MovInventario> Listar()
        //{
        //    var lista = new List<MovInventario>();
        //    using (SqlConnection cn = new SqlConnection(cadenaConexion))
        //    {
        //        //string query = "SELECT * FROM dbo.MOV_INVENTARIO";
        //        //SqlCommand cmd = new SqlCommand(query, cn);
        //        SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_LISTAR", cn);
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(new MovInventario
        //            {
        //                COD_CIA = dr["COD_CIA"].ToString(),
        //                COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString(),
        //                ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString(),
        //                TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString(),
        //                TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString(),
        //                NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString(),
        //                COD_ITEM_2 = dr["COD_ITEM_2"].ToString(),
        //                PROVEEDOR = dr["PROVEEDOR"].ToString(),
        //                ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString(),
        //                CANTIDAD = dr["CANTIDAD"] as int?,
        //                DOC_REF_1 = dr["DOC_REF_1"].ToString(),
        //                DOC_REF_2 = dr["DOC_REF_2"].ToString(),
        //                DOC_REF_3 = dr["DOC_REF_3"].ToString(),
        //                DOC_REF_4 = dr["DOC_REF_4"].ToString(),
        //                DOC_REF_5 = dr["DOC_REF_5"].ToString(),
        //                FECHA_TRANSACCION = dr["FECHA_TRANSACCION"] as DateTime?
        //            });
        //        }
        //    }
        //    return lista;
        //}
        public List<MovInventario> Listar(FiltroInventario filtro)
        {
            var lista = new List<MovInventario>();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaInicio", (object)filtro.FechaInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFin", (object)filtro.FechaFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoMovimiento", (object)filtro.TipoMovimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NroDocumento", (object)filtro.NroDocumento ?? DBNull.Value);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new MovInventario
                    {
                        COD_CIA = dr["COD_CIA"].ToString(),
                        COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString(),
                        ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString(),
                        TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString(),
                        TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString(),
                        NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString(),
                        COD_ITEM_2 = dr["COD_ITEM_2"].ToString(),
                        PROVEEDOR = dr["PROVEEDOR"].ToString(),
                        ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString(),
                        CANTIDAD = dr["CANTIDAD"] as int?,
                        DOC_REF_1 = dr["DOC_REF_1"].ToString(),
                        DOC_REF_2 = dr["DOC_REF_2"].ToString(),
                        DOC_REF_3 = dr["DOC_REF_3"].ToString(),
                        DOC_REF_4 = dr["DOC_REF_4"].ToString(),
                        DOC_REF_5 = dr["DOC_REF_5"].ToString(),
                        FECHA_TRANSACCION = dr["FECHA_TRANSACCION"] as DateTime?
                    });
                }
            }
            return lista;
        }

        public void Guardar(MovInventario mov)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_GRABAR", cn);
                cmd.Parameters.AddWithValue("@COD_CIA", mov.COD_CIA);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.COMPANIA_VENTA_3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", mov.ALMACEN_VENTA);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NRO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", mov.COD_ITEM_2);
                cmd.Parameters.AddWithValue("@PROVEEDOR", (object)mov.PROVEEDOR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object)mov.ALMACEN_DESTINO ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CANTIDAD", (object)mov.CANTIDAD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_1", (object)mov.DOC_REF_1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_2", (object)mov.DOC_REF_2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_3", (object)mov.DOC_REF_3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_4", (object)mov.DOC_REF_4 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_5", (object)mov.DOC_REF_5 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", (object)mov.FECHA_TRANSACCION ?? DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Editar(MovInventario mov)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_MODIFICAR", cn);
                cmd.Parameters.AddWithValue("@COD_CIA", mov.COD_CIA);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.COMPANIA_VENTA_3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", mov.ALMACEN_VENTA);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NRO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", mov.COD_ITEM_2);

                cmd.Parameters.AddWithValue("@PROVEEDOR", (object)mov.PROVEEDOR ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object)mov.ALMACEN_DESTINO ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CANTIDAD", (object)mov.CANTIDAD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_1", (object)mov.DOC_REF_1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_2", (object)mov.DOC_REF_2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_3", (object)mov.DOC_REF_3 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_4", (object)mov.DOC_REF_4 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DOC_REF_5", (object)mov.DOC_REF_5 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", (object)mov.FECHA_TRANSACCION ?? DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Eliminar(string codCia, string comp, string alm, string tipoMov, string tipoDoc, string nroDoc, string codItem)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand("SP_MOV_INVENTARIO_ELIMINAR", cn);
                cmd.Parameters.AddWithValue("@COD_CIA", codCia);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", comp);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", alm);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMov);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", tipoDoc);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDoc);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", codItem);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
