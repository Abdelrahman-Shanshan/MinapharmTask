namespace MinapharmTask.Models
{
    public class AssetsAttributes
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string? Owner { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Version { get; set; }
        public string? Processor { get; set; }
        public string? InstallesMomory { get; set; }
        public string? Driver { get; set; }
        public int? Year { get; set; }
    }
}
