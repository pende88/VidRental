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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Zanr> GetZanr();
        [OperationContract]
        void AddUppZanr(Zanr zanr);
        [OperationContract]
        void deleteZanr(int id);
        [OperationContract]
        int DeleteZanrSafe(int idZanr);


        [OperationContract]
        List<Film> GetFilmZanr();
        [OperationContract]
        List<Film> GetFilm();
        [OperationContract]
        List<Film> SearchFilm(string naziv);

        [OperationContract]
        List<Film> GetSlobodniFilmovi();
        [OperationContract]
        List<Film> GetFilmDDL();

        [OperationContract]
        void AddUppFilm(Film film);
        [OperationContract]
        void DeleteFilm(int id);
        [OperationContract]
        int DeleteFilmSafe(int id);

        [OperationContract]
        List<Klijent> GetKlijent();
        [OperationContract]
        void AddUppKlijent(Klijent klijent);
        [OperationContract]
        void DeleteKlijent(int id);
        [OperationContract]
        int DeleteKlijentSafe(int idKlijent);
        [OperationContract]
        List<Klijent> GetKlijentDDL();


        [OperationContract]
        List<Posudba> GetAktivnaPosudba();
        
        [OperationContract]
        void AddUppPosudba(Posudba posudba);
        [OperationContract]
        void DeletePosudba(int id);


        [OperationContract]
        List<TipMedija> GetTipMedija();

    }
}