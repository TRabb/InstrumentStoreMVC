using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InstrumentStoreMVC.Models;

namespace InstrumentStoreMVC.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{FirstName="Thomas", LastName="Train", Age=23, Email="trainboy@gmail.com", Phone="231-959-2857" },
                new Customer{FirstName="Joe", LastName="Pepper", Age=18, Email="pepper4life@gmail.com", Phone="231-194-1028" },
                new Customer{FirstName="Vince", LastName="Stapler", Age=59, Email="godspeed492@gmail.com", Phone="402-143-1040" },
                new Customer{FirstName="George", LastName="Monkey", Age=20, Email="actuallyamonkey@gmail.com", Phone="100-422-8592" },
                new Customer{FirstName="Mountain", LastName="Man", Age=38, Email="iliketohike@gmail.com", Phone="940-929-5727" },
                new Customer{FirstName="Old", LastName="Greg", Age=90, Email="imanoldman@gmail.com", Phone="455-140-1849" },
                new Customer{FirstName="Bettle", LastName="Boy", Age=27, Email="bugsarefriends@gmail.com", Phone="492-0091-992" },
                new Customer{FirstName="Zach", LastName="Willow", Age=57, Email="willowtree@gmail.com", Phone="293-399-1299" }
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var instruments = new List<Instrument>
            {
                new Instrument{InstrumentName="Trumpet", Price=250},
                new Instrument{InstrumentName="Saxophone", Price=300},
                new Instrument{InstrumentName="Trombone", Price=500},
                new Instrument{InstrumentName="Kazoo", Price=25},
                new Instrument{InstrumentName="Flute", Price=350},
                new Instrument{InstrumentName="Snare Drum", Price=400},
                new Instrument{InstrumentName="Bass Drum", Price=500},
                new Instrument{InstrumentName="Clarinet", Price=400}
            };
            instruments.ForEach(i => context.Instruments.Add(i));
            context.SaveChanges();

            var storeDetails = new List<StoreDetail>
            {
                new StoreDetail{State="MI", City="Traverse City", Zip=49686, Phone="493-249-2948"},
                new StoreDetail{State="WI", City="Madison", Zip=49686, Phone="203-487-4289"},
                new StoreDetail{State="OH", City="Columbus", Zip=49686, Phone="134-039-3877"},
                new StoreDetail{State="CA", City="San Fransico", Zip=49686, Phone="943-918-9933"},
                new StoreDetail{State="TX", City="Houston", Zip=49686, Phone="392-499-2911"},
                new StoreDetail{State="ME", City="Portland", Zip=49686, Phone="593-299-9290"},
                new StoreDetail{State="FL", City="Miami", Zip=49686, Phone="933-302-9488"},
                new StoreDetail{State="ND", City="Fargo", Zip=49686, Phone="234-382-8884"}
            };
            storeDetails.ForEach(sd => context.StoreDetails.Add(sd));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{DateOrdered=DateTime.Parse("2020-2-13"), Quantity=1, CustomerID=1, StoreID=1},
                new Order{DateOrdered=DateTime.Parse("2020-2-12"), Quantity=10, CustomerID=2, StoreID=2},
                new Order{DateOrdered=DateTime.Parse("2020-2-11"), Quantity=2, CustomerID=3, StoreID=3},
                new Order{DateOrdered=DateTime.Parse("2020-2-2"), Quantity=5, CustomerID=4, StoreID=4},
                new Order{DateOrdered=DateTime.Parse("2020-1-20"), Quantity=1, CustomerID=5, StoreID=5},
                new Order{DateOrdered=DateTime.Parse("2020-1-12"), Quantity=2, CustomerID=6, StoreID=6},
                new Order{DateOrdered=DateTime.Parse("2020-2-7"), Quantity=1, CustomerID=7, StoreID=7},
                new Order{DateOrdered=DateTime.Parse("2020-2-1"), Quantity=8, CustomerID=8, StoreID=8}
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail{OrderID=1, StoreID=1, InstrumentID=1},
                new OrderDetail{OrderID=2, StoreID=2, InstrumentID=2},
                new OrderDetail{OrderID=3, StoreID=3, InstrumentID=3},
                new OrderDetail{OrderID=4, StoreID=4, InstrumentID=4},
                new OrderDetail{OrderID=5, StoreID=5, InstrumentID=5},
                new OrderDetail{OrderID=6, StoreID=6, InstrumentID=6},
                new OrderDetail{OrderID=7, StoreID=7, InstrumentID=7},
                new OrderDetail{OrderID=8, StoreID=8, InstrumentID=8}
            };
            orderDetails.ForEach(od => context.OrderDetails.Add(od));
            context.SaveChanges();
        }

    }
}