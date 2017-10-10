using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindReader.model
{
    class BrainWaveSummary
    {
        //Alpha, Low_beta, High_beta, Gamma, Theta
        private double _Alpha;
        private double _Low_Beta;
        private double _High_beta;
        private double _Gamma;
        private double _Theta;


        public double Alpha
        {
            get
            { return _Alpha; }
            set
            { this._Alpha = value; }
        }

        public double Low_Beta
        {
            get
            { return _Low_Beta; }
            set
            { this._Low_Beta = value; }
        }

        public double High_Beta
        {
            get
            { return _High_beta; }
            set
            { this._High_beta = value; }
        }

        public double Gamma
        {
            get
            { return _Gamma; }
            set
            { this._Gamma = value; }
        }

        public double Theta
        {
            get
            { return _Theta; }
            set
            { this._Theta = value; }
        }

    }
}
