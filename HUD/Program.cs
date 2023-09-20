using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HUD
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            // Code is terrible, in the middle of renovation
            // Putting everything in Main() is not doing it for me

            Player player = new Player();
            Entity defaultEnemy = new Entity();

            player.maxHealth = 100; 
            player.maxShield = 100;
            player.lives = 3;
            

            int playerMaxShield = 100;

            int playerDamage = 10;

            int enemyHealth = 20;
            int enemyDamage = 5;

            // This is the position of the pointer for the menu arrow thing to move it around, not used yet
            int optionSelectIndex = 0;

            string playerHealthDisplay;
            string playerShieldDisplay;

            string enemyHealthDisplay;
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
                player.currentHealth = player.maxHealth;
                player.currentShield = player.maxShield;
                player.damage = 10;

                defaultEnemy.damage = 20;
            }

            List<String> options = new List<String> {
                "Attack",
                "Heal",
                "Regenerate Shield",
                "Die"
            };

            void Attack( Entity enemy ) {
                enemy.currentHealth -= player.damage;
            }

            void OptionSelector( string optionSelected ) {
                switch ( optionSelected ) {
                    case "Attack":
                        Attack( defaultEnemy );
                        break;
                }
            }


            // This setup barely works so I'm overhauling it later
            void FillScreen(){
                playerHealthDisplay = "Health: " + player.currentHealth + "/" + player.maxHealth;
                playerShieldDisplay = "Shield: " + player.currentShield + "/" + player.maxShield;
                enemyHealthDisplay = "Enemy HP: " + defaultEnemy.currentHealth;
                quitInfo = "Press Escape Key to Quit";

                screen = new List<String> {
                    playerHealthDisplay,
                    playerShieldDisplay,
                    "Lives: " + player.lives,
                    "",
                    enemyHealthDisplay,
                    "",
                    "[ Esc ] to quit game",
                    "[ Space ] to damage enemy",
                    "Revive doesn't work yet and neither does my negative health stopper"
                }; 
            }

            void DrawScreen()
            {
                Console.Clear();
                ShowHUD();
            }

            void ShowHUD()
            {
                foreach (string line in screen)
                {
                    Console.WriteLine(line);
                }
            }

            // Also bad, also overhauling
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

                    case ConsoleKey.Spacebar:
                        OptionSelector ("Attack"); break;
                }
            }

            

            void PlayerTurn()
            {
                ManageInput();
            }

            // Game Loop

            OnStart();

            while (running) {
                FillScreen();
                DrawScreen();
                PlayerTurn();
                player.TakeDamage(defaultEnemy.damage);
            }
        }
    }

    public class Entity
    {
        public int currentHealth;
        public int maxHealth;
        public int damage;
        public int maxShield;
        public int currentShield;
        public int lives;

        /*string DisplayStat (int stat)
        {

        }*/

        public void TakeDamage(int damage)
        {
            if ( currentShield > 0)
            {
                currentShield -= damage;
            }
            else currentHealth -= damage;

            
        }

        public void Revive()
        {
            if (lives > 0)
            {
                currentHealth = maxHealth;
                currentShield = maxShield;

                lives -= 1;
            }

            // else GameOver();
        }
    }

    public class Player : Entity
    {
        // NTS, Nothing calls this, probably needs restructure
        void Die()
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Revive();
            }
        }
    }
}
