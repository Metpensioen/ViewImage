using System.Windows;
using System.Windows.Controls;

using static GridEdit;
using static GridMenu;
using static GridView;

class WindowGrid : Grid
{
    public Grid GridInit()
    {
        for (int i = 1; i <= 2; i++) // maak 2 rijen
        {
            RowDefinitions.Add(new RowDefinition());
        }

        RowDefinitions[0].Height = new GridLength(30);

        for (int i = 1; i <= 2; i++) // maak 2 kolommen
        {
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        ShowGridLines = true;

        Children.Add(gridMenu.MenuInit());
        Children.Add(gridEdit.EditInit());
        Children.Add(gridView.ViewInit());

        Grid.SetColumnSpan(gridMenu, 2);

        Grid.SetRow(gridEdit, 1);
        Grid.SetColumn(gridEdit, 1);
        Grid.SetColumnSpan(gridEdit, 1);

        Grid.SetRow(gridView, 1);
        Grid.SetColumn(gridView, 0);
        Grid.SetColumnSpan(gridView, 1);

        return this;
    }

    public void GridDone()
    {
        gridEdit.EditDone();
    }

    public void GridRuns()
    {
        gridEdit.EditRuns();
    }

    public static WindowGrid windowGrid = new WindowGrid();
}