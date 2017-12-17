using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSParking.Dominio
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int estacionamiento_id { get; set; }

        [DataMember]
        public DateTime fecha { get; set; }

        [DataMember]
        public int estado { get; set; }

    }
}