using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam_stavby_vlastnici : BasePage
    {
        IStavbaVlastnik stavbaVlastnik;
        Collection<StavbaVlastnik> stavbyVlastnici;
        StavbaVlastnik konkretniStavbaVlastnik = new StavbaVlastnik();

        IStavba stavba;
        IVlastnik vlastnik;

        Stavba konkretniStavba = new Stavba();

        Vlastnik konkretniVlastnik = new Vlastnik();

        public object ObjectMerger { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowUser();
            this.ControlMenuItems();
            this.GetFactory();

            if (Session["login"] == null)
            {
                Response.Redirect("~/Form/Login.aspx");
            }

            //stavbaVlastnik = (IStavbaVlastnik) this.GetFactory(DecisionMaker.Items.StavbaVlastnik);
            //stavba = (IStavba) this.GetFactory(DecisionMaker.Items.Stavba);
            //vlastnik = (IVlastnik) this.GetFactory(DecisionMaker.Items.Vlastnik);

            stavbaVlastnik = DecisionMaker.StavbaVlastnik.CreateStavbaVlastnik();
            stavba = DecisionMaker.Stavba.CreateStavba();
            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();

            stavbyVlastnici = stavbaVlastnik.Select();
            //stavby = stavba.Select();
            //vlastnici = vlastnik.Select();

            GridViewStavbyVlastnici.DataSource = this.nactiStavbyVlastniky();
            GridViewStavbyVlastnici.DataBind();
        }

        private List<object> nactiStavbyVlastniky()
        {
            List<object> list = new List<object>();

            foreach(StavbaVlastnik stavbaVlastnik in stavbyVlastnici)
            {
                konkretniStavba = stavba.Select_id(stavbaVlastnik.Id_stavby);
                konkretniVlastnik = vlastnik.Select_id(stavbaVlastnik.Id_vlastnika);
                object obj = new { konkretniStavba.Typ_stavby, konkretniStavba.Ulice, konkretniStavba.Cislo_popisne, konkretniVlastnik.Jmeno, konkretniVlastnik.Prijmeni, konkretniVlastnik.Datum_narozeni };
                list.Add(obj);
            }

            return list;
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewStavbyVlastnici.PageIndex = e.NewPageIndex;
            GridViewStavbyVlastnici.DataBind();
        }
    }
}