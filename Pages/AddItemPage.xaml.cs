using Inventory_Management_System.Data;
using Inventory_Management_System.PageModels;

namespace Inventory_Management_System.Pages
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage(DatabaseContext database)
        {
            InitializeComponent();
            BindingContext = new AddItemPageModel(database);
        }
    }
}
