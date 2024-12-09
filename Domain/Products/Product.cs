using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Products;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required, Column(TypeName = "text")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("product_category_id")]
    [Required]
    public Guid ProductCategoryId { get; set; }

    [ForeignKey("ProductCategoryId")]
    public ProductCategory? ProductCategory { get; set; } = null!;
}
