using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VideotekaService.DAL;



namespace VideotekaService
{
    public class Repository
    {
        private static string _cs = System.Configuration.ConfigurationManager.ConnectionStrings["VideotekaDatabaseConnectionString"].ConnectionString;

        public List<Zanr> GetZanr()
        {
            List<Zanr> lista = new List<Zanr>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetZanr", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Zanr z = new Zanr();
                        z.Id = int.Parse(dr["Id"].ToString());
                        z.Naziv = dr["Naziv"].ToString();

                        lista.Add(z);
                    }
                };
            }
            catch (SqlException e)
            {
                //exception kada budemo unaprijeđivali program
            }

            return lista;
        }

        public void AddUppZanr(Zanr zanr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddZanr2", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", zanr.Id));
                    command.Parameters.Add(new SqlParameter("@Naziv", zanr.Naziv));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteZanr(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteZanr", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteZanrSafe(int idZanr)
        {
            int povrat;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteZanrSafe", conn);
                    SqlParameter returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idZanr", idZanr));
                    command.ExecuteNonQuery();
                    povrat = (int)returnParameter.Value;
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return povrat;
        }


        public List<Film> GetFilmZanr()
        {
            List<Film> list = new List<Film>();
            

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getFilmZanr", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Film f = new Film();
                        f.idFilm = int.Parse(dr["IdFilm"].ToString());
                        f.naziv = dr["Naziv"].ToString();
                        f.godina = dr["godina"].ToString();
                        f.FilmZanr = dr["Zanr"].ToString();
                        if(f.FilmZanr == "")
                        {
                            f.FilmZanr = "";
                        }

                        f.zanrId = dr["IdZanr"] == DBNull.Value ? 0 : (int)dr["IdZanr"];
                        

                        list.Add(f);
                    };
                };
            }
            catch (Exception e) 
            {
                throw e;
            }
            return list;
        }

        public List<Film> GetSlobodniFilmovi()
        {
            List<Film> list = new List<Film>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getSlobodniFilmovi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Film f = new Film();
                        f.idFilm = int.Parse(dr["IdFilm"].ToString());
                        
                        f.naziv = dr["Naziv"].ToString();
                        

                        list.Add(f);
                    };
                };
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public void AddUppFilm(Film film)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddUppFilm", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idFilm", film.idFilm));
                    command.Parameters.Add(new SqlParameter("@zanrId", film.zanrId));
                    command.Parameters.Add(new SqlParameter("@godina", film.godina));
                    command.Parameters.Add(new SqlParameter("@naziv", film.naziv));

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteFilm(int idFilm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.deleteFilm", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idFilm", idFilm));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int DeleteFilmSafe(int idFilm)
        {
            int povrat;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.deleteFilmSafe", conn);
                    SqlParameter returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idFilm", idFilm));
                    command.ExecuteNonQuery();
                    povrat = (int)returnParameter.Value;
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return povrat;
        }

        public List<Film> GetFilm()
        {
            List<Film> list = new List<Film>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getAllFilmovi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Film f = new Film();
                        f.idFilm = int.Parse(dr["IdFilm"].ToString());
                        // štelaj za nulu
                        f.zanrId = dr["IdZanr"] == DBNull.Value ? 0 : (int)dr["IdZanr"];
                        f.naziv = dr["Naziv"].ToString();
                        f.godina = dr["godina"].ToString();

                        list.Add(f);
                    };
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public List<Film> GetFilmDDL()
        {
            List<Film> list = new List<Film>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getFilmDDL", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Film f = new Film();
                        f.idFilm = int.Parse(dr["IdFilm"].ToString());

                        f.naziv = dr["Naziv"].ToString();


                        list.Add(f);
                    };
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
    


        public List<Film> SearchFilm(string naziv)
        {
            List<Film> list = new List<Film>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SearchFilm", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Naziv", naziv));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Film f = new Film();
                        f.idFilm = int.Parse(dr["IdFilm"].ToString());
                        f.naziv = dr["Naziv"].ToString();
                        f.godina = dr["godina"].ToString();
                        f.FilmZanr = dr["Zanr"].ToString();
                        f.zanrId = dr["IdZanr"] == DBNull.Value ? 0 : (int)dr["IdZanr"];
                        

                        list.Add(f);
                    };
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }



        public List<Klijent> GetKlijent()
        {
            List<Klijent> list = new List<Klijent>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getKlijenti", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Klijent k = new Klijent();
                        k.id = int.Parse(dr["id"].ToString());
                        k.ime = dr["Ime"].ToString();
                        k.prezime = dr["Prezime"].ToString();
                        k.adresa = dr["Adresa"].ToString();
                        k.grad = dr["Grad"].ToString();

                        list.Add(k);
                    };
                };
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public void AddUppKlijent(Klijent klijent)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddUppKlijent", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", klijent.id));
                    command.Parameters.Add(new SqlParameter("@Ime", klijent.ime));
                    command.Parameters.Add(new SqlParameter("@Prezime", klijent.prezime));
                    command.Parameters.Add(new SqlParameter("@Adresa", klijent.adresa));
                    command.Parameters.Add(new SqlParameter("@Grad", klijent.grad));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteKlijent(int idKlijent)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteKlijent", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", idKlijent));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Klijent> GetKlijentDDL()
        {
            List<Klijent> list = new List<Klijent>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getKlijentiDDL", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Klijent k = new Klijent();
                        k.id = int.Parse(dr["id"].ToString());
                        
                        k.prezime = dr["prezime"].ToString();
                        
                        

                        list.Add(k);
                    };
                    
                };
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public int DeleteKlijentSafe(int idKlijent)
        {
            int povrat;
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteKorisnikSafe", conn);
                    SqlParameter returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idKlijent", idKlijent));
                    command.ExecuteNonQuery();
                    povrat = (int)returnParameter.Value;
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return povrat;
        }




        public List<TipMedija> GetTipMedija()
        {
            List<TipMedija> list = new List<TipMedija>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getTipMedija", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TipMedija t = new TipMedija();
                         t.id = int.Parse(dr["id"].ToString());
                         t.naziv = dr["Naziv"].ToString();
                       

                        list.Add(t);
                    };
                };
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public void AddUppTipMedija(TipMedija tipMedija)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddUppTipMedija", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", tipMedija.id));
                    command.Parameters.Add(new SqlParameter("@naziv", tipMedija.naziv));
                   
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTipMedija(int idTipMedija)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeleteTipMedija", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", idTipMedija));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        

        public List<Posudba> GetAktivnaPosudba()
        {
            List<Posudba> list = new List<Posudba>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.getPosudbeAktivne", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Posudba p = new Posudba();
                        p.id = int.Parse(dr["id"].ToString());

                        p.NazivFilma = dr["NazivFilma"].ToString();

                        p.Medij = dr["Medij"].ToString();

                        p.ime = dr["Ime"].ToString();

                        p.prezime = dr["Prezime"].ToString();

                        p.idFilm = dr["idFilm"] == DBNull.Value ? 0 : (int)dr["idFilm"];

                        p.idKorisnik = dr["idKorisnik"] == DBNull.Value ? 0 : (int)dr["idKorisnik"];

                        p.idTipmedija = int.Parse(dr["idTipMedija"].ToString());

                        p.datumPosudbe = (DateTime)dr["DatumPosudbe"];

                        p.datumPovrata = dr["DatumPovrata"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["DatumPovrata"];


                     


                        list.Add(p);
                    };
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public void AddUppPosudba(Posudba posudba)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.AddUppPosudba", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", posudba.id));
                    command.Parameters.Add(new SqlParameter("@idKorisnik", posudba.idKorisnik));
                    command.Parameters.Add(new SqlParameter("@idFilm", posudba.idFilm));
                    command.Parameters.Add(new SqlParameter("@idTipMedija", posudba.idTipmedija));

                    command.Parameters.Add(new SqlParameter("@datumPosudbe", posudba.datumPosudbe));
                    // command.Parameters.Add(new SqlParameter("@datumPovrata", posudba.datumPovrata));

                    if (posudba.datumPovrata.Equals (new DateTime(1800,1,1)))
                    {
                        command.Parameters.Add(new SqlParameter("@datumPovrata", DBNull.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@datumPovrata", posudba.datumPovrata));


                    }

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePosudba(int idPosudba)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("dbo.DeletePosudba", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", idPosudba));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}
