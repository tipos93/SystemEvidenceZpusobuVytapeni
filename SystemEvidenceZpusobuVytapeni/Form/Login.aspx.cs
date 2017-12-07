using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Login : BasePage
    {
        IUzivatele uzivatele;
        IVlastnik vlastnik;
        Uzivatele konkretniUzivatele;
        Vlastnik konkretniVlastnik;
        Menu mn;

        protected void Page_Load(object sender, EventArgs e)
        {
            mn = (Menu)Master.FindControl("NavigationMenu");
            mn.Visible = false;

            LinkButton odhlaseni = (LinkButton)Master.FindControl("Odhlaseni");
            odhlaseni.Visible = false;
            Label prihlaseny = (Label)Master.FindControl("Prihlaseny");
            prihlaseny.Visible = false;

            this.GetFactory();
            uzivatele = DecisionMaker.Uzivatele.CreateUzivatele();
            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();
        }

        protected void Prihlaseni_Click(object sender, EventArgs e)
        {
            TextBox Login = Login1.FindControl("UserName") as TextBox;
            TextBox Heslo = Login1.FindControl("Password") as TextBox;

            konkretniUzivatele = uzivatele.Select_id(Login.Text.ToString());
            konkretniVlastnik = vlastnik.Select_id(konkretniUzivatele.Id_vlastnika);

            if (konkretniUzivatele.Heslo.Equals(Heslo.Text.ToString()))
            {
                Session["login"] = Login.Text.ToString();
                Session["jmeno"] = konkretniVlastnik.Jmeno;
                Session["prijmeni"] = konkretniVlastnik.Prijmeni;
                Session["id_vlastnika"] = konkretniUzivatele.Id_vlastnika;
                Session["postaveni"] = konkretniUzivatele.Postaveni;

                Response.Redirect("~/Default.aspx");
                Session.RemoveAll();
            }
            Literal error = Login1.FindControl("FailureText") as Literal;
            error.Text = "Nepovedlo se přihlášení do systému!";
        }
    }
}