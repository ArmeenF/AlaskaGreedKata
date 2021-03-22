/*
 * Method Main:
 * I've included fixed value integer arrays (values 1-6) in the main method, which are also printed to the console.
 * We begin by creating an array, which is then passed to the Score() method.
 * 
 * Method Score:
 * Since we expect an int return value, Score() is initialized as an int method.
 * Method  Score() is the place where the array from main is passed to manage.
 * We first pass the original array to countDice() where we get a return type of a new array of integers
 *  From this new array of integers we pass it to the method CalculateScore() where we get a return of an integer value or the final score of the original array.
 * 
 * Method CountDice:
 * We use this method to determine how many of each value, from 1-6, are present in the original array and how many of those values should be allocated to the new array.
 * For example [ 1, 1, 1, 5, 1, ] ---> [ 4, 0, 0, 0, 1, 0]. We have four 1's and one 5
 * The foreach loop traverses through the original array where we look for specific cases, or specific values present in the original array from 1-6.
 * These specific cases are then assigned to the new array where deemed appropraite. For example, if three "1's" are present in the original array, then the new array at spot [0] would be set to 3.
 * Another example, if two "5's" are present in the original array, then the new array at spot [4] would be set to 2.
 * I figured this was the best way to handle the original array so we can see how much of each value was present in the original array when scoring the new array.
 * 
 * 
 * Method CalculateScore
 * The new array created from countDice() is now passed to CalculateScore() from method Score().
 * Now, according the the rules of the game, we can check the new array for how many of each value was present from the original array. 
 * Using a while loop with if statements inside, we check the new array for how many of each value was present in the original using the rules of the game.
 * For example, [ 4, 0, 0, 0, 1, 0] is passed to calculateScore() which tells us four "1's" and one "5" is present. The if statement that handles the 4 "1's" assigns the score of
 * 1000 plus any addtional "1's" present over a count of 3 (three of a kind). So, int ones = 1000 + ( (4 subtratced by 3 = 1) 1 * 100) = 1100
 * Then we chech all the other spots in the array till we check spot [4] in the array. spot [4] = 1. So, int fives =  50
 * Then at the end, checking each spot in the array we add up all the values and return and integer value, or the final score 
 * int score = 0, int ones = 1100, int twos = 0, int threes = 0, int fours = 0, int fives = 50, int sixes = 0 -----------> return score + ones + twos + threes + fours + fives + sixes; --------> returns a score of 1150
 * 
 */

using System;

namespace AlaskaGreedKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1,1,1,5,1]");
            Console.WriteLine("The score is: " + Score(new int[] { 1, 1, 1, 5, 1, }));
            Console.WriteLine("[2,3,4,6,2]");
            Console.WriteLine("The score is: " + Score(new int[] { 2, 3, 4, 6, 2, }));
            Console.WriteLine("[3,4,5,3,3]");
            Console.WriteLine("The score is: " + Score(new int[] { 3, 4, 5, 3, 3, }));
            Console.WriteLine("[1,5,1,2,4]");
            Console.WriteLine("The score is: " + Score(new int[] { 1, 5, 1, 2, 4, }));
            Console.WriteLine("[5,5,5,5,5] ");
            Console.WriteLine("The score is: " + Score(new int[] { 5, 5, 5, 5, 5, }));
            Console.ReadLine();
        }
        public static int Score(int[] dice)
        {
            return CalculateScores(CountDice(dice));
        }
        public static int[] CountDice(int[] dice)
        {
            int[] scoreArray = new int[] { 0, 0, 0, 0, 0, 0 };

            foreach (int number in dice)
            {
                switch (number)
                {
                    case 1:
                        scoreArray[0]++;
                        break;
                    case 2:
                        scoreArray[1]++;
                        break;
                    case 3:
                        scoreArray[2]++;
                        break;
                    case 4:
                        scoreArray[3]++;
                        break;
                    case 5:
                        scoreArray[4]++;
                        break;
                    default:
                        scoreArray[5]++;
                        break;
                }
            }
            return scoreArray;
        }
        public static int CalculateScores(int[] diceTally)
        {
            int score = 0;
            int ones = 0;
            int fives = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int sixes = 0;

            while (true)
            {
                if (diceTally[0] < 3)
                {
                    ones = diceTally[0] * 100;
                }
                if (diceTally[0] >= 3)
                {
                    ones = 1000 + (diceTally[0] - 3) * 100;
                }
                if (diceTally[4] < 3)
                {
                    fives = diceTally[4] * 50;
                }
                if (diceTally[4] >= 3)
                {
                    fives = 500 + (diceTally[4] - 3) * 50;
                }
                if (diceTally[1] < 3)
                {
                    twos = 0;
                }
                if (diceTally[1] >= 3)
                {
                    twos = 200;
                }
                if (diceTally[2] < 3)
                {
                    threes = 0;
                }
                if (diceTally[2] >= 3)
                {
                    threes = 300;
                }
                if (diceTally[3] < 3)
                {
                    fours = 0;
                }
                if (diceTally[3] >= 3)
                {
                    fours = 400;
                }
                if (diceTally[5] < 3)
                {
                    sixes = 0;
                }
                if (diceTally[5] >= 3)
                {
                    sixes = 600;
                }
                return score + ones + twos + threes + fours + fives + sixes;
            }
        }
    }
}