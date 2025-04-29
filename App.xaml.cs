using Inventory_Management_System.Data;

namespace Inventory_Management_System;

public partial class App : Application
{
    private readonly DatabaseContext _database;

    public App(DatabaseContext database)
    {
        InitializeComponent();
        _database = database;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell(_database));
    }
}