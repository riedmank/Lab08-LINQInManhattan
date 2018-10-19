using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Lab08_LINQInManhattan.Classes;
using System.Linq;

namespace Lab08_LINQInManhattan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JSONConversion();
        }

        public static void JSONConversion()
        {
            string path = "../../../data.json";
            string text = "";

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<RootObject>(text);

            var neighborhood = data.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood);

            Console.WriteLine("====================================================");
            Console.WriteLine("Question1: Output all Neighborhoods");
            Console.WriteLine("====================================================");

            var neighborhoodNames = neighborhood.Select(x => x);

            foreach (var item in neighborhoodNames)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Question2: Filter out neighborhoods without names");
            Console.WriteLine("====================================================");

            var noEmptyNeighborhoodNames = neighborhoodNames.Where(x => x.Length > 0);

            foreach (var item in noEmptyNeighborhoodNames)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Question3: Remove duplicates");
            Console.WriteLine("====================================================");

            var uniqueNeighborhoodNames = noEmptyNeighborhoodNames.Select(x => x).Distinct();

            foreach (var item in uniqueNeighborhoodNames)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Question4: Consolidate into single query");
            Console.WriteLine("====================================================");

            var singleQuery = neighborhood.Where(x => x.Length > 0).Distinct();

            foreach (var item in singleQuery)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Question5: Do a LINQ Query");
            Console.WriteLine("====================================================");

            var LINQQuery = from hood in neighborhood
                            select hood;

            foreach (var hood in LINQQuery)
            {
                Console.WriteLine(hood);
            }

            //from hood in hoods,
            //select hood;

        }
    }
}
