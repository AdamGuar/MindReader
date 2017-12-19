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

        private static String pythonDir = null;

        public static void loadPythonDir()
        {
            if (pythonDir == null) {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader("pythonDir.conf"))
                    {
                        // Read the stream to a string, and write the string to the console.
                        String line = sr.ReadToEnd();
                        pythonDir = line;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }

            
        }


        public static void Refresh()
        {
            string fileName = string.Format(@"{0}\external\brain-waves-awake.py", Application.StartupPath);

            Process p = new Process();

            loadPythonDir();

            double alpha = ReaderWorker.currentState.Alpha;
            double beta = ReaderWorker.currentState.Low_Beta + ReaderWorker.currentState.High_Beta;
            double gamma = ReaderWorker.currentState.Gamma;

            String alphaString = alpha.ToString().Replace(',', '.');
            String betaString = beta.ToString().Replace(',', '.');
            String gammaString = gamma.ToString().Replace(',', '.');

            string args = string.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\"", fileName, alphaString, betaString, gammaString, "-fuzz");
            p.StartInfo = new ProcessStartInfo(pythonDir, args)
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
