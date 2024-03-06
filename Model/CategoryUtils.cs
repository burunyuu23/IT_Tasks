using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IT_Tasks.Model;

public static class CategoryUtils
{
    public static readonly ImageSource FolderImage =
        new BitmapImage(new Uri(@"file://C:\Users\user\RiderProjects\IT_Tasks\Shared\Icons\folder.png"));
    
    public static readonly ImageSource FileImage =
        new BitmapImage(new Uri(@"file://C:\Users\user\RiderProjects\IT_Tasks\Shared\Icons\file.png"));

    public static ImageSource GetCategoryImage(Category category)
    {
        return category switch
        {
            Category.Folder => FolderImage,
            Category.File => FileImage,
            _ => throw new Exception("No category for file!")
        };
    }
}