using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSParking.Dominio;
using WSParking.Modelo;
using WSParking.Utils;

namespace WSParking.Persistencia
{
    public class EstacionamientoDAO
    {







        public Estacionamiento Crear(Estacionamiento est)
        {

            Estacionamiento estCreado = null;
            int id = 0;
            string sql = "insert into estacionamiento (est_numero, est_idsucursal, est_piso, est_estado) OUTPUT INSERTED.est_id VALUES (@numero, @idsucursal, @piso, @estado)";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", est.id));
                    comando.Parameters.Add(new SqlParameter("@numero", est.numero));
                    comando.Parameters.Add(new SqlParameter("@idsucursal", est.idsucursal));
                    comando.Parameters.Add(new SqlParameter("@piso", est.piso));
                    comando.Parameters.Add(new SqlParameter("@estado", est.estado));

                    //comando.ExecuteNonQuery();
                    id = (int)comando.ExecuteScalar();
                }
                estCreado = Obtener(id);
            }
            return estCreado;
        }


        public Estacionamiento Modificar(Estacionamiento est)
        {
            Estacionamiento estModificado = null;
            string sql = "update estacionamiento set est_numero=@numero,est_idsucursal=@idsucursal,est_piso=@piso,est_estado=@estado where est_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", est.id));
                    comando.Parameters.Add(new SqlParameter("@numero", est.numero));
                    comando.Parameters.Add(new SqlParameter("@idsucursal", est.idsucursal));
                    comando.Parameters.Add(new SqlParameter("@piso", est.piso));
                    comando.Parameters.Add(new SqlParameter("@estado", est.estado));

                    comando.ExecuteNonQuery();
                }

            }
            estModificado = Obtener(est.id);
            return estModificado;
        }

        public Estacionamiento Obtener(int id)
        {
            Estacionamiento estEncontrado = null;
            string sql = "select * from estacionamiento where est_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            estEncontrado = new Estacionamiento()
                            {

                                id = (int)resultado["est_id"],
                                numero = (int)resultado["est_numero"],
                                idsucursal = (int)resultado["est_idsucursal"],
                                piso = (int)resultado["est_piso"],
                                estado = (int)resultado["est_estado"]

                            };
                        }
                    }
                }
            }
            return estEncontrado;
        }


        public Objeto Eliminar(int id)
        {
            int err = 1; string err_msj = "No se ha podido eliminar estacionamiento con id = " + id;
            string sql = "delete from estacionamiento where  est_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    comando.ExecuteNonQuery();
                    err = 0;
                    err_msj = "Estacionamiento eliminado correctamente";
                }
            }

            return new Objeto() { Codigo = 1, Error = err, Mensaje = err_msj };
        }


        public List<Estacionamiento> Listar()
        {
            List<Estacionamiento> listaSensores = new List<Estacionamiento>();
            Estacionamiento estEncontrado = null;
            string sql = "select * from estacionamiento";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            estEncontrado = new Estacionamiento()
                            {
                                id = (int)resultado["est_id"],
                                numero = (int)resultado["est_numero"],
                                idsucursal = (int)resultado["est_idsucursal"],
                                piso = (int)resultado["est_piso"],
                                estado = (int)resultado["est_estado"]

                            };
                            listaSensores.Add(estEncontrado);
                        }
                    }
                }
            }
            return listaSensores;
        }








    }
}