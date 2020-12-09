using System;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defining variables
            string[] typeNames = new string[11];
            typeNames[0] = "sbyte"; typeNames[1] = "byte";  typeNames[2] = "short";
            typeNames[3] = "ushort"; typeNames[4] = "int"; typeNames[5] = "uint";
            typeNames[6] = "long"; typeNames[7] = "ulong"; typeNames[8] = "float";
            typeNames[9] = "double"; typeNames[10] = "decimal";

            int[] typeSizes = new int[11];
            typeSizes[0] = sizeof(sbyte);
            typeSizes[1] = sizeof(byte);
            typeSizes[2] = sizeof(short);
            typeSizes[3] = sizeof(ushort);
            typeSizes[4] = sizeof(int);
            typeSizes[5] = sizeof(uint);
            typeSizes[6] = sizeof(long);
            typeSizes[7] = sizeof(ulong);
            typeSizes[8] = sizeof(float);
            typeSizes[9] = sizeof(double);
            typeSizes[10] = sizeof(decimal);

            string[] typeMins = new string[11];
            typeMins[0] = sbyte.MinValue.ToString();
            typeMins[1] = byte.MinValue.ToString();
            typeMins[2] = short.MinValue.ToString();
            typeMins[3] = ushort.MinValue.ToString();
            typeMins[4] = int.MinValue.ToString();
            typeMins[5] = uint.MinValue.ToString();
            typeMins[6] = long.MinValue.ToString();
            typeMins[7] = ulong.MinValue.ToString();
            typeMins[8] = float.MinValue.ToString();
            typeMins[9] = double.MinValue.ToString();
            typeMins[10] = decimal.MinValue.ToString();

            string[] typeMaxs = new string[11];
            typeMaxs[0] = sbyte.MaxValue.ToString();
            typeMaxs[1] = byte.MaxValue.ToString();
            typeMaxs[2] = short.MaxValue.ToString();
            typeMaxs[3] = ushort.MaxValue.ToString();
            typeMaxs[4] = int.MaxValue.ToString();
            typeMaxs[5] = uint.MaxValue.ToString();
            typeMaxs[6] = long.MaxValue.ToString();
            typeMaxs[7] = ulong.MaxValue.ToString();
            typeMaxs[8] = float.MaxValue.ToString();
            typeMaxs[9] = double.MaxValue.ToString();
            typeMaxs[10] = decimal.MaxValue.ToString();

            string line2print;

            WriteLine("-----------------------------------------------------------------------------");
            WriteLine("{0,-8} {1,-4} {2,28} {3,31}", "Type", "Byte(s)", "Min value", "Max value");
            WriteLine("-----------------------------------------------------------------------------");
            for (int i = 0; i < 11; i++)
            {
                // line2print = String.Format($"{typeNames[i]} {typeSizes[i]} {typeMins[i]} {typeMaxs[i]}");
                line2print = String.Format($"{typeNames[i],-8} {typeSizes[i],4} {typeMins[i],31} {typeMaxs[i],31}");
                WriteLine(line2print);
            }
            WriteLine("-----------------------------------------------------------------------------");
        }
    }
}
