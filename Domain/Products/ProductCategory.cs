using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Products;

public class ProductCategory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
