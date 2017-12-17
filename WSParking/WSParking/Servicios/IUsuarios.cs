using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSParking.Dominio;
using WSParking.Modelo;

namespace WSParking.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarios" in both code and config file together.
    [ServiceContract]
    public interface IUsuarios
    {

        [OperationContract]
        Objeto AutentificarUsuario(string usuario, string contrasena);

        [OperationContract]
        Usuario CrearUsuario(Usuario usuario);


        [OperationContract]
        Usuario ModificarUsuario(Usuario usuario);

        
        [OperationContract]
        Usuario ObtenerUsuario(int usuario_id);


        [OperationContract]
        Objeto EliminarUsuario(int usuario_id);


        [OperationContract]
        List<Usuario> ListaUsuario();


        


    }
}
