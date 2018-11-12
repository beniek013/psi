using System;
using System.Collections.Generic;
using psi_1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psi_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tabX = new List<double>();
            var random = new Random();
            for (int i = 0; i < 100; i++) {
                tabX.Add((random.NextDouble() * (2 - 0) + 0));
            }
            var tabY = new List<double>();
            foreach (var value in tabX) {
                tabY.Add(2 * value + 0.5);
            }
            var max = 3;
            var min = -3;
            var W = random.NextDouble() * Math.Abs(max - min) + min;
            var b = random.NextDouble() * Math.Abs(max - min) + min;
            var W2 = random.NextDouble() * Math.Abs(max - min) + min;
            var b2 = random.NextDouble() * Math.Abs(max - min) + min;
            var Z = Functions.NN(tabX, W, b);
            Console.WriteLine(Functions.MSE(tabY, Z));
            Console.WriteLine(Functions.MSE(tabY, Functions.NN(tabX, 2, 0.5)));
            var Z2 = Functions.NN2(tabX, W, b, W2, b2);
            Console.WriteLine(Functions.MSE(Z2, tabY));
            var E = 0.01; //tempo uczenia
            Console.WriteLine("====================================");
            for (int i = 0; i < 1000; i++) {
                Functions.Update(tabX, tabY, ref W, ref b, E);
                Console.WriteLine(Functions.MSE(tabY, Functions.NN(tabX, W, b)));
            }
            var max2 = 0.1;
            var min2 = -0.1;
            double N; 
            var Y2 = new List<double>();
            var Y3 = new List<double>();
            foreach (var x in tabX)
            {
                N = random.NextDouble() * Math.Abs(max2 - min2) + min2;
                Y2.Add(-3 * x + 4 + N);
            }
            foreach (var y2 in Y2)
            {
                Y3.Add(Math.Pow(y2, 2));
            }
            Console.ReadLine();
        }
    }
}
