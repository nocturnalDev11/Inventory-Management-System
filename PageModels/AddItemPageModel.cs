using Inventory_Management_System.Models;
using Inventory_Management_System.Data;

namespace Inventory_Management_System.PageModels;

public class AddItemPageModel : BindableObject
{
    private string? _name;
    private int _quantity;
    private decimal _price;
    private readonly DatabaseContext _database;

    public string? Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }

    public int Quantity
    {
        get => _quantity;
        set { _quantity = value; OnPropertyChanged(); }
    }

    public decimal Price
    {
        get => _price;
        set { _price = value; OnPropertyChanged(); }
    }

    public Command SaveItemCommand { get; }
    public Command CancelCommand { get; }

    public AddItemPageModel(DatabaseContext database)
    {
        _database = database;
        SaveItemCommand = new Command(async () => await SaveItemAsync());
        CancelCommand = new Command(async () => await NavigateToAsync("MainPage"));
    }

    private async Task SaveItemAsync()
    {
        if (string.IsNullOrEmpty(Name))
        {
            await Shell.Current.DisplayAlert("Error", "Name is required", "OK");
            return;
        }

        var item = new Item
        {
            Name = Name,
            Quantity = Quantity,
            Price = Price
        };
        await _database.SaveItemAsync(item);
        await NavigateToAsync("ItemListPage");
    }

    private async Task NavigateToAsync(string route)
    {
        if (Shell.Current is AppShell appShell)
        {
            var page = appShell.CreatePage(route);
            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}