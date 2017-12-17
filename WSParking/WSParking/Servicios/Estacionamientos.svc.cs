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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Estacionamientos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Estacionamientos.svc or Estacionamientos.svc.cs at the Solution Explorer and start debugging.
    public class Estacionamientos : IEstacionamientos
    {
        private EstacionamientoDAO estacionamientoDAO = new EstacionamientoDAO();



        public Estacionamiento CrearEstacionamiento(Estacionamiento estacionamiento)
        {
            return estacionamientoDAO.Crear(estacionamiento);
        }

        public Estacionamiento ModificarEstacionamiento(Estacionamiento estacionamiento)
        {
            return estacionamientoDAO.Modificar(estacionamiento);
        }

        public Estacionamiento ObtenerEstacionamiento(int estacionamiento_id)
        {
            return estacionamientoDAO.Obtener(estacionamiento_id);
        }

        public Objeto EliminarEstacionamiento(int estacionamiento_id)
        {
            return estacionamientoDAO.Eliminar(estacionamiento_id);
        }


        public List<Estacionamiento> ListaEstacionamiento()
        {
            return estacionamientoDAO.Listar();
        }
    }
}
