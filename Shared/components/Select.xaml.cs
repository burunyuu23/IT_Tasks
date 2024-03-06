using System.Windows;
using IT_Tasks.Model;
using IT_Tasks.Model.FirstTask;
using IT_Tasks.ViewModel;

namespace IT_Task1.shared.components;

public partial class Select : Window
{
    private readonly TaskViewModel _taskViewModel;

    public Select(TaskViewModel taskViewModel, string title)
    {
        InitializeComponent();

        _taskViewModel = taskViewModel;
        DataContext = _taskViewModel;
        FolderFiles.ItemsSource = _taskViewModel.Files.Where(file => file.Category == Category.Folder);
        Title.Text = title;
    }

    public IFile SelectedItem => (IFile)FolderFiles.SelectedItem;

    private void OKButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}