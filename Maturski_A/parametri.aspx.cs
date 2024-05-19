using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturski_A
{
    public partial class parametri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == "null")
            {
                Response.Redirect("login.aspx");
            }
        }

      

   

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }





        protected void Button2_Click(object sender, EventArgs e)
        {
            maturski_a upis_Igrac = new maturski_a();
            int rezultat;
            rezultat = upis_Igrac.Unos_Igraca(txtimeigraca.Text, txtprezimeigraca.Text, txtdrzavaigraca.Text, txtsportigraca.Text, Int32.Parse(txtbrojmedaljaigraca.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");

            }
        }

     
        protected void Button4_Click(object sender, EventArgs e)
        {
            maturski_a upis_Sport = new maturski_a();
            int rezultat;
            rezultat = upis_Sport.Unos_Sporta(txtnazivsporta.Text, Int32.Parse(txtbrojfazasporta.Text), Int32.Parse(txtvrstasporta.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            maturski_a upis_Drzava = new maturski_a();
            int rezultat;
            rezultat = upis_Drzava.Unos_Drzave(txtnazivdrzave.Text, Int32.Parse(txtbrojmedaljadrzave.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a brisanje_igraca = new Maturski_A.maturski_a();
            int rezultat = brisanje_igraca.Bacanje_Igraca(Convert.ToInt32(ListBox2.SelectedItem.Value));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a izmena_igraca = new Maturski_A.maturski_a();
            int rezultat = izmena_igraca.Ispravka_Igrac(Convert.ToInt32(ListBox2.SelectedItem.Value), txtimeigraca.Text,txtprezimeigraca.Text,txtdrzavaigraca.Text,txtsportigraca.Text,Convert.ToInt32(txtbrojmedaljaigraca.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a izmena_sporta = new Maturski_A.maturski_a();
            int rezultat = izmena_sporta.Ispravka_Sporta(Convert.ToInt32(ListBox4.SelectedItem.Value), txtnazivsporta.Text, Convert.ToInt32(txtbrojfazasporta.Text), Convert.ToInt32(txtvrstasporta.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a brisanje_sporta = new Maturski_A.maturski_a();
            int rezultat = brisanje_sporta.Bacanje_Sporta(Convert.ToInt32(ListBox4.SelectedItem.Value));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a izmena_drzave = new Maturski_A.maturski_a();
            int rezultat = izmena_drzave.Ispravka_Drzave(Convert.ToInt32(ListBox3.SelectedItem.Value), txtnazivdrzave.Text, Convert.ToInt32(txtbrojmedaljadrzave.Text));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a brisanje_drzave = new Maturski_A.maturski_a();
            int rezultat = brisanje_drzave.Bacanje_Drzave(Convert.ToInt32(ListBox3.SelectedItem.Value));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            maturski_a upis_Ekipa = new maturski_a();
            int rezultat;
            rezultat = upis_Ekipa.Unos_Ekipe(ListBox5.SelectedItem.Text,ListBox6.SelectedItem.Text);
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a brisanje_Ekipe = new Maturski_A.maturski_a();
            int rezultat = brisanje_Ekipe.Bacanje_Ekipe(Convert.ToInt32(ListBox7.SelectedItem.Value));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            maturski_a upis_trener = new maturski_a();
            int rezultat;
            rezultat = upis_trener.Unos_Trenera(txtimetrenera.Text, txtprezimetrenera.Text, txtdrzavatrenera.Text, txtsporttrenera.Text, txtvrstatrenera.Text);

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");

            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a brisanje_trenera = new Maturski_A.maturski_a();
            int rezultat = brisanje_trenera.Bacanje_Trenera(Convert.ToInt32(ListBox8.SelectedItem.Value));
            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a izmena_trenera = new Maturski_A.maturski_a();
            int rezultat = izmena_trenera.Ispravka_Trener(Convert.ToInt32(ListBox8.SelectedItem.Value), txtimetrenera.Text, txtprezimetrenera.Text, txtdrzavatrenera.Text, txtsporttrenera.Text, txtvrstatrenera.Text);

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void ListBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            maturski_a upis_utakmica = new maturski_a();
            int rezultat;
            rezultat = upis_utakmica.Unos_Utakmice(Convert.ToInt32(ListBox9.SelectedItem.Value), Convert.ToInt32(ListBox10.SelectedItem.Value),Convert.ToInt32(txtfazautakmice.Text));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");

            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Maturski_A.maturski_a izmena_utakmice = new Maturski_A.maturski_a();
            int rezultat = izmena_utakmice.Gotova_Utakmica(Convert.ToInt32(txtrezultat1utakmica.Text),Convert.ToInt32(txtrezultat2utakmica.Text),Convert.ToInt16(ListBox11.SelectedItem.Value));

            if (rezultat == 0)
            {
                Response.Redirect("parametri.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}