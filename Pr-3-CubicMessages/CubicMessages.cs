using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pr_3_CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            string num = Console.ReadLine();
            List<string> listOfSequences = new List<string>();
            List<int> listOfIntegers = new List<int>();

            while (sequence != "Over!")
            {
                listOfSequences.Add(sequence);
                listOfIntegers.Add(int.Parse(num));

                sequence = Console.ReadLine();
                num = Console.ReadLine();
            }

            for (int i = 0; i < listOfSequences.Count; i++)
            {
                int number = listOfIntegers[i];
                string pattern = string.Format($"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$");
                Regex regex = new Regex(pattern);
                bool isMatch = regex.IsMatch(listOfSequences[i]);
                if (isMatch)
                {
                    Match machSequence = regex.Match(listOfSequences[i]);
                    StringBuilder sb = new StringBuilder();
                    int index = 0;
                    if (machSequence.Groups[2].Length == number)
                    {
                        Console.Write(machSequence.Groups[2] + " == ");
                        for (int j = 0; j < machSequence.Groups[1].Length; j++)
                        {
                            index = machSequence.Groups[1].ToString()[j] - 48;
                            if (index < machSequence.Groups[2].Length)
                            {
                                sb.Append(machSequence.Groups[2].ToString()[index]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }

                        if (machSequence.Groups[3].Length > 0)
                        {
                            for (int k = 0; k < machSequence.Groups[3].Length; k++)
                            {
                                index = machSequence.Groups[3].ToString()[k] - 48;
                                if (index >=0 && index <=9)
                                {
                                    if (index < machSequence.Groups[2].Length)
                                    {
                                        sb.Append(machSequence.Groups[2].ToString()[index]);
                                    }
                                    else
                                    {
                                        sb.Append(" ");
                                    }
                                }
                            }
                        }
                        Console.WriteLine(sb);
                    }
                }
            }
        }
    }
}
