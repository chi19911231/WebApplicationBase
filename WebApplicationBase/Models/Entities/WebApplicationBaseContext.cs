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

    public virtual DbSet<AddressInfo> AddressInfos { get; set; }

    public virtual DbSet<BaseTable> BaseTables { get; set; }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4NO5S2N;Database=WebApplicationBase;User ID=sa;Password=1qaz@WSX;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressInfo>(entity =>
        {
            entity.ToTable("AddressInfo");

            entity.Property(e => e.Id)
                .HasComment("ID")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasComment("姓名");
            entity.Property(e => e.CreateTime)
                .HasComment("建立時間")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasComment("建立使用者");
            entity.Property(e => e.UpdateTime)
                .HasComment("異動時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasComment("更新使用者");
            entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");
        });

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

        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.ToTable("ProductInfo");

            entity.Property(e => e.Id)
                .HasComment("ID")
                .HasColumnName("ID");
            entity.Property(e => e.CreateTime)
                .HasComment("建立時間")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasComment("建立使用者");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasComment("姓名");
            entity.Property(e => e.Price)
                .HasComment("身分證")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Type).HasComment("性別(列舉值 1:男生 2:女生 3:其他)");
            entity.Property(e => e.UpdateTime)
                .HasComment("異動時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasComment("更新使用者");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("UserInfo");

            entity.Property(e => e.Id)
                .HasComment("ID")
                .HasColumnName("ID");
            entity.Property(e => e.Acount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("帳號");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasComment("地址");
            entity.Property(e => e.CreateTime)
                .HasComment("建立時間")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasComment("建立使用者");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("電子信箱");
            entity.Property(e => e.Gender).HasComment("性別(列舉值 1:男生 2:女生 3:其他)");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasComment("姓名");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("密碼");
            entity.Property(e => e.PersonId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("身分證")
                .HasColumnName("PersonID");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("手機");
            entity.Property(e => e.UpdateTime)
                .HasComment("異動時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasComment("更新使用者");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
