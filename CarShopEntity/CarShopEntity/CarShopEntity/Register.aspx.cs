using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistr_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {                    //new user
                    Membership.CreateUser(txtName.Text, txtPassword.Text, txtEmail.Text);
                }
                catch (Exception ex)
                {
                    errorMessage.Text = ex.Message;
                    errorMessage.ForeColor = Color.Red;
                    return;
                }

                errorMessage.Text = "User registred successful!!";
                btRegistr.Enabled = false;
                FormsAuthentication.RedirectFromLoginPage(txtName.Text, false);
            }
        }        
    }
}