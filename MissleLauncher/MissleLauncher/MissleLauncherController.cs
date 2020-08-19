using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher
{
    public class MissleLauncherController
    {
        private MissleLauncherStock _stock;
        public Dictionary<int, Func<string>> Actions;
        public MissleLauncherController(MissleLauncherStock stock)
        {
            _stock = stock;
        }

        private string AddMissle() { }

    }
}
