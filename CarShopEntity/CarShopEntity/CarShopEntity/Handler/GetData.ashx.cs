using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using CarShopEntity.DB;
using CarShopEntity.ModelDB;
using Newtonsoft.Json;

namespace CarShopEntity.Handler
{
    /// <summary>
    /// Summary description for GetData
    /// </summary>
    public class GetData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            var request = context.Request;

            var pageSize = Convert.ToInt32(request["rows"]);
            var pageNumber = Convert.ToInt32(request["page"]);
            var sortColumnName = request["sidx"];
            var sortOrderBy = request["sord"];
            var lastpage = int.Parse(request["lastpage"]);
            int total;


            if (lastpage < pageNumber && lastpage!=0)
            {
                pageNumber = lastpage;
            }

            var listCar = GetDataForGrid(ref pageNumber, pageSize, sortColumnName, sortOrderBy);

            var output = BuildJqGridResults(listCar,pageSize, pageNumber);

            response.Write(output);
        }

        private List<CarView> GetDataForGrid(ref int pageNumber, int pageSize, string sortColumnName, string sortOrderBy)
        {
            var dt = Repository.Select<ModelCar>().Include(o => o.Car).Include(o => o.TypeCar);

            var cars = (from car in dt
                select new CarView()
                {
                    CarName = car.Car.CarName,
                    CarModel = car.ModelName,
                    CarType = car.TypeCar.TypeName,
                    Color = car.Color,
                    Engine = car.Engine.ToString(),
                    Fuel = car.Fuel,
                    IssueDate = car.IssueDate.ToString(),
                    ImgPath = car.ImgPath
                }).ToList();

            if (pageNumber > 1)
            {
                cars.Skip(pageSize * (pageNumber - 1));
            }
            

            if (!cars.Any() && pageNumber > 1)
            {
                pageNumber = 1;
                cars = GetDataForGrid(ref pageNumber, pageSize, sortColumnName, sortOrderBy);
            }

            return cars.ToList();
        }


        private string BuildJqGridResults(List<CarView> cars, int pageSize, int pageNumber)
        {
            int i = 1;
            var result = new JqGridResult();
            var rows = new List<JqGridRow>();

            if (cars!=null)
            {
                foreach (var car in cars)
                {
                    var row = new JqGridRow();
                    row.cell = new string[8];
                    row.id = i++;
                    row.cell[0] = car.CarName;
                    row.cell[1] = car.CarModel;
                    row.cell[2] = car.CarType;
                    row.cell[3] = car.Color;
                    row.cell[4] = car.Engine;
                    row.cell[5] = car.Fuel;
                    row.cell[6] = car.IssueDate;
                    row.cell[7] = car.ImgPath;
                    rows.Add(row);
                }
                var totalRecords = cars.Count;
                result.rows = rows.ToArray();
                result.page = pageNumber;
                result.total = (totalRecords + pageSize - 1) / pageSize;
                if (totalRecords == 0)
                {
                    result.total = 1; //no result? -> page 1/1
                }
                result.records = totalRecords;
            }
            return JsonConvert.SerializeObject(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}