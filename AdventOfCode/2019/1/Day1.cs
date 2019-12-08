using System;

namespace AdventOfCode
{
    class Day1
    {
        static void Main(string[] args)
        {
            int totalMassPart1 = 0;
            int totalMassPart2 = 0;

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mcstephe\Documents\GitHub\wargames\AdventOfCode\2019\1\input.txt");

            foreach (string line in lines)
            {
                totalMassPart1 += GetFuelReqPart1(Convert.ToInt32(line));
                totalMassPart2 += GetFuelReqPart2(Convert.ToInt32(line));
            }

            //Correct answers are 3515171 and 5269882.
            Console.WriteLine("Fuel Required \n Part 1: {0} Part 2: {1}", totalMassPart1, totalMassPart2); 
        }

        static int GetFuelReqPart1(int mass)
        {
            //Do not need to round down. Casting as int will drop off.
            int fuel = mass / 3; 
            fuel -= 2; 

            return fuel;
        }

        static int GetFuelReqPart2(int mass) 
        {
            
            int fuel = mass / 3; 
            fuel -= 2;

            //8 is highest value that is non negative after conversion that doesn't require additional recursion
            if (fuel <= 8 ) 
            {
                return fuel;
            }

            //Use Recursion to solve additional fuel requirements.
            return fuel + GetFuelReqPart2(fuel);
        }

    }
}
