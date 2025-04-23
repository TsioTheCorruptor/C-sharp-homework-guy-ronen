using System;


namespace Ex01_05
{
    class Program
    {
        static void Main()
        {
            string userInputId = PromptForValidId();
            Console.WriteLine();
            Console.WriteLine("Results for your number: {0}", userInputId);

            RunAnalysis(userInputId);
        }

        //Runs analysis steps b–e on a valid input
        static void RunAnalysis(string i_numberString)
        {
            int[] digitArray = ConvertStringToDigitArray(i_numberString);

            int countDigitsSmallerThanLeftmost = CountSmallerThanLeftmost(digitArray);
            int countDigitsDivisibleByThree = CountDivisibleBy3(digitArray);
            int differenceBetweenMaxAndMinDigits = DifferenceBetweenMaxAndMinDigits(digitArray);

            int digitWithMaxFrequency;
            int frequencyOfMostCommonDigit;
            GetMostFrequentDigit(digitArray, out digitWithMaxFrequency, out frequencyOfMostCommonDigit);

            Console.WriteLine(
                "Digits smaller than the left-most ({0}): {1}",
                digitArray[0],
                countDigitsSmallerThanLeftmost
            );
            Console.WriteLine("Digits divisible by 3: {0}", countDigitsDivisibleByThree);
            Console.WriteLine("Difference between largest and smallest: {0}", differenceBetweenMaxAndMinDigits);
            Console.WriteLine(
                "Most frequent digit: {0} (appears {1} times)",
                digitWithMaxFrequency,
                frequencyOfMostCommonDigit
            );
        }

        //Prompt until the user provides an 8-digit number
        static string PromptForValidId()
        {
            while (true)
            {
                Console.Write("Enter your 8-digit number: ");
                string i_userInput = Console.ReadLine();
                if (i_userInput != null)
                {
                    i_userInput = i_userInput.Trim();
                }
                else
                {
                    i_userInput = string.Empty;
                }

                if (!IsEightDigitNumeric(i_userInput))
                {
                    Console.WriteLine("Invalid format. Please enter exactly 8 digits.");
                    continue;
                }

                return i_userInput;
            }
        }

        //check length and all digits
        static bool IsEightDigitNumeric(string i_input)
        {
            if (i_input.Length != 8)
                return false;

            for (int i = 0; i < i_input.Length; i++)
            {
                if (!Char.IsDigit(i_input[i]))
                    return false;
            }
            return true;
        }

        //Convert string array of ints
        static int[] ConvertStringToDigitArray(string i_idString)
        {
            int[] digitArray = new int[i_idString.Length];
            for (int index = 0; index < i_idString.Length; index++)
            {
                digitArray[index] = i_idString[index] - '0';
            }
            return digitArray;
        }

        //Count digits smaller than the left-most digit
        static int CountSmallerThanLeftmost(int[] i_digitArray)
        {
            int referenceDigit = i_digitArray[0];
            int countSmaller = 0;
            foreach (int digit in i_digitArray)
            {
                if (digit < referenceDigit)
                    countSmaller++;
            }
            return countSmaller;
        }

        //Count digits divisible by 3
        static int CountDivisibleBy3(int[] i_digitArray)
        {
            int countDivBy3 = 0;
            foreach (int digit in i_digitArray)
            {
                if (digit % 3 == 0)
                    countDivBy3++;
            }
            return countDivBy3;
        }

        //Difference between the largest and smallest digit
        static int DifferenceBetweenMaxAndMinDigits(int[] i_digitArray)
        {
            int maxDigit = i_digitArray[0];
            int minDigit = i_digitArray[0];
            foreach (int digit in i_digitArray)
            {
                if (digit > maxDigit)
                    maxDigit = digit;
                if (digit < minDigit)
                    minDigit = digit;
            }
            return maxDigit - minDigit;
        }

        //Find the most frequent digit and its count (via out parameters)
        static void GetMostFrequentDigit(
            int[] i_digitArray,
            out int o_mostFrequentDigit,
            out int o_maxFrequency
        )
        {
            int[] digitCounts = new int[10];
            for (int i = 0; i < i_digitArray.Length; i++)
            {
                digitCounts[i_digitArray[i]]++;
            }

            o_mostFrequentDigit = 0;
            o_maxFrequency = digitCounts[0];
            for (int d = 1; d < digitCounts.Length; d++)
            {
                if (digitCounts[d] > o_maxFrequency)
                {
                    o_maxFrequency = digitCounts[d];
                    o_mostFrequentDigit = d;
                }
            }
        }
    }

}

