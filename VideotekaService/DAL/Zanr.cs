using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VideotekaService.DAL
{
    [DataContract]
    public class Zanr
    {

        [DataMember]
        public int Id;
        [DataMember]
        public string Naziv;
    }
}