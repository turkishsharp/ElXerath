using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using System.Drawing;


namespace ElXerath
{

    public class ElXerathMenu
    {
        public static Menu _menu;

        public static void Initialize()
        {
            _menu = new Menu("ElXerath(TR)", "menu", true);

            //ElXerath.Orbwalker
            var orbwalkerMenu = new Menu("Orbwalker", "orbwalker");
            Xerath.Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            _menu.AddSubMenu(orbwalkerMenu);

            //ElXerath.TargetSelector
            var targetSelector = new Menu("Hedef Secme", "TargetSelector");
            TargetSelector.AddToMenu(targetSelector);
            _menu.AddSubMenu(targetSelector);

            var cMenu = new Menu("Kombo", "Combo");
            cMenu.AddItem(new MenuItem("ElXerath.Combo.Q", "Q'yu Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElXerath.Combo.W", "W'yu Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElXerath.Combo.E", "E'yi Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ComboActive", "Kombo!").SetValue(new KeyBind(32, KeyBindType.Press)));

            _menu.AddSubMenu(cMenu);

            var rMenu = new Menu("Ulti", "Ult");
            rMenu.AddItem(new MenuItem("ElXerath.R.AutoUseR", "Yükleri Otomatik Kullanma").SetValue(true));
            rMenu.AddItem(new MenuItem("ElXerath.R.Mode", "Mod ").SetValue(new StringList(new[] { "Normal", "Özel Gecikmeler", "Dokunmayla", "Özel Vurma Şansı" })));
            rMenu.AddItem(new MenuItem("ElXerath.R.OnTap", "Ultiyi Tıklama İle Kullan").SetValue(new KeyBind("T".ToCharArray()[0], KeyBindType.Press)));
            rMenu.AddItem(new MenuItem("ElXerath.R.Block", "Hareketi Engelle").SetValue(true));

            rMenu.SubMenu("CustomDelay").AddItem(new MenuItem("ElXerath.R.Delay", "Özel Gecikmeler").SetValue(true));
            for (var i = 1; i <= 3; i++)
                rMenu.SubMenu("CustomDelay").SubMenu("Custom delay").AddItem(new MenuItem("Delay" + i, "Delay" + i).SetValue(new Slider(0, 1500, 0)));

            _menu.AddSubMenu(rMenu);   

            var hMenu = new Menu("Harass", "Dürtme");
            hMenu.AddItem(new MenuItem("ElXerath.Harass.Q", "Q'yu Kullan").SetValue(true));
            hMenu.AddItem(new MenuItem("ElXerath.Harass.W", "W'yu Kullan").SetValue(true));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElXerath.AutoHarass", "[Devamlı] Otomatik Dürtme", false).SetValue(new KeyBind("U".ToCharArray()[0], KeyBindType.Toggle)));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElXerath.UseQAutoHarass", "Q'yu Kullan").SetValue(true));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElXerath.UseWAutoHarass", "W'yu Kullan").SetValue(true));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElXerath.harass.mana", "Otomatik Dürtme İçin Mana")).SetValue(new Slider(55));

            _menu.AddSubMenu(hMenu);

            var lMenu = new Menu("Clear", "Koridor Temizleme");
            lMenu.AddItem(new MenuItem("ElXerath.clear.Q", "Use Q").SetValue(true));
            lMenu.AddItem(new MenuItem("ElXerath.clear.W", "Use W").SetValue(true));
            lMenu.AddItem(new MenuItem("fasfsafsafsasfasfa", ""));
            lMenu.AddItem(new MenuItem("ElXerath.jclear.Q", "Jungle Use Q").SetValue(true));
            lMenu.AddItem(new MenuItem("ElXerath.jclear.W", "Jungle Use W").SetValue(true));
            lMenu.AddItem(new MenuItem("ElXerath.jclear.E", "Jungle Use E").SetValue(true));
            lMenu.AddItem(new MenuItem("fasfsafsafsadsasasfasfa", ""));
            lMenu.AddItem(new MenuItem("minmanaclear", "Auto harass mana")).SetValue(new Slider(55));

            _menu.AddSubMenu(lMenu);

            //ElXerath.Misc
            var miscMenu = new Menu("Misc", "Misc");
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.off", "Turn drawings off").SetValue(false));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.Q", "Draw Q").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.W", "Draw W").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.E", "Draw E").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.R", "Draw R").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.Text", "Draw Text").SetValue(true));
            miscMenu.AddItem(new MenuItem("ElXerath.Draw.RON", "Draw R target radius").SetValue(true));
            miscMenu.AddItem(new MenuItem("useEFafsdsgdrmddsddsasfsasdsdsaadsd", ""));
            miscMenu.AddItem(new MenuItem("ElXerath.Ignite", "Use ignite").SetValue(true));
            miscMenu.AddItem(new MenuItem("ElXerath.misc.ks", "Killsteal mode").SetValue(false));
            miscMenu.AddItem(new MenuItem("ElXerath.misc.Antigapcloser", "Antigapcloser").SetValue(true));
           // miscMenu.AddItem(new MenuItem("ElXerath.misc.Notifications", "Use notifications").SetValue(true));
            miscMenu.AddItem(new MenuItem("useEdaadaDFafsdsgdrmddsddsasfsasdsdsaadsd", ""));
            miscMenu.AddItem(new MenuItem("ElXerath.hitChance", "Hitchance Q").SetValue(new StringList(new[] { "Low", "Medium", "High", "Very High" }, 3)));

            _menu.AddSubMenu(miscMenu);

            //Here comes the moneyyy, money, money, moneyyyy
            var credits = new Menu("Credits", "jQuery");
            credits.AddItem(new MenuItem("ElXerath.Paypal", "if you would like to donate via paypal:"));
            credits.AddItem(new MenuItem("ElXerath.Email", "info@zavox.nl"));
            _menu.AddSubMenu(credits);

            _menu.AddItem(new MenuItem("422442fsaafs4242f", ""));
            _menu.AddItem(new MenuItem("422442fsaafsf", "Version: 1.0.0.0"));
            _menu.AddItem(new MenuItem("fsasfafsfsafsa", "Made By jQuery"));

            _menu.AddToMainMenu();

            Console.WriteLine("Menu Loaded");
        }
    }
}
