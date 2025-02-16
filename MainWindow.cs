using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;

using static WindowGrid;

class MainWindow : Window
{
    public WindowChrome windowChrome = new WindowChrome();
    public static Brush backColor = new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x28, 0x3B));

    public void WindowInit()
    {
        windowChrome.GlassFrameThickness = new Thickness(0, 30, 0, 0);

        WindowChrome.SetWindowChrome(this, windowChrome);

        Width = 1800;
        Height = 930;
        Background = backColor;
        Content = windowGrid.GridInit();

        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        StateChanged += WindowSize;
        Closing += WindowDone;
    }

    public void WindowDone(object sender, CancelEventArgs e)
    {
        windowGrid.GridDone();
    }

    public void WindowRuns()
    {
        windowGrid.GridRuns();
        mainWindow.ShowDialog();
    }

    public void WindowSize(object sender, EventArgs e) // afmeting veranderen
    {
        BorderThickness = (WindowState == WindowState.Maximized) ? new Thickness(8) : new Thickness(0);
    }

    public static MainWindow mainWindow = new MainWindow();

    [STAThread]

    static void Main()
    {
        mainWindow.WindowInit();
        mainWindow.WindowRuns();
    }
}