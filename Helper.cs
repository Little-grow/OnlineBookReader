using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal static class Helper
    {
        public static int ReadInt(int low, int high)
        {
            Console.WriteLine($"Enter number in range {low} - {high}");
            int choice = int.Parse(Console.ReadLine());
            if (choice >= low && choice <= high)
                return choice;
            Console.WriteLine("Error: Invalid number...Try again");
            return ReadInt(low, high);
        }

        public static int ShowReadMenu(List<string> menu)
        {
            Console.WriteLine("\nMenu:");
            for (int ch = 0; ch < menu.Count(); ch++)
            {
                Console.WriteLine($" {ch + 1}: {menu[ch]}");
            }
            return ReadInt(1, menu.Count);
        }

        public static List<string> ReadFileLines(string path)
        {
            var lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    foreach (var line in lines)
                    {
                        if (line.Length != 0)
                        {
                            lines.Add(line);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
            
            return lines;
        }
        public static void WriteFileLines(string path, List<string> lines, bool append = true)
        {
            using (StreamWriter writer = new StreamWriter(path,append))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
   
        

    }
}
