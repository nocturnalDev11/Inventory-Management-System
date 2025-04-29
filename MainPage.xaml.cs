using Inventory_Management_System.Data;
using Inventory_Management_System.PageModels;

namespace Inventory_Management_System
{
    public partial class MainPage : ContentPage
    {
        public MainPage(DatabaseContext database)
        {
            InitializeComponent();
            BindingContext = new PageModels.MainPageModel();
        }
    }
}
