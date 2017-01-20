using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr_04_CubicAssault
{
    class CubicAssault
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            SortedDictionary<string, SortedDictionary<string, int>> allData
                = new SortedDictionary<string, SortedDictionary<string, int>>();

            SortedDictionary<string, SortedDictionary<string, int>> allDataCopy
                = new SortedDictionary<string, SortedDictionary<string, int>>();

            SortedDictionary<string, int> regionsBlack = new SortedDictionary<string, int>();

            while (line != "Count em all")
            {
                string[] lineArray = line.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToArray();
                string regionName = lineArray[0];
                string typeMeteor = lineArray[1];
                int count = int.Parse(lineArray[2]);

                if (!allData.ContainsKey(regionName))
                {
                    allData.Add(regionName, new SortedDictionary<string, int>());
                    allData[regionName].Add("Red", 0);
                    allData[regionName].Add("Black", 0);
                    allData[regionName].Add("Green", 0);
                }
                allData[regionName][typeMeteor] += count;
                line = Console.ReadLine();
            }

            int otherMeteor = 0;
            int currentMeteor = 0;

            foreach (var regions in allData)
            {
                allDataCopy.Add(regions.Key, new SortedDictionary<string, int>());
                allDataCopy[regions.Key].Add("Red", 0);
                allDataCopy[regions.Key].Add("Black", 0);
                allDataCopy[regions.Key].Add("Green", 0);

                int black = 0;
                int red = 0;

                foreach (var meteors in regions.Value)
                {
                    switch (meteors.Key)
                    {
                        case "Green":
                            if (meteors.Value >= 1000000)
                            {
                                otherMeteor = meteors.Value / 1000000;
                                currentMeteor = meteors.Value % 1000000;
                                allDataCopy[regions.Key][meteors.Key] = currentMeteor;
                                red += otherMeteor;
                            }
                            else
                            {
                                allDataCopy[regions.Key][meteors.Key] = meteors.Value;
                            }
                            break;
                        case "Red":
                            if (meteors.Value >= 1000000)
                            {
                                otherMeteor = meteors.Value / 1000000;
                                currentMeteor = meteors.Value % 1000000;
                                red += currentMeteor;
                                black += otherMeteor;
                            }
                            else
                            {
                                red += meteors.Value;
                            }
                            break;
                        case "Black":
                            black += meteors.Value;
                            break;
                    }
                }
                if (red >= 1000000)
                {
                    otherMeteor = red / 1000000;
                    currentMeteor = red % 1000000;
                    red = currentMeteor;
                    black += otherMeteor;
                }
                allDataCopy[regions.Key]["Red"] = red;
                allDataCopy[regions.Key]["Black"] = black;
                regionsBlack.Add(regions.Key, allData[regions.Key]["Black"]);
            }

            var sortedRegionsBlack = regionsBlack.OrderByDescending(x => x.Value).OrderBy(x => x.Key.Length);

            foreach (var regi in sortedRegionsBlack)
            {
                Console.WriteLine(regi.Key);
                var kvp = allDataCopy[regi.Key];
                var met = kvp.OrderByDescending(x => x.Value);
                foreach (var meteorsCount in met)
                {
                    Console.WriteLine($"-> {meteorsCount.Key} : {meteorsCount.Value}");
                }
            }
        }
    }
}