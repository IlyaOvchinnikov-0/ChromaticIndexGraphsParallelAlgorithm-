/*using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    class ChromaticIndex
    {
        static object locker = new object();
        static List<Edge> result = new List<Edge>();

        public int FindChromaticIndex(List<Edge> edges, int e)
        {
            
            Parallel.For(1, e+1, x =>
                {
                    var newGraph = new List<Edge>(edges);

                    Coloring(newGraph, 0, e, x);

                    lock (locker)
                    {
                        result = newGraph;
                    }
                }
            );

            int max = 0;

            Parallel.For(0, e, x => FindMaxColor(result, x, ref max));

            return max;
        }

        private void Coloring(List<Edge> edges, int i, int m, int num_color)
        {
            if (i == m) return;
            for (int c = 1; c <= num_color; c++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == i)
                        continue;
                    if ((edges[j].FirstVertex == edges[i].FirstVertex || edges[j].FirstVertex == edges[i].SecondVertex
                    || edges[j].SecondVertex == edges[i].FirstVertex || edges[j].SecondVertex == edges[i].SecondVertex)
                    && edges[j].Color == edges[i].Color)
                    {
                        edges[i].Color = c;
                        Coloring(edges, i + 1, m, num_color);
                    }
                }
            }
            Coloring(edges, i + 1, m, num_color);
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
}*/