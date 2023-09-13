using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUD
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            List<String> screen;
            screen = new List<String> { "a", "b" };

            ConsoleKey ReadInput()
            {
                return Console.ReadKey(true).Key;
            }
            
            void DrawScreen()
            {
                Console.Clear();
                foreach (string line in screen)
                {
                    Console.WriteLine(line);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                DrawScreen();
                ReadInput();
            }
        }
    }
}
