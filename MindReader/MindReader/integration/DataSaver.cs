using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.integration
{
    class DataSaver
    {
        private String createCSVEntry(double alpha, double lowBtea, double highBeta, double gamma, double theta)
        {
            String header = "TIME_STAMP,ALPHA,LOW_BETA,HIGH_BETA,GAMMA,THETA";
            String line = GetPauseSeparatedTimestamp(DateTime.Now) + ";" + alpha + ";" + lowBtea + ";" + highBeta + ";" + gamma + ";" + theta;

            return header + "\n" + line;
        }


        private String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        private String GetPauseSeparatedTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd-HH:mm:ss:fff");
        }

        public void saveCurrentState()
        {
            Guid id = Guid.NewGuid();
            string path = @"Saved\" + GetTimestamp(DateTime.Now) + id.ToString();
            if (!File.Exists(path))
            {
                File.WriteAllText(path, createCSVEntry(ReaderWorker.currentState.Alpha, ReaderWorker.currentState.Low_Beta, ReaderWorker.currentState.High_Beta, ReaderWorker.currentState.Gamma, ReaderWorker.currentState.Theta));
            }
        }

    }
}
