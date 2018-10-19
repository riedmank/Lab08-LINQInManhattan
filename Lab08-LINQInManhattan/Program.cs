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

            var neighborhood = data.Features.Select(x => x).Select(x => x.Properties);

            Console.WriteLine("====================================================");
            Console.WriteLine("Question1: Output all Neighborhoods");
            Console.WriteLine("====================================================");

            var neighborhoodNames = neighborhood.Select(x => x.Neighborhood);

            foreach (var item in neighborhoodNames)
            {
                Console.WriteLine(item);
            }

            neighborhoodNames = neighborhood.Where(x => x.Neighborhood.Length > 0).Select(x => x.Neighborhood);
            
            Console.WriteLine("====================================================");
            Console.WriteLine("Question2: Filter out neighborhoods without names");
            Console.WriteLine("====================================================");

            foreach (var item in neighborhoodNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
