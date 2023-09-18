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
            int playerMaxHealth = 100;
            int playerCurrentHealth;
            string healthStatus;
            int playerMaxShield = 100;
            int playerCurrentShield;

            List<String> screen;
            screen = new List<String> { "a", "b" };
            bool running = true;
            ConsoleKey currentInput;

            ConsoleKey ReadInput()
            {
                return Console.ReadKey(true).Key;
            }
           
            void FillScreen(){
                 screen = new List<String>{
                    
               }; 
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

            while (running) {
                currentInput = ReadInput();
                if ( currentInput == ConsoleKey.Q ) {
                   running = false;
                }
            }
        }
    }
}
