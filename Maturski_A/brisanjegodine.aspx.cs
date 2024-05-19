using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturski_A
{
    public partial class brisanjegodine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["korisnik"] == "null")
            {
                Response.Redirect("login.aspx");
            }

            Maturski_A.maturski_a brisanje_godine = new Maturski_A.maturski_a();

            int broj_brisanja = Convert.ToInt32(Request.QueryString["id"]);
            Response.Write(broj_brisanja);

            int rezultat = brisanje_godine.Bacanje_godine(broj_brisanja);

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