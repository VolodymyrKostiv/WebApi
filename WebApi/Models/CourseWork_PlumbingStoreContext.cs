using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.DTOs;

namespace WebApi.Models
{
    public partial class CourseWork_PlumbingStoreContext : DbContext
    {
        public CourseWork_PlumbingStoreContext()
        {
        }

        public CourseWork_PlumbingStoreContext(DbContextOptions<CourseWork_PlumbingStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;
        public virtual DbSet<FullProductInfo> FullProductInfos { get; set; } = null!;
        public virtual DbSet<LoginDatum> LoginData { get; set; } = null!;
        public virtual DbSet<PersonalDatum> PersonalData { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;
        public virtual DbSet<StorageProduct> StorageProducts { get; set; } = null!;
        public virtual DbSet<Subcategory> Subcategories { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplyOrder> SupplyOrders { get; set; } = null!;
        public virtual DbSet<SupplyOrderProduct> SupplyOrderProducts { get; set; } = null!;
        public virtual DbSet<SupplyOrderState> SupplyOrderStates { get; set; } = null!;
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; } = null!;
        public DbSet<ShopStorageProductDTO> ShopStorageProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CourseWork_PlumbingStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Employ__403A8C7D");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__ShopID__3F466844");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<FullProductInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FullProductInfo");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Subcategory).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UnitOfMeasurement).HasMaxLength(20);
            });

            modelBuilder.Entity<LoginDatum>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.LoginDatum)
                    .HasForeignKey<LoginDatum>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoginData__Emplo__4222D4EF");
            });

            modelBuilder.Entity<PersonalDatum>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.PersonalDatum)
                    .HasForeignKey<PersonalDatum>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonalD__Emplo__440B1D61");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UnitOfMeasurementId).HasColumnName("UnitOfMeasurementID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandID__30F848ED");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK__Product__Subcate__32E0915F");

                entity.HasOne(d => d.UnitOfMeasurement)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitOfMeasurementId)
                    .HasConstraintName("FK__Product__UnitOfM__31EC6D26");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PurchaseOrder");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Emplo__46E78A0C");
            });

            modelBuilder.Entity<PurchaseOrderProduct>(entity =>
            {
                entity.ToTable("PurchaseOrderProduct");

                entity.Property(e => e.PurchaseOrderProductId).HasColumnName("PurchaseOrderProductID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Produ__49C3F6B7");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderProducts)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PurchaseO__Purch__4AB81AF0");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shop__StorageID__3A81B327");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");
            });

            modelBuilder.Entity<StorageProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StorageProduct");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoragePr__Produ__37A5467C");

                entity.HasOne(d => d.Storage)
                    .WithMany()
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoragePr__Stora__36B12243");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategory");

                entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subcatego__Categ__2A4B4B5E");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<SupplyOrder>(entity =>
            {
                entity.ToTable("SupplyOrder");

                entity.Property(e => e.SupplyOrderId).HasColumnName("SupplyOrderID");

                entity.Property(e => e.ActualDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExpectedDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplyOrderStateId).HasColumnName("SupplyOrderStateID");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SupplyOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyOrd__Emplo__4E88ABD4");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplyOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyOrd__Suppl__4D94879B");

                entity.HasOne(d => d.SupplyOrderState)
                    .WithMany(p => p.SupplyOrders)
                    .HasForeignKey(d => d.SupplyOrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyOrd__Suppl__4F7CD00D");
            });

            modelBuilder.Entity<SupplyOrderProduct>(entity =>
            {
                entity.ToTable("SupplyOrderProduct");

                entity.Property(e => e.SupplyOrderProductId).HasColumnName("SupplyOrderProductID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SupplyOrderId).HasColumnName("SupplyOrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SupplyOrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyOrd__Produ__52593CB8");

                entity.HasOne(d => d.SupplyOrder)
                    .WithMany(p => p.SupplyOrderProducts)
                    .HasForeignKey(d => d.SupplyOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyOrd__Suppl__534D60F1");
            });

            modelBuilder.Entity<SupplyOrderState>(entity =>
            {
                entity.ToTable("SupplyOrderState");

                entity.Property(e => e.SupplyOrderStateId).HasColumnName("SupplyOrderStateID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<UnitOfMeasurement>(entity =>
            {
                entity.ToTable("UnitOfMeasurement");

                entity.Property(e => e.UnitOfMeasurementId).HasColumnName("UnitOfMeasurementID");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
