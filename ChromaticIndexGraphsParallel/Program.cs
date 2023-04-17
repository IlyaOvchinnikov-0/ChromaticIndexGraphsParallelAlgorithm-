using System;
using System.Collections.Generic;

namespace ChromaticIndexGraphsParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин графа: ");
            int vertex = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество ребер графа: ");
            int edges = Int32.Parse(Console.ReadLine());

            Graph.CreateGraph(edges);

            ChromaticIndex chromaticIndex = new ChromaticIndex();

            Console.WriteLine($"\nХроматический индекс данного графика равен: {chromaticIndex.FindChromaticIndex(Graph.Edges, edges)}");

            for (int i = 0; i < edges; i++)
                Console.WriteLine($"Цвет ребра между вершинами {Graph.Edges[i].FirstVertex} и {Graph.Edges[i].SecondVertex} это: цвет C{Graph.Edges[i].Color}.");

            Console.ReadLine();
        }
    }
}
