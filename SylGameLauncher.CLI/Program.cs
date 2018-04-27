using System;
using System.Collections.Generic;
using System.IO;
using SylGameLauncher;

namespace SylGameLauncher.CLI {
    public class Program {
        private static SylGameLauncher launcher;
        private static string folder = @"D:\Git\SylGameLauncher\database";


        static void Main(string[] args) {
            string json;
            try {
                using (var sr = new StreamReader($@"{folder}\model-new.json")) {
                    json = sr.ReadToEnd();
                }
                launcher = new SylGameLauncher(json);
            } catch {
                Console.WriteLine("Initial Database");
                Console.Write("Input Username: ");
                string username = Console.ReadLine();
                Console.WriteLine();
                launcher = new SylGameLauncher();
                launcher.Data.User.Name = username;
            }
            bool isQuit = false;
            while (isQuit == false) {
                string cmd = Command();
                Console.WriteLine();
                switch (cmd) {
                    case "1":
                        PlayCommand();
                        break;
                    case "2":
                        ShowUserState();
                        break;
                    case "3":
                        EditDatabase();
                        break;
                    case "4":
                        Version();
                        break;
                    case "5":
                        isQuit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        Console.WriteLine();
                        break;
                }
            }
            json = launcher.ToJson();
            using (var sw = new StreamWriter($@"{folder}\model-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.json")) {
                sw.Write(json);
            }
            using (var sw = new StreamWriter($@"{folder}\model-new.json")) {
                sw.Write(json);
            }
        }

        private static string Command() {
            Console.WriteLine("Welcome to SylvaX's Game Launcher");
            Console.WriteLine("  1. Play Game");
            Console.WriteLine("  2. Show User State");
            Console.WriteLine("  3. Edit Database");
            Console.WriteLine("  4. About");
            Console.WriteLine("  5. Quit");
            Console.Write("Input: ");
            return Console.ReadLine();
        }

        private static void PlayCommand() {
            Dictionary<int, string> gameList = launcher.GetGameList();
            if (gameList.Count == 0) {
                Console.WriteLine("No game.\n");
                return;
            }
            foreach (int key in gameList.Keys) {
                Console.WriteLine($"{key}. {gameList[key]}");
            }
            Console.WriteLine("0. Return");
            int select = -1;
            while (select != 0) {
                Console.Write("\nGameId: ");
                try {
                    select = Int32.Parse(Console.ReadLine());
                    if (gameList.ContainsKey(select)) {
                        DateTime start = DateTime.Now;
                        Console.Write("Input any key to exit: ");
                        Console.ReadKey();
                        Console.WriteLine();
                        DateTime end = DateTime.Now;
                        launcher.AddRecord(select, start, end);
                        Console.WriteLine(gameList[select]);
                        Console.WriteLine($"Start Time: {start}");
                        Console.WriteLine($"End   Time: {end}");
                        Console.WriteLine();
                        select = 0;
                    }
                } catch (Exception) {
                    Console.WriteLine("Invalid Id.");
                }
            }
            Console.WriteLine();
        }

        private static void ShowUserState() {
            Console.WriteLine($"User: {launcher.Data.User.Name}");
            int allTime = launcher.Data.User.PlayGameTimeSum;
            int allSecond = allTime % 60;
            int allMinute = allTime / 60 % 60;
            int allHour = allTime / 3600 % 60;
            Console.WriteLine($"Play: {allHour} h, {allMinute} m, {allSecond} s");
            Dictionary<int, string> gameList = launcher.GetGameList();
            foreach (var item in launcher.Data.User.PlayGameState.Keys) {
                int time = launcher.Data.User.PlayGameState[item];
                int second = time % 60;
                int minute = time / 60 % 60;
                int hour = time / 3600 % 60;
                Console.WriteLine($"{item}. {gameList[item]}");
                Console.WriteLine($"    {hour} h, {minute} m, {second} s");
            }
            Console.WriteLine();
        }


        private static void EditDatabase() {
            Console.WriteLine("1. Add Game");
            Console.Write("[name]: ");
            string name = Console.ReadLine();
            Console.Write("[nameCN]: ");
            string nameCN = Console.ReadLine();
            launcher.AddGame(name, nameCN, string.Empty, string.Empty, DateTime.Now);
            Console.WriteLine();
        }

        private static void Version() {
            Console.WriteLine("SylGameLauncher CLI version 1.0");
            Console.WriteLine(SylGameLauncher.Version());
            Console.WriteLine();
        }
    }
}
