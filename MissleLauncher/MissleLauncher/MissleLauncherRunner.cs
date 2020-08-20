using MenuBuilder.Abstraction;
using MissleLauncher.Missles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher
{
    public class MissleLauncherRunner
    {
        private MissleLauncherController _controller;
        private MenuHendler _menuHendler;
        private IMenu _headMenu;

        public MissleLauncherRunner(MissleLauncherController controller)
        {
            _controller = controller;
            _menuHendler = new MenuHendler();
            _headMenu = MenuHendler.CreateNumberMenu(GetHeadMenuOptions());
            InitMenus();
        }

        public void Run()
        {
            _menuHendler.Runner.Run(_headMenu);
        }

        private void InitMenus()
        {
            _menuHendler.Runner.AddMenu("1", _menuHendler.CreateStringsFunctionMenu(_controller.MissleFactory.GetMissles(), _controller.AddMissle));
            _menuHendler.Runner.AddMenu("head", _headMenu);
        }
        private List<Option<int>> GetHeadMenuOptions()
        {
            var mainActions = new List<Option<int>>();
            mainActions.Add(new Option<int>(1, _menuHendler.MoveToOtherMenu, "choose missle to add"));
            mainActions.Add(new Option<int>(3, _controller.StockReport, "get stock report"));
            return mainActions;
        }


    }
}
