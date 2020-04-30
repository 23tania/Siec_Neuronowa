using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec_neuronowa
{
    class Function_Activation
    {
        static double alfa = 0.25;

        //Funkcja aktywacji
        static public double BipolarActivationFunction(double input)
        {
            return (1 - Math.Pow(Math.E, -alfa * input)) / (1 + Math.Pow(Math.E, -alfa * input));
        }

        //Pochodna funkcji aktywacji
        static public double DerivativeBipolar(double input)
        {
            return (2 * alfa * Math.Pow(Math.E, -alfa * input)) / (Math.Pow(1 + Math.Pow(Math.E, -alfa * input), 2));
        }
    }
}
