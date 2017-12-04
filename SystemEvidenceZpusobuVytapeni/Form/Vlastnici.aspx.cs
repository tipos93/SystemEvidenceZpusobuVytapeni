using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZV.DTO;
using EZV.DataDecisionMaker;
using EZV.DAOFactory;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Vlastnici : BasePage
    {
        IVlastnik vlastnik;
        Vlastnik konkretniVlastnik = new Vlastnik();

        protected void Page_Load(object sender, EventArgs e)
        {
            //vlastnik = (IVlastnik) this.GetFactory(DecisionMaker.Items.Vlastnik);
            this.GetFactory();
            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();

            CalendarDatumNarozeni.SelectedDate = CalendarDatumNarozeni.TodaysDate;

            //vlastnik = (IVlastnik) DecisionMaker.DecideSQL(DecisionMaker.Items.Vlastnik);

            //IVlastnikFactory vlastnikFactory = DecisionMaker.NewSQLFactory();
            //vlastnik = vlastnikFactory.CreateVlastnik();
        }

        protected void Vložení_Click(object sender, EventArgs e)
        {
            Id.Text = string.Empty;
            Jmeno.Text = string.Empty;
            Prijmeni.Text = string.Empty;
            CalendarDatumNarozeni.SelectedDate = CalendarDatumNarozeni.TodaysDate;
            Rodne_cislo.Text = string.Empty;
            Pohlavi.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Mesto.Text = string.Empty;
            PSC.Text = string.Empty;
            AktualniVlastnik.Text = string.Empty;

            Uložení.Visible = true;
            konkretniVlastnik.Id_vlastnika = vlastnik.Sequence();
            Id.Text = konkretniVlastnik.Id_vlastnika.ToString();
            Id.ReadOnly = true;
        }

        protected void Změna_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Zmena_vlastnika.aspx");
        }

        protected void Uložení_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniVlastnik.Id_vlastnika = int.Parse(Id.Text);
                konkretniVlastnik.Jmeno = Jmeno.Text.ToString();
                konkretniVlastnik.Prijmeni = Prijmeni.Text.ToString();
                konkretniVlastnik.Datum_narozeni = CalendarDatumNarozeni.SelectedDate;
                konkretniVlastnik.Datum_umrti = null;
                konkretniVlastnik.Rodne_cislo = Rodne_cislo.Text.ToString();
                if (Pohlavi.Text == "muž")
                    konkretniVlastnik.Pohlavi = "M";
                else
                {
                    konkretniVlastnik.Pohlavi = "Z";
                }
                konkretniVlastnik.Trvale_bydliste_ulice = Ulice.Text.ToString();
                konkretniVlastnik.Trvale_bydliste_cislo_popisne = int.Parse(Cislo_popisne.Text);
                konkretniVlastnik.Trvale_bydliste_mesto = Mesto.Text.ToString();
                konkretniVlastnik.Trvale_bydliste_PSC = PSC.Text.ToString();
                if (AktualniVlastnik.Text == "ano")
                    konkretniVlastnik.Aktualni_vlastnik = "A";
                else
                {
                    konkretniVlastnik.Aktualni_vlastnik = "N";
                }

                vlastnik.Insert(konkretniVlastnik);
                
                Uspesnost.Text = "Úspěšné vložení vlastníka!";
            }
            catch (Exception exception)
            {
                Uspesnost.Text = "Nepovedlo se úspěšně vložit vlastníka - zkontrolujte rodné číslo!";
            }

            Id.Text = string.Empty;
            Jmeno.Text = string.Empty;
            Prijmeni.Text = string.Empty;
            CalendarDatumNarozeni.SelectedDate = CalendarDatumNarozeni.TodaysDate;
            Rodne_cislo.Text = string.Empty;
            Pohlavi.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Mesto.Text = string.Empty;
            PSC.Text = string.Empty;
            AktualniVlastnik.Text = string.Empty;
            vlastnik = null;
        }

        protected void Seznam_vlastniku_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vlastniku.aspx");
        }
    }
}