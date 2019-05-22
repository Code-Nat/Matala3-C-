using System;

namespace TimeToAngelOnClock
{
    class Pogream
    {
        static void Main()
        {
            string Swi = "-1";
            Clock time;
            while (Swi != "0")
            {
                time = new Clock();
                Console.WriteLine(time.getAngel());
#if !DEBUG
                Swi = Console.ReadLine();
#endif
#if DEBUG
                if (Clock.testHours > 12)
                    Swi = "0";
#endif
            }
        }

        class Clock
        {
            private double hours;
            private double minutes;
            static int maxMinutes = 60;
            static int maxHours = 12;

#if DEBUG
            public static int testHours = 0;
            static int testMint = 0;
#endif

            static int Input(string text)
            {
                Console.WriteLine(text);
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception i)
                {
                    Console.WriteLine("What you enter has return error: {0}", i.Message);
                    return -1;
                }
            }
            public Clock()
            {
#if !DEBUG
                Hours = -1;
                Minutes = -1;
#endif
#if DEBUG
                Minutes = 0;
                Hours = 0;
#endif
            }

            private double Hours
            {
                set
                {
#if !DEBUG
                    while (value > maxHours || value < 0)
                        value = Input("Pleae etner hours");
#endif
#if DEBUG
                    value = testHours;
#endif
                    hours = (360 / maxHours) * value;
                }
            }

            private double Minutes
            {
                set
                {
#if !DEBUG
                    while (value > maxMinutes || value < 0)
                        value = Input("Pleae etner Minutes");
#endif
#if DEBUG
                    if (testMint <= 60) value = testMint++; else { testMint = 0; value = testMint; testHours++; }
#endif
                    minutes = (360 / maxMinutes) * value;
                }
            }

            public int getAngel()
            {
#if DEBUG
                Console.WriteLine("The time is: " + (hours / (360 / maxHours)) + ":" + (minutes / (360 / maxMinutes)) + " and " + hours + ":" + minutes);
#endif
                if (hours > minutes)
                    if (hours - minutes <= 180)
                        return (int)(hours - minutes);
                    else
                        return (int)(hours - minutes) - 180;
                else
                    if (minutes - hours <= 180)
                        return (int)(minutes - hours);
                    else
                        return (int)(minutes - hours) - 180;
            }
        }
    }
}
