using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class Store: IModel
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int? AdministratorId { get; set; }

    public virtual User? Administrator { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Statistic> Statistics { get; set; } = new List<Statistic>();

    public int GetId()
    {
        return StoreId;
    }

    public string ToString()
    {
        return $"Store: {StoreId} {Name} {Location} {AdministratorId}";
    }
}
