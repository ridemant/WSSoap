using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSParking.Dominio;
using WSParking.Persistencia;

namespace WSParking.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Reservas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Reservas.svc or Reservas.svc.cs at the Solution Explorer and start debugging.
    public class Reservas : IReservas
    {
        private ReservaDAO reservaDAO = new ReservaDAO();



        public Reserva ModificarReserva(Reserva reserva)
        {
            return reservaDAO.Modificar(reserva);
        }

        public List<Reserva> ListaReserva()
        {
            return reservaDAO.Listar();
        }

        public Reserva ObtenerReserva(int reserva_id)
        {
            return reservaDAO.Obtener(reserva_id);
        }
    }
}
