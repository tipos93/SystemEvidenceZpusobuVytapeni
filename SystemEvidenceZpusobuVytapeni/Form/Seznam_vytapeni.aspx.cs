using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class Seznam_vytapeni : BasePage
    {
        IZpusob_vytapeni zpusob;
        IStavba stavba;
        IStavbaVlastnik stavbaVlastnik;
        Collection<Zpusob_vytapeni> zpusoby;

        Zpusob_vytapeni konkretniZpusob = new Zpusob_vytapeni();
        Stavba konkretniStavba = new Stavba();
        Collection<StavbaVlastnik> konkretniStavbyVlastnici = new Collection<StavbaVlastnik>();
        int stavbaId;
        string zpusobTyp;
        List<object> stavbyZpusoby = new List<object>();

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
            //zpusob = (IZpusob_vytapeni)this.GetFactory(DecisionMaker.Items.Zpusob);
            //stavba = (IStavba)this.GetFactory(DecisionMaker.Items.Stavba);
            zpusob = DecisionMaker.Zpusob.CreateZpusob();
            stavba = DecisionMaker.Stavba.CreateStavba();

            zpusoby = zpusob.Select();

            if (Session["postaveni"].Equals("vlastnik"))
            {
                stavbaVlastnik = DecisionMaker.StavbaVlastnik.CreateStavbaVlastnik();
                konkretniStavbyVlastnici = stavbaVlastnik.Select();
                int idVlastnika = int.Parse(Session["id_vlastnika"].ToString());
                Collection<Zpusob_vytapeni> zpusobyVlastnik = new Collection<Zpusob_vytapeni>();

                foreach (StavbaVlastnik sv in konkretniStavbyVlastnici)
                {
                    if (sv.Id_vlastnika == idVlastnika)
                    {
                        foreach(Zpusob_vytapeni zp in zpusoby)
                        {
                            if(zp.Id_stavby == sv.Id_stavby)
                                zpusobyVlastnik.Add(zp);
                        }
                    }
                }
                zpusoby.Clear();
                zpusoby = zpusobyVlastnik;
            }

            this.nactiStavbyZpusoby();

            GridViewZpusobu.DataSource = stavbyZpusoby;
            GridViewZpusobu.DataBind();
        }

        private void nactiStavbyZpusoby()
        {
            foreach (Zpusob_vytapeni zpusobV in zpusoby)
            {
                konkretniStavba = stavba.Select_id(zpusobV.Id_stavby);
                object stavbaZpusob = new { konkretniStavba.Id_stavby, konkretniStavba.Typ_stavby, konkretniStavba.Ulice, konkretniStavba.Cislo_popisne, zpusobV.Typ_vytapeni, zpusobV.Platnost_od, zpusobV.Platnost_do };
                stavbyZpusoby.Add(stavbaZpusob);
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewZpusobu.PageIndex = e.NewPageIndex;
            GridViewZpusobu.DataBind();
        }

        protected void btnVybrat_Click(object sender, EventArgs e)
        {
            Literal stavbaLiteral = (sender as Button).NamingContainer.FindControl("ltrIdStavby") as Literal;
            Literal zpusobLiteral = (sender as Button).NamingContainer.FindControl("ltrTypVytapeni") as Literal;

            if (stavbaLiteral != null && zpusobLiteral != null)
            {
                int.TryParse(stavbaLiteral.Text.ToString(), out stavbaId);
                zpusobTyp = zpusobLiteral.Text.ToString();
            }
            else
            {
                stavbaId = -1;
                zpusobTyp = "";
            }

            konkretniZpusob = zpusob.Select_id(stavbaId, zpusobTyp);
            konkretniStavba = stavba.Select_id(konkretniZpusob.Id_stavby);
            object stavbaZpusob = new { konkretniStavba.Id_stavby, konkretniStavba.Typ_stavby, konkretniStavba.Ulice, konkretniStavba.Cislo_popisne, konkretniZpusob.Typ_vytapeni, konkretniZpusob.Platnost_od, konkretniZpusob.Platnost_do };
            stavbyZpusoby.Clear();
            stavbyZpusoby.Add(stavbaZpusob);
            DetailsViewZpusobu.DataSource = stavbyZpusoby;
            DetailsViewZpusobu.DataBind();
        }
    }
}