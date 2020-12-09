using System;
using static System.Console;

namespace WrittingFunctions
{
  class Program
  {
    static void TimesTable(byte number)
    {
      WriteLine($"This is the {number} times table:");
      for (int row = 0; row <= 12; row++)
      {
        WriteLine($"{row} x {number} = {row * number}");
      }
      WriteLine();
    }

    static void RunTimestable()
    {
      bool isNumber;
      do
      {
        Write("Enter a number between 0 and 255: ");
        isNumber = byte.TryParse(ReadLine(), out byte number);

        if (isNumber)
        {
          TimesTable(number);
        }
        else
        {
          WriteLine("You did not enter a valid number!");
        }
      } while (isNumber);
    }

    /// <summary>
    /// Pass an amount of money and a region code, and it will calculate the tax value
    /// that needs to be payed.
    /// </summary>
    /// <param name="amount">Amount of money base of tax calculation</param>
    /// <param name="twoLetterRegionCode">Region code from where to apply the tax</param>
    /// <returns>Tax to be payed.</returns>
    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
      decimal rate = 0.0M;

      switch (twoLetterRegionCode)
      {
        case "CH": // Switzerland
          rate = 0.08M;
          break;
        case "DK": // Denmark
        case "NO": // Norway
          rate = 0.25M;
          break;
        case "GB": // United Kingdom
        case "FR": // France
          rate = 0.2M;
          break;
        default:
          break;
      }
      return amount * rate;
    }

    static void RunCalculateTax()
    {
      Write("Enter and amount: ");
      string amountInText = ReadLine();

      Write("Enter a two-letter region code: ");
      string region = ReadLine();

      if (decimal.TryParse(amountInText, out decimal amount))
      {
        decimal taxToPay = CalculateTax(amount, region);
        WriteLine($"You must pay {taxToPay} in sales tax.");
      }
      else
      {
        WriteLine("You did not enter a valid amount!");
      }
    }

    static int Factorial(int number)
    {
      if (number < 1)
      {
        return 0;
      }
      else if (number == 1)
      {
        return 1;
      }
      else
      {
        return number * Factorial(number - 1);
      }
    }

    static void RunFactorial()
    {
      bool isNumber;
      do
      {
        Write("Enter a number: ");
        isNumber = int.TryParse(ReadLine(), out int number);
        if (isNumber)
        {
          WriteLine($"{number:N0}! = {Factorial(number):N0}");
        }
        else
        {
          WriteLine("You did not enter a valid number!");
        }
      } while (isNumber);
    }
    static void Main(string[] args)
    {
      // RunTimestable();
      //RunCalculateTax();
      RunFactorial();
    }
  }
}
