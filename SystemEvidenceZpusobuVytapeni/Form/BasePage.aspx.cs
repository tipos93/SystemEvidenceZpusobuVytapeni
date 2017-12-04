using EZV.DataDecisionMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemEvidenceZpusobuVytapeni.Form
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected virtual void GetFactory(/*DecisionMaker.Items item*/)
        {
            //return (DecisionMaker.DecideSQL(item));
            DecisionMaker.getInstances();
        }
    }
}