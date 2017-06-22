using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int bank = 1000;
            int dClever = 100;
            double pClever = (((bank - dClever) / 6.0) + dClever) / bank;
            double pOther = (1 - pClever) / 5;
            Console.WriteLine($"Вероятность выпадения номера 'Умного пирата' должна быть равна - {pClever}");
            var r = new Random();
            double[] intervals = new double[6];
            intervals[0] = pClever;
            for (int i = 1; i < intervals.Length; i++)
            {
                intervals[i] = intervals[i - 1] + pOther;
            }
            for (;;)
            {
                int[] winnings = new int[6];
                for (int i = 0; i < bank; i++)
                {
                    var d = r.NextDouble();
                    for (int j = 0; j < intervals.Length; j++)
                    {
                        if (d <= intervals[j])
                        {
                            winnings[j]++;
                            break;
                        }
                    }
                }
                var sum = 0;
                for (int i = 1; i < intervals.Length; i++)
                {
                    sum += winnings[i];
                }

                for (int i = 0; i < intervals.Length; i++)
                {
                    Console.WriteLine($"{i} пират выиграл - {winnings[i]}");
                }
                Console.WriteLine($"'Умный' пират выйграл в среднем на {winnings[0] - sum / 5} больше,чем остальные");
                Console.ReadKey();
            }

        }
    }
}
