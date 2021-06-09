using System;
using System.Diagnostics.CodeAnalysis;
namespace Filter
{
    public class FilterMain
    {
        [ExcludeFromCodeCoverage]
        public static string FilterAantalPersonen(int PersonenAanTafel, bool Test)
        {
            if (Test)
            {
                string userInput = "";
                bool isNotInt = true;
                while (isNotInt)
                {
                    Console.WriteLine("Met hoeveel personen wilt u reserveren?\nHet personeel is altijd in staat om uw tafel te wijzigen als dat beter uitkomt voor de rest van de gasten.");
                    userInput = "6";

                    if (typeCheckInt(userInput))
                    {
                        //omzetten naar int zodat je niet steeds convert.toint hoeft te typen
                        int a = Convert.ToInt32(userInput);

                        if ((a > 0 && a < 7) && (a <= PersonenAanTafel))
                        {
                            return userInput;
                        }
                        else if (a > 0 && a < 7)
                        {
                            Console.WriteLine("Dit is een te grote groep voor de tafel die u gekozen heeft");
                            userInput = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Dit is een te grote groep, reserveer via het volgende telefoon nummer : 010-794-4000");
                            userInput = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dit is geen geldig nummer!");
                        userInput = Console.ReadLine();
                    }

                }
                return "";
            }
            else
            {
                string userInput = "";
                bool isNotInt = true;
                while (isNotInt)
                {
                    Console.WriteLine("Met hoeveel personen wilt u reserveren?\nHet personeel is altijd in staat om uw tafel te wijzigen als dat beter uitkomt voor de rest van de gasten.");
                    userInput = Console.ReadLine();

                    if (typeCheckInt(userInput))
                    {
                        //omzetten naar int zodat je niet steeds convert.toint hoeft te typen
                        int a = Convert.ToInt32(userInput);

                        if ((a > 0 && a < 7) && (a <= PersonenAanTafel))
                        {
                            return userInput;
                        }
                        else if (a > 0 && a < 7)
                        {
                            Console.WriteLine("Dit is een te grote groep voor de tafel die u gekozen heeft");
                        }
                        else
                        {
                            Console.WriteLine("Dit is een te grote groep, reserveer via het volgende telefoon nummer : 010-794-4000");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dit is geen geldig nummer!");
                    }

                }
                return "";
            }
            
            
        }
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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


    public class DateCheck
    {
        [ExcludeFromCodeCoverage]
        public static string Check(string DateInput)
        {

            bool running = true;
            while (running)
            {
                //string DateInput = Console.ReadLine();
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
                                if(thisDay < day && day > 0 && day <= daysinmonth)
                                {
                                    return DateInput;
                                }
                                else
                                {
                                    Console.WriteLine("Niet beschikbaar");
                                    DateInput = Console.ReadLine();
                                }
                                
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                            DateInput = Console.ReadLine();
                        }

                        

                    }
                    else
                    {
                        Console.WriteLine("Deze datum is niet beschikbaar, probeer het nog eens.\n");
                        DateInput = Console.ReadLine();

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