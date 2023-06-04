using System;
using System.Collections.Generic;

namespace ChromaticIndexGraphsParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите количество вершин графа: ");
            int vertex = Int32.Parse(Console.ReadLine());*/

            Console.WriteLine("Введите количество ребер графа: ");
            int edges = Int32.Parse(Console.ReadLine());

            Graph graph = new Graph();

            graph.CreateGraph(edges);

            ChromaticIndex chromaticIndex = new ChromaticIndex();

            Console.WriteLine($"\nХроматический индекс данного графа равен: {chromaticIndex.FindChromaticIndex(graph.Edges, edges)}");

            for (int i = 0; i < edges; i++)
                Console.WriteLine($"Цвет ребра между вершинами {graph.Edges[i].FirstVertex} и {graph.Edges[i].SecondVertex} это: цвет C{graph.Edges[i].Color}.");

            Console.ReadLine();
        }
    }
}
