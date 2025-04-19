using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Driver.Classes;
using Microsoft.EntityFrameworkCore;

namespace Driver.Views;

public partial class GenerateLic : UserControl
{
    public GenerateLic(int _id)
    {
        InitializeComponent();
        Help.test.Licens.Load();
        Help.test.Drivers.Load();
        DG.DataContext = Help.test.Licens.FirstOrDefault(el => el.Id == _id);
        var us = Help.test.Licens.FirstOrDefault(el => el.Id == _id);
        using (var ms = new MemoryStream((us.Driver.Photo.Photo1)))
        {
            ter.Source = new Bitmap(ms);
        }
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.CCH.Content = new Licens();
    }
}