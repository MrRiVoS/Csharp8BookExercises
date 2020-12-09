using System;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;

            Console.WriteLine(
                format: "{0} apples cost {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );

            string formatted = string.Format(
                format: "{0} apple costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );

            Console.WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");

            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;

            Console.WriteLine("{0,-8} {1,6:N0}", "Name", "Count");
            Console.WriteLine("{0,-8} {1,6:N0}", applesText, applesCount);
            Console.WriteLine("{0,-8} {1,6:N0}", bananasText, bananasCount);
        }
    }
}
