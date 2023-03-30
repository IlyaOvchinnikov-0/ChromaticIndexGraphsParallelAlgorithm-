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
            for (int i = 0; i < e; i++)
            {
                if (max < edges[i].Color)
                    max = edges[i].Color;
            }

            return max;
        }

        public void FindChromInd(List<Edge> edges, int e, int i)
        {
            int c = 1;
        flag:
            edges[i].Color = c;
            for (int j = 0; j < e; j++)
            {
                if (j == i)
                    continue;
                if (edges[j].FirstVertex == edges[i].FirstVertex || edges[j].FirstVertex == edges[i].SecondVertex
                    || edges[j].SecondVertex == edges[i].FirstVertex || edges[j].SecondVertex == edges[i].SecondVertex)
                {
                    if (edges[j].Color == edges[i].Color)
                    {
                        c++;
                        goto flag;
                    }
                }
            }
        }

    }
}