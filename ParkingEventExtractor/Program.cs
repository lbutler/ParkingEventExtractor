using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingEventExtractor.Models;
using System.Data.Entity;
using Newtonsoft.Json;


namespace ParkingEventExtractor
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start Test");

            EntityContext db = new EntityContext();
            DateTime date1 = new DateTime(2014, 1, 1, 0, 0, 0);

            Console.WriteLine("Getting Parking Bays with events");
            var bays = db.Bays.Where(b => b.ParkingEvents.Any(pe => pe.DateOfPark == date1));


            List<BayJsonFeature> jsonBays = new List<BayJsonFeature>();


            Console.WriteLine("Adding Parking Events");

            foreach (Bay bay in bays)
            {
                var test = db.ParkingEvents.Where(x => x.BayId == bay.BayId && x.DateOfPark == date1).ToList();
                bay.ParkingEvents = test;
            }




            Console.WriteLine("Creating Json Features");
            foreach (Bay bay in bays)
            {

                jsonBays.Add(new BayJsonFeature(bay));

            }



            var featureCollection = new {
                    type = "FeatureCollection",
                    features = jsonBays
                };

            Console.WriteLine("Serializing Json Features");
            string json = JsonConvert.SerializeObject(featureCollection);

            Console.WriteLine("Output to text");
            System.IO.File.WriteAllText(@"E:\Parking\test.json", json);


            Console.WriteLine("End Test");

        }
    }
}
