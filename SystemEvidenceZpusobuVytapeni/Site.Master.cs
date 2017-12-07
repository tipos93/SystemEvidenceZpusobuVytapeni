using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Odhlaseni_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Form/Login.aspx");
        }
    }
}