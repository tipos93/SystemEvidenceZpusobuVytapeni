using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using EZV.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam : System.Web.UI.Page
    {
        IStavba stavba;
        Collection<Stavba> stavby;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            IStavbaFactory stavbaFactory = new SqlFactory();
            IStavba stavba = stavbaFactory.CreateStavba();
            Collection<Stavba> stavby = stavba.Select();
            */

            //IStavbaFactory stavbaFactory = null;
            //IStavba stavba = (IStavba) DecisionMaker.DecideSQL(stavbaFactory);
            //Collection<Stavba> stavby = stavba.Select();

            IStavbaFactory stavbafactory = DecisionMaker.DecideSQL();
            stavba = stavbafactory.CreateStavba();
            stavby = stavba.Select();

            GridViewStavby.DataSource = stavby;
            GridViewStavby.DataBind();
        }
        /*
        protected override void Render(HtmlTextWriter writer)
        {

            foreach (GridViewRow row in GridViewStavby.Rows)

                ClientScript.RegisterForEventValidation(row.UniqueID.ToString());

            base.Render(writer);

        }*/

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewStavby.PageIndex = e.NewPageIndex;
            GridViewStavby.DataBind();
        }

        protected void DetailsViewStavby_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridViewStavby.DataBind();
            GridViewStavby.SelectRow(-1);
        }
        /*
        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Int32 iID = Convert.ToInt32((GridViewStavby.DataKeys[e.NewEditIndex].Value));
            EditMethod(iID);         // now you can send ID and retrieve data.
        }

        private void EditMethod(int iID)
        {
            Stavba konkretniStavba = stavba.Select_id(iID);
            DetailsViewStavby.DataSource = konkretniStavba;
            DetailsViewStavby.DataBind();
        }
        */
        
        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal stavbaLiteral = (sender as Button).NamingContainer.FindControl("ltrId") as Literal;

            int stavbaId;

            if (stavbaLiteral == null)
            {
                stavbaId = -1;
            }
            else if (int.TryParse(stavbaLiteral.Text.ToString(), out stavbaId))
            {

            }
            else
            {
                stavbaId = -1;
            }

            Stavba konkretniStavba = stavba.Select_id(stavbaId);
            stavby.Clear();
            stavby.Add(konkretniStavba);
            DetailsViewStavby.DataSource = stavby;
            DetailsViewStavby.DataBind();
        }
        
        protected void btnAktualizovat_Click(object sender, EventArgs e)
        {

        }
    }
}