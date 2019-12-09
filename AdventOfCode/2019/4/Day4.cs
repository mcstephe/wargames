using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Day4
    {
        static void Main(string[] args)
        {
            int minRange = 193651;
            int maxRange = 649729;
            int counter = 0;


            for (int i = minRange; i <= maxRange; i++)
            {
                if (hasDoublePart1(i) && isIncreasing(i))
                    counter++;
            }

            Console.WriteLine("Part 1: {0}", counter);

            counter = 0;

            for (int i = minRange; i <= maxRange; i++)
            {
                if (hasDoublePart2(i) && isIncreasing(i))
                    counter++;
            }

            Console.WriteLine("Part 2: {0}",counter);

        }

        static bool hasDoublePart1(int num)
        {
            char[] list = num.ToString().ToCharArray();
            var numbers = new Dictionary<char, int>();

            foreach (var nums in list)
            {
                if (numbers.ContainsKey(nums))
                    numbers[nums]++;
                else
                    numbers.Add(nums, 1);
            }

            for (int i = 2; i <= list.Length; i++)
            {
                if (numbers.ContainsValue(i))
                    return true;
            }
       
            return false;

        }

        static bool hasDoublePart2(int num)
        {
            char[] list = num.ToString().ToCharArray();
            var numbers = new Dictionary<char, int>();

            foreach (var nums in list)
            {
                if (numbers.ContainsKey(nums))
                    numbers[nums]++;
                else
                    numbers.Add(nums, 1);
            }

            if (numbers.ContainsValue(2))
                return true;
            else return false;

        }

        static bool isIncreasing(int num)
        {
            char[] list = num.ToString().ToCharArray();

            for (int i = 0; i < list.Length - 1; i++)
            {
                if (list[i] > list[i + 1])
                    return false;
            }
            return true;
        }
    }
}
