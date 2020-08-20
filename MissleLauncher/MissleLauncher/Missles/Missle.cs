using MissleLauncher.LaunchTech;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Missles
{
    public abstract class Missle
    {
        public string Name { get; private set; }
        public bool FailedLaunch { get; set; }
        public Missle(string name)
        {
            Name = name;
        }
        public bool Launch(ILaunchTechnique technique)
        {
            Random rander = new Random();
            int randNum = rander.Next(1, 101);
            return technique.CalculatePercentage() >= randNum;
        }

        
    }
}
