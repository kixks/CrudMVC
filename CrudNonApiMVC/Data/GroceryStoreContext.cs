using System;
using System.Collections.Generic;
using CrudNonApiMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNonApiMVC.Data;

public partial class GroceryStoreContext : DbContext
{
    public GroceryStoreContext()
    {
    }

    public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvailableItem> AvailableItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:GroceryStoreConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
