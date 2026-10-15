using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PyroProjet.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Consumable> Consumables { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Contain> Contains { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }

    public virtual DbSet<DeliveryNoteLine> DeliveryNoteLines { get; set; }

    public virtual DbSet<Effect> Effects { get; set; }

    public virtual DbSet<HasContract> HasContracts { get; set; }

    public virtual DbSet<IncludesLine> IncludesLines { get; set; }

    public virtual DbSet<Interaction> Interactions { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<OrdersArticle> OrdersArticles { get; set; }

    public virtual DbSet<PlaysSound> PlaysSounds { get; set; }

    public virtual DbSet<Produce> Produces { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductFamily> ProductFamilies { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<Pyrotechnician> Pyrotechnicians { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationLine> QuotationLines { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<Sound> Sounds { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StockMovement> StockMovements { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TriggersArticle> TriggersArticles { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=romaric-thibault.fr,1433;Database=projet_pyrofete;User Id=etudiants;Password=Btssio2026;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3213E83F6862E089");

            entity.ToTable("Approval");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FilePathCertification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("file_path_certification");
            entity.Property(e => e.ObtainedDate).HasColumnName("obtained_date");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Article__3213E83F75746624");

            entity.ToTable("Article");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.Sellable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sellable");
            entity.Property(e => e.VisibilityState).HasColumnName("visibility_state");

            entity.HasMany(d => d.Id1s).WithMany(p => p.IdsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "Transport",
                    r => r.HasOne<Truck>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Transports__id_1__32767D0B"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Transports__id__318258D2"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__Transpor__6BC895152DC0FBCB");
                        j.ToTable("Transports");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brand__3213E83F776F5562");

            entity.ToTable("Brand");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Color__3213E83F470C116F");

            entity.ToTable("Color");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Consumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consumab__3213E83FB6AC7CD4");

            entity.ToTable("Consumable");

            entity.HasIndex(e => e.Id1, "UQ__Consumab__9DB7D2A598599DF4").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit_of_measurement");

            entity.HasOne(d => d.Id1Navigation).WithOne(p => p.Consumable)
                .HasForeignKey<Consumable>(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consumable__id_1__01D345B0");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3213E83F3282427A");

            entity.ToTable("Contact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contact__id_1__5224328E");
        });

        modelBuilder.Entity<Contain>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__Contains__6BC895157C55F395");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.PhysicalQuantity).HasColumnName("physical_quantity");
            entity.Property(e => e.TheoricalQuantity).HasColumnName("theorical_quantity");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Contains)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contains__id__4C364F0E");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Contains)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contains__id_1__4D2A7347");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F5F5C1AA1");

            entity.ToTable("Customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__id_1__498EEC8D");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F5EEF0201");

            entity.ToTable("CustomerType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<DeliveryNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3213E83F8E1EEE24");

            entity.ToTable("DeliveryNote");

            entity.HasIndex(e => e.Id1, "UQ__Delivery__9DB7D2A56B4B0E2D").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Carrier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("carrier");
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.IsCompliance).HasColumnName("is_compliance");
            entity.Property(e => e.ReceptionRemarks)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reception_remarks");
            entity.Property(e => e.ShippingDate).HasColumnName("shipping_date");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tracking_number");

            entity.HasOne(d => d.Id1Navigation).WithOne(p => p.DeliveryNote)
                .HasForeignKey<DeliveryNote>(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DeliveryNo__id_1__6CD828CA");
        });

        modelBuilder.Entity<DeliveryNoteLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3213E83F9D2F11B8");

            entity.ToTable("DeliveryNoteLine");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Effect>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Effect__3213E83F17BD235A");

            entity.ToTable("Effect");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<HasContract>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__HasContr__6BC89515EAE4623E");

            entity.ToTable("HasContract");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.HasContracts)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HasContract__id__39237A9A");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.HasContracts)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HasContrac__id_1__3A179ED3");
        });

        modelBuilder.Entity<IncludesLine>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__Includes__6BC8951565DA5E5C");

            entity.ToTable("IncludesLine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.IncludesLines)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IncludesLine__id__40C49C62");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.IncludesLines)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IncludesLi__id_1__41B8C09B");
        });

        modelBuilder.Entity<Interaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Interact__3213E83FA42FE713");

            entity.ToTable("Interaction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Call)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("call_");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Meeting)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("meeting");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Interactions)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interactio__id_1__55009F39");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3213E83FCA049512");

            entity.ToTable("Inventory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date_");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Id2).HasColumnName("id_2");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__id_1__14E61A24");

            entity.HasOne(d => d.Id2Navigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Id2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__id_2__15DA3E5D");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3213E83F7B8D36B5");

            entity.ToTable("Material");

            entity.HasIndex(e => e.Id1, "UQ__Material__9DB7D2A5D4FCFDD4").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serial_number");

            entity.HasOne(d => d.Id1Navigation).WithOne(p => p.Material)
                .HasForeignKey<Material>(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Material__id_1__7E02B4CC");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Media__3213E83FA75FC68B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Media)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Media__id_1__04AFB25B");
        });

        modelBuilder.Entity<OrdersArticle>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__OrdersAr__6BC895154A9F7368");

            entity.ToTable("OrdersArticle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.HistoryPrice)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("historyPrice");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.OrdersArticles)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdersArticl__id__3CF40B7E");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.OrdersArticles)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdersArti__id_1__3DE82FB7");
        });

        modelBuilder.Entity<PlaysSound>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__PlaysSou__6BC8951544CD381A");

            entity.ToTable("PlaysSound");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.StartSound).HasColumnName("start_sound");
            entity.Property(e => e.Timecode)
                .HasColumnType("datetime")
                .HasColumnName("timecode");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.PlaysSounds)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlaysSound__id__1E6F845E");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.PlaysSounds)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlaysSound__id_1__1F63A897");
        });

        modelBuilder.Entity<Produce>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__Produces__6BC895153B664891");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Duration).HasColumnName("duration");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Produces)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produces__id__5006DFF2");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Produces)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produces__id_1__50FB042B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83FDA94C174");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Id3, "UQ__Product__9DB7D2A7913B1EAC").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApprovalNumber).HasColumnName("approval_number");
            entity.Property(e => e.CaliberMm)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("caliber_mm");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EuClassification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eu_classification");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Id2).HasColumnName("id_2");
            entity.Property(e => e.Id3).HasColumnName("id_3");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NecGrams)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("nec_grams");
            entity.Property(e => e.SellPrice)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("sell_price");
            entity.Property(e => e.WeightGrams).HasColumnName("weight_grams");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__id_1__19AACF41");

            entity.HasOne(d => d.Id2Navigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Id2)
                .HasConstraintName("FK__Product__id_2__1A9EF37A");

            entity.HasOne(d => d.Id3Navigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Id3)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__id_3__1B9317B3");

            entity.HasMany(d => d.Id1s).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "HasColor",
                    r => r.HasOne<Color>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HasColor__id_1__54CB950F"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HasColor__id__53D770D6"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__HasColor__6BC8951539010BCA");
                        j.ToTable("HasColor");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<ProductFamily>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductF__3213E83FAA1D9DC3");

            entity.ToTable("ProductFamily");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3213E83FC20F648B");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date_");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseOr__id_1__690797E6");
        });

        modelBuilder.Entity<Pyrotechnician>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pyrotech__3213E83F6CF7E2EB");

            entity.ToTable("Pyrotechnician");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("license_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasMany(d => d.Id1s).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "HoldsApproval",
                    r => r.HasOne<Approval>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HoldsAppro__id_1__2AD55B43"),
                    l => l.HasOne<Pyrotechnician>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HoldsApprova__id__29E1370A"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__HoldsApp__6BC895150B115668");
                        j.ToTable("HoldsApproval");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quotatio__3213E83F34519AC2");

            entity.ToTable("Quotation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date_");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Object)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("object");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quotation__id_1__4C6B5938");
        });

        modelBuilder.Entity<QuotationLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quotatio__3213E83FDC7BD07E");

            entity.ToTable("QuotationLine");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceHt)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("price_ht");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.QuotationLines)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuotationL__id_1__4F47C5E3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83F87F139E2");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<ServiceProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceP__3213E83F01514EC8");

            entity.ToTable("ServiceProvider");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasMany(d => d.Id1s).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "Qualify",
                    r => r.HasOne<ServiceType>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Qualifies__id_1__36470DEF"),
                    l => l.HasOne<ServiceProvider>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Qualifies__id__3552E9B6"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__Qualifie__6BC8951579FD925D");
                        j.ToTable("Qualifies");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceT__3213E83F8370D962");

            entity.ToTable("ServiceType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Settings__3213E83F4E6B4C94");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Logo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.PurchaseOrderCondition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("purchase_order_condition");
            entity.Property(e => e.QuotationCondition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quotation_condition");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Show__3213E83F4F02D7A3");

            entity.ToTable("Show");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Date).HasColumnName("date_");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Id2).HasColumnName("id_2");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.SitePlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("site_plan");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Shows)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show__id_1__11158940");

            entity.HasOne(d => d.Id2Navigation).WithMany(p => p.Shows)
                .HasForeignKey(d => d.Id2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show__id_2__1209AD79");

            entity.HasMany(d => d.Id1s).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "Assign",
                    r => r.HasOne<Truck>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Assigns__id_1__2EA5EC27"),
                    l => l.HasOne<Show>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Assigns__id__2DB1C7EE"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__Assigns__6BC895152A28CFFF");
                        j.ToTable("Assigns");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });

            entity.HasMany(d => d.Id1sNavigation).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "AssignsPyrotechnician",
                    r => r.HasOne<Pyrotechnician>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AssignsPyr__id_1__2704CA5F"),
                    l => l.HasOne<Show>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AssignsPyrot__id__2610A626"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__AssignsP__6BC89515E3BC7CCF");
                        j.ToTable("AssignsPyrotechnician");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<Sound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sound__3213E83F1A2475EF");

            entity.ToTable("Sound");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Artist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("artist");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.Format)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("format");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.LengthMs).HasColumnName("length_ms");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3213E83F02998B25");

            entity.ToTable("Status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<StockMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockMov__3213E83FB58F2162");

            entity.ToTable("StockMovement");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date_");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Id2).HasColumnName("id_2");
            entity.Property(e => e.Id3).HasColumnName("id_3");
            entity.Property(e => e.Id4).HasColumnName("id_4");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.StockMovements)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockMovem__id_1__7755B73D");

            entity.HasOne(d => d.Id2Navigation).WithMany(p => p.StockMovementId2Navigations)
                .HasForeignKey(d => d.Id2)
                .HasConstraintName("FK__StockMovem__id_2__7849DB76");

            entity.HasOne(d => d.Id3Navigation).WithMany(p => p.StockMovementId3Navigations)
                .HasForeignKey(d => d.Id3)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockMovem__id_3__793DFFAF");

            entity.HasOne(d => d.Id4Navigation).WithMany(p => p.StockMovements)
                .HasForeignKey(d => d.Id4)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockMovem__id_4__7A3223E8");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__Stores__6BC89515AC2CF964");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stores__id__44952D46");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stores__id_1__4589517F");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3213E83FEC9675FA");

            entity.ToTable("Supplier");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TriggersArticle>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Id1 }).HasName("PK__Triggers__6BC895157EE5B25B");

            entity.ToTable("TriggersArticle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id1).HasColumnName("id_1");
            entity.Property(e => e.Timecode)
                .HasColumnType("datetime")
                .HasColumnName("timecode");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TriggersArticles)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TriggersArti__id__22401542");

            entity.HasOne(d => d.Id1Navigation).WithMany(p => p.TriggersArticles)
                .HasForeignKey(d => d.Id1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TriggersAr__id_1__2334397B");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Truck__3213E83F9C2475FF");

            entity.ToTable("Truck");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User___3213E83FEE9E8B33");

            entity.ToTable("User_");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");

            entity.HasMany(d => d.Id1s).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "AssignsRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AssignsRol__id_1__4959E263"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AssignsRole__id__4865BE2A"),
                    j =>
                    {
                        j.HasKey("Id", "Id1").HasName("PK__AssignsR__6BC895155B767407");
                        j.ToTable("AssignsRole");
                        j.IndexerProperty<int>("Id").HasColumnName("id");
                        j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                    });
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3213E83F1628FC36");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.LowThreshold).HasColumnName("low_threshold");
            entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
