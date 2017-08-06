using System;
using Motosoft.DocumentProcessing.App.Contracts;

namespace Motosoft.DocumentProcessing.App.View
{
    public class ConsoleView : IView
    {
        public void Show(string[] words)
        {
            if (words == null)
                return;

            foreach (string stringLine in words)
                Console.WriteLine(stringLine);    
        }
    }
}
