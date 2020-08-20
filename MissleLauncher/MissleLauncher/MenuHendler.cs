using System;
using System.Collections.Generic;
using System.Text;
using MenuBuilder;
using MenuBuilder.Abstraction;
using MenuBuilder.Menus;
using MenuBuilder.Presenters;
using MenuBuilder.Providers;
using MenuBuilder.Validators;

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
            
            //Browser = new StackBrowser(headMenu);
            Provider = new ConsoleProvider();
            Presenter = new ConsolePresenter();
            Validator = new StringParamValidator();
           // Runner = new MenuRunner<string>(presenter, provider, validator, browser);
            //Runner.AddMenu("m1", headMenu);
           // Runner.AddMenu("m2", menu2);
        }

       /* public IMenu CreateNumberMenu(Dictionary<int,Func<string>> actions)
        {
            var menu = new NumbersMenu();
            foreach (int key in actions.Keys)
            {
                menu.AddAction(key.ToString(), actions[key],"")
            }
        }*/
    }
}
