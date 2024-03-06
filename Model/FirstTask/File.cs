namespace IT_Tasks.Model.FirstTask;

public class File : IFile
{
    public File(string? name, Category? category, int? size, string path)
    {
        Name = name;
        if (category == null)
        {
            Category = Category.Folder;
            Size = 0;
        }
        else
        {
            Category = (Category)category;
            Size = size ?? 0;
        }
        Path = path;
    }

    public override IFile Copy() => new File(Name, Category, Size, Path);

    public override IFile Paste(IFile toFile) => new File(Name, Category, Size, toFile.Path);

    /// <summary>
    /// В данной реализации будут проблемы, если переместить папку в которой есть файлы (у них не изменится путь, эта проблема решится во втором таске)
    /// </summary>
    public override void Move(IFile toFile) => Path = toFile.Path + (toFile.Path.EndsWith('/') || toFile.Path.EndsWith('\\') ? toFile.Name : $"/{toFile.Name}");
}