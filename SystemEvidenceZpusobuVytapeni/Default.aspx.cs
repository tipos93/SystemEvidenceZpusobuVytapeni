using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni
{
    public partial class _Default : Form.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu mn = (Menu)Master.FindControl("NavigationMenu");
            mn.Visible = true;

            this.ShowUser();
            this.ControlMenuItems();

            if (Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }

            //Session.Add("IDUSER", 1);
            //}
        }
    }
}