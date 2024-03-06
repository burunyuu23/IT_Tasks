using IT_Tasks.Model;
using IT_Tasks.Model.SecondTask;

namespace IT_Tasks.ViewModel.SecondTask;

internal class SecondTaskViewModel : TaskViewModel
{
    public static SecondTaskViewModel Instance { get; } = new();

    private SecondTaskViewModel()
    {
        File anapa = new("Анапа 2009", Category.Folder, null, null);
        File gelendzhik = new("Геленджик 2008", Category.Folder, null, null);
        AddFile(anapa);
        AddFile(gelendzhik);
        AddFile(new File("Удивительный_цифровой_цирк__2009_08_14_160845.ppeg", Category.File, 1984, anapa));
        AddFile(new File("Маркотхский_хребет__2008_02_22_211233.ppeg", Category.File, 1984, anapa));
    }
}