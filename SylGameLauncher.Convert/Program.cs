using SylGameLauncher.Convert.Converter;
using System;

namespace SylGameLauncher.Convert {
    class Program {
        private static string folder = @"D:\Software\SylGameLauncher\database";

        static void Main(string[] args) {
            var converter = new ConvertV0_1ToV0_2($@"{folder}\game.json", $@"{folder}\play.json");
            Console.WriteLine("Initial Database");
            Console.Write("Input Username: ");
            string username = Console.ReadLine();
            converter.StartConvert(username);
            converter.EndConvert($@"{folder}\model-new.json");
            Console.WriteLine("Finish Converter");
            Console.WriteLine("Input any key to exit");
            Console.ReadKey();
        }
    }
}
