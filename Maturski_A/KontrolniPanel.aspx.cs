using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturski_A
{
    public partial class KontrolniPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["korisnik"]=="null")
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}