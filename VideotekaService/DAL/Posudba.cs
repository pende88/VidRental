using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VideotekaService.DAL
{
    [DataContract]
    public class Posudba
    {

        [DataMember]
        public int id;

        [DataMember]
        public int idKorisnik;

        [DataMember]
        public int idFilm;

        [DataMember]
        public int idTipmedija;

        [DataMember]
        public DateTime datumPosudbe;


        [DataMember]
        public DateTime? datumPovrata;
        
       

        [DataMember]
        public string ime;
        [DataMember]
        public string prezime;
        [DataMember]
        public string NazivFilma;
        [DataMember]
        public string Medij;
    }
}