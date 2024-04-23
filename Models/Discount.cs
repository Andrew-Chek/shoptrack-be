using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class Discount: IModel
{
    public int DiscountId { get; set; }

    public int? StoreId { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public virtual Store? Store { get; set; }

    public int GetId()
    {
        return DiscountId;
    }

    public string ToString()
    {
        return $"Discount: {DiscountId} {StoreId} {Description} {Amount}";
    }
}
