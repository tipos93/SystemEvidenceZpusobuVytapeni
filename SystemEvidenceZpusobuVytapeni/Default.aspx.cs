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
            //if (Session["IDUSER"] == null)
            //{
                Menu mn = (Menu)Master.FindControl("NavigationMenu");
                mn.Visible = true;

                this.ControlMenuItems();

                //MenuItem mi = mn.FindItem("1");
                //MenuItem mi2 = mn.FindItem("2");
                //mn.Items.Remove(mi);
                //mn.Items.Remove(mi2);
                //Session.Add("IDUSER", 1);
            //}
        }
    }
}