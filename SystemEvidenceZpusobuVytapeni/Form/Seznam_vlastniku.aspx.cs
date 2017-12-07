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
        Collection<Vlastnik> vlastnici = new Collection<Vlastnik>();
        Vlastnik konkretniVlastnik = new Vlastnik();
        int vlastnikId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();
            this.GetFactory();

            if (Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }

            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();

            if (Session["postaveni"].Equals("vlastnik"))
            {
                int id = int.Parse(Session["id_vlastnika"].ToString());
                vlastnici.Add(vlastnik.Select_id(id));
            }
            else
            {
                vlastnici = vlastnik.Select();
            }
            //vlastnik = (IVlastnik) this.GetFactory(DecisionMaker.Items.Vlastnik);

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