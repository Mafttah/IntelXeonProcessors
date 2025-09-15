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
            ProductCollection = "Intel® Xeon® Platinum 8352V Processor",
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
            ProductCollection = "Intel® Xeon® Gold 5318N Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5318N",
            RecommendedCustomerPrice = 1602.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.1,
            Cache = "36 MB",
            TdpWatt = 150,
            URL = "https://www.intel.com/content/www/us/en/products/sku/215271/intel-xeon-gold-5318y-processor-36m-cache-2-10-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Gold%205318N%20Processor",
            LaunchDate = new DateTime(2021, 6, 2),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2667",
            MaximumMemorySpeedMHz = 2667,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Gold 6312U Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "6312U",
            RecommendedCustomerPrice = 1692.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.6,
            ProcessorBaseFrequencyGHz = 2.4,
            Cache = "36 MB",
            TdpWatt = 185,
            URL = "https://www.intel.com/content/www/us/en/products/sku/215282/intel-xeon-gold-6312u-processor-36m-cache-2-40-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Gold%206312U%20Processor",
            LaunchDate = new DateTime(2021, 7, 7),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Gold 5320T Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5320T",
            RecommendedCustomerPrice = 1977.00m,
            TotalCores = 20,
            TotalThreads = 40,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "30 MB",
            TdpWatt = 150,
            URL = "https://www.intel.com/content/www/us/en/products/sku/215284/intel-xeon-gold-5320t-processor-30m-cache-2-30-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Gold%205320T%20Processor",
            LaunchDate = new DateTime(2021, 6, 7),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2933",
            MaximumMemorySpeedMHz = 2933,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Gold 6342 Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "6342",
            RecommendedCustomerPrice = 2977.00m,
            TotalCores = 24,
            TotalThreads = 48,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.8,
            Cache = "36 MB",
            TdpWatt = 230,
            URL = "https://www.intel.com/content/www/us/en/products/sku/215276/intel-xeon-gold-6342-processor-36m-cache-2-80-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Gold%206342%20Processor",
            LaunchDate = new DateTime(2021, 5, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Platinum 8352M Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8352M",
            RecommendedCustomerPrice = 4471.00m,
            TotalCores = 32,
            TotalThreads = 64,
            MaxTurboFrequencyGHz = 3.5,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "48 Mb",
            TdpWatt = 185,
            URL = "https://www.intel.com/content/www/us/en/products/sku/217215/intel-xeon-platinum-8352m-processor-48m-cache-2-30-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208352M%20Processor",
            LaunchDate = new DateTime(2021, 8, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Gold 5320 Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "5320",
            RecommendedCustomerPrice = 1780.00m-1792.00m,
            TotalCores = 26,
            TotalThreads = 52,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.2,
            Cache = "39 MB",
            TdpWatt = 185,
            URL = "https://www.intel.com/content/www/us/en/products/sku/215285/intel-xeon-gold-5320-processor-39m-cache-2-20-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Gold%205320%20Processor",
            LaunchDate = new DateTime(2021, 6, 15),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-2933",
            MaximumMemorySpeedMHz = 2933,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Platinum 8362 Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8362",
            RecommendedCustomerPrice = 6236.00m,
            TotalCores = 32,
            TotalThreads = 64,
            MaxTurboFrequencyGHz = 3.6,
            ProcessorBaseFrequencyGHz = 2.8,
            Cache = "48 MB",
            TdpWatt = 265,
            URL = "https://www.intel.com/content/www/us/en/products/sku/217216/intel-xeon-platinum-8362-processor-48m-cache-2-80-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208362%20Processor",
            LaunchDate = new DateTime(2021, 5, 20),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6978P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6978P",
            RecommendedCustomerPrice = 11025.00m,
            TotalCores = 120,
            TotalThreads = 240,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 3.2,
            Cache = "504 MB",
            TdpWatt = 500,
            URL = "https://www.intel.com/content/www/us/en/products/sku/244340/intel-xeon-6978p-processor-504m-cache-2-10-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%206978P%20Processor",
            LaunchDate = new DateTime(2025, 9, 5),
            MaxMemorySizeGB = 3, // 4 TB
            MemoryTypes = "DDR5(6400MT/s) MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 12,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6962P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6962P",
            RecommendedCustomerPrice = 9925.00m,
            TotalCores = 72,
            TotalThreads = 144,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.7,
            Cache = "432 MB",
            TdpWatt = 500,
            URL = "https://www.intel.com/content/www/us/en/products/sku/244339/intel-xeon-6962p-processor-432m-cache-2-70-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%206962P%20Processor",
            LaunchDate = new DateTime(2025, 10, 6),
            MaxMemorySizeGB = 3, // 4 TB
            MemoryTypes = "DDR5(6400MT/s) MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 12,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Platinum 8380 Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8380",
            RecommendedCustomerPrice = 9359.00m,
            TotalCores = 40,
            TotalThreads = 80,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "60 MB",
            TdpWatt = 270,
            URL = "https://www.intel.com/content/www/us/en/products/sku/212287/intel-xeon-platinum-8380-processor-60m-cache-2-30-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208380%20Processor",
            LaunchDate = new DateTime(2021, 6, 9),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Platinum 8368 Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8368",
            RecommendedCustomerPrice = 7214.00m,
            TotalCores = 38,
            TotalThreads = 76,
            MaxTurboFrequencyGHz = 3.4,
            ProcessorBaseFrequencyGHz = 2.4,
            Cache = "57 MB",
            TdpWatt = 270,
            URL = "https://www.intel.com/content/www/us/en/products/sku/212455/intel-xeon-platinum-8368-processor-57m-cache-2-40-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208368%20Processor",
            LaunchDate = new DateTime(2021, 7, 10),
            MaxMemorySizeGB = 6, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® Platinum 8368Q Processor",
            CodeName = "Products formerly Ice Lake",
            ProcessorNumber = "8368Q",
            RecommendedCustomerPrice = 7719.00m,
            TotalCores = 38,
            TotalThreads = 76,
            MaxTurboFrequencyGHz = 3.7,
            ProcessorBaseFrequencyGHz = 2.6,
            Cache = "57 MB",
            TdpWatt = 270,
            URL = "https://www.intel.com/content/www/us/en/products/sku/212289/intel-xeon-platinum-8368q-processor-57m-cache-2-60-ghz/specifications.html?wapkw=Intel%C2%AE%20Xeon%C2%AE%20Platinum%208368Q%20Processor",
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
            URL = "https://www.intel.com/content/www/us/en/products/sku/217246/intel-xeon-w3375-processor-57m-cache-up-to-4-00-ghz/specifications.html?wapkw=W-3375",
            LaunchDate = new DateTime(2021, 10, 20),
            MaxMemorySizeGB = 4, // 4 TB
            MemoryTypes = "DDR4-3200",
            MaximumMemorySpeedMHz = 3200,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6774P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6774P",
            RecommendedCustomerPrice = 6760.00m,
            TotalCores = 64,
            TotalThreads = 128,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.5,
            Cache = "336 MB",
            TdpWatt = 350,
            URL = "https://www.intel.com/content/www/us/en/products/sku/243692/intel-xeon-6774p-processor-336m-cache-2-50-ghz/specifications.html",
            LaunchDate = new DateTime(2025, 6, 12),
            MaxMemorySizeGB = 4, // 4 TB
            MemoryTypes = "DDR5(6400MT/s), MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8000,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6776P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6776P",
            RecommendedCustomerPrice = 9875.00m,
            TotalCores = 64,
            TotalThreads = 128,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.3,
            Cache = "336 MB",
            TdpWatt = 350,
            URL = "https://www.intel.com/content/www/us/en/products/sku/243691/intel-xeon-6776p-processor-336m-cache-2-30-ghz/specifications.html",
            LaunchDate = new DateTime(2025, 6, 12),
            MaxMemorySizeGB = 4, // 4 TB
            MemoryTypes = "DDR5(6400MT/s), MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8000,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6762P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6762P",
            RecommendedCustomerPrice = 12350.00m,
            TotalCores = 64,
            TotalThreads = 128,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.9,
            Cache = "320 MB",
            TdpWatt = 350,
            URL = "https://www.intel.com/content/www/us/en/products/sku/240782/intel-xeon-6966pc-processor-432m-cache-3-00-ghz/specifications.html",
            LaunchDate = new DateTime(2025, 9, 5),
            MaxMemorySizeGB = 4, // 4 TB
            MemoryTypes = "DDR5(6400MT/s), MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 8,
            EccMemorySupported = true,
        },

        new() {
            ProductCollection = "Intel® Xeon® 6962P Processor",
            CodeName = "Products formerly Granite Rapids",
            ProcessorNumber = "6962P",
            RecommendedCustomerPrice = 9925.00m,
            TotalCores = 72,
            TotalThreads = 144,
            MaxTurboFrequencyGHz = 3.9,
            ProcessorBaseFrequencyGHz = 2.7,
            Cache = "432 MB",
            TdpWatt = 500,
            URL = "https://www.intel.com/content/www/us/en/products/sku/244339/intel-xeon-6962p-processor-432m-cache-2-70-ghz/specifications.html",
            LaunchDate = new DateTime(2025, 10, 4),
            MaxMemorySizeGB = 3, // 4 TB
            MemoryTypes = "DDR5(6400MT/s) MRDIMM(8800MT/s)",
            MaximumMemorySpeedMHz = 8800,
            MaxMemoryChannels = 12,
            EccMemorySupported = true,
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

