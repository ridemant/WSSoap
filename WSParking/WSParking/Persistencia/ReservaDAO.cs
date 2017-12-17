using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSParking.Dominio;
using WSParking.Utils;

namespace WSParking.Persistencia
{
    public class ReservaDAO
    {


        public Reserva Modificar(Reserva scs)
        {
            Reserva scsModificado = null;
            string sql = "update estado_estacionamiento set sta_estado=@estacionamientoid, sta_fecha=@fecha, sta_condicion=@condicion where sta_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", scs.id));
                    comando.Parameters.Add(new SqlParameter("@estacionamientoid", scs.estacionamiento_id));
                    comando.Parameters.Add(new SqlParameter("@fecha", scs.fecha));
                    comando.Parameters.Add(new SqlParameter("@condicion", scs.estado));
                    comando.ExecuteNonQuery();
                }

            }
            scsModificado = Obtener(scs.id);
            return scsModificado;
        }


        public Reserva Obtener(int id)
        {
            Reserva scsEncontrado = null;
            string sql = "select * from estado_estacionamiento where sta_id = @id";
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
                            scsEncontrado = new Reserva()
                            {
                                id = (int)resultado["sta_id"],
                                estacionamiento_id = (int)resultado["sta_estado"],
                                fecha = (DateTime)resultado["sta_fecha"],
                                estado = (int)resultado["sta_condicion"]
                            };
                        }
                    }
                }
            }
            return scsEncontrado;
        }



        public List<Reserva> Listar()
        {
            List<Reserva> listaResv = new List<Reserva>();
            Reserva scsEncontrado = null;
            string sql = "select * from estado_estacionamiento";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            scsEncontrado = new Reserva()
                            {
                                id = (int)resultado["sta_id"],
                                estacionamiento_id = (int)resultado["sta_estado"],
                                fecha = (DateTime)resultado["sta_fecha"],
                                estado = (int)resultado["sta_condicion"]

                            };
                            listaResv.Add(scsEncontrado);
                        }
                    }
                }
            }
            return listaResv;
        }



    }
}