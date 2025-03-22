using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }
        public DbSet<AddressEntity>? Addresses { get; set; }
        public DbSet<PaymentMethodEntity>? PaymentMethods { get; set; }
        public DbSet<CartEntity>? Carts { get; set; }
        public DbSet<CartItemEntity>? CartItems { get; set; }
        public DbSet<ProductEntity>? Products { get; set; }
        public DbSet<OrderEntity>? Orders { get; set; }
        public DbSet<OrderItemEntity>? OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de las relaciones

            // Relación uno a muchos entre User y Address
            modelBuilder.Entity<AddressEntity>()
                .HasOne<UserEntity>()
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId);

            // Relación uno a muchos entre User y PaymentMethod
            modelBuilder.Entity<PaymentMethodEntity>()
                .HasOne<UserEntity>()
                .WithMany(u => u.paymentMethodEntities)
                .HasForeignKey(p => p.UserId);

            // Relación uno a uno entre User y Cart
            modelBuilder.Entity<CartEntity>()
                .HasOne<UserEntity>()
                .WithOne(u => u.Cart)
                .HasForeignKey<CartEntity>(c => c.UserId);

            // Relación uno a muchos entre Cart y CartItem
            modelBuilder.Entity<CartItemEntity>()
                .HasOne<CartEntity>()
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            // Relación uno a muchos entre Order y OrderItem
            modelBuilder.Entity<OrderItemEntity>()
                .HasOne<OrderEntity>()
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // Relación uno a muchos entre User y Order
            modelBuilder.Entity<OrderEntity>()
                .HasOne<UserEntity>()
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Relación uno a uno entre Order y Address
            modelBuilder.Entity<OrderEntity>()
                .HasOne<AddressEntity>()
                .WithOne()
                .HasForeignKey<OrderEntity>(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // ------------------ Configuración de las columnas ------------------

            // Dar formato a la columna Price de la tabla Product
            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Dar formato a la columna Total de la tabla Order
            modelBuilder.Entity<CartItemEntity>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            // Dar formato a la columna Price de la tabla OrderItem
            modelBuilder.Entity<OrderItemEntity>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            // Dar formato a la columna Total de la tabla Order
            modelBuilder.Entity<OrderEntity>()
                .Property(o => o.Total)
                .HasColumnType("decimal(18,2)");
        }

    }
    
}
