using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec_neuronowa
{
    class Testing
    {
        //Klasyfikowanie danych do gatunku kwiata
        static public void IrisClassification(Network network, double[] inputs)
        {
            network.PushInputValues(inputs);
            Console.Write("Dane: ");

            for (int i=0; i<inputs.Length; i++)
            {
                Console.Write(inputs[i].ToString() + " ");
            }
            Console.WriteLine();
            Console.Write("Gatunek: ");

            List<double> outputs = network.GetOutput();

            string[] flowerNames = { "Iris-setosa", "Iris-versicolor", "Iris-virginica" };
            Console.Write(flowerNames[outputs.IndexOf(outputs.Max())] + " "); //?
            Console.WriteLine();
            Console.WriteLine();
            
        }

        static void Main(string[] args)
        {
            //TWORZENIE SIECI I TESTOWANIE PROGRAMU

            double[][] data = Data.POBIERZ("iris.txt");
            double[] rowNumbers = new double[data.Length];

            //Pobranie input danych, jeszcze nie przetasowanych
            double[][] inputData = new double[data.Length][];

            for (int i=0; i<data.Length; i++)
            {
                inputData[i] = new double[] { data[i][0], data[i][1], data[i][2], data[i][3] };
            }

            //Tworzenie wytasowanych danych
            for (int i=0; i<data.Length; i++)
            {
                rowNumbers[i] = i;
            }
            rowNumbers = Data.TASUJ(rowNumbers);
            double[][] shuffledData = new double[data.Length][];

            for (int i=0; i<rowNumbers.Length; i++)
            {
                shuffledData[i] = data[(int)rowNumbers[i]]; 
            }

            double[][] expectedValues = new double[shuffledData.Length][];
            double[][] trainingData = new double[shuffledData.Length][];

            for (int i=0; i < shuffledData.Length; i++)
            {
                expectedValues[i] = new double[3];
                trainingData[i] = new double[4];

                //Dodawanie gatunku kwiata do expectedValues
                for (int j=4; j<7; j++)
                {
                    expectedValues[i][j - 4] = shuffledData[i][j];
                }

                //Dodawanie danych, które posłużą jako input sieci
                for (int j=0; j<4; j++)
                {
                    trainingData[i][j] = shuffledData[i][j];
                }
            }

            //Tworzenie nowej sieci neuronowej
            int hiddenLayersCount = 3;
            int hiddenNeuronsCount = 5;
            int inputNeuronsCount = 4;
            int outputNeuronsCount = 3;
            Network network = new Network(hiddenLayersCount, inputNeuronsCount, outputNeuronsCount, hiddenNeuronsCount);

            Console.WriteLine("Tworzenie sieci neuronowej o:");
            Console.WriteLine("- ilości neuronów wejściowych: " + inputNeuronsCount);
            Console.WriteLine("- ilości neuronów wyjściowych: " + outputNeuronsCount);
            Console.WriteLine("- ilości warstw ukrytych: " + hiddenLayersCount);
            Console.WriteLine("- ilości neuronów w warstwach ukrytych: " + hiddenNeuronsCount);
            Console.WriteLine();

            network.PushDesiredValues(expectedValues);
            network.Training(trainingData);

            //Klasyfikacja do gatunku kwiatów
            for (int i = 0; i < trainingData.Length; i++)
                IrisClassification(network, inputData[i]);


            Console.ReadLine();


        }
    }
}
