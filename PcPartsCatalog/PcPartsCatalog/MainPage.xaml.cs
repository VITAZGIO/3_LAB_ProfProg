using PcPartsCatalog.Models;
using PcPartsCatalog.Services;
using PcPartsCatalog.Views;

namespace PcPartsCatalog;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly ApiService _apiService;

    public MainPage()
    {
        InitializeComponent();

        _databaseService = new DatabaseService();
        _apiService = new ApiService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadParts();
    }

    private async Task LoadParts()
    {
        PartsCollection.ItemsSource = await _databaseService.GetPartsAsync();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PartPage(_databaseService));
    }

    private async void OnPartSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PcPart selectedPart)
        {
            PartsCollection.SelectedItem = null;

            await Navigation.PushAsync(new PartPage(_databaseService, selectedPart));
        }
    }

    private async void OnLoadFromApiClicked(object sender, EventArgs e)
    {
        var parts = await _apiService.GetDemoPartsAsync();

        foreach (var part in parts)
        {
            await _databaseService.SavePartAsync(part);
        }

        await LoadParts();

        await DisplayAlertAsync("Готово", "Демо-данные загружены", "ОК");
    }

    private async void OnDeleteAllClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlertAsync(
            "Удаление",
            "Удалить все комплектующие?",
            "Да",
            "Нет");

        if (confirm)
        {
            await _databaseService.DeleteAllPartsAsync();
            await LoadParts();
        }
    }
}