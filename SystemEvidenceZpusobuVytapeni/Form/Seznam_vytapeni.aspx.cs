using System;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam_vytapeni : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsViewZpusobu_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridViewZpusobu.DataBind();
            GridViewZpusobu.SelectRow(-1);
        }

    }
}