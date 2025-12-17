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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KASSAPOS35;Database=shiva_db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Merchant>(entity =>
        {
            entity.HasKey(e => e.MerchantId).HasName("PK__Merchant__044165433031832C");

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
            entity.HasKey(e => e.BankId).HasName("PK__Merchant__AA08CB1339BCCEF7");

            entity.Property(e => e.AccountHolderName).HasMaxLength(100);
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.IsVerified).HasDefaultValue(false);

            entity.HasOne(d => d.Merchant).WithMany(p => p.MerchantBankAccounts)
                .HasForeignKey(d => d.MerchantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MerchantBankAccounts_Merchants");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
