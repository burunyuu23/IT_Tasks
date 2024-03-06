using System.Text.RegularExpressions;
using System.Windows.Media;
using IT_Tasks.Model.FirstTask;

namespace IT_Tasks.Model;

public abstract class IFile
{
    private static readonly string PathPattern = "^(?:[a-zA-Z]:(\\\\\\\\|\\/\\/))([^\\\\\\/\\:*?<>\"|]+[\\\\\\/]?)+$";

    public string? Name { get; protected set; }

    public Category Category { get; protected set; }

    /// <summary>
    /// In bytes
    /// </summary>
    public int Size { get; protected set; }

    public ImageSource ImageSource => CategoryUtils.GetCategoryImage(Category);

    protected string _path;
    public virtual string Path
    {
        get => _path;
        protected set
        {
            if (!Regex.Match(value, PathPattern).Success)
            {
                throw new Exception("Incorrect path");
            }
            _path = value;
        }
    }
    
    public abstract IFile Copy();
    public abstract IFile Paste(IFile toFile);
    public abstract void Move(IFile toFile);
    public void Rename(string? newName) => Name = newName;
}