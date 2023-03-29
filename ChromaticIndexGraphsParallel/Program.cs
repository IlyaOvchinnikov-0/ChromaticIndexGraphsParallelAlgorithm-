using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticIndexGraphsParallel
{
    internal class Program
    {
        static void ChromaticIndex(int[,] ed, int e)
        {
            //для присвоения допустимого цвета каждому краю 'i'.
            for (int i = 0; i < e; i++)
            {
                int c = 1;
            flag:
                //назначить цвет текущему краю 
                ed[i,2] = c;
                for (int j = 0; j < e; j++)
                {
                    if (j == i)
                        continue;
                    //Проверьте цвета ребер, прилегающих к краю i
                    if (ed[j,0] == ed[i,0] || ed[j,0] == ed[i,1] || ed[j,1] == ed[i,0] || ed[j,1] == ed[i,1])
                    {
                        if (ed[j,2] == ed[i,2])
                        {
                            c++;
                            goto flag;
                        }
                    }
                }
            }

        }

        static int maxColors(int[,] ed, int e)
        {
            int max = -1;
            for (int i = 0; i < e; i++)
            {
                if (max < ed[i, 2])
                    max = ed[i, 2];
            }

            return max;
        }

        static void Main(string[] args)
        {
            //int v;

            /*cout << "Введите количество вершин графа: ";
            cin >> v;*/

            /*cout << "Введите количество ребер графа: ";
            cin >> e;*/

            //количество ребер
            int e = 4;

            int[,] ed = new int[e, 3];


            for (int i = 0; i < e; i++)
            {
                Console.WriteLine($"Введите пару вершин ребра {i + 1}");
                Console.Write("V(1): ");
                ed[i, 0] = Int32.Parse(Console.ReadLine());
                Console.Write("V(2): ");
                ed[i, 1] = Int32.Parse(Console.ReadLine());
            }

            ChromaticIndex(ed, e);

            Console.WriteLine($"Хроматический индекс данного графика равен: {maxColors(ed, e)}");

            for (int i = 0; i < e; i++)
                Console.WriteLine($"Цвет ребра между вершинами n(1): {ed[i, 0]} и n(2): { ed[i, 1]} это: цвет C{ ed[i, 2]}.");

            Console.ReadLine();
        }
    }
}
