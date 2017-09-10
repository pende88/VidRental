using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VideotekaService.DAL;

namespace VideotekaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void AddUppFilm(Film film)
        {
            new Repository().AddUppFilm(film);
        }

        public void AddUppKlijent(Klijent klijent)
        {
            new Repository().AddUppKlijent(klijent);
        }

        public void AddUppPosudba(Posudba posudba)
        {
            new Repository().AddUppPosudba(posudba);
        }

        public void AddUppZanr(Zanr zanr)
        {
            new Repository().AddUppZanr(zanr);
        }

        public void DeleteFilm(int id)
        {
            new Repository().DeleteFilm(id);
        }
        public int DeleteFilmSafe(int id)
        {
            return (new Repository()).DeleteFilmSafe(id);
        }

        public void DeleteKlijent(int id)
        {
            new Repository().DeleteKlijent(id);
        }
        public int DeleteKlijentSafe(int idKlijent)
        {
            return (new Repository()).DeleteKlijentSafe(idKlijent);
        }

        public void DeletePosudba(int id)
        {
            new Repository().DeletePosudba(id);        }

        public void deleteZanr(int id)
        {
            new Repository().DeleteZanr(id);
        }
        public int DeleteZanrSafe(int id)
        {
            return (new Repository()).DeleteZanrSafe(id);
        }

        public List<Posudba> GetAktivnaPosudba()
        {
            return (new Repository()).GetAktivnaPosudba();
        }
        //ovo provjeri
        public List<Posudba> GetAllPosudba()
        {
            return (new Repository()).GetAktivnaPosudba();
        }

        public List<Film> GetFilm()
        {
            return (new Repository()).GetFilm();
        }

        public List<Film> GetFilmDDL()
        {
            return (new Repository()).GetFilmDDL();
        }

        public List<Film> GetFilmZanr()
        {
            return (new Repository()).GetFilmZanr();
        }

        public List<Klijent> GetKlijent()
        {
            return (new Repository()).GetKlijent();
        }

        public List<Zanr> GetZanr()
        {
            return (new Repository()).GetZanr();
        }

        public List<Film> SearchFilm(string naziv)
        {
            return (new Repository()).SearchFilm(naziv);
        }

        public List<Film> GetSlobodniFilmovi()
        {
            return (new Repository()).GetSlobodniFilmovi();
        }

        public List<TipMedija> GetTipMedija()
        {
            return (new Repository()).GetTipMedija();
        }

        public List<Klijent> GetKlijentDDL()
        {
            return (new Repository()).GetKlijentDDL();

        }

       
    }

}
