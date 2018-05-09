using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //number of cities must be given to here
        static int numberOfNodes = 5;
        static double cost = 0;
        static void Main(string[] args)
        {

            Double[,] graph = new Double[numberOfNodes, numberOfNodes];

            //StreamReader streamreader = new StreamReader(@"C:\Users\erdog\source\repos\ConsoleApp1\ConsoleApp1\Euclidian.txt");
            //char[] delimiter = new char[] { '\t' };

            //input directory must be given to here with a proper format
            using (StreamReader reader = new StreamReader(@"C:\Users\Arif\Desktop\project\ConsoleApp1\Tab İnputs\symmetric.txt"))
            {
                int i = 0;
                int j = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var delimiters = new char[] { '\t' };
                    var segments = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach (var segment in segments)
                    {

                        graph[i, j] = double.Parse(segment, System.Globalization.CultureInfo.InvariantCulture);
                        j++;
                    }
                    i++;
                    j = 0;
                }
            }

            
            List<int> path = new List<int>();
            path.Add(0);

            
            EnYakınKomşuBaldanTatlıdır(graph, path);
            //cost += graph[path.Last(), 0];

            Console.WriteLine("Total Cost: " +cost);
            foreach(int node in path)
            {
                Console.Write(node+1 + "-");
            }

            Console.ReadLine();


        }
        public static void EnYakınKomşuBaldanTatlıdır (Double[,] graph, List<int> path){

            Dictionary<int, Double> shortestOnes = new Dictionary<int, Double>();
            for (int i = 0; i < numberOfNodes; i++)
                shortestOnes.Add(i, 100000);

            int p = 0;
            do
            {
                int position = path.Last();
                int i = position;
                
                for (int j = 0; j < numberOfNodes; j++)
                {
                    if (graph[i, j] != 0 && shortestOnes[i] > graph[i, j] && !path.Contains(j))
                    {
                        shortestOnes[i] = graph[i, j];
                        position = j;
                        //graph[i, j] = 0;

                    }
                    //else
                    //{
                    //    graph[i, j] = 0;
                    //}
                }

                path.Add(position);
                cost += shortestOnes[i];
                //for (int k = 0; k < numberOfNodes; k++)
                //    graph[k, i] = 0;
                p++;

            }
            while (path.Last() != 0 && p<numberOfNodes-1);

            cost += graph[path.Last(), 0];
            path.Add(0);


        }
    }
}
