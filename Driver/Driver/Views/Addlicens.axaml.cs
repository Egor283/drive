using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Driver.Classes;
using Driver.Models;
using Microsoft.EntityFrameworkCore;

namespace Driver.Views;

public partial class Addlicens : Window
{
    public Addlicens()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        Help.test.Licens.Load();
        Help.test.Statuses.Load();
        Help.test.Drivers.Load();
        StatusCB.ItemsSource = Help.test.Statuses.ToList();
        DriverCB.ItemsSource = Help.test.Drivers.ToList();
        SP.DataContext = new Licen();
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.test.Licens.Add(SP.DataContext as Licen);
        Help.test.SaveChanges();
        Close();
    }
}