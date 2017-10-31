using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CarShopEntity
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogIn_Click(object sender, EventArgs e)
        {
            errorLogMss.Text = string.Empty;
            if (logTxt.Text == "admin" && passTxt.Text == "123")
            {
                FormsAuthentication.RedirectFromLoginPage(logTxt.Text, true);                

            }
            else
            {
                errorLogMss.Text = "Errror";
            }
        }

        protected void btLogIn_Click1(object sender, EventArgs e)
        {
            bool isUsUsere = Membership.ValidateUser(logTxt.Text, passTxt.Text);
            if (isUsUsere)
            {
                FormsAuthentication.RedirectFromLoginPage(logTxt.Text, false);
            }
            else
            {
                errorLogMss.Text = "Error login";
            }
        }
    }
}