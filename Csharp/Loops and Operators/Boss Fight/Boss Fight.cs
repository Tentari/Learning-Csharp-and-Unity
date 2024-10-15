using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string BasicAttack = "1";
            const string FireBall = "2";
            const string Explosion = "3";
            const string Heal = "4";

            int bossHealth = 1500;
            int bossDamage = 100;
            int playerMaxHealth = 500;
            int playerHealth = playerMaxHealth;
            int playerDamage = 70;
            int playerMaxMana = 100;
            int playerMana = playerMaxMana;
            int fireballManaCost = 20;
            int fireballDamage = 200;
            int healMaxCount = 3;
            int healLifeRestoration = 200;
            int healManaRestoration = 30;
            int healChargeCost = 1;
            int fireballCount = 0;
            int explosionManaCost = 50;
            int explosionDamage = 500;
            string playerInput;

            Console.WriteLine("You see a giant. Thats a RB");

            while (bossHealth > 0 && playerHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{playerHealth} - Your HP.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{playerMana} - Your Mana.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{bossHealth} - Boss HP.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\nChoose your action.\n{BasicAttack} - Basic attack({playerDamage})damage.\n{FireBall} - Fireball({fireballDamage})damage (-{fireballManaCost}Mana).\n{Explosion} - Explosion({fireballCount})Charges.({explosionDamage}Damage) (-{explosionManaCost}Mana).\n{Heal} - Heal.({healMaxCount})(+{healLifeRestoration}heal)(+{healManaRestoration}mana)");
                playerInput = Console.ReadLine();

                Console.Clear();

                switch (playerInput)
                {
                    case BasicAttack:
                        bossHealth -= playerDamage;
                        Console.WriteLine($"Boss was damaged by {playerDamage}");
                        break;

                    case FireBall:
                        if (playerMana >= fireballManaCost)
                        {
                            fireballCount++;

                            playerMana -= fireballManaCost;
                            bossHealth -= fireballDamage;

                            Console.WriteLine($"Boss was damaged by {fireballDamage}");
                        }
                        else
                        {
                            Console.WriteLine("No mana. You wasted action.");
                        }
                        break;

                    case Explosion:
                        if (playerMana >= explosionManaCost)
                        {
                            if (fireballCount > 0)
                            {
                                fireballCount--;

                                playerMana -= explosionManaCost;
                                bossHealth -= explosionDamage;

                                Console.WriteLine($"Boss was damaged by {fireballDamage}");
                            }
                            else
                            {
                                Console.WriteLine("No charges. You wasted action.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No mana. You wasted action.");
                        }
                        break;

                    case Heal:
                        if (healMaxCount > 0)
                        {
                            healMaxCount -= healChargeCost;

                            if (playerHealth >= playerMaxHealth - healLifeRestoration)
                            {
                                playerHealth = playerMaxHealth;

                                Console.WriteLine("You healed to max HP.");
                            }
                            else
                            {
                                playerHealth += healLifeRestoration;

                                Console.WriteLine($"You healed {healLifeRestoration} HP");
                            }
                            if (playerMana >= playerMaxMana - healManaRestoration)
                            {
                                playerMana = playerMaxMana;

                                Console.WriteLine("You increased Mana to max.");
                            }
                            else
                            {
                                playerMana += healManaRestoration;

                                Console.WriteLine($"You restored {healManaRestoration}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You can't heal no more and wasted action.");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Wrong and wasted action.");
                        }
                        break;
                }

                playerHealth -= bossDamage;

                Console.WriteLine($"You got {bossDamage} damage.");
            }

            Console.Clear();

            if (playerHealth > 0)
            {
                Console.WriteLine("You won!");
            }
            else if (bossHealth > 0)
            {
                Console.WriteLine("You DIED.");
            }
            else
            {
                Console.WriteLine("Draw.");
            }

            Console.ReadKey();
        }
    }
}
