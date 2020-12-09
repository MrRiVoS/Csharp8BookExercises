using System;
using static System.Console;
using Packt.Shared;

namespace PeopleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var bob = new Person();
      bob.Name = "Bob Smith";
      // bob.DateOfBirth = new DateTime(1965, 12, 22);
      // bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
      // bob.BucketList = WondersOfTheAncientWorld.HangingGardesnOfBabilon
      //   | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
      // bob.Children.Add(new Person{ Name = "Alfred"});
      // bob.Children.Add(new Person{ Name = "Zoe"});

      // WriteLine($"{bob.Name} has {bob.Children.Count} children:");
      // for (int child = 0; child < bob.Children.Count; child++)
      // {
      //   WriteLine($"  {bob.Children[child].Name}");
      // }
      // foreach (var child in bob.Children)
      // {
      //   WriteLine($"  {child.Name}");
      // }

      // var alice = new Person{
      //   Name = "Alice Jones",
      //   DateOfBirth = new DateTime(1998, 3, 7)
      // };

      WriteLine($"{bob.Name} is a {Person.Species}");
      // WriteLine("{0} was born on {1:dddd, d MMMM yyyy}", bob.Name, bob.DateOfBirth);
      // WriteLine("{0}'s favorite wonder is {1}. It's integer is {2}.",
      //   bob.Name, bob.FavoriteAncientWonder, (int)bob.FavoriteAncientWonder);
      // WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
      // WriteLine("{0} was born on {1:dddd, d MMMM yyyy}", alice.Name, alice.DateOfBirth);

      // BankAccount.InterestRate = 0.012M;  // store a shared value

      // var jonesAccount = new BankAccount{ AccountName = "Mrs. Jones", Balance = 2400};
      // WriteLine("{0} earned {1:C} interest.", jonesAccount.AccountName,
      //   jonesAccount.Balance * BankAccount.InterestRate);

      // var gerrierAccount = new BankAccount{ AccountName = "Ms. Gerrier", Balance = 98};
      // WriteLine("{0} earned {1:C} interest.", gerrierAccount.AccountName,
      //   gerrierAccount.Balance * BankAccount.InterestRate);

      // var blankPerson = new Person();

      // WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}.");

      // var gunny = new Person("Gunny", "Mars");
      // WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}.");

      // bob.WriteToConsole();
      // WriteLine(bob.GetOrigin());

      // (string, int) fruit = bob.GetFruit();
      // WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

      // var fruitNamed = bob.GetNamedFruit();
      // WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

      // var thing1 = ("Neville", 4);
      // WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

      // var thing2 = (bob.Name, bob.Children.Count);
      // WriteLine($"{thing2.Name} has {thing2.Count} children.");

      // (string fruitName, int fruitNumber) = bob.GetFruit();
      // WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

      // WriteLine(bob.SayHello());
      // WriteLine(bob.SayHello("Emily"));
      // WriteLine(bob.OptionalParameters());
      // WriteLine(bob.OptionalParameters("Jump!", 98.5));
      // WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
      // WriteLine(bob.OptionalParameters(command: "Hide!", active: false));

      // int a = 10;
      // int b = 20;
      // int c = 30;

      // WriteLine($"Before: a = {a}, b = {b}, c = {c}");

      // bob.PassingParameters(a, ref b, out c);

      // WriteLine($"After: a = {a}, b = {b}, c = {c}");

      // int d = 10;
      // int e = 20;

      // WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");

      // simplified C# 7.0 syntax for the out parameter
      // bob.PassingParameters(d, ref e, out int f);

      // WriteLine($"After: d = {d}, e = {e}, f = {f}");

      var sam = new Person{ Name = "Sam", DateOfBirth = new DateTime(1972, 1, 27)};

      WriteLine(sam.Origin);
      WriteLine(sam.Greeting);
      WriteLine(sam.Age);

      sam.FavoriteIceCream = "Chocolate Fudge";
      sam.FavoritePrimaryColor = "Blue";

      WriteLine($"Sam's favorite ice cream flavor is {sam.FavoriteIceCream}.");
      WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

      sam.Children.Add( new Person{ Name = "Charlie" });
      sam.Children.Add( new Person{ Name = "Ella" });

      WriteLine($"Sam's first child is {sam.Children[0].Name}");
      WriteLine($"Sam's second child is {sam.Children[1].Name}");
      WriteLine($"Sam's first child is {sam[0].Name}");
      WriteLine($"Sam's second child is {sam[1].Name}");
    }
  }
}
