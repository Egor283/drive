using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Driver.Classes;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace Driver.Views;

public partial class Licens : UserControl
{
    public Licens()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        Help.test.Licens.Load();
        Help.test.Statuses.Load();
        DG.ItemsSource = Help.test.Licens.ToList();
    }

    private void NazBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.CCH.Content = new Datadriver();
    }

    private void HIsBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var us = DG.SelectedItem as Models.Licen;
        if (us == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы не выбрали пользователя").ShowAsync();
            return;
        }
        else
        {
            Help.CCH.Content = new HistoryStatus(us.Id);
        }
    }
    private void GnBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var us = DG.SelectedItem as Models.Licen;
        if (us == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы не выбрали пользователя").ShowAsync();
            return;
        }
        else
        {
            Help.CCH.Content = new GenerateLic(us.Id);
        }
    }
}