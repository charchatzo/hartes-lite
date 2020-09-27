using System;
using Gtk;
using WebKit2;

namespace deepdivegtksharp
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
            back.Activated += (sender, e) => {
                mainView.GoBack();
            };
            forward.Activated += (sender, e) => {
                mainView.GoForward();
            };
            back.Label = "<-";
            forward.Label = "->";
            mainGrid.Attach(searchBar, 0, 0, 1, 1);
            mainGrid.AttachNextTo(mainView, searchBar, PositionType.Bottom, 1, 1);
            mainGrid.AttachNextTo(forward, searchBar, PositionType.Left, 1, 1);
            mainGrid.AttachNextTo(back, forward, PositionType.Left, 1, 1);
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
            };
            mainView.Inspector.Show();
            mainView.Settings = mainViewSettings;
            mainView.LoadUri("https://google.com/");
            win.Add(mainGrid);
            win.ShowAll();
            Application.Run();
        }
    }
}
