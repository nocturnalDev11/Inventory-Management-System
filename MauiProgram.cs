using Microsoft.Extensions.Logging;
using Inventory_Management_System.Data;

namespace Inventory_Management_System
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "inventory.db3");
            builder.Services.AddSingleton(new DatabaseContext(dbPath));

            return builder.Build();
        }
    }
}
