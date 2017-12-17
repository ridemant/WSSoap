using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSParking.Dominio
{
            [DataContract]
    public class Sucursal
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public decimal tarifa { get; set; }


    }
}