using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            Laps = new List<string>();
        }

        public string GetTime => stopwatch.Elapsed.ToString().Substring(3);

        public List<string> Laps;

        public string Lap()
        {
            TimeSpan time = stopwatch.Elapsed;
            var lap = time.ToString();
            Laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            stopwatch.Reset();
            Laps.Clear();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public string GetLaps()
        {
            var laps = "";

            for (int i = 0; i < Laps.Count; i++)
            {
                laps += $"{i}. {Laps[i]}{Environment.NewLine}";
            }

            if (Laps.Count == 0)
            {
                laps = "Laps: no laps";
            }

            return laps.TrimEnd();
        }
    }
}
