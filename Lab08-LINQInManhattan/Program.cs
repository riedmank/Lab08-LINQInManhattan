using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Lab08_LINQInManhattan.Classes;

namespace Lab08_LINQInManhattan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }

        public static void JSONConversion()
        {
            string path = "../../../data.json";
            string text = "";

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            List<NeighborhoodData> myStuff = JsonConvert.DeserializeObject<List<NeighborhoodData>>(text);


        }
    }
}
