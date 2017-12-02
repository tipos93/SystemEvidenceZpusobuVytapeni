using System;
using EZV.DTO;
using EZV.DataDecisionMaker;
using EZV.DAOFactory;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Stavby : System.Web.UI.Page
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
            //stavba = (IStavba)DecisionMaker.DecideSQL(DecisionMaker.Items.Stavba);
            stavba = (IStavba)DecisionMaker.DecideXML(DecisionMaker.Items.Stavba);
            //vlastnik = (IVlastnik)DecisionMaker.DecideSQL(DecisionMaker.Items.Vlastnik);
            vlastnik = (IVlastnik)DecisionMaker.DecideXML(DecisionMaker.Items.Vlastnik);
            //stavbaVlastnik = (IStavbaVlastnik)DecisionMaker.DecideSQL(DecisionMaker.Items.StavbaVlastnik);
            stavbaVlastnik = (IStavbaVlastnik)DecisionMaker.DecideXML(DecisionMaker.Items.StavbaVlastnik);
            zpusobVytapeni = (IZpusob_vytapeni)DecisionMaker.DecideSQL(DecisionMaker.Items.Zpusob);

            /*
            IStavbaFactory stavbaFactory = DecisionMaker.DecideSQL();
            stavba = stavbaFactory.CreateStavba();

            IVlastnikFactory vlastnikFactory = DecisionMaker.DecideSQL();
            vlastnik = vlastnikFactory.CreateVlastnik();

            IStavbaVlastnikFactory stavbaVlastnikFactory = DecisionMaker.DecideSQL();
            stavbaVlastnik = stavbaVlastnikFactory.CreateStavbaVlastnik();

            IZpusob_vytapeniFactory zpusobVytapeniFactory = DecisionMaker.DecideSQL();
            zpusobVytapeni = zpusobVytapeniFactory.CreateZpusob();
            */

            if (!IsPostBack)
            {
                NacitaniDropDownListu();
            }
        }

        public void NacitaniDropDownListu()
        {
            stavby = stavba.Select();
            vlastnici = vlastnik.Select();

            ListStavbaV.Items.Add(new ListItem("", "-9999"));
            ListStavbaZ.Items.Add(new ListItem("", "-9999"));
            Stavba_zpusob.Items.Add(new ListItem("", "-9999"));
            ListVlastnikV.Items.Add(new ListItem("", "-9999"));
            ListVlastnikZ.Items.Add(new ListItem("", "-9999"));

            foreach (var jednaStavba in stavby)
            {
                ListStavbaV.Items.Add(new ListItem(jednaStavba.Typ_stavby + ", " + jednaStavba.Ulice + ", " + jednaStavba.Cislo_popisne.ToString(), jednaStavba.Id_stavby.ToString()));
                ListStavbaZ.Items.Add(new ListItem(jednaStavba.Typ_stavby + ", " + jednaStavba.Ulice + ", " + jednaStavba.Cislo_popisne.ToString(), jednaStavba.Id_stavby.ToString()));
            }
            foreach (var jedenVlastnik in vlastnici)
            {
                ListVlastnikV.Items.Add(new ListItem(jedenVlastnik.Jmeno + ", " + jedenVlastnik.Prijmeni + ", " + jedenVlastnik.Rodne_cislo, jedenVlastnik.Id_vlastnika.ToString()));
                ListVlastnikZ.Items.Add(new ListItem(jedenVlastnik.Jmeno + ", " + jedenVlastnik.Prijmeni + ", " + jedenVlastnik.Rodne_cislo, jedenVlastnik.Id_vlastnika.ToString()));
            }

            //ListStavbaZ.DataSource = ListStavbaV.Items;
            //ListStavbaZ.DataBind();
            Stavba_zpusob.DataSource = ListStavbaV.Items;
            Stavba_zpusob.DataBind();
            //ListVlastnikZ.DataSource = ListVlastnikV.Items;
            //ListVlastnikZ.DataBind();
        }

        #region Stavba

        protected void Vložení_Click(object sender, EventArgs e)
        {
            Id.Text = string.Empty;
            Typ.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Cislo_stavby_na_KU.Text = string.Empty;
            Nazev_KU.Text = string.Empty;
            Datum_kolaudace.Text = string.Empty;

            Uložit.Visible = true;
            konkretniStavba.Id_stavby = stavba.Sequence();
            Id.Text = konkretniStavba.Id_stavby.ToString();
            Id.ReadOnly = true;
        }

        protected void Zmenit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_staveb.aspx");
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
                konkretniStavba.Datum_kolaudace = DateTime.Parse(Datum_kolaudace.Text);

                stavba.Insert(konkretniStavba);
                Uspesnost.Text = "Úspěšné vložení stavby!";
            }
            catch
            {
                Uspesnost.Text = "Nepovedlo se úspěšně vložit stavbu!";
            }

            Id.Text = string.Empty;
            Typ.Text = string.Empty;
            Ulice.Text = string.Empty;
            Cislo_popisne.Text = string.Empty;
            Cislo_stavby_na_KU.Text = string.Empty;
            Nazev_KU.Text = string.Empty;
            Datum_kolaudace.Text = string.Empty;
            konkretniStavba = null;
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
        }

        #endregion

        #region ZpusobVytapeni

        protected void Potvrzeni_vlozeni_zpusobu_Click(object sender, EventArgs e)
        {
            try
            {
                konkretniZpusobVytapeni.Id_stavby = int.Parse(Stavba_zpusob.SelectedValue);
                konkretniZpusobVytapeni.Typ_vytapeni = Zpusob_vytapeni_vlozeni.Text.ToString();
                konkretniZpusobVytapeni.Platnost_od = DateTime.Parse(Platnost_od_v.Text);

                zpusobVytapeni.Insert(konkretniZpusobVytapeni);
                Uspesne_vlozeni_zpusobu.Text = "Úspěšné vložení způsobu vytápění stavby!";
            }
            catch
            {
                Uspesne_vlozeni_zpusobu.Text = "Nepovedlo se úspěšně vložit způsob vytápění stavby!";
            }
            Zpusob_vytapeni_vlozeni.Text = string.Empty;
            Platnost_od_v.Text = string.Empty;
        }

        protected void Zmena_zpusobu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vytapeni.aspx");
        }

        #endregion

        protected void Stavby_kontroly_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Stavby_kontroly.aspx");
        }

        protected void Stavby_topi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Stavby_topi.aspx");
        }

        protected void seznam_zpusobu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_vytapeni.aspx");
        }
    }
}