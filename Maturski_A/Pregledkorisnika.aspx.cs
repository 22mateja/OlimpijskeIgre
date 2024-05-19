using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturski_A
{
    public partial class Pregledkorisnika : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == "null")
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnupiskorisnika_Click(object sender, EventArgs e)
        {
            maturski_a upis_k = new maturski_a();
            int rezultat;

            rezultat = upis_k.Unos_Korisnik(txtime.Text, txtprezime.Text, txtdrzava.Text,txtimekorisnika.Text, txtlozinka.Text);
            if (rezultat==0)
            {
                Response.Redirect("Pregledkorisnika.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
    }
}