using System;

namespace Filter
{
    public class Filter
    {
        static public void FilterString(string input)
        {
            if (typeCheckInt(input))
            {
                Console.WriteLine("Dit is een nummer. Probeer het opnieuw.");
                input = Console.ReadLine();
                Filter.FilterString(input);
            }
            else
            {
                Console.WriteLine("Correct, dit is een string.");
            }
        }

        static public void FilterInt(string input)
        {
            if (!typeCheckInt(input))
            {
                Console.WriteLine("Dit is geen nummer, probeer het opnieuw.");
                input = Console.ReadLine();
                Filter.FilterInt(input);
            } else
            {
                Console.WriteLine("Correct, dit is een getal.");
            }
        }

        public static bool typeCheckInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }
}