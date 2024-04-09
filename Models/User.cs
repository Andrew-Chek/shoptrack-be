using System;
using System.Collections.Generic;

namespace shoptrack_be.Models;

public partial class User: IModel
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public int GetId()
    {
        return UserId;
    }
}
