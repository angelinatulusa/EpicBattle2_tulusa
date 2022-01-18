using System;
using System.IO;

namespace EpicBattle
{
    class Program
    {
        static void Main(string[] args)
        {

            string rootPath = @"C:\Users\opilane\samples\";
            string[] heroes = GetDataFromFile(rootPath + "heroes.txt");
            string[] villians = GetDataFromFile(rootPath + "villians.txt");
            string[] weapon = GetDataFromFile(rootPath + "weapon.txt");
            string[] armor = GetDataFromFile(rootPath + "armor.txt");

            string randomHero = GetRandomElement(heroes);
            string randomVillain = GetRandomElement(villians);
            string heroWeapon = GetRandomElement(weapon);
            string villainWeapon = GetRandomElement(weapon);
            string heroArmor = GetRandomElement(armor);
            string villainArmor = GetRandomElement(armor);
            int heroHP = GenerateHP(heroArmor);
            int villainHP = GenerateHP(villainArmor);

            Console.WriteLine($"{heroArmor} gives {randomHero} {heroHP} HP.");
            Console.WriteLine($"{villainArmor} gives {randomVillain} {villainHP} HP.");

            Console.WriteLine($"{randomHero} with {heroWeapon} will fight {randomVillain} with {villainWeapon}");

            while(heroHP >= 0 && villainHP >= 0)
            {
                heroHP = heroHP - Hit(randomVillain, villainWeapon);
                villainHP = villainHP - Hit(randomHero, heroWeapon);
            }
            if (heroHP > villainHP)
            {
                Console.WriteLine($"{randomHero} saves the day!");
            }else if(heroHP < villainHP)
            {
                Console.WriteLine("Dark side wins!");
            }else
            {
                Console.WriteLine($"{randomHero} and {randomVillain} dropped dead.");
            }

        }

        public static string GetRandomElement(string[] someArray)
        {
            return someArray[GetRandomIndexForArray(someArray)];
        }

        public static string GetWeapon()
        {

            string rootPath = @"C:\Users\opilane\samples\";
            string[] weapon = GetDataFromFile(rootPath + "weapon.txt");

            //string[] weapon = { "plastic fork", "flip-flop", "light saber", "magic wand", "banana" };
            return weapon[GetRandomIndexForArray(weapon)];
        }

        public static int GetRandomIndexForArray(string[] someArray)
        {
            Random rnd = new Random();
            return rnd.Next(0, someArray.Length);
        }
        public static string[] GetDataFromFile(string filePath)
        {
            string[] dataFromFile = File.ReadAllLines(filePath);
            return dataFromFile;
        }

        public static int GenerateHP(string armor)
        {
            return armor.Length;
        }

        public static int Hit(string character, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length - 2);
            Console.WriteLine($"{character} hit {strike}.");

            if (strike==0)
            {
                Console.WriteLine($"Bad luck.{character} missed thr target.");
            }else if(strike == weapon.Length - 2)
            {
                Console.WriteLine($"Awesome! {character} made s critical hit!");
            }

            return strike;
        }
    }
}
