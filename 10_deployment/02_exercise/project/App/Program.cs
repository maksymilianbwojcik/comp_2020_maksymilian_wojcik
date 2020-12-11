using System;
using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            var smh = new NotMuchOfAUtility();
            Console.WriteLine(smh.ViewName());

            // Console.WriteLine("Maksymilian W!");
        }
    }
}