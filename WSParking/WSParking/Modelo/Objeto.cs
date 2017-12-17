using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSParking.Modelo
{
        [DataContract]
    public class Objeto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public int Error { get; set; }
        [DataMember]
        public string Mensaje { get; set; }

    }
}