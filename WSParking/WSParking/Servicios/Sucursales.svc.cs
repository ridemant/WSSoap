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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Sucursales" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Sucursales.svc or Sucursales.svc.cs at the Solution Explorer and start debugging.
    public class Sucursales : ISucursales
    {
        private SucursalDAO sucursalDAO = new SucursalDAO();



        public Sucursal CrearSucursal(Sucursal usuario)
        {
            return sucursalDAO.Crear(usuario);
        }

        public Sucursal ModificarSucursal(Sucursal sucursal)
        {
            return sucursalDAO.Modificar(sucursal);
        }


        public Objeto EliminarSucursal(int sucursal_id)
        {
            return sucursalDAO.Eliminar(sucursal_id);
        }

        public Sucursal ObtenerSucursal(int sucursal_id)
        {
            return sucursalDAO.Obtener(sucursal_id);
        }

        public List<Sucursal> ListaSucursal()
        {
            return sucursalDAO.Listar();
        }
    }
}
