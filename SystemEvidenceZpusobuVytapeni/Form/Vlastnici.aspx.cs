using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZV.DataMapper;
using EZV.DTO;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Vlastnici : System.Web.UI.Page
    {

        Vlastnik vlastnik = new Vlastnik();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Id_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Jmeno_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Jmeno = Convert.ToString(Jmeno.Text);
        }

        protected void Prijmeni_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Prijmeni = Convert.ToString(Prijmeni.Text);
        }

        protected void Datum_narozeni_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Datum_narozeni = DateTime.Parse(Datum_narozeni.Text);
        }

        protected void Datum_umrti_TextChanged(object sender, EventArgs e)
        {
            if (Datum_umrti.Text != string.Empty)
                vlastnik.Datum_umrti = DateTime.Parse(Datum_umrti.Text);
        }

        protected void Rodne_cislo_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Rodne_cislo = Convert.ToString(Rodne_cislo.Text);
        }

        protected void Pohlavi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Pohlavi.Text == "muž")
                vlastnik.Pohlavi = "M";
            else
            {
                vlastnik.Pohlavi = "Z";
            }
        }

        protected void Ulice_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Trvale_bydliste_ulice = Convert.ToString(Ulice.Text);
        }

        protected void Cislo_popisne_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Trvale_bydliste_cislo_popisne = int.Parse(Cislo_popisne.Text);
        }

        protected void Mesto_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Trvale_bydliste_mesto = Convert.ToString(Mesto.Text);
        }

        protected void PSC_TextChanged(object sender, EventArgs e)
        {
            vlastnik.Trvale_bydliste_PSC = Convert.ToString(PSC.Text);
        }

        protected void AktualniVlastnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AktualniVlastnik.Text == "ano")
                vlastnik.Aktualni_vlastnik = "A";
            else
            {
                vlastnik.Aktualni_vlastnik = "N";
            }
        }

        protected void Vložení_Click(object sender, EventArgs e)
        {
            Id.Text = string.Empty;
            Jmeno.Text = string.Empty;
            Prijmeni.Text = string.Empty;
            Datum_narozeni.Text = string.Empty;
            Datum_umrti.Text = string.Empty;
            Rodne_cislo.Text = string.Empty;
            Pohlavi.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Mesto.Text = string.Empty;
            PSC.Text = string.Empty;
            AktualniVlastnik.Text = string.Empty;

            Uložení.Visible = true;
            vlastnik.Id_vlastnika = Vlastnik_DataMapper.Sequence();
            Id.Text = Convert.ToString(vlastnik.Id_vlastnika);
            Id.ReadOnly = true;
            Datum_umrti.ReadOnly = true;
        }

        protected void Změna_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vlastniku.aspx");
        }

        protected void Uložení_Click(object sender, EventArgs e)
        {
            try
            {
                vlastnik.Id_vlastnika = int.Parse(Id.Text);
                //Vlastnik_DataMapper.Insert(vlastnik); ;
                Uspesnost.Text = "Úspěšné vložení vlastníka!";
            }
            catch
            {
                Uspesnost.Text = "Nepovedlo se úspěšně vložit vlastníka!";
            }

            Id.Text = string.Empty;
            Jmeno.Text = string.Empty;
            Prijmeni.Text = string.Empty;
            Datum_narozeni.Text = string.Empty;
            Datum_umrti.Text = string.Empty;
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