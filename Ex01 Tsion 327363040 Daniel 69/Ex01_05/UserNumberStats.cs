using System;

class UserNumberStats
{
    static void Main()
    {

        DisplayRunningExamples();


        string userInputId = PromptForValidId();
        Console.WriteLine($"\nResults for your number: {userInputId}");
        RunAnalysis(userInputId);
    }

    // Runs analysis steps b-e on a valid ID string
    static void RunAnalysis(string i_idString)
    {
        int[] digitArray = ConvertStringToDigitArray(i_idString);

        int countDigitsSmallerThanLeftmost = CountSmallerThanLeftmost(digitArray);
        int countDigitsDivisibleByThree = CountDivisibleBy3(digitArray);
        int differenceBetweenMaxAndMinDigits = DifferenceBetweenMaxAndMinDigits(digitArray);
        var (digitWithMaxFrequency, frequencyOfMostCommonDigit) = GetMostFrequentDigit(digitArray);

        Console.WriteLine($"Digits smaller than the left-most ({digitArray[0]}): {countDigitsSmallerThanLeftmost}");
        Console.WriteLine($"Digits divisible by 3: {countDigitsDivisibleByThree}");
        Console.WriteLine($"Difference between largest and smallest: {differenceBetweenMaxAndMinDigits}");
        Console.WriteLine($"Most frequent digit: {digitWithMaxFrequency} (appears {frequencyOfMostCommonDigit} times)");
    }

    // a. Prompt until the user provides an 8-digit numeric ID
    static string PromptForValidId()
    {
        while (true)
        {
            Console.Write("Enter your 8-digit number: ");
            string i_userInput = Console.ReadLine()?.Trim() ?? string.Empty;

            if (!IsEightDigitNumeric(i_userInput))
            {
                Console.WriteLine("Invalid format. Please enter exactly 8 digits.");
                continue;
            }

            return i_userInput;
        }
    }

    // Display example runs using RunAnalysis
    static void DisplayRunningExamples()
    {
        Console.WriteLine("=== Running Examples ===");
        string[] exampleInputs = new string[]
        {
            "31415926",
            "00770088",
            "10000008",
            "10000016"
        };

        foreach (string exampleId in exampleInputs)
        {
            Console.WriteLine($"\nExample input: {exampleId}");
            RunAnalysis(exampleId);
        }

        Console.WriteLine("\n=== End of Examples ===\n");
    }

    // check length and all digits
    static bool IsEightDigitNumeric(string i_input)
    {
        if (i_input.Length != 8)
            return false;
        foreach (char ch in i_input)
        {
            if (!Char.IsDigit(ch))
                return false;
        }
        return true;
    }

    // Convert string ID into an array of digits
    static int[] ConvertStringToDigitArray(string i_idString)
    {
        int[] digitArray = new int[i_idString.Length];
        for (int index = 0; index < i_idString.Length; index++)
        {
            digitArray[index] = i_idString[index] - '0';
        }
        return digitArray;
    }

    // Count digits smaller than the left-most digit
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

    // Count digits divisible by 3
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

    // Difference between the largest and smallest digit
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

    // Find the most frequent digit and its count
    static (int digit, int count) GetMostFrequentDigit(int[] i_digitArray)
    {
        int[] digitCounts = new int[10];
        foreach (int digit in i_digitArray)
        {
            digitCounts[digit]++;
        }
        int mostFrequentDigit = 0;
        int maxFrequency = digitCounts[0];
        for (int d = 1; d < digitCounts.Length; d++)
        {
            if (digitCounts[d] > maxFrequency)
            {
                maxFrequency = digitCounts[d];
                mostFrequentDigit = d;
            }
        }
        return (mostFrequentDigit, maxFrequency);
    }
}
