using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBase.Models.Entities;

public partial class WebApplicationBaseContext : DbContext
{
    public WebApplicationBaseContext()
    {
    }

    public WebApplicationBaseContext(DbContextOptions<WebApplicationBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseTable> BaseTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4NO5S2N;Database=WebApplicationBase;User ID=sa;Password=1qaz@WSX;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseTable>(entity =>
        {
            entity.ToTable("BaseTable");

            entity.Property(e => e.Id)
                .HasComment("ID")
                .HasColumnName("ID");
            entity.Property(e => e.Content).HasMaxLength(100);
            entity.Property(e => e.CreateTime)
                .HasComment("建立時間")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasComment("建立使用者");
            entity.Property(e => e.Title).HasMaxLength(20);
            entity.Property(e => e.UpdateTime)
                .HasComment("異動時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasComment("更新使用者");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
