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

            string randomHero = GetRandomCharacter(heroes);
            string randomVillain = GetRandomCharacter(villians);
            string heroWeapon = GetWeapon();
            string villainWeapon = GetWeapon();
            Console.WriteLine($"{randomHero} with {heroWeapon} will fight {randomVillain} with {villainWeapon}");

        }

        public static string GetRandomCharacter(string[] someArray)
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
    }
}