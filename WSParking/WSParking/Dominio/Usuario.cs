using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSParking.Dominio
{


    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string usuario { get; set; }

        [DataMember]
        public string contrasena { get; set; }

        [DataMember]
        public string nombres { get; set; }

        [DataMember]
        public string appaterno { get; set; }

        [DataMember]
        public string apmaterno { get; set; }

        [DataMember]
        public string dni { get; set; }

        [DataMember]
        public int tipo { get; set; }

        [DataMember]
        public decimal saldo { get; set; }

        [DataMember]
        public string correo { get; set; }

    }

}