using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class RasterLayer {

        private int[,] raster; 

        public int Width { get; set; }
        public int Height { get; set; }
        
        public int Size
        {
            get
            {
                return Width * Height;
            }
        }

        public int GetPixel(int x, int y)
        {
            return raster[y, x];
        }

        public void SetPixel(int x, int y, int c)
        {
            raster[y, x] = c;
        }

        public int CountDigits(int x)
        {
            int count = 0; 
            foreach(var c in raster) 
            {
                if (c == x)
                    count++;
            }
            return count;
        }

        public RasterLayer(int x, int y)
        {
            raster = new int[y, x];
            Width = x;
            Height = y;
        }

        public override string ToString()
        {
            string temp = "";
            string pixel = "";

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GetPixel(j, i) == 0)
                        pixel = " "; //Will create a blank/black space in terminal
                    else
                        pixel = "X"; //Using X to fill up as much space representing white

                    temp = temp + pixel; // GetPixel(j,i).ToString();
                }
                temp = temp + "\n";
            }
            return temp;
        }
    }

    public class Image
    {
        public List<RasterLayer> layers;

        //add helper methods to find layer with min value
        public int Width { get; set; }
        public int Height { get; set; }

        public int Size
        {
            get
            {
                return Width * Height;
            }
        }

        public int LayerFewestDigits(int d)
        {
            int layer = 0;
            int value = Size; 
            for (int i = 0; i < layers.Count; i++)
            {
                int temp = layers[i].CountDigits(d);
                if ( temp < value )
                {
                    value = temp;
                    layer = i; 
                }
            }
            
            return layer; 
        }

        public RasterLayer Decode()
        {
            RasterLayer decodedLayer = new RasterLayer(Width, Height);

            for (int l = layers.Count - 1; l > -1; l--) //Start at last layer 
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (layers[l].GetPixel(j,i) == 0)
                        {
                            decodedLayer.SetPixel(j, i, 0); 
                        }
                        else if (layers[l].GetPixel(j, i) == 1)
                        {
                            decodedLayer.SetPixel(j, i, 1); 
                        }
                    }
                }
            }           

            return decodedLayer; 
        }

        public Image(int x, int y)
        {
            Width = x;
            Height = y;
            layers = new List<RasterLayer>();
        }
    }


    class Day8
    {
        static void Main(string[] args)
        {
            //Given
            int xSize = 25;
            int ySize = 6;

            //Parse input into an array of ints 
            string stringCode = System.IO.File.ReadAllText(@"C:\Users\mcstephe\Documents\GitHub\wargames\AdventOfCode\2019\8\input.txt");
            char[] charStream = stringCode.ToCharArray();
            int[] stream = Array.ConvertAll(charStream, c => (int)Char.GetNumericValue(c));
            
            //Initialize
            Image image = new Image(xSize, ySize);
            RasterLayer raster = new RasterLayer(xSize, ySize);
            int streamCounter = 0;

            while (streamCounter < stream.Length)
            {
                for (int i = 0; i < ySize; i++)
                {
                    for (int j = 0; j < xSize; j++)
                    {
                        raster.SetPixel(j, i, stream[streamCounter]);
                        streamCounter++;
                    }                    
                }                
                image.layers.Add(raster);
                raster = new RasterLayer(xSize, ySize);
            }

            //PART 1 SOLUTION
            int ones = image.layers[image.LayerFewestDigits(0)].CountDigits(1);
            int twos = image.layers[image.LayerFewestDigits(0)].CountDigits(2);
            Console.WriteLine("PART 1: {0}", ones * twos);
            Console.WriteLine("PART 2: \n{0}",image.Decode().ToString());
            
            
        }



    }
}
