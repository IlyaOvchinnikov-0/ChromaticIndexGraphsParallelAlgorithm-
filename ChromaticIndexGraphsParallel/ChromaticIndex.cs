using ChromaticIndexGraphsParallel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    class ChromaticIndex
    {
        public int FindChromaticIndex(List<Edge> edges, int e)
        {
            Parallel.For(0, e, x => FindChromInd(edges, e, x));

            int max = -1;

            Parallel.For(0, e, x => FindMaxColor(edges, x, ref max));

            return max;
        }

        private void FindMaxColor(List<Edge> edges, int i, ref int max)
        {
            if (max < edges[i].Color)
            {
                max = edges[i].Color;
            }
        }

        private void FindChromInd(List<Edge> edges, int e, int i)
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
        }

    }
}