using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec_neuronowa
{
    class Synapse
    {
        Neuron fromNeuron;
        Neuron toNeuron;

        static double learningRate = 0.6;
        public static Random random = new Random();

        public double Weight { get; set; }

        public double Output { get; set; }

        //Konstruktory
        //Tworzenie synapsy łącącej neuron fromNeuron z toNeuron o zainicjowanej randomowej wadze
        public Synapse(Neuron fromNeuron, Neuron toNeuron)
        {
            this.fromNeuron = fromNeuron;
            this.toNeuron = toNeuron;
            Weight = InitalizeWeight();
        }

        //Tworzenie synapsy o konkretnej wadze
        public Synapse(Neuron fromNeuron, Neuron toNeuron, double waga)
        {
            this.fromNeuron = fromNeuron;
            this.toNeuron = toNeuron;
            Weight = waga;
        }

        //Synapsa w warstwie input
        public Synapse(Neuron neuron, double output)
        {
            toNeuron = neuron;
            Output = output;
            Weight = 1;
        }

        //Zainicjowanie wag poszczególnych synaps
        double InitalizeWeight()
        {
            return random.NextDouble() - 0.5;
        }

        //Zaktualizowanie wagi synapsy
        public void UpdateWeight(double WeightChange)
        {
            Weight += WeightChange * learningRate;
        }

        //Zwraca iloczyn wagi połączenia i wartości output
        public double GetOutputValue()
        {
            if (fromNeuron == null)
            {
                return Output;
            }
            return fromNeuron.OutputValue * Weight;
        }


    }
}
