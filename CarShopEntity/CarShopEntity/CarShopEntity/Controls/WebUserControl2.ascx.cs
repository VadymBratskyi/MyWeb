using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity.Controls
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        public int Height
        {
            get { return (int)panel.Height.Value; }
            set { panel.Height = value; }
        }

        public int Width
        {
            get { return (int)panel.Width.Value; }
            set { panel.Width = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_OnClick(object sender, EventArgs e)
        {
            var str = calendar.SelectedDate.ToShortDateString();
            txtBox.Text = str;

        }

        protected void calendar_OnSelectionChanged(object sender, EventArgs e)
        {
            txtBox.Text = calendar.SelectedDate.ToShortDateString();
        }
    }
}