using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarShopEntity.DB;

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

        [WebMethod]
        public static void SaveDate(List<CarView> items, List<Guid> removeItems)
        {

            var datas = items.Where(o => o.IsChanche).ToList();

            try
            {
                var db = new CodeContext();

                if (datas.Count > 0)
                {
                    foreach (var carView in datas)
                    {
                        var doc = db.ModelsCars.Find(Guid.Parse(carView.Id));
                        doc.PositionIndex = carView.PositionIndex;

                        if (carView.Type != null)
                        {
                            var tp = db.TypesCars.Find(carView.Type.Id);
                            doc.TypeCar = tp;
                        }
                    }
                    db.SaveChanges();
                }

                if (removeItems.Count > 0)
                {
                    foreach (var rItem in removeItems)
                    {
                        var scan = db.ModelsCars.Find(rItem);
                        if (scan != null) db.ModelsCars.Remove(scan);
                    }
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
