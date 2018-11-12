using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psi_1
{
    public class Functions
    {
        public static List<double> NN(List<double> tabX, double W, double b) {
            var listToReturn = new List<double>();
            foreach (var x in tabX) {
                listToReturn.Add(x * W + b);
            }
            return listToReturn;
        }
        public static double MSE(List<double> tabX, List<double> tabY) {
            double suma = 0;
            for (int i = 0; i < tabX.Count; i++)
            {
                suma += Math.Pow((tabX[i] - tabY[i]), 2);
            }
            return suma / tabX.Count;
        }

        public static List<double> ReLU(List<double> tabX) {
            var listToReturn = new List<double>();
            foreach(var x in tabX)
            {
                listToReturn.Add(Math.Max(0, x));
            }
            return listToReturn;
        }

        public static List<double> NN2(List<double> tabX, double W, double b, double W2, double b2) {
            return NN(ReLU(NN(tabX, W, b)), W2, b2);
        }

        public static void Update(List<double> tabX, List<double> tabY, ref double W, ref double b, double E){
            double dw, db;
            dw = db = 0;
            for (int i = 0; i < tabX.Count; i++)
            {
                dw = (W * tabX[i] + b - tabY[i] * tabX[i]) / tabX.Count;
                db = (W * tabX[i] + b - tabY[i]) / tabX.Count;
            }
            W = W - E * dw;
            b = b - E * db;
        }
    }
}
