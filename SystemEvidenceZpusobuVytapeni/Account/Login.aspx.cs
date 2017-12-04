using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Prihlaseni_Click(object sender, EventArgs e)
        {
            
            //SiteMaster siteMaster = new SiteMaster();
            //siteMaster.FindControl("NavigationMenu").Visible = true;
            
            Menu mn = (Menu)Master.FindControl("NavigationMenu");
            mn.Visible = true;
            
            /*
            foreach (MenuItem item in mn.Items)
            {
                string navigate = item.NavigateUrl;
                /// Other stuffs you want to do
            }
            */
            //Menu MasterMenu = (Menu) SiteMaster.FindControl("NavigationMenu");
            //MasterMenu.Visible = true;
        }
    }
}
