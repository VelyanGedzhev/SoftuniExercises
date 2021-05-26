using System;

namespace ChronometerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            IChronometer chronometer = new Chronometer();

            string command = Console.ReadLine();

            while (command != "exit")
            {
                switch (command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        Console.WriteLine(chronometer.Laps.Count < 1
                            ? "Laps: no laps"
                            : $"Laps: {Environment.NewLine}{string.Join(Environment.NewLine, chronometer.Laps)}");
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
  
   
