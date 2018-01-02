using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindReader.integration
{
    class BandDataExeRunner
    {
        String exePath = string.Format(@"{0}\external\AverageBandPowers.exe", Application.StartupPath);
        public static Process BandDatareaderProcess;

        public void RunBandReader()
        {
            BandDatareaderProcess = Process.Start(exePath);
        }

        public static void StopBandDataRaderProcess()
        {
            BandDatareaderProcess.Close();
        }

    }
}
