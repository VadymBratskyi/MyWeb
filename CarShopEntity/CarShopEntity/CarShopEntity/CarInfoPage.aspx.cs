using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarShopEntity.DB;
using CarShopEntity.ModelDB;

namespace CarShopEntity
{
    public partial class CarInfoPage : System.Web.UI.Page
    {
        public string CarName { get; set; }
        public string CarModel { get; set; }

        public Guid? CarId { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            var value = Request["carId"];
            var id = Guid.Empty;

            if (Guid.TryParse(value, out id))
            {
                CarId = id;
                LoadDate(id);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadDate(Guid id)
        {
            var car = Repository.Select<ModelCar>().Include(o=>o.Car).Include(o=>o.TypeCar).FirstOrDefault(o=>o.Id == id);

            if (car == null)
            {
                throw new Exception("car is not found!");
            }
            else
            {
                CarName = car.Car.CarName;
                CarModel = car.ModelName;
                lbType.Text = car.TypeCar!=null ? car.TypeCar.TypeName :string.Empty;
                lbEng.Text = car.Engine.ToString();
                lbPrice.Text = car.Price.ToString();
                lbFuel.Text = car.Fuel;
                lbColor.Text = car.Color;
                lbdate.Text = car.IssueDate.ToLongDateString();
                imgCar.ImageUrl = car.ImgPath;
            }

            

        }

        protected void btnDelite_OnClick(object sender, EventArgs e)
        {
            CodeContext db = new CodeContext();

                try
                {
                    db.Cars.Load();
                    db.TypesCars.Load();
                    db.ModelsCars.Load();

                    var modal = db.ModelsCars.Find(CarId);
                    db.Cars.Remove(modal.Car);
                    db.TypesCars.Remove(modal.TypeCar);
                    db.ModelsCars.Remove(modal);
                    db.SaveChanges();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                Response.RedirectToRoute("Carpage");

         }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CarEditPage.aspx?carId="+CarId);
        }
    }
}