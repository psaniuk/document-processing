using System;
using Motosoft.DocumentProcessing.App.Contracts;
using Motosoft.DocumentProcessing.App.Model;

namespace Motosoft.DocumentProcessing.App.View
{
    public class ConsoleView : IView
    {
        public void Show(WordCounterPair pair)
        {
            if (pair != null)   
                Console.WriteLine($"{pair.Word}: {pair.Counter}");
        }

        public void Show(string str)
        {
            Console.WriteLine(str);
        }
    }
}
