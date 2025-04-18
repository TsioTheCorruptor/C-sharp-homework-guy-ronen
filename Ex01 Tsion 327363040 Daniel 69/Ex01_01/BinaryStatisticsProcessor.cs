using System;
using System.Linq;

public class BinaryStatisticsProcessor
{
    private string[] m_binaryInputs;
    private int[] m_decimalValues;

    public BinaryStatisticsProcessor(string[] i_binaryInputs)
    {
        m_binaryInputs = i_binaryInputs;
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

    private int CountDifferingBits(string i_binaryA, string i_binaryB)
    {
        int count = 0;
        for (int i = 0; i < i_binaryA.Length; i++)
        {
            if (i_binaryA[i] != i_binaryB[i]) count++;
        }
        return count;
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
        RunOneExample("A", new[] { "1111111", "0001110", "1110000", "1010101" });
        RunOneExample("B", new[] { "1011011", "0111110", "1000001", "0000000" });
        RunOneExample("C", new[] { "0011001", "1100110", "1010101", "0101010" });
        RunOneExample("D", new[] { "1001100", "1110001", "0011011", "0110110" });
    }

    private static void RunOneExample(string i_label, string[] i_inputs)
    {
        Console.WriteLine($"\n==== Example {i_label} ====");
        Console.WriteLine(string.Join(", ", i_inputs));

        var processor = new BinaryStatisticsProcessor(i_inputs);
        processor.RunAllAnalysis();
        Console.WriteLine($"\n==== Example {i_label} End ====");
    }

    public static void Main()
    {

        RunMultipleExamples();

        Console.WriteLine("Enter 4 binary numbers (each 7 digits):");
        string[] userInputs = new string[4];
        for (int i = 0; i < 4; i++)
        {
            userInputs[i] = Console.ReadLine();
        }

        var processor = new BinaryStatisticsProcessor(userInputs);
        processor.RunAllAnalysis();
    }
}