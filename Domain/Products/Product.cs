﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Products;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 99999)]
    public decimal Price { get; set; }

    [Required, Column(TypeName = "text")]
    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
}
