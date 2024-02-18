using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplicationRememberAll.Models;

namespace WebApplicationRememberAll.DbConnector;

public partial class CsharpGroupSlaveDbContext : DbContext
{
    public CsharpGroupSlaveDbContext()
    {
    }

    public CsharpGroupSlaveDbContext(DbContextOptions<CsharpGroupSlaveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Slafe> Slaves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87:5432;Database=csharp_group_slave_db;Username=csharp_group_slave_user;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Slafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("slaves_pk");

            entity.ToTable("slaves");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CountryOfOrigin)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("country_of_origin");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
