using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyRounding
{
    class Program
    {
        static void MoneySplitter(double total, int count)
        {
            var split = splitTotal(total, count);
            var result = validateSplit(total, split);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadKey();
        }

        static double[] splitTotal(double total, int count)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Math.Round(total / count, 2);
            }
            return result;
        }

        static double[] validateSplit(double total, double[] split)
        {
            double actualTotal = 0;
            for (int i = 0; i < split.Length; i++)
            {
                actualTotal += split[i];
            }
            if (!(Math.Abs(actualTotal - total) < 0.00001))
            {
                int i = 0;
                while (!(Math.Abs(actualTotal - total) < 0.00001))
                {
                    if (actualTotal > total)
                    {
                        split[i] -= 0.01;
                        actualTotal -= 0.01;
                    }
                    else if (actualTotal < total)
                    {
                        split[i] += 0.01;
                        actualTotal += 0.01;
                    }
                    i = (i + 1) % split.Length; // circulate through the split array
                }
            }
            return split;
        }

        static void Main(string[] args)
        {
            MoneySplitter(800, 3);
        }
    }
}
