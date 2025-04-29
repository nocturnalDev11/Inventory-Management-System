using Inventory_Management_System.Data;

namespace Inventory_Management_System;

public partial class AppShell : Shell
{
    private readonly DatabaseContext _database;

    public AppShell(DatabaseContext database)
    {
        InitializeComponent();
        _database = database;
    }

    public Page CreatePage(string route)
    {
        return route switch
        {
            "MainPage" => new MainPage(_database),
            "ItemListPage" => new Pages.ItemListPage(_database),
            "AddItemPage" => new Pages.AddItemPage(_database),
            _ => throw new InvalidOperationException($"Unknown route: {route}")
        };
    }
}