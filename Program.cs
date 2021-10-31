using System;
using System.Collections.Generic;

namespace Day04Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            bool playAgain = true;

            do
            {  
                Console.WriteLine(NumberGuesser(rand.Next(1, 101)));

                Console.Write("Play again (y/n): ");
                playAgain = PlayAgain();

            } while (playAgain == true);
            

            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }

        public static int GetIntWithinRange(string Prompt, int Min, int Max)
        {
            bool isValidGuess = false;
            int guess = -1;

            do
            {
                bool isInt = false;
                do
                {
                    Console.Write(Prompt);
                    string input = Console.ReadLine();
                    isInt = Int32.TryParse(input, out guess);

                    if (!isInt)
                    {
                        Console.WriteLine("Sorry, whole numbers only please.");
                    }

                } while (isInt == false);
                
                if (guess < Min || guess > Max)
                {
                    Console.WriteLine("Sorry, that was not between 1 and 100.");
                }
                else
                {
                    isValidGuess = true;
                    return guess;
                    
                }
            } while (isValidGuess == false);
            return -1;
        }

        static public string NumberGuesser(int number)
        {
            bool correctGuess = false;
            int numberOfGuesses = 0;
            int guess = GetIntWithinRange("What is your guess? 1-100: ", 1, 100);

            do
            {
                if (guess - number > 10)
                {
                    numberOfGuesses++;
                    Console.WriteLine("Way too high!");
                    guess = GetIntWithinRange("Enter a lower number: ", 1, 100);
                }
                else if (guess < number && (number - guess) > 10) 
                {
                    numberOfGuesses++;
                    Console.WriteLine("Way too low!");
                    guess = GetIntWithinRange("Enter a bigger number: ", 1, 100);
                }
                else if (guess < number)
                {
                    numberOfGuesses++;
                    Console.WriteLine("My number is bigger than that.");
                    guess = GetIntWithinRange("Enter a something higher: ", 1, 100);
                }
                else if (guess > number)
                {
                    numberOfGuesses++;
                    Console.WriteLine("My number is smaller than that.");
                    guess = GetIntWithinRange("Enter a something higher: ", 1, 100);
                }
                else if (guess == number)
                {
                    numberOfGuesses++;
                    correctGuess = true;
                }
            } while (correctGuess == false);
            
            if (numberOfGuesses == 1)
            {
                return "WOW! That's right!! You got it in one guess!";
            } else if (numberOfGuesses < 10)
            {
                return "That's right! Under 10 guesses, you're pretty smart.";
            } else
            {
                return "That it. Glad you finally got it!";
            }
        }

        static public bool PlayAgain()
        {
            bool isValidYesNo = false;
            do
            {
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "n")
                {
                    return false;
                }
                else if (input.Trim().ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please just enter a 'y' or an 'n'.");
                }
            } while (isValidYesNo == false);
            return false;
        }
    }
}
