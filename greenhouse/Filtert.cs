﻿using System;

namespace Filter
{
    public class FilterMain
    {
        static public string FilterString(string input)
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
                return input;
            }
            return input;
        }

        static public int FilterInt(string input)
        {
            if (!typeCheckInt(input))
            {
                Console.WriteLine("Dit is geen nummer, probeer het opnieuw.");
                input = Console.ReadLine();
                FilterMain.FilterInt(input);
            } else
            {
                Console.WriteLine("Gelukt!");
                return Convert.ToInt32(input);
            }
            return Convert.ToInt32(input);
        }

        public static bool typeCheckInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }


    class DateCheck
    {
    
        public static string Check(string DateInput)
        {
            string slash = "/";
            bool Boolian = DateInput.Contains(slash);
            if (DateInput.Length > 5 || !Boolian)
            {
                Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                DateInput = Console.ReadLine();
                Check(DateInput);
            }
            else
            {
                string[] DayMonthList = DateInput.Split('/');

                int Month = DateTime.Now.Month;
                int Day = DateTime.Now.Day;
                int a = Convert.ToInt32(DayMonthList[0]);
                int b = Convert.ToInt32(DayMonthList[1]);


                int daysinmonth = Validate(b);

                if (((Convert.ToInt32(Month) >= b || b > 12) && (Convert.ToInt32(Day) > a || b > 12)) || a > daysinmonth)
                {
                    Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                    DateInput = Console.ReadLine();
                    Check(DateInput);
                }
                return DateInput;
            }
            return DateInput;
        }

        public static int Validate(int Month)
        {
            int Days = DateTime.DaysInMonth(2021, Month);
            return Days;
        }

        public static string Start(string DateInput)
        {
            DateInput = Check(DateInput);
            //Console.WriteLine("Gelukt!");
            //Console.ReadLine();
            return DateInput;

        }
    }
}