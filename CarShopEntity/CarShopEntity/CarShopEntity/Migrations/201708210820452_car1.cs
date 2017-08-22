namespace CarShopEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateTimeOrder = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Car_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Phone = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeCars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelCars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModelName = c.String(nullable: false, maxLength: 50),
                        CarId = c.Guid(),
                        TypeCarId = c.Guid(),
                        ImgPath = c.String(),
                        Color = c.String(),
                        Engine = c.Double(nullable: false),
                        IssueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Fuel = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.TypeCars", t => t.TypeCarId)
                .Index(t => t.CarId)
                .Index(t => t.TypeCarId);
            
            CreateTable(
                "dbo.ClientOrders",
                c => new
                    {
                        Client_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Order_Id })
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.TypeCarCars",
                c => new
                    {
                        TypeCar_Id = c.Guid(nullable: false),
                        Car_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeCar_Id, t.Car_Id })
                .ForeignKey("dbo.TypeCars", t => t.TypeCar_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .Index(t => t.TypeCar_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelCars", "TypeCarId", "dbo.TypeCars");
            DropForeignKey("dbo.ModelCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.TypeCarCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.TypeCarCars", "TypeCar_Id", "dbo.TypeCars");
            DropForeignKey("dbo.ClientOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ClientOrders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Orders", "Car_Id", "dbo.Cars");
            DropIndex("dbo.TypeCarCars", new[] { "Car_Id" });
            DropIndex("dbo.TypeCarCars", new[] { "TypeCar_Id" });
            DropIndex("dbo.ClientOrders", new[] { "Order_Id" });
            DropIndex("dbo.ClientOrders", new[] { "Client_Id" });
            DropIndex("dbo.ModelCars", new[] { "TypeCarId" });
            DropIndex("dbo.ModelCars", new[] { "CarId" });
            DropIndex("dbo.Orders", new[] { "Car_Id" });
            DropTable("dbo.TypeCarCars");
            DropTable("dbo.ClientOrders");
            DropTable("dbo.ModelCars");
            DropTable("dbo.TypeCars");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
        }
    }
}
