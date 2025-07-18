using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SE172725.Repositories.Models;

public partial class Handbag
{
    [Key]
    public int HandbagId { get; set; }

    public int? BrandId { get; set; }

    [Required]
    [RegularExpression(@"^([A-Z0-9][a-zA-Z0-9#]*\s)*([A-Z0-9#][a-zA-Z0-9#]*)$")]
    public string ModelName { get; set; } = null!;

    public string? Material { get; set; }

    public string? Color { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal? Price { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? Stock { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual Brand? Brand { get; set; }
}
