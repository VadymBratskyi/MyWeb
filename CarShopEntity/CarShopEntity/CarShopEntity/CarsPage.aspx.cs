using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarShopEntity.DB;
using CarShopEntity.ModelDB;

namespace CarShopEntity
{
    public partial class CarsPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Write("Thread="+Thread.CurrentThread.ManagedThreadId);
            PageAsyncTask task = new PageAsyncTask(GetDatas);
            RegisterAsyncTask(task);

        }

        private async Task GetDatas()
        {
            await Task.Run(() =>
            {
                var data = Repository.Select<ModelCar>().Include(o => o.Car).Include(o => o.TypeCar);
                lbRowtable.Text = GetRowForTable(data);
                LoadControlsList();
            });
        }


        private void LoadControlsList()
        {
            var dataCars = Repository.Select<Car>().ToList();
            var dataTypes = Repository.Select<TypeCar>().ToList();

            chСarslist.DataSource = dataCars;
            chСarslist.DataTextField = "CarName";
            chСarslist.DataValueField = "Id";
            chСarslist.DataBind();

            chTipelist.DataSource = dataTypes;
            chTipelist.DataTextField = "TypeName";
            chTipelist.DataValueField = "Id";
            chTipelist.DataBind();


            ddNamecar.DataSource = dataCars;
            ddNamecar.DataValueField = "Id";
            ddNamecar.DataTextField = "CarName";
            ddNamecar.DataBind();
            
            var tp = new List<TypeCar>();
            tp.Add(new TypeCar() { Id = Guid.Empty, TypeName = "" });
            tp.AddRange(dataTypes);

            ddType.DataSource = tp;
            ddType.DataValueField = "Id";
            ddType.DataTextField = "TypeName";
            ddType.DataBind();
        }

        public string GetRowForTable(IEnumerable<ModelCar> repository)
        {
            var tr = new StringBuilder();

            foreach (var dbModelsCar in repository )
            {
                var crv = new CarView()
                {
                    CarName = dbModelsCar.Car!= null ? dbModelsCar.Car.CarName : "",
                    CarModel = dbModelsCar.ModelName,
                    CarType = dbModelsCar.TypeCar != null ? dbModelsCar.TypeCar.TypeName : "",
                    Engine = dbModelsCar.Engine.ToString(),
                    IssueDate = dbModelsCar.IssueDate.ToShortDateString(),
                    Fuel = dbModelsCar.Fuel,
                    Color = dbModelsCar.Color
                };

                tr.Append(string.Format("<tr>" +
                                        "<td><img src='{0}' width='250px' height='200px'</td>" +
                                        "<td>{1}</td>" +
                                        "<td class='tdPrice'>{2}</td>" +
                                        "<td>" +
                                        "<div class='btn-group-vertical btngroup'>" +
                                        "<Input type='button' class='btn btn-info' onclick=" + "shovInfo('{3}');" + " value='Подробнее'>" +
                                        "<Input type='button' class='btn btn-warning' onclick=" + "shovEdit('{3}');" + "  value='Редактировать'>" +
                                        "<Input type='button' class='btn btn-danger' onclick=" + "shovDelete('{3}');" + " value='Удалить'>" +
                                        "</div>" +
                                        "</td>" +
                                        "</tr>"
                    , dbModelsCar.ImgPath,
                    GetTable(crv),
                    dbModelsCar.Price, dbModelsCar.Id));
            }

            return tr.ToString();
        }

        public string GetTable(CarView cr)
        {
            return (string.Format("<table class='tabInfo'>" +
                                  "<tr>" +
                                  "<th>Название:</th>" +
                                  "<th>Двигатель:</th>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<td>{0}</td>" +
                                  "<td>{1}</td>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<th>Модель:</th>" +
                                  "<th>Топливо:</th>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<td>{2}</td>" +
                                  "<td>{3}</td>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<th>Тип:</th>" +
                                  "<th>Дата выпуска:</th>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<td>{4}</td>" +
                                  "<td>{5}</td>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<th>Цвет:</th>" +
                                  "<th></th>" +
                                  "</tr>" +
                                  "<tr>" +
                                  "<td>{6}</td>" +
                                  "<td></td>" +
                                  "</tr>" +
                                  "</table>"
                , cr.CarName, cr.Engine
                , cr.CarModel, cr.Fuel
                , cr.CarType, cr.IssueDate
                , cr.Color
            ));

        }


        protected void OnClick(object sender, EventArgs e)
        {
            var searchField = tbSearch.Text;
        }



        [System.Web.Services.WebMethod]
        public static string DeleteCar(string carId)
        {
            var modId = Guid.Parse(carId);
            CodeContext db = new CodeContext();

            try
            {
                db.ModelsCars.Load();

                var modal = db.ModelsCars.Find(modId);
                db.ModelsCars.Remove(modal);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return "success";
        }

        protected void btSearchSecond_OnClick(object sender, EventArgs e)
        {
            var query = Repository.Select<ModelCar>().Include(o => o.Car).Include(o => o.TypeCar);

            var filter = new FilterView()
            {
                CarsChekList = chСarslist.Items.Cast<ListItem>().Where(o => o.Selected),
                TypesChekList = chTipelist.Items.Cast<ListItem>().Where(o => o.Selected),
                EngFrom = engFrom.Text != String.Empty ? Convert.ToInt32(engFrom.Text) : 0,
                EngTo = engTo.Text != String.Empty ? Convert.ToInt32(engTo.Text) : 0,
                PriceFrom = hdPriceFrom.Value!=""?Convert.ToDecimal(hdPriceFrom.Value): 0,
                PriceTo = hdPriceTo.Value!=""?Convert.ToDecimal(hdPriceTo.Value):0
            };

           if (filter.CarsChekList.Any())
            {
                query.Where(o => filter.GetCarId.Contains((Guid) o.CarId));
            }
            if (filter.TypesChekList.Any())
            {
                query.Where(o => filter.GetTypeId.Contains((Guid)o.TypeCarId));
            }

            if (filter.EngFrom != 0)
            {
                query.Where(o => o.Engine >= filter.EngFrom);
            }
            if (filter.EngTo != 0)
            {
                query.Where(o => o.Engine <= filter.EngTo);
            }

            if (filter.PriceFrom != 0)
            {
                query.Where(o => o.Price >= filter.PriceFrom);
            }
            if (filter.PriceTo != 0)
            {
                query.Where(o => o.Price <= filter.PriceTo);
            }
            lbRowtable.Text = GetRowForTable(query);
        }

        protected void btSub_OnClick(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }
            var folder = "ImageSource";
            var name = Guid.NewGuid().ToString().Substring(0, 5) + loadimg.FileName;
            var path = Path.Combine(Server.MapPath(folder), name);
            loadimg.SaveAs(path);

            var context = new CodeContext();

            var idCar = Guid.Parse(ddNamecar.SelectedValue);
            var idType = Guid.Parse(ddType.SelectedValue);

            var model1 = new ModelCar()
            {
                Id = Guid.NewGuid(),
                ModelName = tbModelCar.Text,
                Color = tbColor.Text,
                Engine = Convert.ToDouble(tbEngine.Text),
                Fuel = tbFuel.Text,
                Price = Convert.ToDecimal(tbPrice.Text),
                ImgPath = folder + "/" + name,
                IssueDate = Convert.ToDateTime(tbDateIssue.Text),
                Car = context.Cars.Find(idCar),
                TypeCar = idType!=Guid.Empty ? context.TypesCars.Find(idType) : null
            };
            context.ModelsCars.Add(model1);

            context.SaveChanges();

            Response.Redirect(Request.Url.PathAndQuery);
        }
    }

    public class FilterView
    {
        public IEnumerable<ListItem> CarsChekList { get; set; }
        public IEnumerable<ListItem> TypesChekList { get; set; }
        public int EngFrom { get; set; }
        public int EngTo { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public List<Guid> GetCarId {
            get
            {
                var g = new List<Guid>();
                foreach (var listItem in CarsChekList)
                {
                    g.Add(Guid.Parse(listItem.Value));
                }
                return g;
            }
        }

        public List<Guid> GetTypeId
        {
            get
            {
                var g = new List<Guid>();
                foreach (var listItem in TypesChekList)
                {
                    g.Add(Guid.Parse(listItem.Value));
                }
                return g;
            }
        }
    }

    public class CarView
    {
        public string Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarType { get; set; }
        public TypeCar Type { get; set; }
        public string Engine { get; set; }
        public string IssueDate { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public string ImgPath { get; set; }
        public double PositionIndex { get; set; }
        public bool IsChanche { get; set; }

    }
}