using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.SpeechRecognition
{
    public class Algorithm
    {
        public Algorithm()
        {

        }

        public void Run()
        {
            Console.WriteLine("Starting Speech Recognition Algoritm Example");

            RunSpeechRecognitionAlgorithm();

            Console.WriteLine("Speech Recognition Algoritm Completed!");
        }

        private async void RunSpeechRecognitionAlgorithm()
        {
            // var output = await DeviceInformation.FindAllAsync(MediaDevice.GetAudioRenderSelector());

        }
    }
}
