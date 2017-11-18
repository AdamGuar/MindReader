using CefSharp;
using CefSharp.WinForms;
using MindReader.integration;
using MindReader.model;
using System;
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

    }

}

