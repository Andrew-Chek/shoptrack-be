using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class Statistic: IModel
{
    public int StatisticId { get; set; }

    public int? StoreId { get; set; }

    public DateOnly Date { get; set; }

    public int SoldQuantity { get; set; }

    public virtual Store? Store { get; set; }

    public int GetId()
    {
        return StatisticId;
    }

    public string ToString()
    {
        return $"Statistic: {StatisticId} {StoreId} {Date} {SoldQuantity}";
    }
}
