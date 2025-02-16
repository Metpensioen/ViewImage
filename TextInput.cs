using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

class TextInput
{
    public static string InputBox(string title, string input)
    {
        TextBox textBox = new TextBox()
        {
            Text = input,
        };

        Window window = new Window()
        {
            Height = 60,
            Width = 400,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Title = title,
            Content = textBox,
        };

        textBox.Focus();

        window.KeyUp += BoxKeyUp;

        window.ShowDialog();

        void BoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                input = textBox.Text;
                window.Close();
            }
        }

        return input;
    }
}