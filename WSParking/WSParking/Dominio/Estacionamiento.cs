using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSParking.Dominio
{
              [DataContract]
    public class Estacionamiento
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int numero { get; set; }

        [DataMember]
        public int idsucursal { get; set; }

        [DataMember]
        public int piso { get; set; }

        [DataMember]
        public int estado { get; set; }

    }
}