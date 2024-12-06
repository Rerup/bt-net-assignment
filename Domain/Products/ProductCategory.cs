using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Products;

public class ProductCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
