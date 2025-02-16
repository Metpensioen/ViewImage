using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using static GridView;

class ViewImage : Image
{
    public static string imageFile = "";

    public Image ImageInit()
    {
        HorizontalAlignment = HorizontalAlignment.Left; // default = stretch
        VerticalAlignment = VerticalAlignment.Top; // default = stretch

        return this;
    }

    public void ImageOpen(string file)
    {
        if (file != null)
        {
            imageFile = file;
            Source = new BitmapImage(new System.Uri(imageFile));

            if (!gridView.Children.Contains(viewImage)) gridView.Children.Add(viewImage);
        }
    }

    public static ViewImage viewImage = new ViewImage();
}