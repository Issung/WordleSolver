using System;
using System.Collections.Generic;
using System.Linq;
using WordleSolver.Logic;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly List<ILetter> letters = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Options: ");
            Console.WriteLine("\t'absent x' - Set letter x as absent.");
            Console.WriteLine("\t'miss [0-4] x' - Set the letter x as unknown position.");
            Console.WriteLine("\t'[0-4] x' - Set position 0 - 4 as letter x.");
            Console.WriteLine("\t'clear' - Wipe memory and start again.");
            Console.WriteLine("\t'calc' - Run algorithm to figure out possible words.");
            Console.WriteLine("");

            while (true)
            {
                Console.Write("Input: ");

                var input = Console.ReadLine();

                if (input.StartsWith("absent"))
                {
                    letters.Add(new AbsentLetter(input.Last()));
                }
                else if (input.StartsWith("miss"))
                {
                    int index = int.Parse(input[5].ToString());
                    letters.Add(new KnownMissLetter(input.Last(), index));
                }
                else if (int.TryParse(input.First().ToString(), out var index))
                {
                    letters.RemoveAll(t => t.Letter == input.Last() && t.GetType() == typeof(KnownMissLetter));
                    letters.Add(new KnownPositionLetter(input.Last(), index));
                }
                else if (input == "clear")
                {
                    letters.Clear();
                }
                else if (input == "calc")
                {
                    var possibleWords = Solver.Discern(letters);

                    Console.WriteLine("Possible words: " + String.Join(", ", possibleWords));
                }
            }
        }
    }
}
