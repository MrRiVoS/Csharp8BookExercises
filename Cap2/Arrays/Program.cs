using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names;

            names = new string[4];

            names[0] = "Ivens";
            names[1] = "Aline";
            names[2] = "Amanda";
            names[3] = "Roger";

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
