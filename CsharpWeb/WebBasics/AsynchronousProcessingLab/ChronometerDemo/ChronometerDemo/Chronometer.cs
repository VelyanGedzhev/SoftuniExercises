using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerDemo
{
    public class Chronometer : IChronometer
    {
        private Stopwatch timer;
        private List<string> laps;

        public Chronometer()
        {
            timer = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime => GetCurrentTime();

        public List<string> Laps => laps;

        public string Lap()
        {
            laps.Add(GetCurrentTime());
            return GetCurrentTime();
        }

        public void Reset()
        {
            timer.Reset();
            laps.Clear();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private string GetCurrentTime()
        {
            return timer.Elapsed.ToString("mm\\:ss\\.ff");
        }

    }
}
