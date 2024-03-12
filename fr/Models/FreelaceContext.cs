using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fr.Models;

public partial class FreelaceContext : DbContext
{
    public FreelaceContext()
    {
    }

    public FreelaceContext(DbContextOptions<FreelaceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<ProposalStatus> ProposalStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PFD2B5E;Database=freelace;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CtegoryName).HasMaxLength(200);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Orders_OrderStatuses");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.Property(e => e.PortfolioId).HasColumnName("PortfolioID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Portfolios_Users");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profiles_Users");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.Property(e => e.ProposalId).HasColumnName("ProposalID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Order).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposals_Orders");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposals_ProposalStatuses");

            entity.HasOne(d => d.User).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposals_Users");
        });

        modelBuilder.Entity<ProposalStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Category1Navigation).WithMany(p => p.UserCategory1Navigations)
                .HasForeignKey(d => d.Category1)
                .HasConstraintName("FK_Users_Categories");

            entity.HasOne(d => d.Category2Navigation).WithMany(p => p.UserCategory2Navigations)
                .HasForeignKey(d => d.Category2)
                .HasConstraintName("FK_Users_Categories1");

            entity.HasOne(d => d.Category3Navigation).WithMany(p => p.UserCategory3Navigations)
                .HasForeignKey(d => d.Category3)
                .HasConstraintName("FK_Users_Categories2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
