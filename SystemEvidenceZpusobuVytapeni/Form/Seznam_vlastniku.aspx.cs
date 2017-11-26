using System;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam_vlastniku : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsViewVlastnici_ItemUpdated(object sender, System.Web.UI.WebControls.DetailsViewUpdatedEventArgs e)
        {
            GridViewVlastnici.DataBind();
            GridViewVlastnici.SelectRow(-1);
        }
    }
}