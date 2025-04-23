using System;


namespace Ex01_03
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
        static void Main()
        {
           
            bool result = int.TryParse(Console.ReadLine(), out treeHeight);
            treeMiddle =treeLevelDistanceFromBorder + treeHeight ;
            spacePrintAmount  =treeMiddle ;
            
            while(currentTreeheight<treeHeight)
            {
                printLettersAndSpaces();

                printDigitsInTreeLevel(currentTreeheight);
               currentTreeheight++;
                
            }

        }   
        static void printDigitsInTreeLevel(int i_level)
        {
            int amountToPrint = 1 + (treeWidthMultiplier * i_level);
            int currentDigit = minDigitToPrint;
            for (int i = 0; i < amountToPrint; i++)
            {
               
                currentDigit = currentDigitToPrint % maxDigitToPrint; 
                if (currentDigit ==0 ) { currentDigit = minDigitToPrint;currentDigitToPrint = minDigitToPrint; }

                Console.Write(currentDigit);
                ++currentDigitToPrint;
            }
            Console.WriteLine();

        }
        static void printLettersAndSpaces()
        {
            Console.Write(currentLetterToPrint);
            printSpaces(spacePrintAmount);
            spacePrintAmount--;

            if (currentLetterToPrint == 'X')
                currentLetterToPrint = 'A';
            else
                currentLetterToPrint++;
            

        }
        static void printSpaces(int i_printAmount)
        {
            for (int i = 0; i < i_printAmount; i++)
                Console.Write(" ");
        }
    }
}




