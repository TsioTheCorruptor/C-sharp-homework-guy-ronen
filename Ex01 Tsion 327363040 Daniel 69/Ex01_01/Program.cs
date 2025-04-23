using System;


namespace Ex01_01
{
    public class Program
    {
        private string[] m_binaryInputs;
        private int[] m_decimalValues;

        public Program()
        {
            m_binaryInputs = new string[4];
            m_decimalValues = new int[4];
            

            Console.WriteLine("Enter 4 binary numbers (each exactly {0} digits):", 8);
            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                m_binaryInputs[i] = ReadValidatedBinary(i);
            }

            ConvertInputsToDecimal();
        }

        private void RunAllAnalysis()
        {
            DisplayDecimalValuesInDescendingOrder();
            DisplayStatistics();
            DisplayLongestStreakOfConsecutiveOnes();
            DisplayBitFlipCountsPerNumber();
            DisplayBinaryWithMostOnes();
            DisplayTotalNumberOfOnes();
        }

        private static string ReadValidatedBinary(int index)
        {
            while (true)
            {
                Console.Write("  #" + (index + 1).ToString() + ": ");
                string input = Console.ReadLine();
                if (IsValidBinary(input, 8))
                {
                    return input;
                }
                Console.WriteLine("    → Invalid: must be exactly {0} characters of '0' or '1'.", 8);
            }
        }

        private static bool IsValidBinary(string i_string_to_check, int i_length)
        {
            if (i_string_to_check == null || i_string_to_check.Length != i_length)
                return false;
            for (int i = 0; i < i_string_to_check.Length; i++)
            {
                if (i_string_to_check[i] != '0' && i_string_to_check[i] != '1')
                    return false;
            }
            return true;
        }

        private void ConvertInputsToDecimal()
        {
            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                m_decimalValues[i] = Convert.ToInt32(m_binaryInputs[i], 2);
            }
        }

        private void DisplayDecimalValuesInDescendingOrder()
        {
            int[] sortedValues = new int[m_decimalValues.Length];
            for (int i = 0; i < m_decimalValues.Length; i++)
                sortedValues[i] = m_decimalValues[i];

            Array.Sort(sortedValues);
            Array.Reverse(sortedValues);

            Console.WriteLine();
            Console.WriteLine("Decimal values in descending order:");
            for (int i = 0; i < sortedValues.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(sortedValues[i].ToString());
            }
            Console.WriteLine();
        }

        private void DisplayStatistics()
        {
            int sum = 0;
            for (int i = 0; i < m_decimalValues.Length; i++)
                sum += m_decimalValues[i];

            double average = (double)sum / m_decimalValues.Length;

            Console.WriteLine();
            Console.WriteLine("Average: {0}", average);
        }

        private void DisplayBitFlipCountsPerNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Total number of bit flips for each number:");
            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                string binary = m_binaryInputs[i];
                int flips = 0;
                for (int j = 1; j < binary.Length; j++)
                {
                    if (binary[j] != binary[j - 1])
                        flips++;
                }
                Console.WriteLine("({0}) {1}", binary, flips);
            }
        }

        private void DisplayBinaryWithMostOnes()
        {
            int maxOnes = -1;
            string binaryMostOnes = null;

            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                string b = m_binaryInputs[i];
                int countOnes = 0;
                for (int j = 0; j < b.Length; j++)
                    if (b[j] == '1') countOnes++;

                if (countOnes > maxOnes)
                {
                    maxOnes = countOnes;
                    binaryMostOnes = b;
                }
            }

            int decValue = Convert.ToInt32(binaryMostOnes, 2);
            Console.WriteLine();
            Console.WriteLine("Number with most 1s: {0} ({1})", decValue, binaryMostOnes);
        }

        private void DisplayLongestStreakOfConsecutiveOnes()
        {
            int maxStreak = 0;
            string bestBinary = null;

            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                string b = m_binaryInputs[i];
                int currentStreak = 0;
                int longestThis = 0;

                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] == '1')
                    {
                        currentStreak++;
                        if (currentStreak > longestThis)
                            longestThis = currentStreak;
                    }
                    else
                    {
                        currentStreak = 0;
                    }
                }

                if (longestThis > maxStreak)
                {
                    maxStreak = longestThis;
                    bestBinary = b;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Longest streak of 1s: {0} (in {1})", maxStreak, bestBinary);
        }

        private void DisplayTotalNumberOfOnes()
        {
            int totalOnes = 0;
            for (int i = 0; i < m_binaryInputs.Length; i++)
            {
                string b = m_binaryInputs[i];
                for (int j = 0; j < b.Length; j++)
                    if (b[j] == '1') totalOnes++;
            }
            Console.WriteLine();
            Console.WriteLine("Total number of 1s: {0}", totalOnes);
        }

        public static void Main(string[] args)
        {
            Program processor = new Program();
            processor.RunAllAnalysis();
        }
    }

}

