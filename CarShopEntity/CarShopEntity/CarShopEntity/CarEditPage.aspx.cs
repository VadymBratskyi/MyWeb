using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarShopEntity.DB;
using CarShopEntity.ModelDB;

namespace CarShopEntity
{
    public partial class CarEditPage : System.Web.UI.Page
    {
        public Guid? CarId { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            var value = Request["carId"];
            var id = Guid.Empty;

            if (Guid.TryParse(value, out id))
            {
                CarId = id;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            LoadControl();
        }

        private void LoadControl()
        {
            var repos = Repository.Select<ModelCar>().Include(o => o.Car).Include(o => o.TypeCar).SingleOrDefault(o=>o.Id == CarId);
            var cars = Repository.Select<Car>();
            var types = Repository.Select<TypeCar>();


            tbModelCar.Text = repos.ModelName;
            tbEng.Text = repos.Engine.ToString();
            tbFuel.Text = repos.Fuel;
            tbPrice.Text = ((int)repos.Price).ToString();

            tbDate.Text = repos.IssueDate.ToString("yyyy-MM-dd");
            
            tbColor.Text = repos.Color;

            imgCar.ImageUrl = repos.ImgPath;

            dbNamecar.DataSource = cars.ToList();
            dbNamecar.DataValueField = "Id";
            dbNamecar.DataTextField = "CarName";
            dbNamecar.DataBind();
            dbNamecar.SelectedIndex = dbNamecar.Items.IndexOf(dbNamecar.Items.FindByValue(repos.CarId.ToString()));

            var tp = new List<TypeCar>();
            tp.Add(new TypeCar() { Id = Guid.Empty, TypeName = "" });
            tp.AddRange(types);

            dbType.DataSource = tp;
            dbType.DataValueField = "Id";
            dbType.DataTextField = "TypeName";
            dbType.DataBind();
            dbType.SelectedIndex = dbType.Items.IndexOf(dbType.Items.FindByValue(repos.TypeCarId.ToString()));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            CodeContext code = new CodeContext();
            code.Cars.Load();
            code.TypesCars.Load();
            code.ModelsCars.Load();

            var folder = "ImageSource";
            var name = Guid.NewGuid().ToString().Substring(0, 5) + imgLoader.FileName;
            var path = Path.Combine(Server.MapPath(folder), name);
            imgLoader.SaveAs(path);

            var idCar = Guid.Parse(dbNamecar.SelectedValue);
            var idType = Guid.Parse(dbType.SelectedValue);

            var model = code.ModelsCars.Find(CarId);
            if (model!=null)
            {
                model.Car = code.Cars.Find(idCar);
                model.ModelName = tbModelCar.Text;
                model.Color = tbColor.Text;
                model.IssueDate = Convert.ToDateTime(tbDate.Text);
                model.Engine = Convert.ToDouble(tbEng.Text);
                if (imgLoader.FileName != "")
                {
                    model.ImgPath = folder + "/" + name;
                }
                model.Fuel = tbFuel.Text;
                model.Price = Convert.ToDecimal(tbPrice.Text);
                model.TypeCar = idType != Guid.Empty ? code.TypesCars.Find(idType) : null;

                code.SaveChanges();
            }

            Response.RedirectToRoute("Carpage");

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Carpage");
        }
    }
}