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
        Collection<Stavba> stavby;
        Stavba konkretniStavba = new Stavba();
        int stavbaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //stavba = (IStavba) this.GetFactory(DecisionMaker.Items.Stavba);
            this.GetFactory();
            stavba = DecisionMaker.Stavba.CreateStavba();
            stavby = stavba.Select();

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