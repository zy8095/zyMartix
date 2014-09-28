using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zyMartix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 3;
            DoubleMartix a = new DoubleMartix(n, n);
            int count =0;
            int num = 0;
            Parallel.For(0, (int)(Math.Pow(2, n * n)), (int k)=>
            {
                num++;
                if (num % 3000 == 0)
                {
                    int p =num / 3000;
                    Console.Clear();
                    Console.WriteLine(((double)(p)) / 100 + "%");
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a.Data[i, j] = (k & (int)Math.Pow(2, i * n + j)) >> i * n + j;
                    }
                }
                if (a.GetDet() != 0)
                {
                    count++;
                }
            });

            Console.WriteLine(count);
        }
    }
}
