using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using static EditText;
using static MainWindow;
using static TabsFile;

class GridMenu : Grid
{
    public TextBox menuText = new TextBox()
    {
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center,
        BorderThickness = new Thickness(0),
        Background = Brushes.Transparent,
        Foreground = Brushes.White,
        FontFamily = new FontFamily("Consolas"),
        FontSize = 16.0,
        Height = 20,
        Text = "EditText",
    };

    public Grid MenuInit()
    {
        Rectangle menuIcon = new Rectangle()
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            Width = 30,
            Height = 30,
            Fill = new ImageBrush(new BitmapImage(new Uri("d:\\data\\png\\sc\\c#.png"))),
        };

        MenuItem fileNew = new MenuItem()
        {
            Background = backColor,
            Foreground = Brushes.White,
            BorderThickness = new Thickness(0),
            Header = "_New",
            InputGestureText = "Alt+N",
        };

        gridMenu.MenuShortcut(Key.N, ModifierKeys.Alt, tabsFile.FileNew);

        MenuItem menuFile = new MenuItem()
        {
            BorderThickness = new Thickness(0),

            Header = "_File",
        };

        menuFile.Items.Add(fileNew);

        MenuItem textFind = new MenuItem()
        {
            Background = backColor,
            Foreground = Brushes.White,
            BorderThickness = new Thickness(0),
            Header = "_Find",
            InputGestureText = "Alt+F",
        };

        gridMenu.MenuShortcut(Key.F, ModifierKeys.Alt, editText.TextFind);

        gridMenu.MenuShortcut(Key.H, ModifierKeys.Alt, editText.TextReplace);

        MenuItem menuEdit = new MenuItem()
        {
            Header = "_Edit",
        };

        Menu menuMenu = new Menu()
        {
            Background = Brushes.Transparent,
            Foreground = Brushes.White,
            FontFamily = new FontFamily("Consolas"),
            FontSize = 16,
        };

        menuMenu.Items.Add(menuIcon);
        //menuMenu.Items.Add(menuFile);
        //menuMenu.Items.Add(menuEdit);

        Rectangle menuButton = new Rectangle()
        {
            Width = 130,
            Height = 30,
            Fill = new ImageBrush(new BitmapImage(new Uri("d:\\data\\png\\sc\\buttons.png"))),
            HorizontalAlignment = HorizontalAlignment.Right,
        };

        Children.Add(menuMenu);
        Children.Add(menuText);
        Children.Add(menuButton);

        return this;
    }

    public void MenuShortcut(Key K, ModifierKeys M, ExecutedRoutedEventHandler E)
    {
        RoutedCommand C = new RoutedCommand();

        C.InputGestures.Add(new KeyGesture(K, M));
        mainWindow.CommandBindings.Add(new CommandBinding(C, E));
    }

    public static GridMenu gridMenu = new GridMenu();
}