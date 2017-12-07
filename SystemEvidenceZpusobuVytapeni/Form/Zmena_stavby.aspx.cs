using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Zmena_stavby : BasePage
    {
        IStavba stavba;
        Collection<Stavba> stavby;
        Stavba konkretniStavba = new Stavba();
        int stavbaId;
        int StavbaCisloPopisne;
        int StavbaCislo;
        DateTime stavbaDatum;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();

            if (Session["login"] == null)
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

                GridViewStavby.DataSource = stavby;
                GridViewStavby.DataBind();
            }
        }

        private void nahraniDetailsView()
        {
            konkretniStavba = stavba.Select_id(stavbaId);
            //vymazani kolekce vlastniku
            stavby.Clear();
            //pridani vybraneho zaznamu
            stavby.Add(konkretniStavba);
            DetailsViewStavby.DataSource = stavby;
            DetailsViewStavby.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewStavby.PageIndex = e.NewPageIndex;
            GridViewStavby.DataBind();
        }

        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal stavbaLiteral = (sender as Button).NamingContainer.FindControl("ltrId") as Literal;

            if (stavbaLiteral != null)
            {
                int.TryParse(stavbaLiteral.Text.ToString(), out stavbaId);
            }
            else
            {
                stavbaId = -1;
            }

            this.nahraniDetailsView();
        }

        protected void btnUpravit_Click(object sender, EventArgs e)
        {
            DetailsViewStavby.ChangeMode(DetailsViewMode.Edit);
            Label stavbaLabel = DetailsViewStavby.FindControl("idStavby") as Label;

            if (stavbaLabel != null)
            {
                int.TryParse(stavbaLabel.Text.ToString(), out stavbaId);
            }
            else
            {
                stavbaId = -1;
            }

            this.nahraniDetailsView();
        }

        protected void btnAktualizovat_Click(object sender, EventArgs e)
        {
            DetailsViewStavby.UpdateItem(true);
        }

        protected void DetailsViewStavby_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (DetailsViewStavby.CurrentMode == DetailsViewMode.Edit)
            {
                Label idLabel = DetailsViewStavby.FindControl("idStavby") as Label;
                DropDownList typLabel = DetailsViewStavby.FindControl("ListTyp") as DropDownList;
                TextBox uliceText = DetailsViewStavby.FindControl("TextUlice") as TextBox;
                TextBox cisloPopisneText = DetailsViewStavby.FindControl("TextCislo_popisne") as TextBox;
                TextBox cisloStavbyText = DetailsViewStavby.FindControl("TextCislo_stavby") as TextBox;
                TextBox nazevText = DetailsViewStavby.FindControl("TextNazev") as TextBox;
                TextBox datumText = DetailsViewStavby.FindControl("TextDatum") as TextBox;

                int.TryParse(idLabel.Text.ToString(), out stavbaId);
                konkretniStavba.Id_stavby = stavbaId;

                konkretniStavba.Typ_stavby = typLabel.Text.ToString();
                konkretniStavba.Ulice = uliceText.Text.ToString();

                int.TryParse(cisloPopisneText.Text.ToString(), out StavbaCisloPopisne);
                konkretniStavba.Cislo_popisne = StavbaCisloPopisne;

                int.TryParse(cisloStavbyText.Text.ToString(), out StavbaCislo);
                konkretniStavba.Cislo_stavby_na_KU = StavbaCislo;

                konkretniStavba.Nazev_KU = nazevText.Text.ToString();

                DateTime.TryParse(datumText.Text.ToString(), out stavbaDatum);
                konkretniStavba.Datum_kolaudace = stavbaDatum;

                DetailsViewStavby.ChangeMode(DetailsViewMode.ReadOnly);
                stavba.Update(konkretniStavba);

                DetailsViewStavby.DataSource = null;
                DetailsViewStavby.DataBind();

                GridViewStavby.DataSource = stavba.Select();
                GridViewStavby.DataBind();
                GridViewStavby.SelectRow(-1);
            }
        }

        protected void btnStorno_Click(object sender, EventArgs e)
        {
            DetailsViewStavby.ChangeMode(DetailsViewMode.ReadOnly);
            Label stavbaLabel = DetailsViewStavby.FindControl("idStavby") as Label;

            if (stavbaLabel != null)
            {
                int.TryParse(stavbaLabel.Text.ToString(), out stavbaId);
            }
            else
            {
                stavbaId = -1;
            }

            this.nahraniDetailsView();
        }
    }
}