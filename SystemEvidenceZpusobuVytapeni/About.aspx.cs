using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni
{
    public partial class About : Form.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();

            if (Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }
        }
    }
}