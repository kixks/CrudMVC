using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CrudNonApiMVC.Models;

[Table("availableItems")]
public partial class AvailableItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("itemName")]
    [StringLength(50)]
    [Unicode(false)]
    public string ItemName { get; set; } = null!;

    [Column("itemGenre")]
    [StringLength(50)]
    [Unicode(false)]
    public string ItemGenre { get; set; } = null!;

    [Column("itemPrice", TypeName = "money")]
    public decimal ItemPrice { get; set; }
}
