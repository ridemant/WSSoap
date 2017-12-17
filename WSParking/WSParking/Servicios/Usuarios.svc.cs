using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSParking.Dominio;
using WSParking.Modelo;
using WSParking.Persistencia;

namespace WSParking.Servicios
{

    public class Usuarios : IUsuarios
    {

        private UsuarioDAO UsuarioDAO = new UsuarioDAO();

        public Objeto AutentificarUsuario(string usuario, string contrasena)
        {
            return UsuarioDAO.AutentificarUsuario(usuario, contrasena);
        }

        public Usuario CrearUsuario(Usuario usuario)
        {
            return UsuarioDAO.Crear(usuario);
        }

        public Usuario ModificarUsuario(Usuario usuario)
        {
            return UsuarioDAO.Modificar(usuario);
        }

        public Usuario ObtenerUsuario(int usuario_id)
        {
            return UsuarioDAO.Obtener(usuario_id);
        }

        public Objeto EliminarUsuario(int usuario_id)
        {
            return UsuarioDAO.Eliminar(usuario_id);
        }


        public List<Usuario> ListaUsuario()
        {
            return UsuarioDAO.Listar();
        }


    }
}
