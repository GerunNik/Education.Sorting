using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to sort");
            string stringToSort = Console.ReadLine();

            string sortedBubbleString = BubbleSort(stringToSort);
            string sortedMergeString = MergeSort(stringToSort);

            Console.WriteLine(sortedBubbleString);
            Console.WriteLine(sortedMergeString);
            Console.ReadKey();
        }

        public static string BubbleSort(string value)
        {
            char[] sortingString = value.ToCharArray();

            for (int totalSizeOfString = sortingString.Length; totalSizeOfString > 1; --totalSizeOfString)
            {
                for (int currentPositionInString = 0; currentPositionInString < totalSizeOfString-1; ++currentPositionInString)
                {
                    if (sortingString[currentPositionInString] > sortingString[currentPositionInString+1])
                    {
                        SwapArray(ref sortingString[currentPositionInString], ref sortingString[currentPositionInString+1]);
                    }
                }
            }
            string finishedString = "";
            foreach (var item in sortingString)
            {
                finishedString = finishedString + item; 
            }

            return finishedString;

        }
        public static string MergeSort(string value)
        {
            char[] sortingString = value.ToCharArray();
            string finalString = "";
            
            if (sortingString.Length > 1)
            {
                int currentChar = 0;
                List<char> firstHalf = new List<char>();
                List<char> secondHalf = new List<char>();
                foreach (char item in sortingString) //Den String auf zwei aufteilen
                {
                    if (currentChar * 2 < sortingString.Length)
                    {
                        firstHalf.Add(item);
                        currentChar++;
                    }
                    else
                    {
                        secondHalf.Add(item);
                        currentChar++;
                    }
                }

                if (firstHalf.Count > 1) //Falls die hälfte mehr als zwei hat
                {
                    string leftString = "";
                    foreach (var item in firstHalf)
                    {
                        leftString = leftString + item;
                    }
                    leftString = MergeSort(leftString);
                    firstHalf.Clear();
                    foreach (var item in leftString)
                    {
                        firstHalf.Add(item);
                    }
                }
                if (secondHalf.Count > 1) //Falls die hälfte mehr als zwei hat
                {
                    string rightString = "";
                    foreach (var item in secondHalf)
                    {
                        rightString = rightString + item;
                    }
                    rightString = MergeSort(rightString);
                    secondHalf.Clear();
                    foreach (var item in rightString)
                    {
                        secondHalf.Add(item);
                    }
                }
                string finalLeftString = "";
                foreach (var item in firstHalf)
                {
                    finalLeftString = finalLeftString + item;
                }
                string finalRightString = "";
                foreach (var item in secondHalf)
                {
                    finalRightString = finalRightString + item;
                }

                finalString = finalLeftString + finalRightString;
                finalString = BubbleSort(finalString);     
            }
            return finalString;
        }

        public static void SwapArray(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
