using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Processor
    {
        // Essentials
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? ProductCollection { get; set; }
        public string? CodeName { get; set; }
        public string? ProcessorNumber { get; set; }
        public decimal? RecommendedCustomerPrice { get; set; }

        // CPU Specifications
        public int TotalCores { get; set; }
        public int TotalThreads { get; set; }
        public double? MaxTurboFrequencyGHz { get; set; }
        public double ProcessorBaseFrequencyGHz { get; set; }
        public string? Cache { get; set; }
        public int TdpWatt { get; set; }

        // Supplemental Information
        public string URL { get; set; }
        public DateTime? LaunchDate { get; set; }

        // Memory Specifications
        public int? MaxMemorySizeGB { get; set; }
        public string? MemoryTypes { get; set; }
        public int? MaximumMemorySpeedMHz { get; set; }
        public int MaxMemoryChannels { get; set; }
        public bool EccMemorySupported { get; set; }

    }
}
