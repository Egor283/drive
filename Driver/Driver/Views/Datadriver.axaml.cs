using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Driver.Classes;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;


namespace Driver.Views;

public partial class Datadriver : UserControl
{
    public Datadriver()
    {
        InitializeComponent();
        LoaData();
    }

    private void LoaData()
    {
        Help.test.Drivers.Load();
        Help.test.Photos.Load();
        DG.ItemsSource = Help.test.Drivers.ToList();
    }

    private async void DelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var us = DG.SelectedItem as Models.Driver;
        
        if (us == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы не выбрали пользователя").ShowAsync();
            return;
        }
        else
        {
            var res = await MessageBoxManager.GetMessageBoxStandard("Удаление", "Вы уверены?",
                MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Question).ShowAsync();
            if (res == MsBox.Avalonia.Enums.ButtonResult.Yes)
            {
                Help.test.Drivers.Remove(us);
                Help.test.SaveChanges();
                LoaData();
            }
        }
    }

    private async void DobBtn_OnClick(object? sender, RoutedEventArgs e)
    {
       AddDriver wind = new AddDriver();
       wind.ShowDialog(Help.win);
    }

    private void EditBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var us = DG.SelectedItem as Models.Driver;
        if (us == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы не выбрали пользователя").ShowAsync();
            return;
        }
        else
        {
            AddDriver wind = new AddDriver(us.Id);
            wind.ShowDialog(Help.win);
        }
    }

    private void ObnBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        LoaData();
    }
}