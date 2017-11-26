using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            List<Stavba> stavby = .Select(connection).Where(c => c.PociatocnaStanica.ID == stanicaZ
                && c.CielovaStanica.ID == stanicaDo && c.Odchod > cas).ToList();

            gridNalezeneListky.DataSource = cesty;
            gridNalezeneListky.DataBind();
            */
        }

        protected void DetailsViewStavby_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridViewStavby.DataBind();
            GridViewStavby.SelectRow(-1);
        }

        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal stavbaLiteral = (sender as Button).NamingContainer.FindControl("ltrId") as Literal;

            int stavbaId;

            if(stavbaLiteral == null)
            {
                stavbaId = -1;
            }
            else if (int.TryParse(stavbaLiteral.ToString(), out stavbaId))
            {

            }
            else
            {
                stavbaId = -1;
            }
        }
    }
}