using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MissleLauncher.Missles
{
    public class MissleFactory
    {
        public MissleFactory()
        {

        }

        public Missle Generate(string missleType) 
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(type => type.IsAssignableFrom(typeof(Missle)))
                .FirstOrDefault(type => type.Name==missleType);
            if(type == null)
            {
                throw new ArgumentException("type of missle doesnt recognize");
            }

            return (Missle)Activator.CreateInstance(type);
           
        }

    }
}
