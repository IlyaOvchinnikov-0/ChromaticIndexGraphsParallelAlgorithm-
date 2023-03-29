using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    internal class ChromaticIndex
    {
        public int FindChromaticIndex(List<Edge> edges, int e)
        {
            //для присвоения допустимого цвета каждому краю 'i'.
            for (int i = 0; i < e; i++)
            {
                int c = 1;
            flag:
                //назначить цвет текущему краю 
                edges[i].Color = c;
                for (int j = 0; j < e; j++)
                {
                    if (j == i)
                        continue;
                    //Проверьте цвета ребер, прилегающих к краю i
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

            int max = -1;
            for (int i = 0; i < e; i++)
            {
                if (max < edges[i].Color)
                    max = edges[i].Color;
            }

            return max;
        }
    }
}
