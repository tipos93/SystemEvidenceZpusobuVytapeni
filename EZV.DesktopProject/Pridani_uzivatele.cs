using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EZV.DesktopProject
{
    public partial class Pridani_uzivatele : BaseForm
    {
        IUzivatele uzivatele;
        IVlastnik vlastnik;

        Uzivatele konkretniUzivatele = new Uzivatele();

        public Pridani_uzivatele()
        {
            InitializeComponent();
            this.GetFactory();
            uzivatele = DecisionMaker.Uzivatele.CreateUzivatele();
            vlastnik = DecisionMaker.Vlastnik.CreateVlastnik();
            this.NacitaniListBoxu();
            UspesnostPridani.Visible = false;
        }

        private void NacitaniListBoxu()
        {
            Dictionary<int, string> vlastnici1 = new Dictionary<int, string>();
            vlastnici1.Add(-9999, " ");

            Dictionary<int, string> vlastnici = vlastnik.Select().ToDictionary(v => v.Id_vlastnika, v => v.Jmeno + " " + v.Prijmeni + " " + v.Rodne_cislo);

            Dictionary<string, string> postaveni = new Dictionary<string, string>();
            postaveni.Add(" ", " ");
            postaveni.Add("vlastnik", "vlastník");
            postaveni.Add("obec", "člen zastupitelstva obce");
            postaveni.Add("komise", "člen kontrolní komise");
            postaveni.Add("ministerstvo", "člen ministerstva průmyslu a obchodu");

            Dictionary<string, string> aktualnost = new Dictionary<string, string>();
            aktualnost.Add(" ", " ");
            aktualnost.Add("A", "Ano");
            aktualnost.Add("N", "Ne");

            VlastniciList.DataSource = new BindingSource(vlastnici1.Concat(vlastnici), null);
            VlastniciList.DisplayMember = "Value";
            VlastniciList.ValueMember = "Key";

            PostaveniList.DataSource = new BindingSource(postaveni, null);
            PostaveniList.DisplayMember = "Value";
            PostaveniList.ValueMember = "Key";

            AktualnostList.DataSource = new BindingSource(aktualnost, null);
            AktualnostList.DisplayMember = "Value";
            AktualnostList.ValueMember = "Key";
        }

        private void VlozeniButton_Click(object sender, EventArgs e)
        {
            UspesnostPridani.Visible = true;

            try
            {
                konkretniUzivatele.Id_vlastnika = int.Parse(VlastniciList.SelectedValue.ToString());
                konkretniUzivatele.Postaveni = PostaveniList.SelectedValue.ToString();
                konkretniUzivatele.Login = LoginText.Text.ToString();
                konkretniUzivatele.Heslo = HesloText1.Text.ToString();
                konkretniUzivatele.Aktualnost = AktualnostList.SelectedValue.ToString();

                uzivatele.Insert(konkretniUzivatele);

                UspesnostPridani.Text = "Úspěšné vložení stavby!";
            }
            catch
            {
                UspesnostPridani.Text = "Nepovedlo se úspěšně vložit stavbu!";
            }

            VlastniciList.SelectedValue = -9999;
            PostaveniList.SelectedValue = " ";
            LoginText.Text = " ";
            HesloText1.Text = " ";
            AktualnostList.SelectedValue = " ";
        }
    }
}
