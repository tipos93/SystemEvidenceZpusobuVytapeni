using EZV.DataDecisionMaker;
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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected virtual void GetFactory(/*DecisionMaker.Items item*/)
        {
            //return (DecisionMaker.DecideSQL(item));
            DecisionMaker.getInstances();
        }
    }
}
