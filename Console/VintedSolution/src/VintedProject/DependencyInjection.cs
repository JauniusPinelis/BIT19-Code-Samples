using Microsoft.Extensions.DependencyInjection;
using VintedProject.Discounts;
using VintedProject.Interfaces;
using VintedProject.Services;

namespace VintedProject
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this ServiceCollection services)
        {
            services.AddTransient<Executor>();
            services.AddTransient<ImportService>();
            services.AddTransient<ITextImportService, TextImportService>();
            services.AddTransient<ShippingService>();
            services.AddTransient<IOutputService, OutputService>();
            services.AddTransient<DiscountFactory>();
        }
    }
}
