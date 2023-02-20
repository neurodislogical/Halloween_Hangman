using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanGame
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n   ____ ");
                Console.WriteLine("  |/   |");
                Console.WriteLine("  |     ");
                Console.WriteLine("  |     ");
                Console.WriteLine("  |     ");
                Console.WriteLine("  |     ");
                Console.WriteLine("  |     ");
                Console.WriteLine(" _|______");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n   ____   ");
                Console.WriteLine("  |/   |  ");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n   ____   ");
                Console.WriteLine("  |/   |  ");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n   ____   ");
                Console.WriteLine("  |/   |  ");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |   \\|  ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n   ____ ");
                Console.WriteLine("  |/   |");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |   \\|/ ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |       ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n   ____ ");
                Console.WriteLine("  |/   |");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |   \\|/ ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |   /   ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n   ____ ");
                Console.WriteLine("  |/   |");
                Console.WriteLine("  |  {;.;}");
                Console.WriteLine("  |   \\|/ ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |   / \\ ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
            else if (wrong == 7)
            {
                Console.WriteLine("\nYou have been defeated!");
                Console.WriteLine("\n   ____ ");
                Console.WriteLine("  |/   |");
                Console.WriteLine("  |  {x.x}");
                Console.WriteLine("  |   /|\\ ");
                Console.WriteLine("  |    |  ");
                Console.WriteLine("  |   / \\ ");
                Console.WriteLine("  |       ");
                Console.WriteLine(" _|______ ");
            }
        }
        private static int printWord(List<char> guessedLetters, string halloweenThemedWord)
        {
            int counter = 0;
            int correctLetters = 0;
            Console.Write("\r\n");
            foreach (char c in halloweenThemedWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    correctLetters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return correctLetters;
        }

        private static void printLines(string halloweenThemedWord)
        {
            Console.Write("\r");
            foreach (char c in halloweenThemedWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("BOO! Time to play Halloween Hangman...if you dare!");
            Console.WriteLine("            __   __");
            Console.WriteLine("           |  |_|  |______ _,___ _,___ _   _         \\--/");
            Console.WriteLine("           |   _   |__    |  __ |  __ | |_| |     /`-'  '-`\\");
            Console.WriteLine("           |__| |__|__-_,_| ,___| ,___|___, |    /          \\");
            Console.WriteLine("                          |_|   |_|       |_|   /.'|/\\  /\\|'.\\");
            Console.WriteLine("         __   __        _ _                           \\/");
            Console.WriteLine("        |  |_|  |______| | |______ __ _ __ ______ ______ _,____");
            Console.WriteLine("        |   _   |__    | | |  __  |  | |  |  --__|  --__|  __  \\");
            Console.WriteLine("        |__| |__|__-_,_|_|_|______|_______|______|______|_|  |_|");
            Console.WriteLine("\r\n");

            Random random = new Random();
            List<string> halloweenWordDictionary = new List<string> { "frankenstein", "dracula", "chucky", "pinhead", "bates", "krueger", "ghostface", "scream", "halloween", "pumpkin", "carrie", "vampire", "witches", "werewolf", "nightmare", "spider", "cobwebs" };
            int index = random.Next(halloweenWordDictionary.Count);
            String randomHalloweenWord = halloweenWordDictionary[index];

            foreach (char x in randomHalloweenWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomHalloweenWord.Length;
            int amountOfIncorrectGuesses = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersCorrect = 0;

            while (amountOfIncorrectGuesses != 7 && currentLettersCorrect != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed thus far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + ", ");
                }
                // User Input Prompt
                Console.Write("\nCan you conjure a correct letter?\nMake your guess: ");
                char letterGuessed = Console.ReadLine()[0];
                // Review if letter has been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\nFOOL! This guess has already been made!");
                    printHangman(amountOfIncorrectGuesses);
                    currentLettersCorrect = printWord(currentLettersGuessed, randomHalloweenWord);
                    printLines(randomHalloweenWord);
                }
                else
                {
                    //Review if letter is in word
                    bool correct = false;
                    for (int i = 0; i < randomHalloweenWord.Length; i++)
                    {
                        if (letterGuessed == randomHalloweenWord[i])
                        {
                            correct = true;
                        }
                    }
                    if (correct)
                    {
                        printHangman(amountOfIncorrectGuesses);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersCorrect = printWord(currentLettersGuessed, randomHalloweenWord);
                        Console.Write("\r\n");
                        printLines(randomHalloweenWord);
                    }
                    else
                    {
                        amountOfIncorrectGuesses++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountOfIncorrectGuesses);
                        currentLettersCorrect = printWord(currentLettersGuessed, randomHalloweenWord);
                        Console.Write("\r\n");
                        printLines(randomHalloweenWord);
                    }
                                    }
            }
            //Game Over
            Console.WriteLine("\r\nGAME OVER!!!...Why not play again?");
        }
    }
}

