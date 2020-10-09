using System;
using Gdk;
using Gtk;
using WebKit2;

namespace ddsharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            WebView mainView = new WebView();
            Application.Init();
            WebKit2.Settings mainViewSettings = new WebKit2.Settings();
            MainWindow win = new MainWindow();
            Entry searchBar = new Entry();
            Grid mainGrid = new Gtk.Grid();
            Button back = new Button();
            Button forward = new Button();
            Button reload = new Button();
            Pixbuf mainIcon = new Pixbuf("/usr/share/icons/Faenza/apps/16/chromium.png");
            AboutDialog about = new AboutDialog();
            string[] artist = { "Charalabos Chatzoglou" };
            string[] author = { "Charalabos Chatzoglou" };
            string license = @"      Deep Dive is free software: you can redistribute it and / or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

    Deep Dive is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Deep Dive.If not, see < https://www.gnu.org/licenses/>.";

            about.Show();
            about.DestroyWithParent = true;
            about.TransientFor = win;
            about.Modal = true;
            about.Artists = artist;
            about.Authors = author;
            about.ProgramName = @"Deep Dive lite(sharp)
            A privacy oriented web browser 
            which keeps only session history";
            about.Version = "1.0";
            about.License = license;
            about.Logo = mainIcon;
            win.Icon = mainIcon;
            reload.Pressed += (sender, e) => {
                mainView.Reload();
                searchBar.Text = mainView.Uri;
            };
            back.Pressed += (sender, e) => {
                mainView.GoBack();
            };
            forward.Pressed += (sender, e) => {
                mainView.GoForward();
            };
            back.Label = "←";
            forward.Label = "→";
            reload.Label = "\ud83d\uddd8";
            mainGrid.Attach(searchBar, 0, 0, 1, 1);
            mainGrid.AttachNextTo(mainView, searchBar, PositionType.Bottom, 1, 1);
            mainGrid.AttachNextTo(forward, searchBar, PositionType.Left, 1, 1);
            mainGrid.AttachNextTo(back, forward, PositionType.Left, 1, 1);
            mainGrid.AttachNextTo(reload, back, PositionType.Left, 1, 1);
            mainView.Hexpand = true;
            mainView.Vexpand = true;
            searchBar.Activated += (sender, e) => {
                mainView.LoadUri(searchBar.Text);
            };
            mainViewSettings.EnableDeveloperExtras = true;
            mainViewSettings.EnableWebaudio = true;
            mainViewSettings.EnableJavascript = true;
            mainViewSettings.EnableWebgl = true;
            mainViewSettings.EnableSmoothScrolling = true;
            mainViewSettings.EnablePrivateBrowsing = true;
            mainViewSettings.EnableAccelerated2dCanvas = true;
            mainView.LoadChanged += (o, sender) => {
                searchBar.Text = mainView.Uri;
                win.Title = mainView.Title + " - Deep Dive lite";
            };
            mainView.Inspector.Show();
            mainView.Settings = mainViewSettings;
            mainView.LoadUri("https://duckduckgo.com/");
            win.Add(mainGrid);
            win.ShowAll();
            Application.Run();
        }
    }
}
