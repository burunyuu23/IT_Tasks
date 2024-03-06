using IT_Tasks.Model;
using IT_Tasks.Model.FirstTask;

namespace IT_Tasks.ViewModel.FirstTask;

internal class FirstTaskViewModel : TaskViewModel
{
    public static FirstTaskViewModel Instance { get; } = new();

    private FirstTaskViewModel()
    {
        AddFile(new File("Анапа 2009", Category.Folder, null, "C://Documents/"));
        AddFile(new File("Геленджик 2008", Category.Folder, null, "C://Documents/"));
        AddFile(new File("Удивительный_цифровой_цирк__2009_08_14_160845.ppeg", Category.File, 1984, "C://Documents/Анапа 2009/"));
        AddFile(new File("Маркотхский_хребет__2008_02_22_211233.ppeg", Category.File, 1984, "C://Documents/Анапа 2009/"));
    }
}