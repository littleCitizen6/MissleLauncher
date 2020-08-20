using MenuBuilder.Abstraction;
using MissleLauncher.Missles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissleLauncher.LaunchTech
{
    public class LaunchTechFactory
    {
        public ILaunchTechnique Generate(string missle, MenuHendler hendler)
        {
            switch (missle)
            {
                case "Torpedo":
                    return new LaunchChance100();
                case "Ballistic":
                    return new LaunchChance50();
                case "Cruise":
                    return new LaunchChance20();
                case "LongTerm":
                    return new RelativeDistance1500Tech(hendler.GetInt("please insert distance"));
            }
            throw new NotImplementedException("the launcher doesnt have a technique for this missle");
        }
    }
}
