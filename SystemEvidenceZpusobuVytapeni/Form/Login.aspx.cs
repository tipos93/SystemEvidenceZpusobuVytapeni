using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Login : BasePage
    {
        IUzivatele uzivatele;
        Uzivatele konkretniUzivatele;
        Menu mn;

        protected void Page_Load(object sender, EventArgs e)
        {
            mn = (Menu)Master.FindControl("NavigationMenu");
            mn.Visible = false;

            this.GetFactory();
            uzivatele = DecisionMaker.Uzivatele.CreateUzivatele();
        }

        protected void Prihlaseni_Click(object sender, EventArgs e)
        {
            TextBox Login = Login1.FindControl("UserName") as TextBox;
            TextBox Heslo = Login1.FindControl("Password") as TextBox;

            konkretniUzivatele = uzivatele.Select_id(Login.Text.ToString());
            if (konkretniUzivatele.Heslo.Equals(Heslo.Text.ToString()))
            {
                Session["login"] = Login.Text.ToString();
                Response.Redirect("~/Default.aspx");
                Session.RemoveAll();
            }
            Literal error = Login1.FindControl("FailureText") as Literal;
            error.Text = "Nepovedlo se přihlášení do systému!";
        }
    }
}