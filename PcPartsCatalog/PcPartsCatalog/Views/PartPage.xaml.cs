using PcPartsCatalog.Models;
using PcPartsCatalog.Services;

namespace PcPartsCatalog.Views;

public partial class PartPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly PcPart _part;

    public PartPage(DatabaseService databaseService, PcPart part = null)
    {
        InitializeComponent();

        _databaseService = databaseService;
        _part = part ?? new PcPart();

        if (part != null)
        {
            NameEntry.Text = part.Name;
            CategoryEntry.Text = part.Category;
            ManufacturerEntry.Text = part.Manufacturer;
            PriceEntry.Text = part.Price.ToString();
            DescriptionEditor.Text = part.Description;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _part.Name = NameEntry.Text;
        _part.Category = CategoryEntry.Text;
        _part.Manufacturer = ManufacturerEntry.Text;

        double.TryParse(PriceEntry.Text, out double price);
        _part.Price = price;

        _part.Description = DescriptionEditor.Text;

        await _databaseService.SavePartAsync(_part);
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_part.Id != 0)
        {
            await _databaseService.DeletePartAsync(_part);
        }

        await Navigation.PopAsync();
    }
}