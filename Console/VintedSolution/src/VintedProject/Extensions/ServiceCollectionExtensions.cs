using Microsoft.Extensions.DependencyInjection;
using VintedProject.Interfaces;
using VintedProject.Services;

namespace VintedProject.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this ServiceCollection services)
        {
            services.AddTransient<Executor>();
            services.AddTransient<FileService>();
            services.AddTransient<ITextImportService, TextImportService>();
            services.AddTransient<PriceService>();
            services.AddTransient<ShippingService>();
            services.AddTransient<IOutputService, OutputService>();
        }
    }
}
