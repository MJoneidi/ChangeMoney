using System;
using System.Collections.Generic;

namespace ChangeMoney
{
    class Program
    {
        enum Bill
        {
            B100 = 100,
            B50 = 50,
            B10 = 10
        }

        static void Main(string[] args)
        {
            int money =0;
            Console.WriteLine("Please enter your amount :");
            var input=  Console.ReadLine();
            if (int.TryParse(input, out money))
                AllPossibleChange(money);
            else
                Console.WriteLine("Please enter valid amount.");
            Console.ReadLine();
        }


        static void AllPossibleChange(int amount)
        {
            int hundredLoop = (int)(amount / (int) Bill.B100) + 1;
            for (int h = 0; h < hundredLoop; h++)
            {               
                int remainAmountDeductedHundred = amount - (h * (int)Bill.B100);
                var hunderdStr = $"{h} * 100 EUR, ";
                if (h > 0)
                    Console.Write(hunderdStr);

                if (remainAmountDeductedHundred > 0)
                {
                    int fiftyLoop = (int)(remainAmountDeductedHundred / (int)Bill.B50) + 1;
                    for (int f = 0; f < fiftyLoop; f++)
                    {
                        int remainAmountDeductedFifty = remainAmountDeductedHundred - (f * (int)Bill.B50);
                        var fiftyStr = $"{f} * 50 EUR, ";

                        if (f > 0)
                        {
                            if (h > 0)
                                Console.Write(hunderdStr);
                            Console.Write(fiftyStr);
                        }

                        int tenCount = (int)(remainAmountDeductedFifty / (int)Bill.B10);
                        Console.Write($"{tenCount} * 10 EUR");

                        int remain = remainAmountDeductedFifty - (tenCount * (int)Bill.B10);


                        if (remain > 0)
                            Console.Write($" + {remain} remained");

                        Console.WriteLine();
                    }
                }                
            }
            Console.WriteLine();
        }
    }
}
