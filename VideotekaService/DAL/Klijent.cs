using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VideotekaService.DAL
{
    [DataContract]
    public class Klijent
    {
        [DataMember]
        public int id;

        [DataMember]
        public string ime;

        [DataMember]
        public string prezime;

        [DataMember]
        public string adresa;

        [DataMember]
        public string grad;

       

    }
}