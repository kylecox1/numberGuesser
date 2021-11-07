using System;
using System.Collections.Generic;
using System.Text;

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

                Console.WriteLine(AddAllCounts(3));

                //Console.WriteLine(NumberGuesser(rand.Next(1, 101)));

                Console.Write("Play again (y/n): ");
                playAgain = PlayAgain();

            } while (playAgain == true);


            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }

        public static int GetIntWithinRange(string Prompt, int Min, int Max)
        {
            bool isValid = false;
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
                    Console.WriteLine($"Sorry, that was not between {Min} and {Max}.");
                }
                else
                {
                    isValid = true;
                    return guess;

                }
            } while (isValid == false);
            return -1;
        }


        public static double GetDoubleWithinRange(string Prompt, int Min, int Max)
        {
            bool isValid = false;
            double number = -1;

            do
            {
                bool isDouble = false;
                do
                {
                    Console.Write(Prompt);
                    string input = Console.ReadLine();
                    isDouble = double.TryParse(input, out number);

                    if (!isDouble)
                    {
                        Console.WriteLine("Sorry, numbers only please.");
                    }

                } while (isDouble == false);

                if (number < Min || number > Max)
                {
                    Console.WriteLine("Sorry, that was out of range.");
                }
                else
                {
                    isValid = true;
                    return number;
                }
            } while (isValid == false);
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
            }
            else if (numberOfGuesses < 10)
            {
                return "That's right! Under 10 guesses, you're pretty smart.";
            }
            else
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

        // Exercise 9
        static public string SelectLanguage()
        {
            Console.Write("Please enter a language: ");
            string input = Console.ReadLine();
            switch (input.ToLower().Trim())
            {
                case "english":
                    return "Hello, World!";
                case "spanish":
                    return "Hola Mundo!";
                case "dutch":
                    return "Hallo wereld!";
                default:
                    return "Sorry, I don't speak that one yet.";
            }

        }

        // Exercise 10
        static public string CheckHeight()
        {
            double height = GetDoubleWithinRange("Please enter your height in inches: ", 5, 108);
            double requiredHeight = 54;
            if (height < requiredHeight)
            {
                return $"Sorry, you cannot ride the Raptor. You need {requiredHeight - height} more inches.";
            }
            else
            {
                return "Great, you can ride the Raptor!";
            }
        }

        // Exercise 11
        static public string OutputNumberRange(int Min, int Max)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = Min; i <= Max; i++)
            {
                sb.AppendFormat($"{ i.ToString() } ");
            }
            return sb.ToString();
        }

        // Exercise 12
        static public string OutputNumberRangeReverse(int Max)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = Max; i >= 0; i--)
            {
                sb.AppendFormat($"{ i.ToString() } ");
            }
            return sb.ToString();
        }

        // Exercise 13
        static public string PromptNumberRangeReverse(string Prompt)
        {
            bool isInt = false;
            int number = -1;
            do
            {
                Console.Write(Prompt);
                string input = Console.ReadLine();
                isInt = Int32.TryParse(input, out number);

                if (!isInt)
                {
                    Console.WriteLine("Sorry, whole numbers only please.");
                }

            } while (isInt == false);

            StringBuilder sb = new StringBuilder("");
            for (int i = number; i >= 0; i--)
            {
                sb.AppendFormat($"{ i.ToString() } ");
            }
            return sb.ToString();
        }

        // Exercise 14
        static public string PromptNumberRangeSquares(string Prompt)
        {
            bool isInt = false;
            int number = -1;
            do
            {
                Console.Write(Prompt);
                string input = Console.ReadLine();
                isInt = Int32.TryParse(input, out number);

                if (!isInt)
                {
                    Console.WriteLine("Sorry, whole numbers only please.");
                }

            } while (isInt == false);

            StringBuilder sb = new StringBuilder("");
            for (int i = 1; i <= number; i++)
            {
                int square = i * i;
                sb.AppendFormat($"{ square.ToString() } ");
            }
            return sb.ToString();
        }

        // Exercise 15
        static public string PromptNumberRangeCubes(string Prompt)
        {
            bool isInt = false;
            int number = -1;
            do
            {
                Console.Write(Prompt);
                string input = Console.ReadLine();
                isInt = Int32.TryParse(input, out number);

                if (!isInt)
                {
                    Console.WriteLine("Sorry, whole numbers only please.");
                }

            } while (isInt == false);

            StringBuilder sb = new StringBuilder("");
            for (int i = 1; i <= number; i++)
            {
                int square = i * i * i;
                sb.AppendFormat($"{ square.ToString() } ");
            }
            return sb.ToString();
        }

        // Exercise 16
        public static string AsteriskPyramid(int BaseLength)
        {
            StringBuilder sb = new StringBuilder("");

            for (int i = 1; i <= BaseLength; i++)
            {
                StringBuilder sbLine = new StringBuilder("");
                for (int j = i; j > 0; j--)
                {
                    sbLine.AppendFormat("*");
                }
                sb.AppendFormat(sbLine.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        // Exercise 17
        public static string AsteriskPyramidCentered(int BaseLength)
        {
            StringBuilder sb = new StringBuilder("");
            int spaces = BaseLength * 2 -2; 
            for (int i = 1; i < BaseLength; i++)
            {
                for (int k = spaces; k >= BaseLength; k--)
                {
                    sb.AppendFormat(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    sb.AppendFormat("* ");
                }
                sb.Append(Environment.NewLine);
                spaces--;
            }
            return sb.ToString();
        }

        // Exercise 18
        public static int AddAllCounts(int number)
        {
            int total = 0;
            for (int i = 1; i <= number; i++)
            {
                total += i;
            }
            return total;
        }

        // Exercise 19 test
    }
}
