namespace SE172725.Services.DTOs
{
    public class BrandResponse
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public string? Country { get; set; }

        public int? FoundedYear { get; set; }

        public string? Website { get; set; }
    }
}
