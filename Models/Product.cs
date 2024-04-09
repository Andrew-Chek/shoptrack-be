using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class Product: IModel
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual Store? Store { get; set; }

    public int GetId()
    {
        return ProductId;
    }
}
