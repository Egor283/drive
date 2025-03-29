using Avalonia.Controls;
using Avalonia.Interactivity;
using Driver.Classes;
using MsBox.Avalonia;

namespace Driver.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Button_OnClick_OK(object? sender, RoutedEventArgs e)
    {
        if (LoginTB.Text == "Инспектор" && PasswTB.Text == "Инспектор")
        {
            Help.CCH.Content = new Datadriver();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Неправильный логин или пароль").ShowAsync();
        }
    }
}