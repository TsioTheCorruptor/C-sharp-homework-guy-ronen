using System;
using System.Text;


namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string of exactly 12 characters:");
            string userInputString = getInputFromUser();

            analyzeString(userInputString);
        }

        private static String getInputFromUser()
        {
            string o_userInputString;
            while (true)
            {
                o_userInputString = Console.ReadLine();
                if (string.IsNullOrEmpty(o_userInputString) || o_userInputString.Length != 12)
                {
                    Console.WriteLine("Invalid input. Please enter exactly 12 characters.");
                }
                else
                {
                    return o_userInputString;
                }
            }
        }

        static void analyzeString(string i_inputString)
        {
            Console.WriteLine(String.Format("\nInput: {0}", i_inputString));

            bool isPalindrome = isPalindromeRecursive(i_inputString);
            Console.WriteLine(String.Format("Is palindrome (case insensitive): {0}", isPalindrome));

            // Determine if input is only digits or only letters
            string digitsOnlyString = extractDigits(i_inputString);
            string lettersOnlyString = extractLetters(i_inputString);

            if (digitsOnlyString.Length == i_inputString.Length)
            {
                // Input is all numbers
                bool dividesByThree = doesNumberDivideByThree(digitsOnlyString);
                Console.WriteLine(String.Format("Number {0} divides evenly by 3: {1}", digitsOnlyString, dividesByThree));
            }
            else if (lettersOnlyString.Length == i_inputString.Length)
            {
                // Input is all letters
                int uppercaseLetterCount = countUppercaseLetters(lettersOnlyString);
                Console.WriteLine(String.Format("Uppercase letters count: {0}", uppercaseLetterCount));

                bool areLettersSortedAscending = areLettersInAscendingOrder(lettersOnlyString);
                Console.WriteLine(String.Format("Letters sorted ascending (case insensitive): {0}", areLettersSortedAscending));
            }
        }

        static bool isPalindromeRecursive(string i_inputString)
        {
            return checkPalindrome(i_inputString, 0, i_inputString.Length - 1);
        }

        static bool checkPalindrome(string i_inputString, int i_leftIndex, int i_rightIndex)
        {
            bool o_isCurrentPalindrome = true;
            if (i_leftIndex < i_rightIndex)
            {
                if (Char.ToLower(i_inputString[i_leftIndex]) != Char.ToLower(i_inputString[i_rightIndex]))
                {
                    o_isCurrentPalindrome = false;
                }
                else
                {
                    o_isCurrentPalindrome = checkPalindrome(
                        i_inputString,
                        i_leftIndex + 1,
                        i_rightIndex - 1
                    );
                }
            }
            return o_isCurrentPalindrome;
        }

        static string extractDigits(string i_inputString)
        {
            StringBuilder o_digitsBuilder = new StringBuilder();
            foreach (char currentChar in i_inputString)
            {
                if (Char.IsDigit(currentChar))
                {
                    o_digitsBuilder.Append(currentChar);
                }
            }
            return o_digitsBuilder.ToString();
        }

        static bool doesNumberDivideByThree(string i_digitsOnlyString)
        {
            if (Int64.TryParse(i_digitsOnlyString, out long parsedNumber))
            {
                long remainder;
                Math.DivRem(parsedNumber, 3, out remainder);
                return remainder == 0;
            }
            return false;
        }

        static string extractLetters(string i_inputString)
        {
            StringBuilder lettersBuilder = new StringBuilder();
            foreach (char currentChar in i_inputString)
            {
                if (Char.IsLetter(currentChar))
                {
                    lettersBuilder.Append(currentChar);
                }
            }
            return lettersBuilder.ToString();
        }

        static int countUppercaseLetters(string i_lettersOnlyString)
        {
            int o_uppercaseLetterCount = 0;
            foreach (char currentChar in i_lettersOnlyString)
            {
                if (Char.IsUpper(currentChar))
                {
                    o_uppercaseLetterCount++;
                }
            }
            return o_uppercaseLetterCount;
        }

        static bool areLettersInAscendingOrder(string i_lettersOnlyString)
        {
            bool o_areSortedAscending = true;
            char previousCharLowercase = Char.ToLower(i_lettersOnlyString[0]);
            for (int index = 1; index < i_lettersOnlyString.Length; index++)
            {
                char currentCharLowercase = Char.ToLower(i_lettersOnlyString[index]);
                if (previousCharLowercase > currentCharLowercase)
                {
                    o_areSortedAscending = false;
                    break;
                }
                previousCharLowercase = currentCharLowercase;
            }
            return o_areSortedAscending;
        }
    }

}


