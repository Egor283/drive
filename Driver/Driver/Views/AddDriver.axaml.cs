using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Driver.Classes;
using Driver.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace Driver.Views;

public partial class AddDriver : Window
{
    private int _id = -1;
    public AddDriver(int id=-1)
    {
        InitializeComponent();
        LoaData();
        _id = id;
        if (_id == -1)
        {
            SP.DataContext = new Models.Driver() { Photo = new Photo()};
        }
        else
        {
            var us = Help.test.Drivers.First(el => el.Id == _id);
            SP.DataContext = us;
            using (var ms = new MemoryStream(us.Photo.Photo1))
            {
                DriverPhoto.Source = new Bitmap(ms);
            }
            SP.IsEnabled = false;
            OkBtn.IsEnabled = false;
        }
    }

    private void LoaData()
    {
        Help.test.Drivers.Load();
        Help.test.Photos.Load();
    }

    private async void ObBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var toplevel = TopLevel.GetTopLevel(this);
        var file = await toplevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            Title = "Open File",
            AllowMultiple = false,
            FileTypeFilter = new []{FilePickerFileTypes.ImageAll }
        });
        if (file.Count > 0)
        {
            var dr = SP.DataContext as Models.Driver;
            dr.Photo.Photo1 = File.ReadAllBytes(file[0].Path.LocalPath);
            DriverPhoto.Source = new Bitmap(file[0].Path.LocalPath);
        }
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Regex regPhone = new Regex(@"\+7\(\d\d\d\)\d\d\d\-\d\d\d\d");
            if (!regPhone.IsMatch(TTB.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы ввели неправильный формат номеры телефона").ShowAsync();
                return;
            }
            
            Regex regEmail = new Regex("[^@]+@[^@]+");
            if (!regEmail.IsMatch(ETB.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы ввели неправильный формат почты").ShowAsync();
                return;
            }
            if (_id == -1)
            {
                Help.test.Drivers.Add(SP.DataContext as Models.Driver);
            }
            Help.test.SaveChanges();
            Close();
        }
        catch
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы заполнили не все поля").ShowAsync();
            return;
        }
    }

    private void OtBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}