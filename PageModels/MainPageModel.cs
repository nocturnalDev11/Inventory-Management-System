namespace Inventory_Management_System.PageModels;

public class MainPageModel : BindableObject
{
    public string WelcomeMessage { get; set; } = "Welcome to Inventory Management System";
    public Command ViewInventoryCommand { get; }

    public MainPageModel()
    {
        ViewInventoryCommand = new Command(async () => await NavigateToAsync("ItemListPage"));
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