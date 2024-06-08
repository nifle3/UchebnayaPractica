using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Model;



public partial class RealtorsStoreContext : DbContext
{
    private static readonly Lazy<RealtorsStoreContext> Lazy =
        new Lazy<RealtorsStoreContext>(() => new RealtorsStoreContext()); 
    
    private RealtorsStoreContext()
    {
    }

    public RealtorsStoreContext(DbContextOptions<RealtorsStoreContext> options)
        : base(options)
    {
    }
    
    [DbFunction("dbo", "LevenshteinDistance")]
    public static int LevenshteinDistance(string s, string t)
    {
        throw new NotSupportedException("This method is only for EF Core to use.");
    }

    
    public static RealtorsStoreContext Instance => Lazy.Value;

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ApartmentsNeed> ApartmentsNeeds { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Estate> Estates { get; set; }

    public virtual DbSet<EstateApartment> EstateApartments { get; set; }

    public virtual DbSet<EstateHouse> EstateHouses { get; set; }

    public virtual DbSet<EstateLand> EstateLands { get; set; }

    public virtual DbSet<HouseNeed> HouseNeeds { get; set; }

    public virtual DbSet<LandsNeed> LandsNeeds { get; set; }

    public virtual DbSet<Need> Needs { get; set; }

    public virtual DbSet<Realtor> Realtors { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RealtorsStore;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3213E83FFD98EAF3");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.House)
                .HasMaxLength(255)
                .HasColumnName("house");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");
        });

        modelBuilder.Entity<ApartmentsNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3213E83F3EE06612");

            entity.ToTable("ApartmentsNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxFloor).HasColumnName("max_floor");
            entity.Property(e => e.MaxRoomsCount).HasColumnName("max_rooms_count");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinFloor).HasColumnName("min_floor");
            entity.Property(e => e.MinRoomsCount).HasColumnName("min_rooms_count");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3213E83F4B158436");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__District__72E12F1AAA04A4D4");

            entity.ToTable("District");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Estate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estate__3213E83FB23D0BC7");

            entity.ToTable("Estate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.District)
                .HasMaxLength(255)
                .HasColumnName("district");
            entity.Property(e => e.EstateType)
                .HasMaxLength(255)
                .HasColumnName("estate_type");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Estates)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("EstateAddressFK");

            entity.HasOne(d => d.DistrictNavigation).WithMany(p => p.Estates)
                .HasForeignKey(d => d.District)
                .HasConstraintName("EstateDistrictFK");
        });

        modelBuilder.Entity<EstateApartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateAp__3213E83F9DCBE136");

            entity.ToTable("EstateApartment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<EstateHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateHo__3213E83FC39D851C");

            entity.ToTable("EstateHouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FloorsCount).HasColumnName("floors_count");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<EstateLand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateLa__3213E83F8BB7BFEA");

            entity.ToTable("EstateLand");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<HouseNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HouseNee__3213E83F035B066B");

            entity.ToTable("HouseNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxFloorsCount).HasColumnName("max_floors_count");
            entity.Property(e => e.MaxRoomsCount).HasColumnName("max_rooms_count");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinFloorsCount).HasColumnName("min_floors_count");
            entity.Property(e => e.MinRoomsCount).HasColumnName("min_rooms_count");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<LandsNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandsNee__3213E83F87BE842E");

            entity.ToTable("LandsNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<Need>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Need__3213E83FEF0EA66B");
            entity.UseTptMappingStrategy();
            
            entity.ToTable("Need");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.EstateType)
                .HasMaxLength(255)
                .HasColumnName("estate_type");
            entity.Property(e => e.MaxPrice)
                .HasColumnType("money")
                .HasColumnName("max_price");
            entity.Property(e => e.MinPrice)
                .HasColumnType("money")
                .HasColumnName("min_price");
            entity.Property(e => e.Realtor).HasColumnName("realtor");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("NeedAddressFK");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NeedClientFK");

            entity.HasOne(d => d.RealtorNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Realtor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NeedRealtorFK");
        });

        modelBuilder.Entity<Realtor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Realtor__3213E83F8D56A008");

            entity.ToTable("Realtor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comission).HasColumnName("comission");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suggesti__3213E83FB29B14C6");

            entity.ToTable("Suggestion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Estate).HasColumnName("estate");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Realtor).HasColumnName("realtor");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionClientFK");

            entity.HasOne(d => d.EstateNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Estate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionEstateFK");

            entity.HasOne(d => d.RealtorNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Realtor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionRealtorFK");

            entity.HasMany(d => d.Needs).WithMany(p => p.Suggestions)
                .UsingEntity<Dictionary<string, object>>(
                    "Deal",
                    r => r.HasOne<Need>().WithMany()
                        .HasForeignKey("Need")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("DealNeedFK"),
                    l => l.HasOne<Suggestion>().WithMany()
                        .HasForeignKey("Suggestion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("DealSuggestionFK"),
                    j =>
                    {
                        j.HasKey("Suggestion", "Need").HasName("DealPK");
                        j.ToTable("Deal");
                        j.IndexerProperty<int>("Suggestion").HasColumnName("suggestion");
                        j.IndexerProperty<int>("Need").HasColumnName("need");
                    });
        });

        modelBuilder.HasDbFunction(() => LevenshteinDistance("", "")).HasName("LevenshteinDistance")
            .HasSchema("dbo");
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
