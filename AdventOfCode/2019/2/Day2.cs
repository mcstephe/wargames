using System;
using System.Collections;

namespace AdventOfCode
{
    class Day2
    {
        static void Main(string[] args)
        {
            string stringCode = System.IO.File.ReadAllText(@"C:\Users\mcstephe\source\repos\AdventOfCode\AdventOfCode\Day_2_Input.txt");

            int pointer;
            bool isRunning;
            int[] intCode = {0};  

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    //Reset memory
                    pointer = 0;
                    intCode = Array.ConvertAll<string, int>(stringCode.Split(','), Convert.ToInt32);

                    intCode[1] = i;
                    intCode[2] = j;
                   
                    int caseSwitch = intCode[pointer];
                    isRunning = true;

                    while (isRunning)
                    {
                        switch (caseSwitch)
                        {
                            case 1:
                                intCode[intCode[pointer + 3]] = intCode[intCode[pointer + 1]] + intCode[intCode[pointer + 2]];
                                pointer += 4;
                                caseSwitch = intCode[pointer];
                                break;
                            case 2:
                                intCode[intCode[pointer + 3]] = intCode[intCode[pointer + 1]] * intCode[intCode[pointer + 2]];
                                pointer += 4;
                                caseSwitch = intCode[pointer];
                                break;
                            case 99:
                                isRunning = false;
                                break;
                            default:
                                //Console.WriteLine("Ignore invalid op codes");
                                break;
                        }
                    }

                    if (intCode[0] == 19690720)
                    {
                        Console.Write("FOUND 19690720 OUTPUT: {0} {1}", intCode[1], intCode[2]);
                        break;
                    }
                }
                if (intCode[0] == 19690720)
                {
                    Console.Write("FOUND 19690720 OUTPUT: {0} {1}", intCode[1], intCode[2]);  //Correct answer is 20 03
                    break;
                }

            }
                
        }
    }
}
