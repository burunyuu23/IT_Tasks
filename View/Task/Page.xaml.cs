using System.Windows.Controls;
using System.Windows.Input;
using IT_Task1.shared.components;
using IT_Tasks.Model;
using IT_Tasks.ViewModel;

namespace IT_Tasks.View.Task;

public partial class Page : System.Windows.Controls.Page
{
    private readonly TaskViewModel _taskViewModel;
    public Page(TaskViewModel taskViewModel)
    {
        InitializeComponent();

        _taskViewModel = taskViewModel;
        DataContext = _taskViewModel;
    }
    
    private void FilesList_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                _taskViewModel.Buffer = null;
                break;
        }
        if (_taskViewModel.SelectedFile == null || Keyboard.Modifiers != ModifierKeys.Control) return;
        Prompt? dialog;
        Select? selectDialog;
        var selected = (IFile)((ListBox)sender).SelectedItem;
        switch (e.Key)
        {
            case Key.C:
                _taskViewModel.CopyFileCommand.Execute(selected);
                break;
            case Key.V:
                _taskViewModel.PasteFileCommand.Execute(selected);
                break;
            case Key.R:
                dialog = new Prompt("Введите новое название: ", _taskViewModel.SelectedFile?.Name);
                dialog.ShowDialog();
                if (dialog.DialogResult == true)
                {
                    _taskViewModel.NewFileName = dialog.ResponseText;
                    _taskViewModel.RenameFileCommand.Execute(selected);
                }
                break;
            case Key.M:
                selectDialog = new Select(_taskViewModel, "Выберите папку в которую хотите переместить файл: ");
                selectDialog.ShowDialog();
                
                if (selectDialog.DialogResult == true)
                {
                    _taskViewModel.MoveFileCommand.Execute(selectDialog.SelectedItem);
                }
                break;
        }

        e.Handled = true;
    }
}