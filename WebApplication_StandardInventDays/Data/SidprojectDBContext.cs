using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Data;

public partial class SidprojectDBContext : DbContext
{
    public SidprojectDBContext()
    {
    }

    public SidprojectDBContext(DbContextOptions<SidprojectDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialList> MaterialLists { get; set; }

    public virtual DbSet<Sid> Sids { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q6QR484\\SQLEXPRESS;Database=SIDProject;Trusted_Connection=True;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialList>(entity =>
        {
            entity.HasKey(e => e.IdMatList);

            entity.ToTable("Material_List");

            entity.Property(e => e.IdMatList)
                .HasMaxLength(5)
                .HasColumnName("id_MatList");
            entity.Property(e => e.Fac).HasMaxLength(3);
            entity.Property(e => e.ItemDesc).HasMaxLength(40);
            entity.Property(e => e.ItemNo).HasMaxLength(18);
            entity.Property(e => e.UoM).HasMaxLength(4);
        });

        modelBuilder.Entity<Sid>(entity =>
        {
            entity.HasKey(e => e.IdSid);

            entity.ToTable("SID");

            entity.Property(e => e.IdSid)
                .HasMaxLength(5)
                .HasColumnName("id_SID");
            entity.Property(e => e.CapacityDifferent)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Capacity_Different");
            entity.Property(e => e.Consumption).HasMaxLength(8);
            entity.Property(e => e.DeliveryCycle)
                .HasMaxLength(8)
                .HasColumnName("Delivery_Cycle");
            entity.Property(e => e.Fac).HasMaxLength(4);
            entity.Property(e => e.IdMatList)
                .HasMaxLength(5)
                .HasColumnName("id_MatList");
            entity.Property(e => e.ItemDesc).HasMaxLength(45);
            entity.Property(e => e.ItemNo).HasMaxLength(30);
            entity.Property(e => e.MoQ).HasMaxLength(8);
            entity.Property(e => e.MonthlyConsume)
                .HasMaxLength(8)
                .HasColumnName("Monthly_Consume");
            entity.Property(e => e.ProdLt)
                .HasMaxLength(8)
                .HasColumnName("ProdLT");
            entity.Property(e => e.Reject).HasMaxLength(8);
            entity.Property(e => e.Remark).HasMaxLength(30);
            entity.Property(e => e.SupplyCapacity)
                .HasMaxLength(8)
                .HasColumnName("Supply_Capacity");
            entity.Property(e => e.UoM).HasMaxLength(3);
            entity.Property(e => e.VendorType).HasMaxLength(3);

            entity.HasOne(d => d.IdMatListNavigation).WithMany(p => p.Sids)
                .HasForeignKey(d => d.IdMatList)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SID_Material_List");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
