using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Models;

public partial class ESingleRestaurantManagementSystemContext : DbContext
{
    public ESingleRestaurantManagementSystemContext()
    {
    }

    public ESingleRestaurantManagementSystemContext(DbContextOptions<ESingleRestaurantManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<DeliveryLocation> DeliveryLocations { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountCategory> DiscountCategories { get; set; }

    public virtual DbSet<DiscountItem> DiscountItems { get; set; }
    public virtual DbSet<Favorite> Favorites { get; set; }
    public virtual DbSet<IssuesSuggestion> IssuesSuggestions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemOption> ItemOptions { get; set; }

    public virtual DbSet<LookupItem> LookupItems { get; set; }

    public virtual DbSet<LookupType> LookupTypes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrdersHistory> OrdersHistories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserIssuesSuggestion> UserIssuesSuggestions { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<UserOtp> UserOtps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FB86LSD\\SQLSERVER;Initial Catalog=DummyDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
           // => optionsBuilder.UseSqlServer("Data Source = VAGRANT - MC0J25I\\SQLEXPRESS; Initial Catalog = Team11; User Id = admin; Password=Test@1234;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__D6AB4759ACB7C396");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "UQ__Cart__206D91712162912E").IsUnique();

            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.CartStatus).HasColumnName("Cart_Status");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.TotalPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Price");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("Update_At");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.CartStatusNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CartStatus)
                .HasConstraintName("FK__Cart__Cart_Statu__671F4F74");

            entity.HasOne(d => d.User).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.UserId)
                .HasConstraintName("FK__Cart__User_Id__662B2B3B");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Cart_Ite__3C0F265CB1ADE5CC");

            entity.ToTable("Cart_Items");

            entity.Property(e => e.CartItemId).HasColumnName("Cart_Item_Id");
            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__Cart_Item__Cart___6CD828CA");

            entity.HasOne(d => d.Item).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Cart_Item__Item___6DCC4D03");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__6DB38D6ED9EC75C4");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CategoryNameAr)
                .HasMaxLength(100)
                .HasColumnName("Category_NameAr");
            entity.Property(e => e.CategoryNameEn)
                .HasMaxLength(100)
                .HasColumnName("Category_NameEn");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("PK__Chats__9783B1DEE62FC6A8");

            entity.Property(e => e.ChatId).HasColumnName("Chat_Id");
            entity.Property(e => e.ChatFilePath)
                .HasMaxLength(255)
                .HasColumnName("Chat_File_Path");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DriverId).HasColumnName("Driver_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.ChatClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chats__Client_Id__0F624AF8");

            entity.HasOne(d => d.Driver).WithMany(p => p.ChatDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chats__Driver_Id__10566F31");

            entity.HasOne(d => d.Order).WithMany(p => p.Chats)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Chats__Order_Id__1332DBDC");
        });

        modelBuilder.Entity<DeliveryLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Delivery__D2BA00E202595D36");

            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(50)
                .HasColumnName("Delivery_Status");
            entity.Property(e => e.DeliveryTime)
                .HasColumnType("datetime")
                .HasColumnName("Delivery_Time");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.DeliveryLocations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DeliveryL__Clien__1CBC4616");

            entity.HasOne(d => d.Order).WithMany(p => p.DeliveryLocations)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DeliveryL__Order__1F98B2C1");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__6C1372049EC8737D");

            entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_ar");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DiscountStatus).HasColumnName("Discount_Status");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LimitAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Limit_Amount");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.TitleAr)
                .HasMaxLength(255)
                .HasColumnName("Title_ar");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("Title_en");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.DiscountStatusNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.DiscountStatus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discounts__Disco__797309D9");
        });

        modelBuilder.Entity<DiscountCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07B0A34FF8");

            entity.ToTable("Discount_Categories");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Category).WithMany(p => p.DiscountCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discount___Categ__3E1D39E1");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountCategories)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discount___Disco__3D2915A8");
        });

        modelBuilder.Entity<DiscountItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC078D4298B4");

            entity.ToTable("Discount_items");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountItems)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discount___Disco__37703C52");

            entity.HasOne(d => d.Item).WithMany(p => p.DiscountItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discount___Item___3864608B");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavouriteId).HasName("PK__Favourites__ID");

            entity.Property(e => e.FavouriteId).HasColumnName("FavouriteId");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnName("Created_At");

            // Relationship: Favourite → User (many-to-one)
            entity.HasOne(d => d.User)
                .WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favourites_Users");

            // Relationship: Favourite → Item (many-to-one)
            entity.HasOne(d => d.Item)
                .WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favourites_Items");
        });

        modelBuilder.Entity<IssuesSuggestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Issues_S__3214EC076EB9F474");

            entity.ToTable("Issues_Suggestions");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IssueType).HasColumnName("Issue_Type");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IssueTypeNavigation).WithMany(p => p.IssuesSuggestions)
                .HasForeignKey(d => d.IssueType)
                .HasConstraintName("FK__Issues_Su__Issue__32AB8735");

            entity.HasOne(d => d.User).WithMany(p => p.IssuesSuggestions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Issues_Su__User___31B762FC");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__3FB50874D4819B4C");

            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Items__Category___628FA481");
        });

        modelBuilder.Entity<ItemOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemOpti__3214EC0715D65DFB");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.OptionId).HasColumnName("Option_Id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemOptio__Item___74AE54BC");

            entity.HasOne(d => d.Option).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK__ItemOptio__Optio__75A278F5");
        });

        modelBuilder.Entity<LookupItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lookup_I__3214EC0713576D9A");

            entity.ToTable("Lookup_Items");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");
            entity.Property(e => e.ValueAr)
                .HasMaxLength(100)
                .HasColumnName("Value_Ar");
            entity.Property(e => e.ValueEn)
                .HasMaxLength(100)
                .HasColumnName("Value_En");

            entity.HasOne(d => d.Type).WithMany(p => p.LookupItems)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lookup_It__Type___6B24EA82");
        });

        modelBuilder.Entity<LookupType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Lookup_T__41F99A32A2710A8C");

            entity.ToTable("Lookup_Types");

            entity.Property(e => e.TypeId).HasColumnName("TYPE_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07F500F7C2");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("Is_Read");
            entity.Property(e => e.NotificationType).HasColumnName("Notification_Type");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.NotificationTypeNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationType)
                .HasConstraintName("FK__Notificat__Notif__2CF2ADDF");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Notificat__User___2BFE89A6");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Options__3260907E7BD27D43");

            entity.Property(e => e.OptionId).HasColumnName("Option_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsRequired)
                .HasDefaultValue(false)
                .HasColumnName("Is_Required");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.OptionType).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4607B19E05042");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");
            entity.Property(e => e.DriverId).HasColumnName("Driver_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.OrderStatus).HasColumnName("Order_Status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Price");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("Update_At");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.OrderClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Client_I__7C4F7684");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK__Orders__Discount__00200768");

            entity.HasOne(d => d.Driver).WithMany(p => p.OrderDrivers)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Orders__Driver_I__7D439ABD");

            entity.HasOne(d => d.OrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__Order_St__01142BA1");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_It__2F30220238919D6B");

            entity.ToTable("Order_Items");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.ItemPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Item_Price");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Price");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Order_Ite__Item___06CD04F7");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Order_Ite__Order__05D8E0BE");
        });

        modelBuilder.Entity<OrdersHistory>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ClientId }).HasName("PK_OrdersHistory");

            entity.ToTable("Orders_History");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.OrdersHistories)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders_Hi__Clien__09A971A2");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersHistories)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Orders_Hi__Order__0C85DE4D");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__DA6C7FC12F15425C");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PaidAt)
                .HasColumnType("datetime")
                .HasColumnName("Paid_At");
            entity.Property(e => e.PaymentMethod).HasColumnName("Payment_Method");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("Update_At");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Client__160F4887");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Payments__Order___18EBB532");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethod)
                .HasConstraintName("FK__Payments__Paymen__19DFD96B");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__89B74485C2324BA6");

            entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .HasColumnName("Created_By");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ratings__3214EC07574E2397");

            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.DriverId).HasColumnName("Driver_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.RatingAmount).HasColumnName("Rating_Amount");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Client).WithMany(p => p.RatingClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__Client___22751F6C");

            entity.HasOne(d => d.Driver).WithMany(p => p.RatingDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__Driver___236943A5");

            entity.HasOne(d => d.Order).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ratings__Order_I__2645B050");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reports__3214EC078EE098FD");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reports__Item_Id__43D61337");

            entity.HasOne(d => d.Order).WithMany(p => p.Reports)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reports__Order_I__44CA3770");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Reports__User_Id__42E1EEFE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__D80AB4BB9468D958");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("Name_En");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId });

            entity.ToTable("Role_Permissions");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__Role_Perm__Permi__56E8E7AB");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Role_Perm__Role___55F4C372");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D917003FA2063");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__17A35CA49DB8C3C0").IsUnique();

            entity.HasIndex(e => e.PasswordHash, "UQ__Users__31C827963597F0F0").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105341D5365BB").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456FF38F0BB").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("Birth_Date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("Full_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(16)
                .HasColumnName("Password_Hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(14)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ProfileImage).HasColumnName("Profile_Image");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__Role_Id__5441852A");
        });

        modelBuilder.Entity<UserIssuesSuggestion>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.IssueSuggestionId });

            entity.ToTable("User_Issues_Suggestions");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.IssueSuggestionId).HasColumnName("Issue_Suggestion_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.IssueSuggestion).WithMany(p => p.UserIssuesSuggestions)
                .HasForeignKey(d => d.IssueSuggestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Issu__Issue__51300E55");

            entity.HasOne(d => d.User).WithMany(p => p.UserIssuesSuggestions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Issu__User___503BEA1C");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.NotificationId });

            entity.ToTable("User_Notifications");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.NotificationId).HasColumnName("Notification_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("Is_Read");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.Notification).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Noti__Notif__4B7734FF");

            entity.HasOne(d => d.User).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Noti__User___4A8310C6");
        });

        modelBuilder.Entity<UserOtp>(entity =>
        {
            entity.HasKey(e => e.UserOtpId).HasName("PK__UserOTP__44938591C6B1170F");

            entity.ToTable("UserOTP");

            entity.HasIndex(e => e.Email, "UQ__UserOTP__A9D10534BCE8D409").IsUnique();

            entity.Property(e => e.UserOtpId).HasColumnName("UserOTP_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("Created_By");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsUsed).HasDefaultValue(false);
            entity.Property(e => e.Otpcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OTPCode");
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .HasDefaultValue("ResetPassword");
            entity.Property(e => e.TryCount).HasDefaultValue(0);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.UserOtps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserOTP__User_Id__5F7E2DAC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
