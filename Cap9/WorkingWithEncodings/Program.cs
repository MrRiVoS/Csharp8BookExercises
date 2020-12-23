using System;
using System.Text;
using static System.Console;

namespace WorkingWithEncodings
{
  class Program
  {
    static void Main(string[] args)
    {
      // Encodings menu
      WriteLine("Encodings:");
      WriteLine("[1] ASCII");
      WriteLine("[2] UTF-7");
      WriteLine("[3] UTF-8");
      WriteLine("[4] UTF-16 (Unicode)");
      WriteLine("[5] UTC-32");
      WriteLine("[any other key] Default");

      // Choose an encoding
      Write("Press a number to choose an encoding: ");
      ConsoleKey number = ReadKey(intercept: false).Key;
      WriteLine("\n");

      Encoding encoder = number switch
      {
        ConsoleKey.D1 => Encoding.ASCII,
        ConsoleKey.D2 => Encoding.UTF7,
        ConsoleKey.D3 => Encoding.UTF8,
        ConsoleKey.D4 => Encoding.Unicode,
        ConsoleKey.D5 => Encoding.UTF32,
        _             => Encoding.Default
      };
      
      // Define a string 
      string message = "A liter of milk is R$ 3,49.";

      // Encode the string into a byte array
      byte[] encoded = encoder.GetBytes(message);

      // Check how many bytes the encoding needed
      WriteLine("{0} uses {1:N0} bytes.", encoder.GetType().Name, encoded.Length);

      // Enumerate each byte
      WriteLine($"BYTE   HEX   CHAR");
      foreach(byte b in encoded)
      {
        WriteLine($"{b,4}  {b.ToString("X"),4}  {(char)b,5}");
      }

      // Decode the byte array back into a string and display it
      string decoded = encoder.GetString(encoded);
      WriteLine($"String decoded:\n{decoded}");
    }
  }
}
