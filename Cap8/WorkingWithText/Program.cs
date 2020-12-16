using System;
using static System.Console;

namespace WorkingWithText
{
  class Program
  {
    static void Main(string[] args)
    {
      string city = "Fortaleza";
      WriteLine($"{city} is {city.Length} characters long.");
      WriteLine($"First char is {city[0]}, and third char is {city[2]}.");

      string cities = "Paris,Berlin,Madrid,New York";

      string[] citiesArray = cities.Split(",");
      foreach (string item in citiesArray)
      {
        WriteLine(item);
      }

      string fullName = "Alan Jones";
      int indexOfSpace = fullName.IndexOf(" ");
      string firstName = fullName.Substring(0, indexOfSpace);
      string lastName = fullName.Substring(indexOfSpace + 1);

      WriteLine($"{lastName}, {firstName}");

      string company = "Microsoft";
      bool startsWithM = company.StartsWith("M");
      bool containsN = company.Contains("N");

      WriteLine($"Starts with M: {startsWithM}, contains N: {containsN}");

      string recombined = string.Join(" => ", citiesArray);
      WriteLine(recombined);

      string fruit = "Apples";
      decimal price = 0.39M;
      DateTime when = DateTime.Today;

      WriteLine($"{fruit} cost {price:C} on {when:dddd}.");
      WriteLine(string.Format("{0} cost {1:C} on {2:dddd}.", fruit, price, when));
    }
  }
}
