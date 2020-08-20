using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.LaunchTech
{
    public class RelativeDistance1500Tech : ILaunchTechnique
    {
        const int MAX_DISTANCE = 1500;
        private double[] _params;
        public RelativeDistance1500Tech(params double[] parametrs)
        {
            _params = parametrs;
        }
        public double CalculatePercentage()
        {
            double distance = _params[0];
            return ((MAX_DISTANCE - distance)/ MAX_DISTANCE) *100;
            

        }
    }
}
