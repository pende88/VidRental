using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VideotekaService.DAL
{
    [DataContract]
    public class Film
    {
        [DataMember]
        public int idFilm;

        [DataMember]
        public string naziv;

        [DataMember]
        public string godina;

        [DataMember]
        public int zanrId;

        [DataMember]
        public string FilmZanr;
    }
}