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
    public class UsuarioDAO
    {
        public Objeto AutentificarUsuario(string usuario, string contrasena)
        {

            Objeto obj = new Objeto();
            obj.Codigo = 0;
            obj.Mensaje = "Los datos ingresados son incorrectos";
            obj.Error = 1;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                obj.Codigo = -1;
            }
            else
            {
                string sql = "select * from usuario where usr_usuario = @Usuario and usr_contrasena = @Contrasena";
                using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@Usuario", usuario));
                        comando.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                obj.Codigo = (int)resultado["usr_id"];
                                obj.Mensaje = "OK";
                                obj.Error = 0;
                            }
                        }
                    }
                }
            }
            return obj;
        }


        public Usuario Crear(Usuario usr){

            Usuario usrCreado = null;
            int id = 0;
            string sql = "insert into usuario (usr_usuario, usr_contrasena, usr_nombres, usr_appaterno, usr_apmaterno, usr_dni, usr_tipo, usr_saldo, usr_correo) OUTPUT INSERTED.usr_id VALUES (@usuario, @contrasena, @nombres, @appaterno, @apmaterno, @dni, @tipo, @saldo, @correo)";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", usr.id));
                    comando.Parameters.Add(new SqlParameter("@usuario", usr.usuario));
                    comando.Parameters.Add(new SqlParameter("@contrasena", usr.contrasena));
                    comando.Parameters.Add(new SqlParameter("@nombres", usr.nombres));
                    comando.Parameters.Add(new SqlParameter("@appaterno", usr.appaterno));
                    comando.Parameters.Add(new SqlParameter("@apmaterno", usr.apmaterno));
                    comando.Parameters.Add(new SqlParameter("@dni", usr.dni));
                    comando.Parameters.Add(new SqlParameter("@tipo", usr.tipo));
                    comando.Parameters.Add(new SqlParameter("@saldo", usr.saldo));
                    comando.Parameters.Add(new SqlParameter("@correo", usr.correo));
                    //comando.ExecuteNonQuery();
                    id = (int)comando.ExecuteScalar();
                }
                usrCreado = Obtener(id);
            }
            return usrCreado;
        }


        public Usuario Modificar(Usuario usr)
        {
            Usuario usrModificado = null;
            string sql = "update usuario set usr_usuario=@usuario, usr_contrasena=@contrasena, usr_nombres=@nombres, usr_appaterno=@appaterno, usr_apmaterno=@apmaterno, usr_dni=@dni, usr_tipo=@tipo, usr_saldo=@saldo, usr_correo=@correo where usr_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", usr.id));
                    comando.Parameters.Add(new SqlParameter("@usuario", usr.usuario));
                    comando.Parameters.Add(new SqlParameter("@contrasena", usr.contrasena));
                    comando.Parameters.Add(new SqlParameter("@nombres", usr.nombres));
                    comando.Parameters.Add(new SqlParameter("@appaterno", usr.appaterno));
                    comando.Parameters.Add(new SqlParameter("@apmaterno", usr.apmaterno));
                    comando.Parameters.Add(new SqlParameter("@dni", usr.dni));
                    comando.Parameters.Add(new SqlParameter("@tipo", usr.tipo));
                    comando.Parameters.Add(new SqlParameter("@saldo", usr.saldo));
                    comando.Parameters.Add(new SqlParameter("@correo", usr.correo));

                    comando.ExecuteNonQuery();
                }

            }
            usrModificado = Obtener(usr.id);
            return usrModificado;
        }

        public Usuario Obtener(int id)
        {
            Usuario usrEncontrado = null;
            string sql = "select * from usuario where usr_id = @id";
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
                            usrEncontrado = new Usuario()
                            {
                                id = (int)resultado["usr_id"],
                                usuario = (string)resultado["usr_usuario"],
                                contrasena = (string)resultado["usr_contrasena"],
                                nombres = (string)resultado["usr_nombres"],
                                appaterno = (string)resultado["usr_appaterno"],
                                apmaterno = (string)resultado["usr_apmaterno"],
                                dni = (string)resultado["usr_dni"],
                                tipo = (int)resultado["usr_tipo"],
                                saldo = (decimal)resultado["usr_saldo"],
                                correo = (string)resultado["usr_correo"]
                            };
                        }
                    }
                }
            }
            return usrEncontrado;
        }


        public Objeto Eliminar(int id)
        {
            int err = 1; string err_msj = "No se ha podido eliminar usuario con id = " + id; 
            string sql = "delete from usuario where  usr_id = @id";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    comando.ExecuteNonQuery();
                    err = 0;
                    err_msj = "Usuario eliminado correctamente";
                }
            }

            return new Objeto() { Codigo = 1, Error = err, Mensaje = err_msj };
        }


        public List<Usuario> Listar()
        {
            List<Usuario> listaSensores = new List<Usuario>();
            Usuario usrEncontrado = null;
            string sql = "select * from usuario";
            using (SqlConnection conexion = new SqlConnection(Config.CAD_CONEXION))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usrEncontrado = new Usuario()
                            {
                                id = (int)resultado["usr_id"],
                                usuario = (string)resultado["usr_usuario"],
                                contrasena = (string)resultado["usr_contrasena"],
                                nombres = (string)resultado["usr_nombres"],
                                appaterno = (string)resultado["usr_appaterno"],
                                apmaterno = (string)resultado["usr_apmaterno"],
                                dni = (string)resultado["usr_dni"],
                                tipo = (int)resultado["usr_tipo"],
                                saldo = (decimal)resultado["usr_saldo"],
                                correo = (string)resultado["usr_correo"]

                            };
                            listaSensores.Add(usrEncontrado);
                        }
                    }
                }
            }
            return listaSensores;
        }



    }
}