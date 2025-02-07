﻿using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");

            if (int.TryParse(Console.ReadLine(), out int rolls) && rolls > 0)
            {
                // Call DiceSimulator class to simulate the rolls
                DiceSimulator simulator = new DiceSimulator();
                int[] rollResults = simulator.SimulateRolls(rolls);

                // Print results
                Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
                Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
                Console.WriteLine($"Total number of rolls = {rolls}.\n");

                for (int i = 2; i <= 12; i++)
                {
                    int percentage = (rollResults[i] * 100) / rolls;
                    string histogram = new string('*', percentage);
                    Console.WriteLine($"{i}: {histogram}");
                }

                Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
    }

    class DiceSimulator
    {
        public int[] SimulateRolls(int rolls)
        {
            // This is the array to track results for sums 2 through 12
            int[] results = new int[13];

            Random random = new Random();
            for (int i = 0; i < rolls; i++)
            {
                int die1 = random.Next(1, 7); // This assigns a random number between 1 and 6
                int die2 = random.Next(1, 7); // This also assigns a random number between 1 and 6 for the second dice.
                int sum = die1 + die2;
                results[sum]++;
            }

            return results;
        }
    }
}