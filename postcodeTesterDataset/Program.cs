using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace postcodeTesterDataset
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = File.ReadAllText("dataset.geoJson");

            restaurant d = new restaurant();

            JArray restaurantArray = JArray.Parse(jsonString);

            IList<restaurant> restaurants =
                restaurantArray.Select(p => new restaurant
                {
                    name = (string)p["properties"]["name"],
                    postcode = ((string)p["properties"]["postcode"])

                }
                ).ToList();
            for (int i = 0; i <= restaurants.Count - 1; i++)
            { 
                if (restaurants[i].postcode == null)
                {
                    restaurants.RemoveAt(i);
                }
            }





            Console.WriteLine("Enter a postcode to search:");
            Console.Write("\t");
            string postcodeInput = Console.ReadLine();

            sortTXTfile(postcodeInput, restaurants);

            Console.ReadKey();
        }


        public static void sortTXTfile(string postcodeInput, IList<restaurant> restaurants)
        {
            string close = "";
            string closer = "";
            string closerer = "";
            string closest = "";
            Regex rx = new Regex("^(?:(?<a>[Gg][Ii][Rr])(?<d>)(?<s>0)(?<u>[Aa]{2}))|(?:(?:(?:(?<a>[A-Za-z])(?<d>[0-9]{1,2}))|(?:(?:(?<a>[A-Za-z][A-Ha-hJ-Yj-y])(?<d>[0-9]{1,2}))|(?:(?:(?<a>[A-Za-z])(?<d>[0-9][A-Za-z]))|(?:(?<a>[A-Za-z][A-Ha-hJ-Yj-y])(?<d>[0-9]?[A-Za-z])))))(?<s>[0-9])(?<u>[A-Za-z]{2}))$", RegexOptions.None | RegexOptions.Compiled);

            Match match = rx.Match(postcodeInput.ToUpper().Replace(" ", String.Empty));
            Console.WriteLine(postcodeInput);


            for (int i = 0; i <= restaurants.Count - 1; i++)
                {
                    int score = 0;                
                try
                {
                    var matchList = rx.Match(restaurants[i].postcode);

                    if (match.Groups["a"].Value == matchList.Groups["a"].Value)
                    {
                        score += 1;

                        if (match.Groups["d"].Value == matchList.Groups["d"].Value)
                        {
                            score += 1;

                            if (match.Groups["s"].Value == matchList.Groups["s"].Value)
                            {
                                score += 1;

                                if (match.Groups["u"].Value == matchList.Groups["u"].Value)
                                {
                                    score += 1;
                                }
                            }
                        }
                    }

                    if (score == 4)
                    {
                        closest += "\t" + restaurants[i].name + " : " + restaurants[i].postcode + Environment.NewLine;
                    }
                    if (score == 3)
                    {
                        closerer += "\t" + restaurants[i].name + " : " + restaurants[i].postcode + Environment.NewLine;
                    }
                    if (score == 2)
                    {
                        closer += "\t" + restaurants[i].name + " : " + restaurants[i].postcode + Environment.NewLine;
                    }
                    if (score == 1)
                    {
                        close += "\t" + restaurants[i].name + " : " + restaurants[i].postcode + Environment.NewLine;
                    }

                }
                catch {
                    i += 1;
                   
                }
                    


                    

            }
            Console.WriteLine("Closest Places to " + postcodeInput + ": (0-2 min)");
            Console.WriteLine(closest);
            Console.WriteLine("Closerer Places to " + postcodeInput + ": (1-6 min)");
            Console.WriteLine(closerer);
            Console.WriteLine("Closer Places to " + postcodeInput + ": (1-15 min)");
            Console.WriteLine(closer);
            Console.WriteLine("Close Places to " + postcodeInput + ": (16-45 min)");
            Console.WriteLine(close);


        }

    }
}
