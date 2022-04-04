
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;



namespace HangmanGame
{

    class Program
    {
        public static string returnInput { get; private set; }

        static void Main(string[] args)
        {
            string userInput;
            bool win = false,
            doublesChecker = false;
            int winPoint = 0;
            int losePoint = 0;

           
            WriteLine("Welcome to play Hangman Game\n\n");  //asking for userinput
            WriteLine("Enter a word in lowercase.");
            userInput = ReadLine();
            Console.Clear();


            string[] newName = new string[userInput.Length];
            string[] guessedLetters = new string[26];
            string[] space = new string[26];
            
                for (int i = 0; i < userInput.Length; i++)
                {
                    newName[i] = userInput.Substring(i, 1);
                }

           
            string[] hiddenWord = new string[userInput.Length];
            for (int h = 0; h < userInput.Length; h++)
            {
                hiddenWord[h] = "_ ";
            }

            
            string[] wrongChoices = new string[7];
            for (int w = 0; w < 7; w++)
            {
                wrongChoices = HangDudes(w);

            }

            _ = new bool[userInput.Length];



            while (win == false && losePoint < 6)
            {
                bool tripleCheck = false;

                Write("Letters Guessed: ");
                for (int g = 0; g < 5; g++)
                {
                    Write(space[g] + " ");
                    Write(guessedLetters[g] + "");
                }
                WriteLine();

                WriteLine(wrongChoices[losePoint]);
                for (int s = 0; s < userInput.Length; s++)
                {
                    Write(hiddenWord[s]);
                }
                WriteLine();

                string guess = GuessFunction();

                                
                for (int l = 0; l < userInput.Length; l++)
                {
                    if (guess == hiddenWord[l])
                    {
                        doublesChecker = true;
                    }
                    else if (guess == newName[l])
                    {
                        tripleCheck = true;
                        hiddenWord[l] = guess;
                        winPoint++;
                        guessedLetters[winPoint] = guess;

                    }


                    if (winPoint != userInput.Length)
                    {
                        win = false;
                    }
                    else
                    {
                        win = true;
                    }


                }
                for (int m = 0; m <= 6; m++)
                {
                    if (guess == space[m])
                        doublesChecker = true;
                }
                if (tripleCheck == true)
                    WriteLine(guess + " fits in.");
                else if (tripleCheck == false)
                {
                    WriteLine("not good..");
                    losePoint++;
                    space[losePoint] = guess;

                }
                else if (doublesChecker == true)
                    WriteLine("Double inputted.Please enter another letter.");





            }
            //Deciding win/lose
            if (win == true)
                WriteLine("Congratulations! You won!");
            else
                WriteLine("Sorry. The correct answer was: " + newName);
            Console.ReadKey();
        }

        //function to ask for a guess
        static string GuessFunction()
        {
            WriteLine("Enter a only one letter: ");
            returnInput = Console.ReadLine().ToLower();
            int check = returnInput.Length;
            while (check > 1)
            {
                WriteLine("More than one letter typed, please try again!");
                Console.Write("> ");
                returnInput = Console.ReadLine().ToLower();
                check = returnInput.Length;
                Console.Clear();
            }
            return returnInput;

        }





        static string[] HangDudes(int a)
        {
            string[] dudes = { @"
  +---+
  |   |
      |
      |
      |
      |
=========", @"
  +---+
  |   |
  O   |
      |
      |
      |
=========", @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========", @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========" 
            };
            return dudes;

        }

    }

}