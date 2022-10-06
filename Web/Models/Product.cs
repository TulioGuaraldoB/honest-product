using System.ComponentModel.DataAnnotations;

namespace HonestProduct.Web.Models;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public float Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
