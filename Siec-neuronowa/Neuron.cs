using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec_neuronowa
{
    class Neuron
    {
        //Lisy outputów i inputów neurona
        public List<Synapse> outputs { get; set; }
        public List<Synapse> inputs { get; set; }

        public double OutputValue { get; set; }
        public double InputValue { get; set; }

        //Konstruktor
        public Neuron()
        {
            outputs = new List<Synapse>();
            inputs = new List<Synapse>();
        }

        //Tworzenie połączeń między neuronami
        //Dodanie neurona, który będzie inputem nowo stworzonej synapsy
        public void AddOutputNeuron(Neuron outputNeuron)
        {
            Synapse synapsa = new Synapse(this, outputNeuron);
            outputs.Add(synapsa);
            outputNeuron.inputs.Add(synapsa);
            
        }

        //Dodanie neurona, który będzie outputem nowo stworzonej synapsy
        public void AddInputNeuron(Neuron inputNeuron)
        {
            Synapse synapsa = new Synapse(inputNeuron, this);
            inputNeuron.outputs.Add(synapsa);
            inputs.Add(synapsa);
        }

        //Dodanie synapsy łączącej neurony w warstwie wejściowej
        public void AddInputConnection(double inputValue)
        {
            Synapse synapsa = new Synapse(this, inputValue);
            inputs.Add(synapsa);
        }

        //Przypisanie wartości jako input synapsy
        public void PushValueOnInput(double inputValue)
        {
            inputs[0].Output = inputValue;
        }

        //Zwrócenie wartości output dla każdego inputu
        public void GetOutputValue()
        {
            InputValue = Function_Input.WeightedSumInputFunction(inputs);
            OutputValue = Function_Activation.BipolarActivationFunction(InputValue);
        }

    }
}
