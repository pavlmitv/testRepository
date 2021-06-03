using System;
using Chronometer.Contracts;
using Chronometer.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chronometer.Core
{
    public class Engine : IEngine
    {
        public Engine(ConsoleReader reader, ConsoleWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        private readonly ConsoleReader reader;

        private readonly ConsoleWriter writer;


        public void Run()
        {
            var chronometer = new Models.Chronometer();

            string command = string.Empty;

            this.ParseCommands(chronometer, command);

            Environment.Exit(0);
        }


        private void ParseCommands(Models.Chronometer chronometer, string command)
        {

            while ((command = this.reader.Read().ToLower()) != "exit")
            {
                if (command.ToLower() == "start")
                {
                    chronometer.Start();
                }

                else if (command.ToLower() == "lap")
                {
                    this.writer.WriteLine(chronometer.Lap());
                }

                else if (command.ToLower() == "stop")
                {
                    chronometer.Stop();
                }

                else if (command.ToLower() == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        this.writer.WriteLine("Laps: no laps");
                    }

                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        this.writer.WriteLine($"{i}. {chronometer.Laps[i]}");
                    }
                }

                else if (command.ToLower() == "time")
                {
                    this.writer.WriteLine(chronometer.GetTime);
                }

                else if (command.ToLower() == "reset")
                {
                    chronometer.Reset();
                }
            }
        }
    }
}
