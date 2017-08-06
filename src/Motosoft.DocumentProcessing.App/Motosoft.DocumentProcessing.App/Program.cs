﻿using System;
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
        
               // countIt.Count("These containers could be loaded onto a locomotive, container ship, or tractor trailer truck, and would consist of a maintenance car equipped with extra batteries, a robotic arm, and a computer system that would allow the vehicles to communicate with a drone. If needed, they could move to a new location to pick up a drone.");
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
            return new CountIt(new DocumentReader(), new TernarySearchTrie(), new ConsoleView(), 
                new WordEncoder(), filter, formatters);
        }
    }
}
