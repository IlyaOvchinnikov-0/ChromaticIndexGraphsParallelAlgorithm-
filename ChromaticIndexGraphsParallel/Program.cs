using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    class Edge
    {
        public int FirstVertex;
        public int SecondVertex;
        public int Color;
    }

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

    class ChromaticIndex
    {
        static object locker = new object();
        static List<Edge> result = new List<Edge>();

        public int FindChromaticIndex(List<Edge> edges, int e)
        {

            Parallel.For(1, FindMaxDegree(edges, e) + 2, () => new List<Edge>(), (i, state, newGraph) =>
            {
                newGraph = new List<Edge>(edges);

                Coloring(newGraph, 0, e, i);

                return newGraph;

            },
            (x) =>
            {
                lock (locker)
                {
                    result = x;
                }
            }
            );

            int max = 0;

            Parallel.For(0, e, x => FindMaxColor(result, x, ref max));

            return max;
        }

        /*private bool Check(List<Edge> edges, int m)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == i)
                        continue;
                    if ((edges[j].FirstVertex == edges[i].FirstVertex
                    || edges[j].FirstVertex == edges[i].SecondVertex
                    || edges[j].SecondVertex == edges[i].FirstVertex
                    || edges[j].SecondVertex == edges[i].SecondVertex)
                    && edges[j].Color == edges[i].Color)
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/

        private void Coloring(List<Edge> edges, int i, int m, int num_color)
        {
            if (i == m) return;
            for (int c = 1; c <= num_color; c++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == i)
                        continue;
                    if ((edges[j].FirstVertex == edges[i].FirstVertex 
                    || edges[j].FirstVertex == edges[i].SecondVertex
                    || edges[j].SecondVertex == edges[i].FirstVertex 
                    || edges[j].SecondVertex == edges[i].SecondVertex)
                    && edges[j].Color == edges[i].Color)
                    {
                        edges[i].Color = c;
                        Coloring(edges, i + 1, m, num_color);
                    }
                }
            }
            Coloring(edges, i + 1, m, num_color);
        }

        public int FindMaxDegree(List<Edge> edges, int e)
        {
            int maxDegree = int.MinValue;
            for (int i = 0; i < e; i++)
            {
                int degree = 0;
                for (int j = 0; j < e; j++)
                {
                    if (edges[i].FirstVertex == edges[j].FirstVertex
                    || edges[i].FirstVertex == edges[j].SecondVertex)
                    {
                        degree++;
                    }
                }
                if (degree > maxDegree) 
                { 
                    maxDegree = degree; 
                }
            }
            for (int i = 0; i < e; i++)
            {
                int degree = 0;
                for (int j = 0; j < e; j++)
                {
                    if (edges[i].SecondVertex == edges[j].FirstVertex
                    || edges[i].SecondVertex == edges[j].SecondVertex)
                    {
                        degree++;
                    }
                }
                if (degree > maxDegree)
                {
                    maxDegree = degree;
                }
            }
            return maxDegree;
        }

        private void FindMaxColor(List<Edge> edges, int i, ref int max)
        {
            lock (locker)
            {
                if (max < edges[i].Color)
                {
                    max = edges[i].Color;
                }
            }

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите количество ребер графа: ");
            int edges = Int32.Parse(Console.ReadLine());

            Graph graph = new Graph();

            graph.CreateGraph(edges);

            /*graph.Edges.Add(new Edge { FirstVertex = 2, SecondVertex = 3, Color = 1 });
            graph.Edges.Add(new Edge { FirstVertex = 1, SecondVertex = 2, Color = 1 });
            graph.Edges.Add(new Edge { FirstVertex = 3, SecondVertex = 4, Color = 1 });
            graph.Edges.Add(new Edge { FirstVertex = 4, SecondVertex = 5, Color = 1 });
            graph.Edges.Add(new Edge { FirstVertex = 1, SecondVertex = 5, Color = 1 });
            graph.Edges.Add(new Edge { FirstVertex = 3, SecondVertex = 5, Color = 1 });*/

            ChromaticIndex chromaticIndex = new ChromaticIndex();

            Console.WriteLine($"\nХроматический индекс данного графа равен: {chromaticIndex.FindChromaticIndex(graph.Edges, edges)} ");

            for (int i = 0; i < edges; i++)
                Console.WriteLine($"Цвет ребра между вершинами {graph.Edges[i].FirstVertex} и {graph.Edges[i].SecondVertex} это: цвет C{graph.Edges[i].Color}.");

            Console.ReadLine();
        }
    }
}
