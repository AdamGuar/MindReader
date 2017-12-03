using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.model
{
    class StatisticalDataBuffer
    {

        private int _entriesNo = 5;
        List<StatisticalSummary> dataList;

        public StatisticalDataBuffer()
        {
            _entriesNo = 5;
            this.dataList = new List<StatisticalSummary>();

            BrainWaveSummary emptyBrainSummary = new BrainWaveSummary();
            emptyBrainSummary.Alpha = 0;
            emptyBrainSummary.Low_Beta = 0;
            emptyBrainSummary.High_Beta = 0;
            emptyBrainSummary.Gamma = 0;
            emptyBrainSummary.Theta = 0;

            StatisticalSummary emptyStatistic = new StatisticalSummary();
            emptyStatistic.TimeStamp = DateTime.Now.ToShortTimeString();
            emptyStatistic.Data = emptyBrainSummary;

            for (int i = 0; i < 5; i++)
            {
                this.addEntry(emptyStatistic);
            }
        }


        public void addEntry(StatisticalSummary entry)
        {
            if(dataList.Count > 5)
            {
                dataList.RemoveAt(0);
                dataList.Add(entry);
            }
            else
            {
                dataList.Add(entry);
            }

        }

        public void addEntry(BrainWaveSummary entry)
        {
            StatisticalSummary statEntry = new StatisticalSummary();
            statEntry.TimeStamp = DateTime.Now.ToShortTimeString();
            statEntry.Data = entry;
            this.addEntry(statEntry);

        }


        public List<StatisticalSummary> getData()
        {
            return this.dataList;
        }


        private double calculateMean(String wave)
        {

            double mean = 0;

            switch (wave)
            {
                case "alpha":
                    dataList.ForEach(el =>
                        mean = mean + el.Data.Alpha
                        );
                    break;
                case "low_beta":
                    dataList.ForEach(el =>
                        mean = mean + el.Data.Low_Beta
                        );
                    break;
                case "high_beta":
                    dataList.ForEach(el =>
                        mean = mean + el.Data.High_Beta
                        );
                    break;
                case "gamma":
                    dataList.ForEach(el =>
                        mean = mean + el.Data.Gamma
                        );
                    break;
                case "theta":
                    dataList.ForEach(el =>
                        mean = mean + el.Data.Theta
                        );
                    break;
            }
            return mean/ this._entriesNo;
        }


        public double calculateMeanForAlpha()
        {
            return calculateMean("alpha");
        }
        public double calculateMeanForLow_Beta()
        {
            return calculateMean("low_beta");
        }
        public double calculateMeanForHigh_Beta()
        {
            return calculateMean("high_beta");
        }
        public double calculateMeanForGamma()
        {
            return calculateMean("gamma");
        }
        public double calculateMeanForTheta()
        {
            return calculateMean("theta");
        }

    }
}
