using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindReader.model;
using System.Threading;

namespace MindReader.integration
{
    class ReaderWorker
    {
        private volatile bool _shouldStop;

        public static BrainWaveSummary currentState = BrainWaveSummary.generateDefaultState();

        CSVFileReader reader = new CSVFileReader();

        /*
        public BrainWaveSummary CurrentDataState {
            get {
                return _currentDataState;
            }
            set {
               _currentDataState = value;
            }
        }*/

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void StartReading()
        {
            while (!_shouldStop)
            {
                ReaderWorker.currentState = reader.readBandPowers();
                Thread.Sleep(1000);
            }
        }


    }
}
