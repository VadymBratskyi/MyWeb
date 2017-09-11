using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarShopEntity.ModelDB;

namespace CarShopEntity.DB
{
    public class InitDb : DropCreateDatabaseIfModelChanges<CodeContext>
    {
        protected override void Seed(CodeContext context)
        {
            InitModels(context);
            base.Seed(context);
        }

        private void InitModels(CodeContext context)
        {
            var car1 = new Car() { Id = Guid.NewGuid(), CarName = "BMW" };
            var car2 = new Car() { Id = Guid.NewGuid(), CarName = "Audi" };
            var car3 = new Car() { Id = Guid.NewGuid(), CarName = "Chevrolet" };
            var car4 = new Car() { Id = Guid.NewGuid(), CarName = "Mersedes" };
            context.Cars.AddRange(new List<Car>() { car1, car2, car3, car4 });

            var typ1 = new TypeCar() { Id = Guid.NewGuid(), TypeName = "sedan" };
            var typ2 = new TypeCar() { Id = Guid.NewGuid(), TypeName = "suv" };
            var typ3 = new TypeCar() { Id = Guid.NewGuid(), TypeName = "coupe" };
            var typ4 = new TypeCar() { Id = Guid.NewGuid(), TypeName = "sport" };
            typ1.Cars.Add(car1);
            typ1.Cars.Add(car4);
            typ2.Cars.Add(car1);
            typ4.Cars.Add(car1);
            typ4.Cars.Add(car4);
            context.TypesCars.AddRange(new List<TypeCar>() { typ1, typ2, typ3, typ4 });

            var model1 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "x5", PositionIndex = 0.1, Color = "#FF0000", Engine = 4.8, Fuel = "benz", Price = 150.550m, ImgPath = "ImageSource/x5.jpg", IssueDate = new DateTime(), Car = car1};
            var model2 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "5", PositionIndex = 0.2, Color = "#0000FF", Engine = 3.0, Fuel = "benz", Price = 200.000m, ImgPath = "ImageSource/5.jpg", IssueDate = new DateTime(), Car = car1};
            var model3 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "m5", PositionIndex = 0.3, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/m5.jpg", IssueDate = new DateTime(), Car = car1};
            var model4 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "sls", PositionIndex = 0.1, Color = "#008000", Engine = 5.0, Fuel = "duz", Price = 700.000m, ImgPath = "ImageSource/sls.jpg", IssueDate = new DateTime(), Car = car4};
            var model5 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "530", PositionIndex = 0.4, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/530.jpg", IssueDate = new DateTime(), Car = car1};
            var model6 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "320", PositionIndex = 0.5, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/320.jpg", IssueDate = new DateTime(), Car = car1 };
            var model7 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "m3", PositionIndex = 0.6, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/m3.jpg", IssueDate = new DateTime(), Car = car1 };
            var model8 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "m4", PositionIndex = 0.7, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/m4.jpg", IssueDate = new DateTime(), Car = car1 };
            var model9 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "328", PositionIndex = 0.8, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/328.jpg", IssueDate = new DateTime(), Car = car1 };
            var model10 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "318", PositionIndex = 0.9, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/318.jpg", IssueDate = new DateTime(), Car = car1 };
            var model11 = new ModelCar() { Id = Guid.NewGuid(), ModelName = "mx5", PositionIndex = 0.10, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/mx5.jpg", IssueDate = new DateTime(), Car = car1 };
            var model12= new ModelCar() { Id = Guid.NewGuid(), ModelName = "x6", PositionIndex = 0.11, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/x6.jpg", IssueDate = new DateTime(), Car = car1 };
            var model13= new ModelCar() { Id = Guid.NewGuid(), ModelName = "mx6", PositionIndex = 0.12, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/mx6.jpg", IssueDate = new DateTime(), Car = car1 };
            var model14= new ModelCar() { Id = Guid.NewGuid(), ModelName = "i8", PositionIndex = 0.13, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/i8.jpg", IssueDate = new DateTime(), Car = car1 };
            var model15= new ModelCar() { Id = Guid.NewGuid(), ModelName = "440", PositionIndex = 0.14, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/440.jpg", IssueDate = new DateTime(), Car = car1 };
            var model16= new ModelCar() { Id = Guid.NewGuid(), ModelName = "m6", PositionIndex = 0.15, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/m6.jpg", IssueDate = new DateTime(), Car = car1 };
            var model17= new ModelCar() { Id = Guid.NewGuid(), ModelName = "630", PositionIndex = 0.16, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/630.jpg", IssueDate = new DateTime(), Car = car1 };
            var model18= new ModelCar() { Id = Guid.NewGuid(), ModelName = "430", PositionIndex = 0.17, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/430.jpg", IssueDate = new DateTime(), Car = car1 };
            var model19= new ModelCar() { Id = Guid.NewGuid(), ModelName = "750", PositionIndex = 0.18, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/750.jpg", IssueDate = new DateTime(), Car = car1 };
            var model20= new ModelCar() { Id = Guid.NewGuid(), ModelName = "730", PositionIndex = 0.19, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/730.jpg", IssueDate = new DateTime(), Car = car1 };
            var model21= new ModelCar() { Id = Guid.NewGuid(), ModelName = "520i", PositionIndex = 0.20, Color = "#000000", Engine = 2.5, Fuel = "benz", Price = 400.500m, ImgPath = "ImageSource/520i.jpg", IssueDate = new DateTime(), Car = car1 };
             context.ModelsCars.AddRange(new List<ModelCar>()
             {
                 model1, model2, model3, model4, model5, model6, model7, model8, model9, model10, model11, model12, model13, model14, model15, model16, model17, model18, model19
                 , model20, model21
             });

            context.SaveChanges();
        }
    }
}