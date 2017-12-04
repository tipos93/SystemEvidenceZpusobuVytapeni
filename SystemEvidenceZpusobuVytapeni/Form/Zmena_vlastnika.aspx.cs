using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Zmena_vlastnika : BasePage
    {
        IVlastnik vlastnik;
        Collection<Vlastnik> vlastnici;
        Vlastnik konkretniVlastnik = new Vlastnik();
        int vlastnikId;
        DateTime vlastnikDatumNarozeni;
        DateTime vlastnikDatumUmrti;
        int vlastnikCisloPopisne;
        public bool priznak = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //vlastnik = (IVlastnik)this.GetFactory(DecisionMaker.Items.Vlastnik);
            this.GetFactory();
            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();
            vlastnici = vlastnik.Select();

            GridViewVlastnici.DataSource = vlastnici;
            GridViewVlastnici.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewVlastnici.PageIndex = e.NewPageIndex;
            GridViewVlastnici.DataBind();
        }

        private void nahraniDetailsView()
        {
            konkretniVlastnik = vlastnik.Select_id(vlastnikId);
            if(konkretniVlastnik.Datum_umrti == null)
            {
                priznak = false;
            }
            //vymazani kolekce vlastniku
            vlastnici.Clear();
            //pridani vybraneho zaznamu
            vlastnici.Add(konkretniVlastnik);
            DetailsViewVlastnici.DataSource = vlastnici;
            DetailsViewVlastnici.DataBind();
        }

        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal vlastnikLiteral = (sender as Button).NamingContainer.FindControl("ltrId") as Literal;

            if (vlastnikLiteral.Text != null)
            {
                int.TryParse(vlastnikLiteral.Text.ToString(), out vlastnikId);
            }
            else
            {
                vlastnikId = -1;
            }

            this.nahraniDetailsView();
        }

        protected void btnUpravit_Click(object sender, EventArgs e)
        {
            DetailsViewVlastnici.ChangeMode(DetailsViewMode.Edit);
            Label vlastnikLiteral = DetailsViewVlastnici.FindControl("IdVlastnika") as Label;

            if (vlastnikLiteral != null)
            {
                int.TryParse(vlastnikLiteral.Text.ToString(), out vlastnikId);
            }
            else
            {
                vlastnikId = -1;
            }
            this.nahraniDetailsView();
        }

        protected void btnAktualizovat_Click(object sender, EventArgs e)
        {
            DetailsViewVlastnici.UpdateItem(true);
        }

        protected void DetailsViewVlastnici_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            Label vlastnikLiteral = DetailsViewVlastnici.FindControl("IdVlastnika") as Label;

            if (vlastnikLiteral != null)
            {
                int.TryParse(vlastnikLiteral.Text.ToString(), out vlastnikId);
            }
            else
            {
                vlastnikId = -1;
            }

            if (DetailsViewVlastnici.CurrentMode == DetailsViewMode.Edit)
            {
                TextBox jmenoText = DetailsViewVlastnici.FindControl("TextJmeno") as TextBox;
                TextBox prijmeniText = DetailsViewVlastnici.FindControl("TextPrijmeni") as TextBox;
                Calendar calDatumNarozeni = DetailsViewVlastnici.FindControl("CalDatum_narozeni") as Calendar;
                Calendar calDatumUmrti = DetailsViewVlastnici.FindControl("CalDatum_umrti") as Calendar;
                TextBox rodneCisloText = DetailsViewVlastnici.FindControl("TextRodne_cislo") as TextBox;
                DropDownList pohlaviList = DetailsViewVlastnici.FindControl("ListPohlavi") as DropDownList;
                TextBox uliceText = DetailsViewVlastnici.FindControl("TextUlice") as TextBox;
                TextBox cisloPopisneText = DetailsViewVlastnici.FindControl("TextCislo_popisne") as TextBox;
                TextBox mestoText = DetailsViewVlastnici.FindControl("TextMesto") as TextBox;
                TextBox PSCText = DetailsViewVlastnici.FindControl("TextPSC") as TextBox;
                DropDownList aktualnostList = DetailsViewVlastnici.FindControl("ListAktualnost") as DropDownList;

                konkretniVlastnik.Id_vlastnika = vlastnikId;

                konkretniVlastnik.Jmeno = jmenoText.Text.ToString();
                konkretniVlastnik.Prijmeni = prijmeniText.Text.ToString();

                DateTime.TryParse(calDatumNarozeni.SelectedDate.ToShortDateString(), out vlastnikDatumNarozeni);
                konkretniVlastnik.Datum_narozeni = vlastnikDatumNarozeni;

                DateTime.TryParse(calDatumUmrti.SelectedDate.ToShortDateString(), out vlastnikDatumUmrti);
                konkretniVlastnik.Datum_umrti = vlastnikDatumUmrti;

                konkretniVlastnik.Rodne_cislo = rodneCisloText.Text.ToString();
                konkretniVlastnik.Pohlavi = pohlaviList.Text.ToString();
                konkretniVlastnik.Trvale_bydliste_ulice = uliceText.Text.ToString();

                int.TryParse(cisloPopisneText.Text.ToString(), out vlastnikCisloPopisne);
                konkretniVlastnik.Trvale_bydliste_cislo_popisne = vlastnikCisloPopisne;

                konkretniVlastnik.Trvale_bydliste_mesto = mestoText.Text.ToString();
                konkretniVlastnik.Trvale_bydliste_PSC = PSCText.Text.ToString();
                konkretniVlastnik.Aktualni_vlastnik = aktualnostList.Text.ToString();

                DetailsViewVlastnici.ChangeMode(DetailsViewMode.ReadOnly);
                vlastnik.Update(konkretniVlastnik);

                DetailsViewVlastnici.DataSource = null;
                DetailsViewVlastnici.DataBind();

                GridViewVlastnici.DataSource = vlastnik.Select();
                GridViewVlastnici.DataBind();
                GridViewVlastnici.SelectRow(-1);
            }
        }

        protected void btnStorno_Click(object sender, EventArgs e)
        {
            DetailsViewVlastnici.ChangeMode(DetailsViewMode.ReadOnly);
            this.nahraniDetailsView();
        }
    }
}