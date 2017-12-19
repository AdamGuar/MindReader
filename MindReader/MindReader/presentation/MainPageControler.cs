using CefSharp;
using CefSharp.WinForms;
using MindReader.integration;
using MindReader.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.presentation
{
    class MainPageControler
    {
        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;
        // The form class needs to be changed according to yours
        private static Form1 _instanceMainForm = null;

        private DataSaver dataSaver = new DataSaver();


        public MainPageControler(ChromiumWebBrowser originalBrowser, Form1 mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        public void opencmd()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c pause");
            Process.Start(start);
        }


        public double getAlhpaPower()
        {
            return ReaderWorker.currentState.Alpha;
        }

        public double getHighBetaPower()
        {
            return ReaderWorker.currentState.High_Beta;
        }

        public double getLowBetaPower()
        {
            return ReaderWorker.currentState.Low_Beta;
        }

        public double getThetaPower()
        {
            return ReaderWorker.currentState.Theta;
        }


        public double getGammaPower()
        {
            return ReaderWorker.currentState.Gamma;
        }
        
        public void refresh()
        {
            FuzzyModelRunner.Refresh();
        }

        public double getAwaknessLVL()
        {
            return FuzzyModelRunner._Awakness_LVL;
        }

        public string getAwaknessLabel()
        {
            return FuzzyModelRunner._Awankess_Label;
        }

        private List<StatisticalSummary> getStatData()
        {
            return ReaderWorker.StatBuffer.getData();
        }


        private StatisticalSummary getSummaryFromBuffer(int summaryIndex)
        {
            return getStatData()[summaryIndex];
        }


        public String getTimeStampFromIndex(int index)
        {
            return getSummaryFromBuffer(index).TimeStamp;
        }

        public double getAlphaFromIndex(int index)
        {
            return getSummaryFromBuffer(index).Data.Alpha;
        }

        public double getLowBetaFromIndex(int index)
        {
            return getSummaryFromBuffer(index).Data.Low_Beta;
        }

        public double getHighBetaFromIndex(int index)
        {
            return getSummaryFromBuffer(index).Data.High_Beta;
        }

        public double getGammaFromIndex(int index)
        {
            return getSummaryFromBuffer(index).Data.Gamma;
        }

        public double getThetaFromIndex(int index)
        {
            return getSummaryFromBuffer(index).Data.Theta;
        }

        public double getMeanForAlpha()
        {
            return ReaderWorker.StatBuffer.calculateMeanForAlpha();
        }

        public double getMeanForLowBeta()
        {
            return ReaderWorker.StatBuffer.calculateMeanForLow_Beta();
        }

        public double getMeanForHighBeta()
        {
            return ReaderWorker.StatBuffer.calculateMeanForHigh_Beta();
        }

        public double getMeanForGamma()
        {
            return ReaderWorker.StatBuffer.calculateMeanForGamma();
        }

        public double getMeanForTheta()
        {
            return ReaderWorker.StatBuffer.calculateMeanForTheta();
        }

        public void saveData()
        {
            dataSaver.saveCurrentState();
        }



    }

}

