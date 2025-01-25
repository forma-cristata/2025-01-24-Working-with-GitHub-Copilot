using System;
using System.Collections.Generic;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayHangman();
        }

        static void PlayHangman()
        {
            string[] words = { "programming", "hangman", "challenge", "computer", "software" };
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            List<char> incorrectGuesses = new List<char>();
            int attemptsLeft = 6;

            while (attemptsLeft > 0 && new string(guessedWord) != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine("Hangman Game");
                Console.WriteLine("Word to guess: " + new string(guessedWord));
                Console.WriteLine("Incorrect guesses: " + string.Join(", ", incorrectGuesses));
                Console.WriteLine("Attempts left: " + attemptsLeft);
                DrawHangman(attemptsLeft);
                Console.Write("Enter a letter: ");
                char guess = Console.ReadLine()[0];

                if (wordToGuess.Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            guessedWord[i] = guess;
                        }
                    }
                }
                else
                {
                    if (!incorrectGuesses.Contains(guess))
                    {
                        incorrectGuesses.Add(guess);
                        attemptsLeft--;
                    }
                }
            }

            Console.Clear();
            if (new string(guessedWord) == wordToGuess)
            {
                Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
            }
            else
            {
                Console.WriteLine("Game over! The word was: " + wordToGuess);
            }
        }

        static void DrawHangman(int attemptsLeft)
        {
            switch (attemptsLeft)
            {
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
            }
        }
    }
}

