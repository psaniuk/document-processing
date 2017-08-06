using System;
using Motosoft.DocumentProcessing.App.Contracts;
using Motosoft.DocumentProcessing.App.Exceptions;
using Motosoft.DocumentProcessing.App.Model.SymbolTable;
using Motosoft.DocumentProcessing.App.Services;
using Motosoft.DocumentProcessing.App.Services.Filters;
using Motosoft.DocumentProcessing.App.Services.Formatters;
using Motosoft.DocumentProcessing.App.View;

namespace Motosoft.DocumentProcessing.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CountIt countIt = CreateDocProcessor();
                countIt.Count("The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.");
            }
            catch (DocumentCountException exception)
            {
                Console.WriteLine("An error has occured. Stack trace:");
                Console.WriteLine(exception);
            }

            Console.ReadKey();
        }


        public static CountIt CreateDocProcessor()
        {
            var filter = new IWordFilter[] {new NumberFilter()};
            var formatters = new IWordFormatter[] {new CaseInsensitiveFormatter()};
            return new CountIt(new DocumentReader(), new TernarySearchTrie(), new ConsoleView(), filter, formatters);
        }
    }
}
