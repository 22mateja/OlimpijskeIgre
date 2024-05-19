using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;




namespace Maturski_A
{
    public class maturski_a
    {
        string webConfig = ConfigurationManager.ConnectionStrings["MatRad"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        string webConfig1 = ConfigurationManager.ConnectionStrings["Olimpijada"].ConnectionString;
        SqlConnection conn1 = new SqlConnection();
        SqlCommand comm1 = new SqlCommand();
        SqlDataAdapter da1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

        public int Provera_Korisnika(string email, string lozinka)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "dbo.Sudija_Email";
            comm1.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm1.Parameters.Add(new SqlParameter("@lozinka", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }


        public DataSet Admin_Svi()
        {
            conn1.ConnectionString = webConfig1;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sve_Sudije";
            conn1.Open();
            da1.SelectCommand = comm1;
            da1.Fill(ds1);

            if (conn1.State == ConnectionState.Open)
            {
                conn1.Close();
            }


            return (ds1);


        }

        public int Unos_Korisnik(string ime, string prezime, string drzava, string email, string loz)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sudija_Insert";
            comm1.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm1.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm1.Parameters.Add(new SqlParameter("@naziv_drzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, drzava));
            comm1.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm1.Parameters.Add(new SqlParameter("@lozinka", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, loz));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }

        public int Unos_SGodina(string s_godina)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "S_Godina_Insert";
            comm.Parameters.Add(new SqlParameter("@s_godina", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, s_godina));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }


        public DataSet SGodina_Svi()
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Sve_Godine";
            conn.Open();
            da.SelectCommand = comm;
            da.Fill(ds);


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            return (ds);


        }

        public int Bacanje_godine(int godina)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "S_Delete_ID";
            comm.Parameters.Add(new SqlParameter("@s_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, godina));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Unos_Premet(string predmet)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Predmet_Insert";
            comm.Parameters.Add(new SqlParameter("@n_predmet", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, predmet));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Bacanje_premeta(int predmet_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Predmet_Delete_ID";
            comm.Parameters.Add(new SqlParameter("@predmet_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, predmet_id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Ispravka_Premet(int premet_id, string predmet)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Predmet_Update";
            comm.Parameters.Add(new SqlParameter("@predmet_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, premet_id));
            comm.Parameters.Add(new SqlParameter("@predmet", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, predmet));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }



        public int Unos_Profesora(string ime, string prez, int predmet1_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Profesor_Insert";
            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prez", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prez));
            comm.Parameters.Add(new SqlParameter("@predmet1_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, predmet1_id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Unos_Igraca(string ime, string prezime, string drzava, string sport, int br_medalja)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Igraci_Insert";
            comm1.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm1.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm1.Parameters.Add(new SqlParameter("@nazivDrzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, drzava));
            comm1.Parameters.Add(new SqlParameter("@nazivSporta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sport));
            comm1.Parameters.Add(new SqlParameter("@br_medalja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_medalja));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Ispravka_Igrac(int id, string ime, string prezime,string nazivdrzave,string nazivsporta, int br_medalja)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Igraci_Update";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm1.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm1.Parameters.Add(new SqlParameter("@nazivDrzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nazivdrzave));
            comm1.Parameters.Add(new SqlParameter("@nazivSporta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nazivsporta));
            comm1.Parameters.Add(new SqlParameter("@br_medalja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_medalja));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Bacanje_Igraca(int id)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Igraci_Delete";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Unos_Sporta(string naziv, int br_faza, int vrsta)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sport_Insert";
            comm1.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm1.Parameters.Add(new SqlParameter("@br_faza", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_faza));
            comm1.Parameters.Add(new SqlParameter("@vrsta", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vrsta));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Ispravka_Sporta(int id, string naziv, int br_faza, int vrsta)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sport_Update";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm1.Parameters.Add(new SqlParameter("@br_faza", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_faza));
            comm1.Parameters.Add(new SqlParameter("@vrsta", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vrsta));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Bacanje_Sporta(int id)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sport_Delete";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Unos_Drzave(string naziv, int br_medalja)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Drzava_Insert";
            comm1.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm1.Parameters.Add(new SqlParameter("@br_medalja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_medalja));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Ispravka_Drzave(int id, string naziv, int br_medalja)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Sport_Update";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm1.Parameters.Add(new SqlParameter("@br_medalja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, br_medalja));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Bacanje_Drzave(int id)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Drzava_Delete";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Unos_Ekipe(string drzava, string sport)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Ekipa_Insert";
            comm1.Parameters.Add(new SqlParameter("@nazivDrzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, drzava));
            comm1.Parameters.Add(new SqlParameter("@nazivSporta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sport));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Bacanje_Ekipe(int id)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Ekipa_Delete";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Unos_Trenera(string ime, string prezime, string drzava, string sport, string vrsta)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Trener_Insert";
            comm1.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm1.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm1.Parameters.Add(new SqlParameter("@nazivDrzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, drzava));
            comm1.Parameters.Add(new SqlParameter("@nazivSporta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sport));
            comm1.Parameters.Add(new SqlParameter("@vrsta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vrsta));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Bacanje_Trenera(int id)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Trener_Delete";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Ispravka_Trener(int id, string ime, string prezime, string nazivdrzave, string nazivsporta, string vrsta)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Trener_Update";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm1.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm1.Parameters.Add(new SqlParameter("@nazivDrzave", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nazivdrzave));
            comm1.Parameters.Add(new SqlParameter("@nazivSporta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nazivsporta));
            comm1.Parameters.Add(new SqlParameter("@vrsta", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vrsta));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
        public int Unos_Utakmice(int id1, int id2, int faza)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Trener_Insert";
            comm1.Parameters.Add(new SqlParameter("@ekipa_id_1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id1));
            comm1.Parameters.Add(new SqlParameter("@ekipa_id_2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id2));
            comm1.Parameters.Add(new SqlParameter("@faza", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current,faza));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();
            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }
        public int Gotova_Utakmica(int id,int rezultat1, int rezultat2)
        {
            conn1.ConnectionString = webConfig1;
            int rezultat;
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.CommandText = "Utakmica_Update";
            comm1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm1.Parameters.Add(new SqlParameter("@rezultat1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, rezultat1));
            comm1.Parameters.Add(new SqlParameter("@rezultat2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, rezultat2));
            comm1.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn1.Open();
            comm1.ExecuteNonQuery();
            conn1.Close();

            int Ret;
            Ret = (int)comm1.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
    }
}