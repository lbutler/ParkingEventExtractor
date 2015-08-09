using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingEventExtractor.Models;
using System.Data.Entity;
using Newtonsoft.Json;

namespace ParkingEventExtractor
{
    class ParkingExtractor
    {

        private EntityContext db = new EntityContext();

        public void CreateJsonFile(DateTime date)
        {


            var bays = db.Bays.Where(b => b.ParkingEvents.Any(pe => pe.DateOfPark == date));

            List<BayJsonFeature> jsonBays = new List<BayJsonFeature>();

            foreach (Bay bay in bays)
            {
                var test = db.ParkingEvents.Where(x => x.BayId == bay.BayId && x.DateOfPark == date).ToList();
                bay.ParkingEvents = test;
            }



            foreach (Bay bay in bays)
            {

                jsonBays.Add(new BayJsonFeature(bay));

            }


            var featureCollection = new
            {
                type = "FeatureCollection",
                features = jsonBays
            };

            string json = JsonConvert.SerializeObject(featureCollection);


            System.IO.File.WriteAllText(@"E:\Parking\Data\" + date.ToString("yyyyMMdd") + ".json", json);




        }
    }
}
