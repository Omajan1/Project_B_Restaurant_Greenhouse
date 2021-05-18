using System;

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

        static public bool FilterInt(string input)
        {
            bool running = true;
            while (running)
            {
                input = Console.ReadLine();
                if (!typeCheckInt(input))
                {
                    Console.WriteLine("Dit is geen nummer, probeer het opnieuw.");
                    
                    FilterMain.FilterInt(input);
                    return false;
                }
                else
                {
                    Console.WriteLine("Gelukt!");
                    return true;
                }

            }

            return true;
   
        }

        public static bool typeCheckInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }


    class DateCheck
    {
    
        public static string Check()
        {

            bool running = true;
            while (running)
            {
                string DateInput = Console.ReadLine();
                bool Boolian = DateInput.Contains("/");
                string[] DayMonthList = DateInput.Split('/');
                if (DateInput.Length != 5 || !Boolian || DayMonthList[0].Length != 2 || DayMonthList[1].Length != 2)
                {
                    Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                }

                else
                {
                    
                    if (Int32.TryParse(DayMonthList[0], out int day) && Int32.TryParse(DayMonthList[1], out int month) && day < 32 && day > 0 && month < 13 && month > 0)
                    {
                        


                        int Month = DateTime.Now.Month;
                        int Day = DateTime.Now.Day;
                        int thisMonth = Convert.ToInt32(Month);
                        int thisDay = Convert.ToInt32(Day);
                        int daysinmonth = Validate(month);


                        if (thisMonth <= month && month <= 12)
                        {
                            if (month > thisMonth)
                            {
                                return DateInput;
                            }
                            else
                            {
                                if(thisDay < day && day > 0 && day < daysinmonth)
                                {
                                    return DateInput;
                                }
                                else
                                {
                                    Console.WriteLine("Niet beschikbaar");
                                }
                                
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                        }

                        

                    }
                    else
                    {
                        Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");

                    }


                }
                
            }
            return "";
        }

        public static int Validate(int Month)
        {
            int Days = DateTime.DaysInMonth(2021, Month);
            return Days;
        }

    }
}