using System;


namespace Ex01_02
{
    internal class Program
    {
        private static int currentDigitToPrint = 1;
        private static int maxDigitToPrint = 10;
        private static int minDigitToPrint = 1;
        private static int treeLevelDistanceFromBorder = 2;
        private static int treeHeight = 0;
        private static int currentTreeheight = 0;
        private static int treeWidthMultiplier = 2;
        private static char currentLetterToPrint = 'A';
        private static int spacePrintAmount = 0;
        private static int treeMiddle = 0;
        private static int trunkLength = 2;
        static void Main()
        {

            treeHeight = 5;
            printTree();

        }
        private static void printTree()
        {
            treeMiddle = treeLevelDistanceFromBorder + treeHeight;
            spacePrintAmount = treeMiddle;

            while (currentTreeheight < treeHeight)
            {
                printLettersAndSpaces();

                printDigitsInTreeLevel(currentTreeheight);
                currentTreeheight++;

            }
            printTrunk();

        }
        
        private static void printDigitsInTreeLevel(int i_level)
        {
            int amountToPrint = 1 + (treeWidthMultiplier * i_level);
            int currentDigit = minDigitToPrint;
            for (int i = 0; i < amountToPrint; i++)
            {

                currentDigit = GetCorrectDigit();


                Console.Write(currentDigit);
                ++currentDigitToPrint;
            }
            Console.WriteLine();

        }
        private static void printLettersAndSpaces()
        {
            Console.Write(currentLetterToPrint);
            printSpaces(spacePrintAmount);
            spacePrintAmount--;

            AdvenceLetter();


        }
        private static void printSpaces(int i_printAmount)
        {
            for (int i = 0; i < i_printAmount; i++)
                Console.Write(" ");
        }
        private static void printTrunk()
        {
            for (int i = 0; i < trunkLength; i++)
            {
                Console.Write(currentLetterToPrint);
                printSpaces(treeMiddle-1);
                Console.WriteLine("|{0}|", GetCorrectDigit());
                
                AdvenceLetter();
            }

        }
        private static int GetCorrectDigit()
        {
            int correctDigit = 0;
            correctDigit = currentDigitToPrint % maxDigitToPrint;
            if (correctDigit == 0) { correctDigit = minDigitToPrint; currentDigitToPrint = minDigitToPrint; }
            return correctDigit;
        }
        private static void AdvenceLetter()
        {
            if (currentLetterToPrint == 'X')
                currentLetterToPrint = 'A';
            else
                currentLetterToPrint++;
        }
    }
}

