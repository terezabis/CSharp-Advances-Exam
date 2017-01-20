using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_01_CubicArtilery
{
    class CubicArtilery
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();

            Queue<char> bunkersQueue = new Queue<char>();
            Dictionary<char, List<int>> bukersWithWeapons = new Dictionary<char, List<int>>();

            while (line != "Bunker Revision")
            {
                string[] lineArray = line.Split();
                for (int i = 0; i < lineArray.Length; i++)
                {
                   
                }

                line = Console.ReadLine();
            }
        }
    }
}
