using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MissleLauncher.Missles
{
    public class MissleFactory
    {
        public IEnumerable<string> GetMissles()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(type => typeof(Missle).IsAssignableFrom(type) && type != typeof(Missle)).Select(type => type.Name);
        }
        public Missle Generate(string missleType) 
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(type => typeof(Missle).IsAssignableFrom(type) && type != typeof(Missle))
                .FirstOrDefault(type => type.Name==missleType);
            if(type == null)
            {
                throw new ArgumentException("type of missle doesnt recognize");
            }

            return (Missle)Activator.CreateInstance(type, new string[] {missleType });
           
        }

    }
}
