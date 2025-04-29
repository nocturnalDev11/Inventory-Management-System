using Inventory_Management_System.Models;
using Inventory_Management_System.Data;

namespace Inventory_Management_System.PageModels
{
    public class ItemListPageModel : BindableObject
    {
        private List<Item> _items = new List<Item>();
        private readonly DatabaseContext _database;

        public List<Item> Items
        {
            get => _items;
            set { _items = value; OnPropertyChanged(); }
        }

        public Command AddItemCommand { get; }

        public ItemListPageModel(DatabaseContext database)
        {
            _database = database;
            AddItemCommand = new Command(async () => await NavigateToAsync("AddItemPage"));
            LoadItemsAsync();
        }

        private async void LoadItemsAsync()
        {
            Items = await _database.GetItemsAsync();
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
}
