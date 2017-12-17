using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSParking.Dominio;

namespace WSParking.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservas" in both code and config file together.
    [ServiceContract]
    public interface IReservas
    {
        [OperationContract]
        Reserva ModificarReserva(Reserva reserva);

        [OperationContract]
        List<Reserva> ListaReserva();

        [OperationContract]
        Reserva ObtenerReserva(int reserva_id);

    }
}
