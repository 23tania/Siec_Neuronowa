using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec_neuronowa
{
    class Function_Input
    {
        //Funkcja input
        static public double WeightedSumInputFunction(List<Synapse> inputs)
        {
            double result = 0.0;
            foreach (Synapse synapsa in inputs)
            {
                result += synapsa.GetOutputValue();
            }
            return result;
        }
    }
}
