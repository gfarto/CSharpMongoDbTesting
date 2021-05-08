using MongoDB.Driver;
using MongoDbTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var deliveries = getFullData();
            saveFullDataIndividually(deliveries);

            Console.ReadLine();
        }

        static List<Delivery> getFullData()
        {
            var watch = new Stopwatch();
            watch.Start();

            var deliveries = new List<Delivery>();

            for (int i = 0; i < 1000000; i++)
            {
                var del = new Delivery()
                {
                    CreatedOn = DateTime.Now,
                    CustomerID = 97,
                    DocumentKey = $"{i}@97.2.1",
                    MovementTypeKey = "Outbound",
                    UpdatedOn = DateTime.Now,
                    BillTo = new DeliveryPoint()
                    {
                        City = "Quito",
                        Code = $"City {i}",
                        Country = "Ecuador",
                        Id = i,
                        MainStreet = $"De los Huavos {i}",
                        State = $"State {i}"
                    },
                    ShipTo = new DeliveryPoint()
                    {
                        City = "Quito",
                        Code = $"City {i}",
                        Country = "Ecuador",
                        Id = i,
                        MainStreet = $"De los Huavos {i}",
                        State = $"State {i}"
                    }
                };

                del.Status = new List<Status>();
                for (int s = 0; s < 10; s++)
                {
                    var item = new Status()
                    {
                        CreatedOn = DateTime.Now,
                        Id = s,
                        Name = $"Status {s}",
                        Notes = $"Notes {s}"
                    };

                    del.Status.Add(item);
                }

                del.Characteristics = new List<Characteristic>();
                for (int s = 0; s < 10; s++)
                {
                    var item = new Characteristic()
                    {
                        Id = s,
                        Name = $"Characteristic {s}",
                        Value = $"Value: {s}"
                    };

                    del.Characteristics.Add(item);
                }

                deliveries.Add(del);
            }

            watch.Stop();
            Console.WriteLine("Getting Data: " + watch.ElapsedMilliseconds);

            return deliveries;

            // 1.000.000 objs se demoro 75308 milisegundos 
            // 1.000.000 objs se demoro 75829 milisegundos (2da ocasion)
        }

        static void saveFullData(List<Delivery> deliveries)
        {
            var watch = new Stopwatch();
            watch.Start();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DataTest");
            var collection = database.GetCollection<Delivery>("deliveries");
            collection.InsertMany(deliveries, new InsertManyOptions()
            {
                IsOrdered = true
            });

            watch.Stop();
            Console.WriteLine("Saving Many Data: " + watch.ElapsedMilliseconds);

            // 1.000.000 de registros se demoro 60125 miliseconds (60.13 segundos / 1.00 minutos)
            // 
        }

        static void saveFullDataIndividually(List<Delivery> deliveries)
        {
            var watch = new Stopwatch();
            watch.Start();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DataTest");
            var collection = database.GetCollection<Delivery>("deliveries");

            deliveries.ForEach(d =>
            {
                collection.InsertOne(d);
            });

            watch.Stop();
            Console.WriteLine("Saving Data Individually: " + watch.ElapsedMilliseconds);

            // 1.000.000 de registros se demoro 288596 miliseconds (288.59 segundos / 4.80 minutos)
        }
    }
}
