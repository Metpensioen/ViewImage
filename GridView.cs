using System.Windows.Controls;

using static ViewImage;

class GridView : Grid
{
    public Grid ViewInit()
    {
        Children.Add(viewImage.ImageInit());

        return this;
    }

    public static GridView gridView = new GridView();
}