using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    internal class Graph
    {
        public static List<Edge> Edges = new List<Edge>();

        public static void CreateGraph(int e)
        {
            for (int i = 0; i < e; i++)
            {
                Edge edge = new Edge();
                Console.WriteLine($"Введите пару вершин ребра {i + 1}");
                Console.Write("V(1): ");
                edge.FirstVertex = Int32.Parse(Console.ReadLine());
                Console.Write("V(2): ");
                edge.SecondVertex = Int32.Parse(Console.ReadLine());
                edge.Color = 0;
                Edges.Add(edge);
            }
        }
    }
}
