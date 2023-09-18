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
            string healthStatus = "Alive";
            int playerMaxShield = 100;
            int playerCurrentShield;

            // This is the position of the pointer for the menu arrow thing to move it around
            int optionSelectIndex = 0;

            string playerHealthDisplay;
            string playerShieldDisplay;
            string playerStatusDisplay;
            string quitInfo;

            List<String> screen;
            bool running = true;
            ConsoleKey currentInput;

            // Functions
            ConsoleKey ReadInput()
            {
                return Console.ReadKey(true).Key;
            }

            void OnStart()
            {
                playerCurrentHealth = playerMaxHealth;
                playerCurrentShield = playerMaxShield;
            }

            List<String> OptionsMenu()
            {

            }

            void OptionsController(string[] options)
            {

            }
           
            void FillScreen(){
                playerHealthDisplay = "Health: " + playerCurrentHealth + "/" + playerMaxHealth;
                playerShieldDisplay = "Shield: " + playerCurrentShield + "/" + playerMaxShield;
                playerStatusDisplay = "Player is " + healthStatus;
                quitInfo = "Press Escape Key to Quit";

                screen = new List<String>{
                    playerHealthDisplay,
                    playerShieldDisplay,
                    playerStatusDisplay,
                    "",
                    quitInfo
                }; 
            }

            void DrawScreen()
            {
                Console.Clear();
                foreach ( string line in screen )
                {
                    Console.WriteLine( line );
                }
            }

            void ManageInput()
            {
                currentInput = ReadInput();

                switch (currentInput) {
                    case ConsoleKey.Escape:
                        running = false;
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        optionSelectIndex -= 1; break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        optionSelectIndex += 1; break;
                }
            }

            // Game Loop

            OnStart();

            while (running) {
                FillScreen();
                DrawScreen();
                Console.WriteLine(optionSelectIndex);
                ManageInput();
            }
        }
    }
}
