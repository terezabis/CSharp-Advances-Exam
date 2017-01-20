using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague
{
    class ChampionsLeague
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, SortedSet<string>> teamWithOpponents = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, int> winsOfTeam = new Dictionary<string, int>();

            int poinsFirstTeam = 0;
            int poinsSecondTeam = 0;
            int awayFirst = 0;
            int awaySecond = 0;

            while (line != "stop")
            {
                string[] lineArray = line.Split('|').Select(x => x.Trim()).ToArray();

                if (!teamWithOpponents.ContainsKey(lineArray[0]))
                {
                    teamWithOpponents.Add(lineArray[0], new SortedSet<string>());
                    winsOfTeam.Add(lineArray[0], 0);
                }
                teamWithOpponents[lineArray[0]].Add(lineArray[1]);

                if (!teamWithOpponents.ContainsKey(lineArray[1]))
                {
                    teamWithOpponents.Add(lineArray[1], new SortedSet<string>());
                    winsOfTeam.Add(lineArray[1], 0);
                }
                teamWithOpponents[lineArray[1]].Add(lineArray[0]);

                string[] mainResults = lineArray[2].Split(':');
                string[] awayResults = lineArray[3].Split(':');
                poinsFirstTeam += int.Parse(mainResults[0]) + int.Parse(awayResults[1]);
                poinsSecondTeam += int.Parse(mainResults[1]) + int.Parse(awayResults[0]);
                awayFirst = int.Parse(awayResults[1]);
                awaySecond = int.Parse(mainResults[1]);

                if (poinsFirstTeam > poinsSecondTeam)
                {
                    winsOfTeam[lineArray[0]]++;
                }
                else if (poinsFirstTeam < poinsSecondTeam)
                {
                    winsOfTeam[lineArray[1]]++;
                }
                else
                {
                    if (awayFirst > awaySecond)
                    {
                        winsOfTeam[lineArray[0]]++;
                    }
                    else
                    {
                        winsOfTeam[lineArray[1]]++;
                    }
                }

                line = Console.ReadLine();
            }

            var sortedWiners = winsOfTeam.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in sortedWiners)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"- Wins: {item.Value}");
                Console.WriteLine($"- Opponents: " + string.Join(", ", teamWithOpponents[item.Key]));
            }
        }
    }
}
