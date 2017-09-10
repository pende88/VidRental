using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VideotekaService.DAL
{
    [DataContract]
    public class TipMedija
    {
        [DataMember]
        public int id;

        [DataMember]
        public string naziv;
    }
}