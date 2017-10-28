using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.integration
{
    interface Filter
    {
        model.BrainWaveSummary FilterData(model.BrainWaveSummary data);
    }
}
