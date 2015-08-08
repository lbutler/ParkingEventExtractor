using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingEventExtractor.Models;

namespace ParkingEventExtractor
{
    class BayJsonFeature
    {
        //EntityContext db = new EntityContext();

        public string type { get; set; }
        public object geometry { get; set; }
        public object properties { get; set; }

        private int[] SensorData { get; set; }

        public BayJsonFeature(Bay bay)
        {

            
            //this.SensorData = new int[1439];
            //FillSensorData(0, 1439, 0);


            ////List<ParkingEvent> parking = db.ParkingEvents.Where(pe => pe.BayId == bayId && DbFunctions.TruncateTime(pe.ArrivalDateTime) == day).OrderBy(pe => pe.ArrivalDateTime).ToList();

            //var signPlates = bay.ParkingEvents.Select(x => x.SignPlate).Distinct().OrderBy(s => s.SignPlateId).ToList();

            //foreach (SignPlate sign in signPlates)
            //{
            //    FillSensorData((int)sign.StartTime.TotalMinutes, sign.EndTime.TotalMinutes, 1);
            //}

            //foreach (ParkingEvent park in bay.ParkingEvents)
            //{
            //    if(park.InViolation)
            //    {
            //        // TODO:
            //        // Check to make sure there isnt a mistake in minutes allowed
                    
            //        //Taken will be in violation
            //        FillSensorData((int)Math.Floor(park.ArrivalDateTime.TimeOfDay.TotalMinutes), park.SignPlate.MinutesAllowed, 3);
            //        //Taken now in violation
            //        FillSensorData((int)Math.Floor(park.ArrivalDateTime.TimeOfDay.TotalMinutes) + park.SignPlate.MinutesAllowed, park.DepartureDateTime.TimeOfDay.TotalMinutes, 4);
            //    }
            //    else
            //    {
            //        //Taken wont be in violation
            //        FillSensorData((int)Math.Floor(park.ArrivalDateTime.TimeOfDay.TotalMinutes), Math.Floor(park.DepartureDateTime.TimeOfDay.TotalMinutes), 2);
            //    }
            //}

            var signPlates = bay.ParkingEvents.Select(x => x.SignPlate).Distinct().OrderBy(s => s.SignPlateId).ToList();

            var sensordata = bay.ParkingEvents.Select(
                pe => new {
                    arrivalDateTime = pe.ArrivalDateTime,
                    depart = pe.DepartureDateTime,
                    inViolation = pe.InViolation,
                    signPlateId = pe.SignPlate.SignPlateId
                });

            this.type = "Feature";
            this.geometry = new
            {
                type = "Point",
                coordinates = new[] { bay.Longitude , bay.Latitude }
            };
            this.properties = new
            {
                bayId = bay.BayId,
                streetMarker = bay.StreetMarker,
                streetName = bay.Street.Name,
                sensor = sensordata,
                signPlates = signPlates
            };

        }

        private void FillSensorData(int start,double end,int value)
        {
            
            for (int i = start; i < end; i++)
            {
                this.SensorData[i] = value;
            }
        }
    }
}
