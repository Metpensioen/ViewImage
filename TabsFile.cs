using System.Windows;

using static EditText;
using static TextInput;

class TabsFile
{
    public static string filePath = "D:\\test";

    public static string FileName(string file)
    {
        file = file.Substring(file.LastIndexOf("\\") + 1);
        file = file.Substring(0, file.LastIndexOf("."));

        return file;
    }

    public static string FilePath(string file)
    {
        string path = file.Substring(0, file.LastIndexOf("\\"));

        return path;
    }

    public static string FileType(string file)
    {
        file = file.Substring(file.LastIndexOf("."));

        return file;
    }

    public void FileNew(object sender, RoutedEventArgs e)
    {
        textInput = InputBox("Enter filename", textInput);

        editText.TextOpen(filePath + "\\" + textInput + ".txt");
        textInput = "";
    }

    public static TabsFile tabsFile = new TabsFile();
}