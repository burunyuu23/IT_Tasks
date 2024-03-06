namespace IT_Tasks.Model.SecondTask;

// TODO: разделить на классы Folder и File
public class File : IFile
{
    private const string DiskPath = "C://";

    private File? _parent;
    public File? Parent
    {
        get => _parent;
        set
        {
            _parent?.Children.Remove(this);
            _parent = value;
            _parent?.Children.Add(this);
        }
    }

    public readonly List<File> Children = [];
    
    public override string Path => Parent == null ? $"{DiskPath}" : $"{Parent.Path}{Parent.Name}/";

    public File(string? name, Category? category, int? size, File? parent)
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
        Parent = parent;
    }

    public override IFile Copy() => new File(Name, Category, Size, Parent);

    public override IFile Paste(IFile toIFile) 
    {
        if (toIFile is not File toFile) return this;
        if (toFile.Category != Category.Folder) return this;
        Parent = toFile;
        return this;
    }

    public override void Move(IFile toIFile)
    {
        if (toIFile is not File toFile) return;
        Parent = toFile;
    }
}