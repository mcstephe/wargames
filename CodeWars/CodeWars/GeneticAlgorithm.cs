using System;
using System.Collections.Generic;
using System.Linq;

public class GeneticAlgorithm
{
    private Random random = new Random();
    private int _length;

    public string Generate(int length)
    {
        string result = "";
        //Random r = new Random();
        for (int i = 0; i < length; i++)
        {
            result += random.Next(2);
        }
        return result;
    }

    public string Select(IEnumerable<string> population, IEnumerable<double> fitnesses, double sum = 0)
    {
        //Random rand = new Random();
        double num = random.NextDouble();
        double count = 0;
        int index = 0;

        foreach (double d in fitnesses)
        {
            count += d;
            if (num < count)
            {
                break;
            }

            index++;
        }

        return population.ElementAt(index);
    }

    public string Mutate(string chromosome, double probability)
    {
        char[] chars = chromosome.ToCharArray();
        //int prob = Convert.ToInt32(probability * 100);
        //Random rand = new Random();
        for (int i = 0; i < chars.Length; i++)
        {
            if (random.NextDouble() <= probability)
            {
                if (chars[i].Equals('0'))
                    chars[i] = '1';
                else
                    chars[i] = '0';
            }
        }
        string result = new String(chars);

        return result;
    }

    public IEnumerable<string> Crossover(string chromosome1, string chromosome2)
    {
        int cut = random.Next(_length);
        return new string[] {
        string.Concat(chromosome1.Substring(0, cut), chromosome2.Substring(cut)),
        string.Concat(chromosome2.Substring(0, cut), chromosome1.Substring(cut))};
    }

    public string Run(Func<string, double> fitness, int length, double p_c, double p_m, int iterations = 100)
    {
        List<ChromosomeWrap> wrapper = new List<ChromosomeWrap>();
        List<string> pList = new List<string>();
        List<string> pList2 = new List<string>();
        List<double> fList = new List<double>();
        List<double> fList2 = new List<double>();
        int populationSize = 100;

        string tempChromo = "";


        //INITIAL POPULATION AND FITNESS 
        for (int i = 0; i < populationSize; i++)
        {
            tempChromo = Generate(length);
            pList.Add(tempChromo);
            fList.Add(fitness(tempChromo));
        }

        for (int i = 0; i < iterations; i++)
        {
            while (pList2.Count() < populationSize)
            {
                string[] chromo = new string[2] { Select(pList, fList), Select(pList, fList) };

                if (random.NextDouble() <= p_c)
                {
                    chromo = Crossover(chromo[0], chromo[1]).ToArray();
                }

                tempChromo = Mutate(chromo[0], p_m);
                pList2.Add(tempChromo);
                fList2.Add(fitness(tempChromo));

                tempChromo = Mutate(chromo[1], p_m);
                pList2.Add(tempChromo);
                fList2.Add(fitness(tempChromo));

            }

            pList = pList2;
            pList2.Clear();

            fList = fList2;
            fList2.Clear();
        }

        int index = fList.IndexOf(1.0);
        
        
        return pList.ElementAt(index);
    }

    public class ChromosomeWrap
    {
        public string Chromosome { get; set; }
        public double Fitness { get; set; }
    }

}
 