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
    public class SucursalDAO
    {




        public Sucursal Crear(Sucursal scs)
        {

            Sucursal scsCreado = null;
            int id = 0;
            string sql = "insert into Sucursal (suc_nombre, suc_tarifa) OUTPUT INSERTED.suc_id VALUES (@nombre, @tarifa)";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", scs.id));
                    comando.Parameters.Add(new SqlParameter("@nombre", scs.nombre));
                    comando.Parameters.Add(new SqlParameter("@tarifa", scs.tarifa));

                    //comando.ExecuteNonQuery();
                    id = (int)comando.ExecuteScalar();
                }
                scsCreado = Obtener(id);
            }
            return scsCreado;
        }


        public Sucursal Modificar(Sucursal scs)
        {
            Sucursal scsModificado = null;
            string sql = "update Sucursal set suc_nombre=@nombre, suc_tarifa=@tarifa where suc_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", scs.id));
                    comando.Parameters.Add(new SqlParameter("@nombre", scs.nombre));
                    comando.Parameters.Add(new SqlParameter("@tarifa", scs.tarifa));

                    comando.ExecuteNonQuery();
                }

            }
            scsModificado = Obtener(scs.id);
            return scsModificado;
        }

        public Sucursal Obtener(int id)
        {
            Sucursal scsEncontrado = null;
            string sql = "select * from Sucursal where suc_id = @id";
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
                            scsEncontrado = new Sucursal()
                            {
                                id = (int)resultado["suc_id"],
                                nombre = (string)resultado["suc_nombre"],
                                tarifa = (decimal)resultado["suc_tarifa"]
                            };
                        }
                    }
                }
            }
            return scsEncontrado;
        }


        public Objeto Eliminar(int id)
        {
            int err = 1; string err_msj = "No se ha podido eliminar Sucursal con id = " + id;
            string sql = "delete from sucursal where  suc_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    comando.ExecuteNonQuery();
                    err = 0;
                    err_msj = "Sucursal eliminado correctamente";
                }
            }

            return new Objeto() { Codigo = 1, Error = err, Mensaje = err_msj };
        }


        public List<Sucursal> Listar()
        {
            List<Sucursal> listaSensores = new List<Sucursal>();
            Sucursal scsEncontrado = null;
            string sql = "select * from Sucursal";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            scsEncontrado = new Sucursal()
                            {
                                id = (int)resultado["suc_id"],
                                nombre = (string)resultado["suc_nombre"],
                                tarifa = (decimal)resultado["suc_tarifa"]

                            };
                            listaSensores.Add(scsEncontrado);
                        }
                    }
                }
            }
            return listaSensores;
        }










    }
}