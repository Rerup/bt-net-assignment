using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Products;

public class ProductCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
