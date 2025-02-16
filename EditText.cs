using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using static GridMenu;
using static TabsFile;
using static TextInput;
using static ViewImage;

class EditText : TextBox
{
    public static string textFile = "";
    public static string textInput;
    public static string textReplace;

    public TextBox TextInit()
    {
        BorderThickness = new Thickness(0);
        Background = Brushes.Transparent;
        Foreground = Brushes.White;
        FontFamily = new FontFamily("Consolas");
        FontSize = 16;
        Margin = new Thickness(8, 0, 0, 0);
        AcceptsReturn = true;
        TextWrapping = TextWrapping.Wrap;
        VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        CaretBrush = Brushes.Yellow;
        SelectionBrush = Brushes.Yellow;
        SelectionOpacity = 0.5;

        SelectionChanged += TextSelection;

        return this;
    }

    public string TextIndex()
    {
        string text = "";
        string path = TabsFile.filePath;
        int length = path.Length + 1;
        string name;
        string type;

        foreach (string folder in Directory.GetDirectories(path))
        {
            text += folder.Substring(length) + "\n";
        }

        if (text != "") text += "\n";

        foreach (string file in Directory.GetFiles(path))
        {
            name = FileName(file);
            type = FileType(file);

            if (type == ".txt") type = "";

            text += name + type + "\n";
        }

        return text;
    }

    public void TextOpen(string file)
    {
        textFile = file;

        if (!textFile.Contains("index"))
        {
            if (File.Exists(textFile))
            {
                Text = File.ReadAllText(textFile);
            }
        }
        else
        {
            Text = TextIndex();
        }

        file = FilePath(textFile) + "\\folder.jpg";

        if (File.Exists(file)) viewImage.ImageOpen(file);


        gridMenu.menuText.Text = textFile;
        Focus();
    }

    public void TextSave()
    {
        if (!textFile.Contains("index") && textFile != "") File.WriteAllText(textFile, Text);
    }

    public void TextFind(object sender, RoutedEventArgs e)
    {
        textInput = InputBox("Find", textInput);

        int length = textInput.Length;
        int caret = editText.CaretIndex;
        int position = editText.Text.IndexOf(textInput, caret + length);

        if (position > -1)
        {
            editText.Select(position, length);
        }
        else
        {
            editText.Select(caret, 0);
        }
    }

    public void TextReplace(object sender, RoutedEventArgs e)
    {
        textInput = InputBox("Find", textInput);
        textReplace = InputBox("Replace", textReplace);

        int position = 0;
        int length = 0;
        int max;

    findNext:
        
        try
        {
            position = editText.Text.IndexOf(textInput, length);
            length = position + textInput.Length;
        }
        catch { }

        max = editText.Text.Length;

        if (position > -1 && length < max)
        {
            editText.Text = editText.Text.Substring(0, position) + textReplace + editText.Text.Substring(length);
            goto findNext;
        }
    }

    public void TextSelection(object sender, RoutedEventArgs e)
    {
        string file = GetLineText(GetLineIndexFromCharacterIndex(CaretIndex)); // geselecteerde regel

        if (file != imageFile)
        {
            imageFile = file;
            viewImage.ImageOpen(imageFile);
        }
    }

    public static EditText editText = new EditText();
}