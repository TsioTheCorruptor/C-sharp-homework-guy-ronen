using System;
using System.Linq;

public class BinaryStatisticsProcessor
{
    private string[] m_binaryInputs;
    private int[] m_decimalValues;

    public BinaryStatisticsProcessor()
    {

        m_binaryInputs = new string[4];
        m_decimalValues = new int[4];


        Console.WriteLine("Enter 4 binary numbers (each exactly 8 digits):");
        for (int i = 0; i < m_binaryInputs.Length; i++)
        {
            m_binaryInputs[i] = ReadValidatedBinary(i);
        }

  
        ConvertInputsToDecimal();
    }

    private BinaryStatisticsProcessor(string[] inputs)
    {
        m_binaryInputs = inputs;
        m_decimalValues = new int[4];
        ConvertInputsToDecimal();
    }

    public void RunAllAnalysis()
    {
        DisplayDecimalValuesInDecendingOrder();
        DisplayStatistics();
        DisplayLongestStreakOfConsecutiveOnes();
        DisplayBitFlipCountsPerNumber();
        DisplayBinaryWithMostOnes();
        DisplayTotalNumberOfOnes();
    }
    private static string ReadValidatedBinary(int index, int requiredLength = 8)
    {
        while (true)
        {
            Console.Write($"  #{index + 1}: ");
            var input = Console.ReadLine()?.Trim();
            if (IsValidBinary(input, requiredLength))
            {
                return input;
            }
            Console.WriteLine($"    → Invalid: must be exactly {requiredLength} characters of ‘0’ or ‘1’.");
        }
    }

    private static bool IsValidBinary(string s, int length)
        => !string.IsNullOrEmpty(s)
           && s.Length == length
           && s.All(c => c == '0' || c == '1');

    private void ConvertInputsToDecimal()
    {
        for (int inputIndex = 0; inputIndex < m_binaryInputs.Length; inputIndex++)
        {
            m_decimalValues[inputIndex] = Convert.ToInt32(m_binaryInputs[inputIndex], 2);
        }
    }

    private void DisplayDecimalValuesInDecendingOrder()
    {
        int[] sortedDecimalValues = (int[])m_decimalValues.Clone();
        Array.Sort(sortedDecimalValues);
        Array.Reverse(sortedDecimalValues);

        Console.WriteLine("\nDecimal values in decending order:");
        Console.WriteLine(string.Join(", ", sortedDecimalValues));
    }

    private void DisplayStatistics()
    {
        double averageValue = m_decimalValues.Average();
        int minValue = m_decimalValues.Min();
        int maxValue = m_decimalValues.Max();
        int range = Math.Abs(maxValue - minValue);

        string averageLine = string.Format("\nAverage: {0}", averageValue);

        Console.WriteLine(averageLine);
    }

    private void DisplayBitFlipCountsPerNumber()
    {
        Console.WriteLine("\nTotal number of bit flips for each number:");

        foreach (string binary in m_binaryInputs)
        {
            int totalFlips = 0;

            for (int i = 1; i < binary.Length; i++)
            {
                if (binary[i] != binary[i - 1])
                {
                    totalFlips++;
                }
            }

            Console.WriteLine($"({binary}) {totalFlips}");
        }
    }


    private void DisplayBinaryWithMostOnes()
    {
        int maxOnes = m_binaryInputs.Max(b => b.Count(c => Char.Equals(c, '1')));
        string binary = m_binaryInputs.First(b => b.Count(c => c == '1') == maxOnes);
        int decimalValue = Convert.ToInt32(binary, 2);

        string output = string.Format("\nNumber with most 1s: {0} ({1})", decimalValue, binary);
        Console.WriteLine(output);
    }

    private void DisplayLongestStreakOfConsecutiveOnes()
    {
        int maxStreakLength = 0;
        string binaryWithLongestStreak = "";

        foreach (string binary in m_binaryInputs)
        {
            int currentStreak = 0;
            int longestStreakInThisBinary = 0;

            foreach (char bit in binary)
            {
                if (Char.Equals(bit, '1'))
                {
                    currentStreak++;
                    if (currentStreak > longestStreakInThisBinary)
                    {
                        longestStreakInThisBinary = currentStreak;
                    }
                }
                else
                {
                    currentStreak = 0;
                }
            }

            if (longestStreakInThisBinary > maxStreakLength)
            {
                maxStreakLength = longestStreakInThisBinary;
                binaryWithLongestStreak = binary;
            }
        }

        string output = string.Format("Longest streak of 1s: {0} (in {1})", maxStreakLength, binaryWithLongestStreak);
        Console.WriteLine(output);
    }

    private void DisplayTotalNumberOfOnes()
    {
        int totalOnes = m_binaryInputs.Sum(b => b.Count(c => c == '1'));
        Console.WriteLine($"Total number of 1s: {totalOnes}");
    }

    public static void RunMultipleExamples()
    {
        RunOneExample("A", new[] { "11111111", "00011100", "11100000", "10101010" });
        RunOneExample("B", new[] { "10110110", "01111100", "10000011", "00000000" });
        RunOneExample("C", new[] { "00110010", "11001101", "10101010", "01010101" });
        RunOneExample("D", new[] { "10011001", "11100010", "00110111", "01101100" });
    }

    private static void RunOneExample(string label, string[] inputs)
    {
        Console.WriteLine($"\n==== Example {label} ====");
        Console.WriteLine(string.Join(", ", inputs));
        var proc = new BinaryStatisticsProcessor(inputs); 
        proc.RunAllAnalysis();
        Console.WriteLine($"==== Example {label} End ====");
    }

    public static void Main()
    {
        RunMultipleExamples();

        Console.WriteLine("\n--- Interactive Mode ---");
        var processor = new BinaryStatisticsProcessor();   
        processor.RunAllAnalysis();
    }
}