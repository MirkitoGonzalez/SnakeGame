using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    static class HallOfFame
    {
        private static string file = "HallOfFame.txt";
        private static List<HallOfFameEntry> entries = new List<HallOfFameEntry>();
        private static void GetHallOfFame()
        {
            entries.Clear();
            if (File.Exists(file))
            {
                StreamReader read = new StreamReader(file);
                using (read)
                {
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        string[] res = line.Split();
                        HallOfFameEntry entry = new HallOfFameEntry();
                        entry.Name = res[0];
                        entry.Score = int.Parse(res[1]);
                        entries.Add(entry);
                        line = read.ReadLine();
                    }
                }
            }
        }
        public static bool CheckForFameResult(int result)
        {
            GetHallOfFame();
            if (result==0)
            {
                return false;
            }
            if (entries.Count<10)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (result>entries[i].Score)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void EnterHallOfFame(HallOfFameEntry entry)
        {
            entries.Add(entry);
            if (entries.Count>10)
            {
                int min = int.MaxValue;
                int pos = 0;
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].Score<min)
                    {
                        min = entries[i].Score;
                        pos = i;
                    }
                }
                entries.RemoveAt(pos);
            }
            SaveHallOfFame();
        }
        private static void SaveHallOfFame()
        {
            StreamWriter write = new StreamWriter(file,false);
            using (write)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    write.WriteLine("{0} {1}", entries[i].Name, entries[i].Score);
                }
            }
        }
        public static void Show()
        {
            GetHallOfFame();
            var list = from entry in entries
                       orderby entry.Score descending
                       select entry;
            int counter = 1;
            foreach (var item in list)
            {
                Console.SetCursorPosition(30, 6 + counter);
                if (counter%2==0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (counter%3==0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("{0} - {1}   -   {2}",counter,item.Name,item.Score);
                Console.ForegroundColor = ConsoleColor.White;
                counter++;
            }
            Console.ReadKey();
            Menu.RunMenu();
        }
    }
}
