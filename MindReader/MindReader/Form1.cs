using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using MindReader.presentation;
using MindReader.integration;
using System.Threading;

namespace MindReader
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();

            // Note that if you get an error or a white screen, you may be doing something wrong !
            // Try to load a local file that you're sure that exists and give the complete path instead to test
            // for example, replace page with a direct path instead :
            // String page = @"C:\Users\SDkCarlos\Desktop\afolder\index.html";

            String page = string.Format(@"{0}\html-resources\html\index.html", Application.StartupPath);
            //String page = @"C:\Users\SDkCarlos\Desktop\artyom-HOMEPAGE\index.html";

            if (!File.Exists(page))
            {
                MessageBox.Show("Error The html file doesn't exists : " + page);
            }

            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(page);

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            // Allow the use of local resources in the browser
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;

            
        }


        public Form1()
        {
            //Reader thread initialization
            BandDataExeRunner runner = new BandDataExeRunner();
            runner.RunBandReader();

            ReaderWorker workerObject = new ReaderWorker();
            workerObject.addFilter(new BasicDataFilter());
            Thread workerThread = new Thread(workerObject.StartReading);
            workerThread.Priority = ThreadPriority.Highest;
            workerThread.Start();
            while (!workerThread.IsAlive) ;
            Thread.Sleep(1000);
            //End of reader thread initialization


            InitializeComponent();
            InitializeChromium();
            // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3
            chromeBrowser.RegisterJsObject("mainPageController", new MainPageControler(chromeBrowser, this));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chromeBrowser.ShowDevTools();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            integration.BandDataExeRunner.StopBandDataRaderProcess();
        }

    }
}
