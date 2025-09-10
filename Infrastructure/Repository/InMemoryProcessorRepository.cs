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
            EccMemorySupported = false,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8352V",
            RecommendedCustomerPrice = 3993.00m,
            TotalCores = 36,
            TotalThreads = 72,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.1,
            Cache = "54 MB",
            TdpWatt = 195,
            URL = "https://www.intel.com/content/www/us/en/products/sku/212454/intel-xeon-platinum-8352v-processor-54m-cache-2-10-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208352V%20Processor",
            LaunchDate = new DateTime(2021, 5, 2),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2933",
            MaximumMemorySpeedMHz = 2933,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5318N",
            RecommendedCustomerPrice = 1602.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.1,
            Cache = "36 MB",
            TdpWatt = 150,
            URL = "",
            LaunchDate = new DateTime(2021, 6, 2),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2667",
            MaximumMemorySpeedMHz = 2667,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "6312U",
            RecommendedCustomerPrice = 1692.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.6,
            ProcessorBaseFrequencyGHz = 2.4,
            Cache = "36 MB",
            TdpWatt = 185,
            URL = "",
            LaunchDate = new DateTime(2021, 7, 7),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5320T",
            RecommendedCustomerPrice = 1977.00m,
            TotalCores = 20,
            TotalThreads = 40,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "30 MB",
            TdpWatt = 150,
            URL = "",
            LaunchDate = new DateTime(2021, 6, 7),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2933",
            MaximumMemorySpeedMHz = 2933,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "6342",
            RecommendedCustomerPrice = 2977.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.8,
            Cache = "36 MB",
            TdpWatt = 230,
            URL = "",
            LaunchDate = new DateTime(2021, 5, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8352M",
            RecommendedCustomerPrice = 4471.00m,
            TotalCores = 32,
            TotalThreads = 64,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "48 Mb",
            TdpWatt = 185,
            URL = "",
            LaunchDate = new DateTime(2021, 8, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5320",
            RecommendedCustomerPrice = 1780.00m-1792.00m,
            TotalCores = 26,
            TotalThreads = 52,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.2,
            Cache = "39 MB",
            TdpWatt = 185,
            URL = "",
            LaunchDate = new DateTime(2021, 6, 15),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2933",
            MaximumMemorySpeedMHz = 2933,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8362",
            RecommendedCustomerPrice = 6236.00m,
            TotalCores = 32,
            TotalThreads = 64,
            MaxTurboFrequencyGHz = 3.6,
            ProcessorBaseFrequencyGHz = 2.8,
            Cache = "48 MB",
            TdpWatt = 265,
            URL = "",
            LaunchDate = new DateTime(2021, 5, 20),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6 processors",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6978P",
            RecommendedCustomerPrice = 11025.00m,
            TotalCores = 120,
            TotalThreads = 240,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 3.2,
            Cache = "505 MB",
            TdpWatt = 500,
            URL = "",
            LaunchDate = new DateTime(2025, 9, 5),
            MaxMemorySizeGB = 3, // 4 TB
            MemoryTypes = "DDR5(6400MT/s) MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 12,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6 processors",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6962P",
            RecommendedCustomerPrice = 9925.00m,
            TotalCores = 72,
            TotalThreads = 144,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.7,
            Cache = "432 MB",
            TdpWatt = 500,
            URL = "",
            LaunchDate = new DateTime(2025, 10, 6),
            MaxMemorySizeGB = 3, // 4 TB
            MemoryTypes = "DDR5(6400MT/s) MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 12,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8380",
            RecommendedCustomerPrice = 9359.00m,
            TotalCores = 40,
            TotalThreads = 80,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "60 MB",
            TdpWatt = 270,
            URL = "",
            LaunchDate = new DateTime(2021, 6, 9),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8368",
            RecommendedCustomerPrice = 7214.00m,
            TotalCores = 38,
            TotalThreads = 76,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.4,
            Cache = "57 MB",
            TdpWatt = 270,
            URL = "",
            LaunchDate = new DateTime(2021, 7, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "3rd Gen Intel® Xeon® Scalable Processors",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8368Q",
            RecommendedCustomerPrice = 7719.00m,
            TotalCores = 38,
            TotalThreads = 76,
            MaxTurboFrequencyGHz = 3.7,
            ProcessorBaseFrequencyGHz = 2.6,
            Cache = "57 MB",
            TdpWatt = 270,
            URL = "",
            LaunchDate = new DateTime(2021, 8, 15),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® W Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "W-3375",
            RecommendedCustomerPrice = 4951.00m,
            TotalCores = 38,
            TotalThreads = 76,
            MaxTurboFrequencyGHz = 4,
            ProcessorBaseFrequencyGHz = 2.5,
            Cache = "57 MB",
            TdpWatt = 270,
            URL = "",
            LaunchDate = new DateTime(2021, 10, 20),
            MaxMemorySizeGB = 4, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        }
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

