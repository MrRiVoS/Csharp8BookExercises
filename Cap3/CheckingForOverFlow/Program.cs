using System;
using static System.Console;

namespace CheckingForOverFlow
{
  class Program
  {
    static void Main(string[] args)
    {
      int x = int.MaxValue - 1;
      
      try
      {
        checked
        {
          WriteLine($"Initial value: {x}");
          x++;
          WriteLine($"After incrementing: {x}");
          x++;
          WriteLine($"After incrementing: {x}");
          x++;
          WriteLine($"After incrementing: {x}");    
        }  
      }
      catch (OverflowException)
      {
        WriteLine("The code overflowed, but I caught the exception.");
      }

      unchecked
      {
        int y = int.MaxValue + 1;

        WriteLine($"Initial value: {y}");
        y--;
        WriteLine($"After incrementing: {y}");
        y--;
        WriteLine($"After incrementing: {y}");
        y--;
        WriteLine($"After incrementing: {y}"); 
      }
      
    }
  }
}
