using Application.Interfaces; // Güncellendi
using Domain.Entities; 
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Modern .NET'te Dependency Injection (DI) ve konfigürasyon için HostBuilder kullanılır.
var builder = Host.CreateApplicationBuilder(args);

// DI Container'a servislerimizi kaydediyoruz.
// "Eğer birisi IProcessorRepository isterse, ona InMemoryProcessorRepository'nin bir örneğini ver." diyoruz.
builder.Services.AddScoped<IProcessorRepository, InMemoryProcessorRepository>();

using var host = builder.Build();

// Programımızı çalıştıralım
await RunApp(host.Services);

static async Task RunApp(IServiceProvider services)
{
    // Servis sağlayıcısından IProcessorRepository'nin somut (concrete) halini istiyoruz.
    using var scope = services.CreateScope();
    var repository = scope.ServiceProvider.GetRequiredService<IProcessorRepository>();

    Console.WriteLine("Tüm İşlemciler Listeleniyor...");
    Console.WriteLine("--------------------------------");

    var allProcessors = await repository.GetAllAsync();

    foreach (var processor in allProcessors)
    {
        PrintProcessorDetails(processor);
    }

    Console.WriteLine("✨ Sorgulama tamamlandı! ✨");
}
// Print islemi bu metod da yapiliyor.
static void PrintProcessorDetails(Processor processor)
{
    if (processor == null) return;

    Console.WriteLine($"Model: {processor.ProductCollection} ({processor.ProcessorNumber})");
    Console.WriteLine($"  Çekirdek/İzlek: {processor.TotalCores}/{processor.TotalThreads}");
    Console.WriteLine($"  Maks. Turbo Frekans: {processor.MaxTurboFrequencyGHz} GHz");
    Console.WriteLine($"  TDP: {processor.TdpWatt}W");
    Console.WriteLine($"  Fiyat: ${processor.RecommendedCustomerPrice}");
    Console.WriteLine(); // Boşluk bırak
}

