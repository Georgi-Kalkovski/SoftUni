using System;
using System.Collections.Generic;
using System.Text;

namespace Chronometer
{
    public interface IChronometer
    {
        string GetTime { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
