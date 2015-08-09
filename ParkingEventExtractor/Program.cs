using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ParkingEventExtractor
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start Extraction");

            DateTime begin = new DateTime(2014, 1, 1, 0, 0, 0);
            DateTime end = new DateTime(2014, 12, 31, 0, 0, 0);

            ParkingExtractor extractor = new ParkingExtractor();

            for (DateTime date = begin; date <= end; date = date.AddDays(1))
            {
                Console.WriteLine(date.ToString("yyyyMMdd"));
                extractor.CreateJsonFile(date);
            }

            Console.WriteLine("Done");


        }
    }
}
