using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissleLauncher.LaunchTech
{
    public class LaunchTechFactory
    {
        public ILaunchTechnique Generate(string launchTechnique)
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(type => type.IsAssignableFrom(typeof(ILaunchTechnique)))
                .FirstOrDefault(type => type.Name == launchTechnique);
            if (type == null)
            {
                throw new ArgumentException("type of LaunchTechnique doesnt recognize");
            }

            return (ILaunchTechnique)Activator.CreateInstance(type);

        }
    }
}
