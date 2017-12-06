using EZV.DataDecisionMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class BasePage : System.Web.UI.Page
    {
        Menu mn;

        protected virtual void GetFactory(/*DecisionMaker.Items item*/)
        {
            //return (DecisionMaker.DecideSQL(item));
            DecisionMaker.getInstances();
        }

        protected virtual void ControlMenuItems()
        {
                mn = (Menu)Master.FindControl("NavigationMenu");

                MenuItem miStavby = new MenuItem();
                miStavby.Value = "1";
                miStavby.Text = "Stavby";
                miStavby.NavigateUrl = "Form/Stavby.aspx";
                mn.Items.AddAt(1, miStavby);

                MenuItem miVlastnici = new MenuItem();
                miVlastnici.Value = "2";
                miVlastnici.Text = "Vlastníci";
                miVlastnici.NavigateUrl = "Form/Vlastnici.aspx";
                mn.Items.AddAt(2, miVlastnici);
        }
    }
}