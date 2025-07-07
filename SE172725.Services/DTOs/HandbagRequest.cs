using System.ComponentModel.DataAnnotations;

namespace SE172725.Services.DTOs
{
    public class HandbagRequest
    {
        [Required]
        [RegularExpression(@"^([A-Z0-9][a-zA-Z0-9#]*\s)*([A-Z0-9][a-zA-Z0-9#]*)$")]
        public string ModelName { get; set; } = null!;
        public string? Material { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(1, int.MaxValue)]
        public int? Stock { get; set; }
        public int? BrandId { get; set; }
    }
}
