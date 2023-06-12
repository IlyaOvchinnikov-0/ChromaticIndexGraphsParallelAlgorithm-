using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    class ChromaticIndex
    {
        static object locker = new object();
        public int FindChromaticIndex(List<Edge> edges, int e)
        {
            //Parallel.For(0, e, x => FindChromInd(edges, e, x));
            
            Parallel.For(1, 10, x => Coloring(edges, 0, e, x));

            int max = 0;

            Parallel.For(0, e, x => FindMaxColor(edges, x, ref max));

            return max;
        }

        /*private void FindChromInd(List<Edge> edges, int e, int i)
        {
            edges[i].Color++;
            for (int j = 0; j < e; j++)
            {
                if (j == i)
                    continue;
                if (edges[j].FirstVertex == edges[i].FirstVertex || edges[j].FirstVertex == edges[i].SecondVertex
                    || edges[j].SecondVertex == edges[i].FirstVertex || edges[j].SecondVertex == edges[i].SecondVertex)
                {
                    if (edges[j].Color == edges[i].Color)
                    {
                        FindChromInd(edges, e, i);
                    }
                }
            }
        }*/

        private void Coloring(List<Edge> edges, int i, int m, int num_color)
        {
            if (i == m) return;
            for (int j = 0; j < m; j++)
            {
                if (j == i)
                    continue;
                if ((edges[j].FirstVertex == edges[i].FirstVertex || edges[j].FirstVertex == edges[i].SecondVertex
                || edges[j].SecondVertex == edges[i].FirstVertex || edges[j].SecondVertex == edges[i].SecondVertex)
                && edges[j].Color == edges[i].Color)
                {
                    edges[i].Color = num_color;
                    Coloring(edges, i+1, m, num_color);
                }
            }
                    
          
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
}