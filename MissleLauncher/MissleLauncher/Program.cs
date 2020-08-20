using System;

namespace MissleLauncher
{
    class Program
    {
        static void Main(string[] args) 
        {
            MissleLauncherStock stock = new MissleLauncherStock();
            MissleLauncherController controller = new MissleLauncherController(stock);
            MissleLauncherRunner runner = new MissleLauncherRunner(controller);
            runner.Run();
        }
    }
}
