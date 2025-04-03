using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nhom1_Giay.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Server=DELL\\SQLEXPRESS;Database=ShoeStoreDB1;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD7B74261B76F");

                entity.HasOne(d => d.User).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carts__UserId__403A8C7D");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0ABE54C3F9");

                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__CartI__4316F928");

                entity.HasOne(d => d.Shoe).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__ShoeI__440B1D61");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B7935B8BE");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF9BEAB3D0");

                entity.Property(e => e.OrderDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__48CFD27E");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681B40EEBAA");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__Order__4BAC3F29");

                entity.HasOne(d => d.Shoe).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__ShoeI__4CA06362");
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasKey(e => e.ShoeId).HasName("PK__Shoes__5A835BF5ECF05982");

                entity.Property(e => e.Color).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Size).HasMaxLength(20);

                entity.HasOne(d => d.Category).WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shoes__CategoryI__3D5E1FD2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                object value = entity.HasKey(e => e.Id).HasName("PK__Users__1788CC4C7A4EE525");
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AF3FBBB8").IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.PasswordHash).HasMaxLength(255);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.VoucherId).HasName("PK__Vouchers__3AEE7921C3296EA5");

                entity.HasIndex(e => e.Code, "UQ__Vouchers__A25C5AA7A17E62A1").IsUnique();

                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.HasOne(d => d.User).WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vouchers__UserId__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
