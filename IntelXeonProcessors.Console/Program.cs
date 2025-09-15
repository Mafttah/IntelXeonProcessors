using Application.Interfaces; // Güncellendi
using Domain.Entities; 
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

    Console.WriteLine("\n- Core Sayisina Gore Siralama -");
    foreach (var cpu in allProcessors)
    {
        Console.WriteLine($"{cpu.CodeName} - {cpu.TotalCores}/{cpu.TotalThreads} Cores");
    }

    Console.WriteLine("\n- Cache Sayisina Gore Siralama -\n");
    foreach (var cpu in allProcessors)
    {
        Console.WriteLine($"{cpu.CodeName} - {cpu.Cache} Cache");
    }

    Console.WriteLine("\n✨ Sorgulama tamamlandı! ✨");
}
// Print islemi bu metod da yapiliyor.
static void PrintProcessorDetails(Processor processor)
{
    if (processor == null) return; // Best practice: Fast-fail yaklasimi. Amac: hatalardan kurtulmak 

    Console.WriteLine($"Model: {processor.ProductCollection} ({processor.ProcessorNumber})");
    Console.WriteLine($"  Çekirdek/İzlek: {processor.TotalCores}/{processor.TotalThreads}");
    Console.WriteLine($"  Maks. Turbo Frekans: {processor.MaxTurboFrequencyGHz} / Base Frekans:{processor.ProcessorBaseFrequencyGHz} GHz");
    Console.WriteLine($"  TDP: {processor.TdpWatt}W");
    Console.WriteLine($"  Fiyat: ${processor.RecommendedCustomerPrice}");
    Console.WriteLine($"  Cache: {processor.Cache}");
    Console.WriteLine($"  Code name: {processor.CodeName}");
    Console.WriteLine($"  Launch date: {processor.LaunchDate}");
    Console.WriteLine($"  Max memory size (GB): {processor.MaxMemorySizeGB}");
    Console.WriteLine($"  Memory types: {processor.MemoryTypes}");
    Console.WriteLine($"  Max. Memory Speed: {processor.MaximumMemorySpeedMHz}");
    Console.WriteLine($"  Max Memory Channel: {processor.MaxMemoryChannels}");
    Console.WriteLine($"  ECC: {processor.EccMemorySupported}");
    Console.WriteLine($"  ULR: {processor.URL}");

    Console.WriteLine(); // Boşluk bırak
}

