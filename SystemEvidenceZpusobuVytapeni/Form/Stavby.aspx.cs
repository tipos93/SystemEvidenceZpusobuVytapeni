using System;
using EZV.DataMapper;
using EZV.DTO;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Stavby : System.Web.UI.Page
    {
        Stavba stavba = new Stavba();
        StavbaVlastnik stavbaVlastnikv = new StavbaVlastnik();
        StavbaVlastnik stavbaVlastnikz = new StavbaVlastnik();
        Zpusob_vytapeni zpusob_vytapeniv = new Zpusob_vytapeni();
        Zpusob_vytapeni zpusob_vytapeniz = new Zpusob_vytapeni();
 
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        #region Stavba

        protected void Id_TextChanged(object sender, EventArgs e)
        {
            stavba.Id_stavby = int.Parse(Id.Text);
        }

        protected void Typ_SelectedIndexChanged(object sender, EventArgs e)
        {
            stavba.Typ_stavby = Convert.ToString(Typ.Text);
        }

        protected void Ulice_TextChanged(object sender, EventArgs e)
        {
            stavba.Ulice = Convert.ToString(Ulice.Text);
        }

        protected void Cislo_popisne_TextChanged(object sender, EventArgs e)
        {
            stavba.Cislo_popisne = int.Parse(Cislo_popisne.Text);
        }

        protected void Cislo_stavby_na_KU_TextChanged(object sender, EventArgs e)
        {
            stavba.Cislo_stavby_na_KU = int.Parse(Cislo_stavby_na_KU.Text);
        }

        protected void Nazev_KU_TextChanged(object sender, EventArgs e)
        {
            stavba.Nazev_KU = Convert.ToString(Nazev_KU.Text);
        }

        protected void Datum_kolaudace_TextChanged(object sender, EventArgs e)
        {
            stavba.Datum_kolaudace = DateTime.Parse(Datum_kolaudace.Text);
        }

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
            stavba.Id_stavby = Stavba_DataMapper.Sequence();
            Id.Text = Convert.ToString(stavba.Id_stavby);
            Id.ReadOnly = true;
        }

        protected void Změna_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Form/Seznam_staveb.aspx");
        }

        protected void Ulozit_Click(object sender, EventArgs e)
        {
            try
            {
                stavba.Id_stavby = int.Parse(Id.Text);
                //Stavba_DataMapper.Insert(stavba); ;
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
            stavba = null;
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

        protected void ListStavbaV_SelectedIndexChanged(object sender, EventArgs e)
        {
            stavbaVlastnikv.Id_stavby = int.Parse(ListStavbaV.SelectedValue);
        }

        protected void ListVlastnikV_SelectedIndexChanged(object sender, EventArgs e)
        {
            stavbaVlastnikv.Id_vlastnika = int.Parse(ListVlastnikV.SelectedValue);
        }

        protected void Potvrzeni_vlozeni_Click(object sender, EventArgs e)
        {
            try
            {
                //StavbaVlastnik_DataMapper.Insert(stavbaVlastnikv);
                Uspesne_vlozeni_vlastnika.Text = "Úspěšné vložení vlastníka stavby!";
            }
            catch
            {
                Uspesne_vlozeni_vlastnika.Text = "Nepovedlo se úspěšně vložit vlastníka stavby! Stavbu již daný vlastník vlastní!";
            }
        }

        protected void ListStavbaZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            stavbaVlastnikz.Id_stavby = int.Parse(ListStavbaZ.SelectedValue);
        }

        protected void ListVlastnikZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            stavbaVlastnikz.Id_vlastnika = int.Parse(ListVlastnikZ.SelectedValue);
        }

        protected void Potvrzeni_zmeny_Click(object sender, EventArgs e)
        {
            try
            {
                //StavbaVlastnik_DataMapper.Update(stavbaVlastnikz);
                Uspesna_zmena_vlastnika.Text = "Úspěšná změna vlastníka stavby!";
            }
            catch
            {
                Uspesna_zmena_vlastnika.Text = "Nepovedlo se změnit vlastníka stavby!";
            }
        }

        #endregion

        #region ZpusobVytapeni

        protected void Stavba_zpusob_SelectedIndexChanged(object sender, EventArgs e)
        {
            zpusob_vytapeniv.Id_stavby = int.Parse(Stavba_zpusob.SelectedValue);
        }

        protected void Zpusob_vytapeni_vlozeni_SelectedIndexChanged(object sender, EventArgs e)
        {
            zpusob_vytapeniv.Typ_vytapeni = Convert.ToString(Zpusob_vytapeni_vlozeni.Text);
        }

        protected void Platnost_od_v_TextChanged(object sender, EventArgs e)
        {
            zpusob_vytapeniv.Platnost_od = DateTime.Parse(Platnost_od_v.Text);
        }

        protected void Potvrzeni_vlozeni_zpusobu_Click(object sender, EventArgs e)
        {
            try
            {
                //Zpusob_vytapeni_DataMapper.Insert(zpusob_vytapeniv);
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