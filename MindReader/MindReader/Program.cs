using MindReader.integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindReader.model;

namespace MindReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CSVFileReader CSVReader = new CSVFileReader();
            BandDataExeRunner runner = new BandDataExeRunner();
            runner.RunBandReader();

            ReaderWorker workerObject = new ReaderWorker();
            Thread workerThread = new Thread(workerObject.StartReading);
            workerThread.Priority = ThreadPriority.Highest;
            workerThread.Start();
            while (!workerThread.IsAlive);
            Thread.Sleep(1000);

            BrainWaveSummary summary = ReaderWorker.currentState;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
