using MenuBuilder.Abstraction;
using MissleLauncher.Missles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace MissleLauncher
{
    public class MissleLauncherController
    {
        private MissleLauncherStock _stock;
        public MissleFactory MissleFactory { get; private set; }
        public MissleLauncherController(MissleLauncherStock stock)
        {
            MissleFactory = new MissleFactory();
            _stock = stock;
        }

        public string AddMissle(string missle) 
        {
            try
            {
                _stock.Missles.Add(MissleFactory.Generate(missle));
            }
            catch (ArgumentException ex) 
            {
                return $"has not succeded to add cause {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"has not succeded to add cause {ex.Message}";
            }
            return "added succesfully";
        }

        /*public string Launch(string name, int num = 0)
        {
            int Counter = 0;

        }*/

        public string StockReport(string userParam)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"there are {_stock.Missles.Count} missles: ");
            _stock.Missles.ForEach(missle => builder.AppendLine($"{missle.Name} missle"));
            return builder.ToString();
        }

    }
}
