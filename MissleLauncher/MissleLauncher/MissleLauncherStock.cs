using MissleLauncher.Missles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher
{
    public class MissleLauncherStock
    {
        public List<Missle> Missles { get; set; }
        public MissleLauncherStock()
        {
            Missles = new List<Missle>();
        }
    }
}
