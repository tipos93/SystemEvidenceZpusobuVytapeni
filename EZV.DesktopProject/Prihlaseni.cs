using EZV.DAO;
using EZV.DAOFactory;
using EZV.DataDecisionMaker;
using EZV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZV.DesktopProject
{
    public partial class Prihlaseni : BaseForm
    {
        IUzivatele uzivatele;
        Uzivatele konkretniUzivatele = new Uzivatele();

        public Prihlaseni()
        {
            InitializeComponent();
            this.GetFactory();
            uzivatele = DecisionMaker.Uzivatele.CreateUzivatele();
        }

        private void Prihlaseni_Click(object sender, EventArgs e)
        {
            konkretniUzivatele = uzivatele.Select_id(JmenoText.Text.ToString());

            if(konkretniUzivatele.Postaveni.Equals("obec"))
            {
                if (konkretniUzivatele.Heslo.Equals(HesloText.Text.ToString()))
                {
                    Pridani_uzivatele pridani = new Pridani_uzivatele();
                    this.Hide();
                    pridani.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                Neuspech.Visible = true;
                Neuspech.Text = "Nepovedlo se přihlášení do systému!";
            }
        }
    }
}
