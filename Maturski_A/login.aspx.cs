using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturski_A
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsign_in_Click(object sender, EventArgs e)
        {
            maturski_a p = new maturski_a();
            int rezultat;
            rezultat = p.Provera_Korisnika(txtemail.Text, txtlozinka.Text);
            if(rezultat==0)
            {
                Session["korisnik"] = txtemail.Text;
                Response.Redirect("kontrolnipanel.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}