using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindReader.integration
{
    class FuzzyModelRunner
    {

        public static double _Awakness_LVL = 0;
        public static String _Awankess_Label = "Off";


        public static void Refresh()
        {
            string fileName = string.Format(@"{0}\external\brain-waves-awake.py", Application.StartupPath);

            Process p = new Process();

            double alpha = ReaderWorker.currentState.Alpha;
            double beta = ReaderWorker.currentState.Low_Beta + ReaderWorker.currentState.High_Beta;
            double gamma = ReaderWorker.currentState.Gamma;

            string args = string.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\"", fileName, alpha, beta, gamma, "-fuzz");
            p.StartInfo = new ProcessStartInfo(@"C:\Users\Adam\Anaconda3\python.exe", args)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            string[] outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            _Awakness_LVL = double.Parse(outputLines[0], CultureInfo.InvariantCulture);
            _Awankess_Label = outputLines[1];
        }

    }
}
