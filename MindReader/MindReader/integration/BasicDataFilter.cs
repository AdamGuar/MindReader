using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindReader.model;

namespace MindReader.integration
{
    class BasicDataFilter : Filter
    {
        public BrainWaveSummary FilterData(BrainWaveSummary data)
        {
            BrainWaveSummary newSummary = new BrainWaveSummary();
            double alfa = data.Alpha;
            double lowbeta = data.Low_Beta;
            double highbeta = data.High_Beta;
            double theta = data.Theta;
            double gamma = data.Gamma;

            if (alfa < 1) alfa = 0.0;            
            if (lowbeta < 1) lowbeta = 0.0;
            if (highbeta < 1) highbeta = 0.0;
            if (theta < 1) theta = 0.0;
            if (gamma < 1) gamma = 0.0;

            newSummary.Alpha = alfa;
            newSummary.Low_Beta = lowbeta;
            newSummary.High_Beta = highbeta;
            newSummary.Theta = theta;
            newSummary.Gamma = gamma;

            return newSummary;
        }
    }
}
