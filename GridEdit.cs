using System.Windows.Controls;

using static EditText;

class GridEdit : Grid
{
    public Grid EditInit()
    {
        Children.Add(editText.TextInit());

        return this;
    }

    public void EditDone()
    {
        editText.TextSave();
    }

    public void EditRuns()
    {
        editText.TextOpen("d:\\test\\info.txt");
    }

    public static GridEdit gridEdit = new GridEdit();
}