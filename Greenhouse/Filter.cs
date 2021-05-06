using System;

namespace Filter
{
    public class FilterMain
    {
        static public void FilterString(string input)
        {
            if (typeCheckInt(input))
            {
                Console.WriteLine("Dit is een nummer. Probeer het opnieuw.");
                input = Console.ReadLine();
                FilterMain.FilterString(input);
            }
            else
            {
                Console.WriteLine("Gelukt!");
            }
        }

        static public void FilterInt(string input)
        {
            if (!typeCheckInt(input))
            {
                Console.WriteLine("Dit is geen nummer, probeer het opnieuw.");
                input = Console.ReadLine();
                FilterMain.FilterInt(input);
            } else
            {
                Console.WriteLine("Gelukt!");
            }
        }

        public static bool typeCheckInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }


    class DateCheck
    {
        public static void Check(string DateInput)
        {
            string slash = "/";
            bool Boolian = DateInput.Contains(slash);
            if (DateInput.Length > 5 || !Boolian)
            {
                Foutmelding();
            }
            string[] DayMonthList = DateInput.Split('/');

            int Month = DateTime.Now.Month;
            int Day = DateTime.Now.Day;
            int a = Convert.ToInt32(DayMonthList[0]);
            int b = Convert.ToInt32(DayMonthList[1]);


            int daysinmonth = Validate(Month);


            if (Convert.ToInt32(Month) >= b || b > 12 && Convert.ToInt32(Day) > a || a > daysinmonth || b > 12)
            {
                Foutmelding();
            }

        }

        public static int Validate(int Month)
        {
            int Days = DateTime.DaysInMonth(2021, Month);
            return Days;
        }


        public static void Foutmelding()
        {
            Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
            string DateInput = Console.ReadLine();
            Main(DateInput);
        }

        public static void Main(string DateInput)
        {
            Check(DateInput);
            Console.WriteLine("Gelukt!");
            Console.ReadLine();
        }
    }
}