using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    internal static class Graph
    {
        public static List<Edge> Edges = new List<Edge>();

        public static void CreateGraph(int e)
        {
            for (int i = 0; i < e; i++)
            {
                Edge edge = new Edge();
                Console.WriteLine($"Введите пару вершин ребра {i + 1}");
                Console.Write("вершина 1: ");
                edge.FirstVertex = Int32.Parse(Console.ReadLine());
                Console.Write("вершина 2: ");
                edge.SecondVertex = Int32.Parse(Console.ReadLine());
                edge.Color = 0;
                Edges.Add(edge);
            }
        }

        public static void GenerateGraph(int e, int v)
        {
            var _Edges = new List<Edge>(e);

            for (int i = 0; i < e; i++)
            {
                var firstVertex = new Random().Next(1, v + 1);
                var secondVertex = new Random().Next(1, v + 1);
                var edge = new Edge();

                Console.WriteLine($"Вершины ребра {i + 1}");
                
                while (firstVertex == secondVertex)
                {
                    firstVertex = new Random().Next(1, v + 1);
                    secondVertex = new Random().Next(1, v + 1);
                }

                edge.FirstVertex = firstVertex;
                Console.WriteLine($"V(1): {edge.FirstVertex}");
                    
                edge.SecondVertex = secondVertex;
                Console.WriteLine($"V(2): {edge.SecondVertex}");

                edge.Color = 0;
                _Edges.Add(edge);
                
            }
            Edges = _Edges;
        }
    }
}
