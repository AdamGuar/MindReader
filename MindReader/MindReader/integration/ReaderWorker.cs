using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindReader.model;
using System.Threading;
using System.Collections;

namespace MindReader.integration
{
    class ReaderWorker
    {
        private volatile bool _shouldStop;
        private ArrayList FiltersList = new ArrayList();


        public static BrainWaveSummary currentState = BrainWaveSummary.generateDefaultState();
        public static String currentInformation = "";
        static public StatisticalDataBuffer StatBuffer = new StatisticalDataBuffer();

        CSVFileReader reader = new CSVFileReader();



        public void addFilter(Filter f)
        {
            this.FiltersList.Add(f);
        }

        

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void StartReading()
        {
            while (!_shouldStop)
            {
                try {
                    ReaderWorker.currentState = filter(reader.readBandPowers());
                    ReaderWorker.StatBuffer.addEntry(ReaderWorker.currentState);
                }catch (CSVFileAccessException ex){
                    //Do nothing;
                }
                Thread.Sleep(1000);
            }
        }


        private BrainWaveSummary filter(BrainWaveSummary data)
        {
            BrainWaveSummary result = data;
            foreach (Filter f in FiltersList)
            {
                result = f.FilterData(result);
            }
            return result;
        }

    }
}
