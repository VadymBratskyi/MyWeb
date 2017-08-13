using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity
{
    public partial class TypeCarsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            ddPrinters.DataSource = new List<string>() { "Printer_1", "Printer_2" };
            ddPrinters.DataBind();
        }
    }
}