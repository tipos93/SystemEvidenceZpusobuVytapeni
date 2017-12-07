using System;
using EZV.DTO;
using EZV.DataDecisionMaker;
using EZV.DAOFactory;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Stavby : BasePage
    {
        IStavba stavba;
        IVlastnik vlastnik;
        IStavbaVlastnik stavbaVlastnik;
        IZpusob_vytapeni zpusobVytapeni;

        Stavba konkretniStavba = new Stavba();
        Collection<Stavba> stavby;

        Vlastnik konkretniVlastnik = new Vlastnik();
        Collection<Vlastnik> vlastnici;

        StavbaVlastnik konkretniStavbaVlastnik = new StavbaVlastnik();

        Zpusob_vytapeni konkretniZpusobVytapeni = new Zpusob_vytapeni();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();

            if(Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }

            if (!Session["postaveni"].Equals("obec"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //stavba = (IStavba) this.GetFactory(DecisionMaker.Items.Stavba);
                this.GetFactory();
                stavba = DecisionMaker.Stavba.CreateStavba();
                stavby = stavba.Select();

                //vlastnik = (IVlastnik) this.GetFactory(DecisionMaker.Items.Vlastnik);
                vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();
                vlastnici = vlastnik.Select();

                //stavbaVlastnik = (IStavbaVlastnik) this.GetFactory(DecisionMaker.Items.StavbaVlastnik);
                //zpusobVytapeni = (IZpusob_vytapeni)this.GetFactory(DecisionMaker.Items.Zpusob);
                stavbaVlastnik = DecisionMaker.StavbaVlastnik.CreateStavbaVlastnik();
                zpusobVytapeni = DecisionMaker.Zpusob.CreateZpusob();

                CalendarDatumKolaudace.SelectedDate = CalendarDatumKolaudace.TodaysDate;
                CalendarPlatnostOd.SelectedDate = CalendarPlatnostOd.TodaysDate;

                if (!IsPostBack)
                {
                    NacitaniDropDownListu();
                }
            }
        }

        private void NacitaniDropDownListu()
        {
            ListStavbaV.Items.Add(new ListItem("", "-9999"));
            ListVlastnikV.Items.Add(new ListItem("", "-9999"));

            foreach (var jednaStavba in stavby)
            {
                ListStavbaV.Items.Add(new ListItem(jednaStavba.Typ_stavby + ", " + jednaStavba.Ulice + ", " + jednaStavba.Cislo_popisne.ToString(), jednaStavba.Id_stavby.ToString()));
            }
            foreach (var jedenVlastnik in vlastnici)
            {
                ListVlastnikV.Items.Add(new ListItem(jedenVlastnik.Jmeno + ", " + jedenVlastnik.Prijmeni + ", " + jedenVlastnik.Rodne_cislo, jedenVlastnik.Id_vlastnika.ToString()));
            }

            ListItem[] itemStavbaV = new ListItem[ListStavbaV.Items.Count];
            ListItem[] itemVlastnikV = new ListItem[ListVlastnikV.Items.Count];

            ListStavbaV.Items.CopyTo(itemStavbaV, 0);
            ListStavbaZ.Items.AddRange(itemStavbaV);
            Stavba_zpusob.Items.AddRange(itemStavbaV);

            ListVlastnikV.Items.CopyTo(itemVlastnikV, 0);
            ListVlastnikZ.Items.AddRange(itemVlastnikV);
        }

        #region Stavba

        private void MazaniPolicekStavby()
        {
            Id.Text = string.Empty;
            Typ.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Cislo_stavby_na_KU.Text = string.Empty;
            Nazev_KU.Text = string.Empty;
            CalendarDatumKolaudace.SelectedDate = CalendarDatumKolaudace.TodaysDate;
        }

        protected void Vložení_Click(object sender, EventArgs e)
        {
            this.MazaniPolicekStavby();

            Uložit.Visible = true;
            konkretniStavba.Id_stavby = stavba.Sequence();
            Id.Text = konkretniStavba.Id_stavby.ToString();
            Id.ReadOnly = true;
        }

        protected void Zmenit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Zmena_stavby.aspx");
        }

        protected void Ulozit_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniStavba.Id_stavby = int.Parse(Id.Text);
                konkretniStavba.Typ_stavby = Typ.Text.ToString();
                konkretniStavba.Ulice = Ulice.Text.ToString();
                konkretniStavba.Cislo_popisne = int.Parse(Cislo_popisne.Text);
                konkretniStavba.Cislo_stavby_na_KU = int.Parse(Cislo_stavby_na_KU.Text);
                konkretniStavba.Nazev_KU = Nazev_KU.Text.ToString();
                konkretniStavba.Datum_kolaudace = CalendarDatumKolaudace.SelectedDate;

                stavba.Insert(konkretniStavba);
                Uspesnost.Text = "Úspěšné vložení stavby!";
            }
            catch
            {
                Uspesnost.Text = "Nepovedlo se úspěšně vložit stavbu!";
            }

            this.MazaniPolicekStavby();
        }

        #endregion

        protected void Stavby_vlastnici_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_stavby_vlastnici.aspx");
        }

        protected void Seznam_staveb_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_staveb.aspx");
        }

        protected void Seznam_vlastniku_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vlastniku.aspx");
        }

        #region StavbaVlastnik

        protected void Potvrzeni_vlozeni_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniStavbaVlastnik.Id_stavby = int.Parse(ListStavbaV.SelectedValue);
                konkretniStavbaVlastnik.Id_vlastnika = int.Parse(ListVlastnikV.SelectedValue);

                stavbaVlastnik.Insert(konkretniStavbaVlastnik);
                Uspesne_vlozeni_vlastnika.Text = "Úspěšné vložení vlastníka stavby!";
            }
            catch
            {
                Uspesne_vlozeni_vlastnika.Text = "Nepovedlo se úspěšně vložit vlastníka stavby! Stavbu již daný vlastník vlastní!";
            }

            ListStavbaV.SelectedValue = "-9999";
            ListVlastnikV.SelectedValue = "-9999";
        }

        protected void Potvrzeni_zmeny_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniStavbaVlastnik.Id_stavby = int.Parse(ListStavbaZ.SelectedValue);
                konkretniStavbaVlastnik.Id_vlastnika = int.Parse(ListVlastnikZ.SelectedValue);

                stavbaVlastnik.Update(konkretniStavbaVlastnik);
                Uspesna_zmena_vlastnika.Text = "Úspěšná změna vlastníka stavby!";
            }
            catch
            {
                Uspesna_zmena_vlastnika.Text = "Nepovedlo se změnit vlastníka stavby!";
            }

            ListStavbaZ.SelectedValue = "-9999";
            ListVlastnikZ.SelectedValue = "-9999";
        }

        #endregion

        #region ZpusobVytapeni

        protected void Potvrzeni_vlozeni_zpusobu_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniZpusobVytapeni.Id_stavby = int.Parse(Stavba_zpusob.SelectedValue);
                konkretniZpusobVytapeni.Typ_vytapeni = Zpusob_vytapeni_vlozeni.Text.ToString();
                konkretniZpusobVytapeni.Platnost_od = CalendarPlatnostOd.SelectedDate;

                zpusobVytapeni.Insert(konkretniZpusobVytapeni);
                Uspesne_vlozeni_zpusobu.Text = "Úspěšné vložení způsobu vytápění stavby!";
            }
            catch
            {
                Uspesne_vlozeni_zpusobu.Text = "Nepovedlo se úspěšně vložit způsob vytápění stavby!";
            }

            Stavba_zpusob.SelectedValue = "-9999";
            Zpusob_vytapeni_vlozeni.Text = string.Empty;
            CalendarPlatnostOd.SelectedDate = CalendarPlatnostOd.TodaysDate;
        }

        protected void Zmena_zpusobu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vytapeni.aspx");
        }

        #endregion

        protected void seznam_zpusobu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vytapeni.aspx");
        }
    }
}