using System.Windows;
using System.Windows.Controls;
using IT_Tasks.ViewModel.FirstTask;
using IT_Tasks.ViewModel.SecondTask;

namespace IT_Tasks.View.HeaderControl;

public partial class HeaderControl : UserControl
{
    private Frame _mainFrame;
    private List<Page> _pageList = [];
    public HeaderControl(Frame mainFrame)
    {
        _mainFrame = mainFrame;
        
        _pageList.Add(new Home.Page());
        _pageList.Add(new Task.Page(FirstTaskViewModel.Instance));
        _pageList.Add(new Task.Page(SecondTaskViewModel.Instance));
        
        InitializeComponent();
    }
    
    private void OpenHome_Click(object sender, RoutedEventArgs e)
    {
        _mainFrame.Navigate(_pageList[0]);
    }
    private void OpenFirstTask_Click(object sender, RoutedEventArgs e)
    {
        _mainFrame.Navigate(_pageList[1]);
    }
    private void OpenSecondTask_Click(object sender, RoutedEventArgs e)
    {
        _mainFrame.Navigate(_pageList[2]);
    }
}