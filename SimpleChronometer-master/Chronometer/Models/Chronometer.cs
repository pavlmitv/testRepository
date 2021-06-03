using Chronometer.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer.Models
{
    public class Chronometer : IChronometer
    {
        public Chronometer()
        {
            this.Stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        private Stopwatch Stopwatch { get; }

        public string GetTime
        {
            get => this.GetCurTime();
        }

        public List<string> Laps { get; }


        public void Start() => this.Stopwatch.Start();


        public void Stop()
        {
            this.Stopwatch.Stop();
        }


        public string Lap()
        {
            var lapTime = this.GetCurTime();

            this.Laps.Add(lapTime);

            return lapTime;
        }


        public void Reset()
        {
            this.Stopwatch.Reset();
        }


        private string GetCurTime()
        {
            TimeSpan ts = this.Stopwatch.Elapsed;

            var lapTime = String.Format("{0:00}:{1:00}.{2:0000}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            return lapTime;
        }
    }
}
