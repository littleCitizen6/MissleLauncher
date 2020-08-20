using MenuBuilder.Abstraction;
using MissleLauncher.LaunchTech;
using MissleLauncher.Missles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace MissleLauncher
{
    public class MissleLauncherController
    {
        private MissleLauncherStock _stock;
        public MissleFactory MissleFactory { get; private set; }
        private LaunchTechFactory _techFactory;
        public MissleLauncherController(MissleLauncherStock stock)
        {
            MissleFactory = new MissleFactory();
            _stock = stock;
            _techFactory = new LaunchTechFactory();
            
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

        public string Launch(string name, int launchCount, MenuHendler hendler) 
        {
            StringBuilder builder = new StringBuilder();
            bool noMore = false;
            for (int i = 0; i < launchCount && !noMore; i++)
            {
                var missle = _stock.Missles.FirstOrDefault(missle => missle.Name == name && !missle.FailedLaunch);
                if (missle == null)
                {
                    noMore = true;
                    builder.AppendLine($"no more miisle of type {name}");
                }
                else
                {
                    bool launched = missle.Launch(_techFactory.Generate(missle.Name, hendler));
                    builder.AppendLine($"for {name} number {i + 1} launch result is {launched}");
                    if (launched)
                    {
                        _stock.Missles.Remove(missle);
                    }
                }
            }
            return builder.ToString();
            
        }

        public string StockReport(string userParam)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"there are {_stock.Missles.Count} missles: ");
            _stock.Missles.ForEach(missle => builder.AppendLine($"{missle.Name} missle"));
            return builder.ToString();
        }
        public string RemoveMissleAt(string index)
        {
            _stock.Missles.RemoveAt(int.Parse(index));
            return "removed succesfully";
        }
        internal string TotalWar(MenuHendler hendler)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var missle in _stock.Missles)
            {
                if(!missle.FailedLaunch)
                {
                    bool launched = missle.Launch(_techFactory.Generate(missle.Name, hendler));
                    builder.AppendLine($"for {missle.Name} launch result is {launched}");
                    if (launched)
                    {
                        _stock.Missles.Remove(missle);
                    }
                }
            }
            return builder.ToString();
        }
    }
}
