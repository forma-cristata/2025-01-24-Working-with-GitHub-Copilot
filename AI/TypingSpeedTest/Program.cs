using System;
using System.Diagnostics;

namespace TypingSpeedTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartTypingSpeedTest();
        }

        static void StartTypingSpeedTest()
        {
            string[] sentences = {
                "The quick brown fox jumps over the lazy dog.",
                "A journey of a thousand miles begins with a single step.",
                "To be or not to be, that is the question.",
                "All that glitters is not gold.",
                "The pen is mightier than the sword."
            };

            Random random = new Random();
            double totalSeconds = 0;
            int successfulTries = 0;

            Console.WriteLine("Typing Speed Test");
            Console.WriteLine("Type the following sentence as quickly and accurately as you can:");
            Console.WriteLine("Press Enter when you are ready to start...");

            Console.ReadLine();

            while (successfulTries < 3)
            {
                string sentenceToType = sentences[random.Next(sentences.Length)];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sentenceToType);
                Console.ResetColor();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (true)
                {
                    string userInput = Console.ReadLine();
                    stopwatch.Stop();

                    if (userInput == sentenceToType)
                    {
                        Console.WriteLine("Congratulations! You typed the sentence correctly.");
                        Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds} seconds");
                        totalSeconds += stopwatch.Elapsed.TotalSeconds;
                        successfulTries++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You made a mistake. Please try again:");
                        stopwatch.Start();
                    }
                }
            }

            double averageTime = totalSeconds / 3;
            double wordsPerMinute = (sentences[0].Split(' ').Length / averageTime) * 60;

            Console.WriteLine($"Your average time for three successful tries is: {averageTime} seconds");
            Console.WriteLine($"Your typing speed is: {wordsPerMinute} words per minute");
        }
    }
}

