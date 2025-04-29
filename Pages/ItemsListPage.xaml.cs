using Inventory_Management_System.Data;
using Inventory_Management_System.PageModels;

namespace Inventory_Management_System.Pages;
public partial class ItemListPage : ContentPage
{
    public ItemListPage(DatabaseContext database)
    {
        InitializeComponent();
        BindingContext = new ItemListPageModel(database);
    }
} 