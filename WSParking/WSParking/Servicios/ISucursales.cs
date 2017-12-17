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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISucursales" in both code and config file together.
    [ServiceContract]
    public interface ISucursales
    {

        [OperationContract]
        Sucursal CrearSucursal(Sucursal sucursal);


        [OperationContract]
        Sucursal ModificarSucursal(Sucursal sucursal);


        [OperationContract]
        Objeto EliminarSucursal(int sucursal_id);


        [OperationContract]
        Sucursal ObtenerSucursal(int sucursal_id);

        [OperationContract]
        List<Sucursal> ListaSucursal();

    }
}
