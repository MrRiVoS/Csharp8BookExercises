#nullable enable

using System;

namespace NullHandling
{
    public class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int thisCannotBeNull = 4;
            // thisCannotBeNull = null;

            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = "London";
            address.Region = null;

            // Check that the variable is not null befor using it
            if (thisCouldBeNull != null)
            {
                // access a member of thisCouldBeNull
                // int length = thisCouldBeNull.Length; //could throw exception
            }

            string authorName = null;

            // this throws a NullReferenceException
            // int x = authorName.Length;

            // instead fo throwing an exception, null is assigned to y
            int? y = authorName?.Length;

            // result will be 3 if authorName?.Length is null
            var result = authorName?.Length ?? 3;
            Console.WriteLine(result);
        }
    }
}
