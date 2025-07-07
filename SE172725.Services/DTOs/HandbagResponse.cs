namespace SE172725.Services.DTOs
{
    public class HandbagResponse
    {
        public int HandbagId { get; set; }

        public string ModelName { get; set; } = null!;

        public string? Material { get; set; }

        public string? Color { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }

        public DateOnly? ReleaseDate { get; set; }

        public BrandResponse? Brand { get; set; }
    }
}
