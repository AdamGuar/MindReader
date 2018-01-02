using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.model
{
    class StatisticalSummary
    {
        String timeStamp;
        BrainWaveSummary data;

        public string TimeStamp { get => timeStamp; set => timeStamp = value; }
        public BrainWaveSummary Data { get => data; set => data = value; }

    }
}
