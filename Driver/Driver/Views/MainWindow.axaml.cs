using Avalonia.Controls;
using Avalonia.Interactivity;
using Driver.Classes;

namespace Driver.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.win = this;
        Help.CCH = this;
        Help.CCH = CCW;
        Help.CCH.Content = new MainView();
    }

    private void Button_OnClick_v(object? sender, RoutedEventArgs e)
    {
        Help.CCH.Content = new MainView();
    }
}