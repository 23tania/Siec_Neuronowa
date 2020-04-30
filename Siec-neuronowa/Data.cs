using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Siec_neuronowa
{
    class Data
    {
        //Funkcja pobierająca dane z pliku
        static public double[][] POBIERZ(string sciezka)
        {
            string[] lines = File.ReadAllLines(sciezka);
            double[][] data = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                data[i] = new double[tmp.Length + 2];

                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }

                if (tmp[4] == "Iris-setosa")
                {
                    data[i][4] = 1;
                    data[i][5] = 0;
                    data[i][6] = 0;
                }
                else if (tmp[4] == "Iris-versicolor")
                {
                    data[i][4] = 0;
                    data[i][5] = 1;
                    data[i][6] = 0;
                }
                else if (tmp[4] == "Iris-virginica")
                {
                    data[i][4] = 0;
                    data[i][5] = 0;
                    data[i][6] = 1;
                }

            }
            return data;
        }

        //Funkcja tasująca dane
        static public double[] TASUJ(double[] data)
        {
            Random rand = new Random();
            int n = data.Length;

            for (int i = 0; i < n-1; i++)
            {
                  int r = i + rand.Next(n - i);
                  double t = data[r];
                  data[r] = data[i];
                  data[i] = t;
            }
            return data;
        }
    }
}
