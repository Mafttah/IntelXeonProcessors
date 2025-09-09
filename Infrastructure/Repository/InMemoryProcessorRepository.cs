using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public class InMemoryProcessorRepository : IProcessorRepository
{
    // Seed Data: Uygulama çalıştığında bellekte tutulacak statik veri listesi.
    private static readonly List<Processor> _processors =
    [
        new() {
            ProductCollection = "Intel® Xeon® W Processors",
            CodeName = "Sapphire Rapids",
            ProcessorNumber = "W9-3495X",
            RecommendedCustomerPrice = 5889.00m,
            TotalCores = 56,
            TotalThreads = 112,
            MaxTurboFrequencyGHz = 4.8,
            ProcessorBaseFrequencyGHz = 1.9,
            Cache = "105 MB L3 Cache",
            TdpWatt = 350,
            URL = "https://www.intel.com/content/www/us/en/products/sku/233483/intel-xeon-w93495x-processor-105m-cache-1-90-ghz/specifications.html?wapkw=W9-3495X",
            LaunchDate = new DateTime(2023, 2, 15),
            MaxMemorySizeGB = 4096, // 4 TB
            MemoryTypes = "Up to DDR5 4800 MT/s",
            MaximumMemorySpeedMHz = 4800,
            MaxMemoryChannels = 8,
            EccMemorySupported = true
        },

        new() {
            ProductCollection = "Intel® Core™ i9 Processors (14th Generation)",
            CodeName = "Raptor Lake",
            ProcessorNumber = "i9-14900K",
            RecommendedCustomerPrice = 589.00m,
            TotalCores = 24,
            TotalThreads = 32,
            MaxTurboFrequencyGHz = 6.0,
            ProcessorBaseFrequencyGHz = 3.2,
            Cache = "36 MB Intel® Smart Cache",
            TdpWatt = 125,
            URL = "https://www.intel.com/content/www/us/en/products/sku/236773/intel-core-i9-processor-14900k-36m-cache-up-to-6-00-ghz/specifications.html?wapkw=i9-14900K",
            LaunchDate = new DateTime(2023, 10, 1),
            MaxMemorySizeGB = 192,
            MemoryTypes = "Up to DDR5 5600 MT/s, Up to DDR4 3200 MT/s",
            MaximumMemorySpeedMHz = 5600,
            MaxMemoryChannels = 2,
            EccMemorySupported = false
        },
    ];

    public Task<IEnumerable<Processor>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Processor>>(_processors);
    }

    public Task<Processor?> GetByProcessorNumberAsync(string processorNumber)
    {
        var processor = _processors.FirstOrDefault(p =>
            p.ProcessorNumber != null &&
            p.ProcessorNumber.Equals(processorNumber, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(processor);
    }
}
