using System;
using static System.Console;

namespace WorkingWithRanges
{
  class Program
  {
    static void Main(string[] args)
    {
      string name = "Samantha Jones";

      int indexOfSpace = name.IndexOf(" ");

      string firstName = name.Substring(0, indexOfSpace);
      string lastName = name.Substring(indexOfSpace + 1, name.Length - indexOfSpace - 1);

      WriteLine($"First name: {firstName}, Last name: {lastName}");

      ReadOnlySpan<char> nameAsSpan = name.AsSpan();

      // (apparently, the variable lengthOf... are missing from the book)
      // var firstNameSpan = nameAsSpan[0..lengthOfFirst];
      // var lastNameAsSpan = nameAsSpan[^lengthOfLast..^0];
    }
  }
}
