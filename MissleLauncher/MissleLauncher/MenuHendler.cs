using System;
using System.Collections.Generic;
using System.Text;
using MenuBuilder;
using MenuBuilder.Abstraction;
using MenuBuilder.Menus;

namespace MissleLauncher
{
    public class MenuHendler
    {
        public MenuRunner<string> Runner { get; set; }
        public IParamProvider Provider { get; set; }
        public IPresenter Presenter { get; set; }
        public IParamVaidator Validator { get; set; }
        public IBrowser Browser { get; set; }
        public MenuHendler(IMenu headMenu)
        {
            var headMenu = CreateHeadMenu();
            headMenu.AddAction("void1", Action1, "for say hi");
            headMenu.AddAction("m2", MoveToMenu2, "for move to menu 2");
            headMenu.AddAction("exit", Exit, "for exit");
            var menu2 = new NumbersMenu();
            menu2.AddAction("1", Action1, "for say hi");
            menu2.AddAction("2", Exit, "for exit");
            menu2.AddAction("3", Previous, "for the previous menu");
            Browser = new StackBrowser(headMenu);
            Provider = new ConsoleProvider();
            Presenter = new ConsolePresenter();
            Validator = new StringParamValidator();
            Runner = new MenuRunner<string>(_presenter, _provider, _validator, _browser);
            Runner.AddMenu("m1", headMenu);
            Runner.AddMenu("m2", menu2);
        }

        public IMenu CreateNumberMenu(Dictionary<int,Func<string>> actions)
        {
            var menu = new NumbersMenu();
            foreach (int key in actions.Keys)
            {
                menu.AddAction(key.ToString(), actions[key],"")
            }
        }
    }
}
