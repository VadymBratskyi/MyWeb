using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CarShopEntity.DB;
using CarShopEntity.ModelDB;
using Newtonsoft.Json;

namespace CarShopEntity.Handler
{
    /// <summary>
    /// Summary description for GetDataKendoList
    /// </summary>
    public class GetDataKendoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            var request = context.Request;

            var isCar = Convert.ToBoolean(request["isCar"]);
            var isType = Convert.ToBoolean(request["isType"]);
            var isModel = Convert.ToBoolean(request["isModel"]);
            var car = request["CarId"];
         

            if (isCar)
            {
                var listCar = GetDataForCarList();
                response.Write(new JavaScriptSerializer().Serialize(listCar));
            }

            if (isType)
            {
                Guid carId = Guid.Empty;
                Guid.TryParse(car, out carId);

                var listType = GetDataForTypesList(carId);
                response.Write(new JavaScriptSerializer().Serialize(listType));
            }

            if (isModel)
            {
               var listModel = GetDataForGrid(car);
                response.Write(new JavaScriptSerializer().Serialize(listModel));
            }
            
        }

        private List<Car> GetDataForCarList()
        {
            var dt = Repository.Select<Car>();

            var cars = dt.OrderBy(o => o.CarName).ToList();

            return cars;
        }

        private List<TypeCar> GetDataForTypesList(Guid carId)
        {
            var dt = Repository.Select<TypeCar>();
            var list = (from tp in dt
                            from cr in tp.Cars
                            where cr.Id == carId
                            select tp).ToList();

            return list;
        }

        private List<CarView> GetDataForGrid( string carId)
        {
            var dt = Repository.Select<ModelCar>().Include(o=>o.TypeCar);
            
            Guid Id = Guid.Empty;
            Guid.TryParse(carId, out Id);

            var cars = (from car in dt
                       where car.CarId == Id
                       orderby car.PositionIndex
                        select new CarView()
                       {
                           Id = car.Id.ToString(),
                           CarModel = car.ModelName,
                           Color = car.Color,
                           Engine = car.Engine.ToString(),
                           Fuel = car.Fuel,
                           Type = car.TypeCar,
                           IssueDate = car.IssueDate.ToString(),
                           ImgPath = car.ImgPath,
                           PositionIndex = car.PositionIndex
                       })
                       .ToList();

            return cars;
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