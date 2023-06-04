using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    class Graph
    {
        public List<Edge> Edges = new List<Edge>();

        public void CreateGraph(int e)
        {
            for (int i = 0; i < e; i++)
            {
                Edge edge = new Edge();
                Console.WriteLine($"Введите пару вершин ребра {i + 1}");
                Console.Write("вершина 1: ");
                edge.FirstVertex = Int32.Parse(Console.ReadLine());
                Console.Write("вершина 2: ");
                edge.SecondVertex = Int32.Parse(Console.ReadLine());
                edge.Color = 1;
                Edges.Add(edge);
            }
        }
    }
}
