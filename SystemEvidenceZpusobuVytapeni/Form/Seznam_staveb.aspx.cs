using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam : BasePage
    {
        IStavba stavba;
        IStavbaVlastnik stavbaVlastnik;
        Collection<Stavba> stavby = new Collection<Stavba>();
        Stavba konkretniStavba = new Stavba();
        Collection<StavbaVlastnik> konkretniStavbyVlastnici;
        int stavbaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();
            this.GetFactory();

            if (Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }

            stavba = DecisionMaker.Stavba.CreateStavba();

            if (Session["postaveni"].Equals("vlastnik"))
            {
                stavbaVlastnik = DecisionMaker.StavbaVlastnik.CreateStavbaVlastnik();
                konkretniStavbyVlastnici = stavbaVlastnik.Select();
                int idVlastnika = int.Parse(Session["id_vlastnika"].ToString());

                foreach (StavbaVlastnik sv in konkretniStavbyVlastnici)
                {
                    if (sv.Id_vlastnika == idVlastnika)
                    {
                        stavby.Add(stavba.Select_id(sv.Id_stavby));
                    }
                }
            }
            else
            {
                stavby = stavba.Select();
            }

            //stavba = (IStavba) this.GetFactory(DecisionMaker.Items.Stavba);

            GridViewStavby.DataSource = stavby;
            GridViewStavby.DataBind();
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

            konkretniStavba = stavba.Select_id(stavbaId);
            stavby.Clear();
            stavby.Add(konkretniStavba);
            DetailsViewStavby.DataSource = stavby;
            DetailsViewStavby.DataBind();
        }
    }
}