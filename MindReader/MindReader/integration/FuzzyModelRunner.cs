using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string args = string.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\"",fileName, ReaderWorker.currentState.Alpha, ReaderWorker.currentState.High_Beta+ReaderWorker.currentState.Low_Beta,ReaderWorker.currentState.Gamma);
            p.StartInfo = new ProcessStartInfo(@"C:\Users\Adam\Anaconda3\python.exe", args)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

        }

    }
}
