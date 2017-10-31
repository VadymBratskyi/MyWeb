using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity.Controls
{
    public partial class ControlObj : System.Web.UI.UserControl
    {
        public Person DataItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lb1.Text = DataItem.FirstName;
            lb2.Text = DataItem.LastName;
            lb3.Text = DataItem.MiddleName;
        }
    }
}