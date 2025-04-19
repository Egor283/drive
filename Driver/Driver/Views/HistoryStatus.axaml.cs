using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Driver.Classes;
using Microsoft.EntityFrameworkCore;

namespace Driver.Views;

public partial class HistoryStatus : UserControl
{
    public HistoryStatus(int _id=-1)
    {
        InitializeComponent();
        Help.test.Licens.Load();
        Help.test.Histories.Load();
        DG.ItemsSource = Help.test.Histories.Where(x => x.Id == _id).ToList();
    }

    private void NazBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.CCH.Content = new Licens();
    }
}