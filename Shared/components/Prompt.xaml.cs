using System.Windows;

namespace IT_Task1.shared.components;

public partial class Prompt : Window
{
    public Prompt(string title, string? defaultText)
    {
        InitializeComponent();
        Title.Text = title;
        ResponseText = defaultText ?? "";
    }
    
    public string? ResponseText {
        get { return ResponseTextBox.Text; }
        set { ResponseTextBox.Text = value; }
    }

    private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = true;
    }
}