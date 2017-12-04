using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam_vlastniku : BasePage
    {
        IVlastnik vlastnik;
        Collection<Vlastnik> vlastnici;
        Vlastnik konkretniVlastnik = new Vlastnik();
        int vlastnikId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //vlastnik = (IVlastnik) this.GetFactory(DecisionMaker.Items.Vlastnik);
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

        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal stavbaLiteral = (sender as Button).NamingContainer.FindControl("ltrId") as Literal;

            if (stavbaLiteral != null)
            {
                int.TryParse(stavbaLiteral.Text.ToString(), out vlastnikId);
            }
            else
            {
                vlastnikId = -1;
            }

            konkretniVlastnik = vlastnik.Select_id(vlastnikId);
            vlastnici.Clear();
            vlastnici.Add(konkretniVlastnik);
            DetailsViewVlastnici.DataSource = vlastnici;
            DetailsViewVlastnici.DataBind();
        }
    }
}