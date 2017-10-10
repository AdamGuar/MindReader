using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindReader.model;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace MindReader.integration
{
    class CSVFileReader
    {
        String CsvPath = string.Format(@"{0}\AverageBandPowers.csv", Application.StartupPath);

        private String ReadLastLine()
        {
            String lastLine = File.ReadLines(CsvPath).Last();
            return lastLine;
        }

        public BrainWaveSummary readBandPowers()
        {
            BrainWaveSummary Summary = new BrainWaveSummary();
            String line = this.ReadLastLine();
            String[] lines = line.Split(',');

            Summary.Alpha = double.Parse(lines[0], CultureInfo.InvariantCulture);
            Summary.Low_Beta = double.Parse(lines[1], CultureInfo.InvariantCulture);
            Summary.High_Beta = double.Parse(lines[2], CultureInfo.InvariantCulture);
            Summary.Gamma = double.Parse(lines[3], CultureInfo.InvariantCulture);
            Summary.Theta = double.Parse(lines[4], CultureInfo.InvariantCulture);

            return Summary;
        }
        

    }
}
