using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class Purchase: IModel
{
    public int PurchaseId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }

    public int GetId()
    {
        return PurchaseId;
    }

    public string ToString()
    {
        return $"Purchase: {PurchaseId} {UserId} {ProductId} {PurchaseDate} {Quantity}";
    }
}
