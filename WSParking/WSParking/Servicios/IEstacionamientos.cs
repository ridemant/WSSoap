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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEstacionamientos" in both code and config file together.
    [ServiceContract]
    public interface IEstacionamientos
    {
        [OperationContract]
        Estacionamiento CrearEstacionamiento(Estacionamiento estacionamiento);


        [OperationContract]
        Estacionamiento ModificarEstacionamiento(Estacionamiento estacionamiento);

        [OperationContract]
        Estacionamiento ObtenerEstacionamiento(int estacionamiento_id);


        [OperationContract]
        Objeto EliminarEstacionamiento(int estacionamiento_id);


        [OperationContract]
        List<Estacionamiento> ListaEstacionamiento();

    }
}
