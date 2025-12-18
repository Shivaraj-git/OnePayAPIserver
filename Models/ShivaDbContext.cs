using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnePayAPI.Models;

public partial class ShivaDbContext : DbContext
{
    public ShivaDbContext()
    {
    }

    public ShivaDbContext(DbContextOptions<ShivaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<MerchantBankAccount> MerchantBankAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Merchant>(entity =>
        {
            entity.HasKey(e => e.MerchantId);

            entity.Property(e => e.BusinessName).HasMaxLength(150);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<MerchantBankAccount>(entity =>
        {
            entity.HasKey(e => e.BankId);

            entity.Property(e => e.AccountHolderName).HasMaxLength(100);
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.IsVerified).HasDefaultValue(false);

            entity.HasOne(d => d.Merchant)
                 .WithMany(p => p.MerchantBankAccounts)
                .HasForeignKey(d => d.MerchantId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
