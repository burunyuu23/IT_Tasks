using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IT_Tasks.Model;

namespace IT_Tasks.ViewModel;

public abstract class TaskViewModel : INotifyPropertyChanged
{    
    private RelayCommand? _copyFileCommand;
    public RelayCommand CopyFileCommand =>
        _copyFileCommand ??= new RelayCommand(_ =>
        {
            Buffer = SelectedFile?.Copy();
        });
    
    private RelayCommand? _pasteFileCommand;
    public RelayCommand PasteFileCommand =>
        _pasteFileCommand ??= new RelayCommand(_ =>
        {
            if (Buffer != null && SelectedFile != null) AddFile(Buffer.Paste(SelectedFile));
        });
    
    private RelayCommand? _moveFileCommand;
    public RelayCommand MoveFileCommand =>
        _moveFileCommand ??= new RelayCommand(o =>
        {
            SelectedFile?.Move((IFile)o);
            OnPropertyChanged(nameof(Files));
            SelectedFile = null;
        });
    
    private RelayCommand? _renameFileCommand;
    public RelayCommand RenameFileCommand =>
        _renameFileCommand ??= new RelayCommand(_ =>
        {
            if (NewFileName != "" && Files.All(file => file.Name != NewFileName))
            {
                if (SelectedFile == null) return;
                SelectedFile.Rename(NewFileName);
                SelectedFile = null;
                ErrorText = null;
                OnPropertyChanged(nameof(Files));
            }
            else
            {
                ErrorText = "Имя должно быть уникальным и не пустым";
            }
        });

    private readonly List<IFile> _files = [];
    public ObservableCollection<IFile> Files => new(_files);

    protected void AddFile(IFile file)
    {
        _files.Add(file);
        OnPropertyChanged(nameof(Files));
    }

    private string? _newFileName;
    public string? NewFileName
    {
        get => _newFileName;
        set
        {
            _newFileName = value;
            OnPropertyChanged();
        }
    }

    private string? _errorText;
    public string? ErrorText
    {
        get => _errorText;
        set
        {
            _errorText = value;
            OnPropertyChanged();
        }
    }

    private IFile? _selectedFile;
    public IFile? SelectedFile
    {
        get => _selectedFile;
        set
        {
            _selectedFile = value;
            OnPropertyChanged();
        }
    }

    private IFile? _buffer;
    public IFile? Buffer
    {
        get => _buffer;
        set
        {
            _buffer = value;
            OnPropertyChanged();
        }
    }
    
    
    
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}