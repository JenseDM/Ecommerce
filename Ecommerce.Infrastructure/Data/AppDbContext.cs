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
                .HasOne<UserEntity>() // AddressEntity tiene una relación con UserEntity
                .WithMany() // UserEntity no tiene una colección de AddressEntity
                .HasForeignKey(a => a.UserId); // Clave foránea en AddressEntity

            // Relación uno a muchos entre User y PaymentMethod
            modelBuilder.Entity<PaymentMethodEntity>()
                .HasOne<UserEntity>() // PaymentMethodEntity tiene una relación con UserEntity
                .WithMany() // UserEntity no tiene una colección de PaymentMethodEntity
                .HasForeignKey(p => p.UserId); // Clave foránea en PaymentMethodEntity

            // Relación uno a muchos entre User y Order
            modelBuilder.Entity<OrderEntity>()
                .HasOne<UserEntity>() // OrderEntity tiene una relación con UserEntity
                .WithMany() // UserEntity no tiene una colección de OrderEntity
                .HasForeignKey(o => o.UserId) // Clave foránea en OrderEntity
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento de eliminación

            // Relación uno a uno entre User y Cart
            modelBuilder.Entity<CartEntity>()
                .HasOne<UserEntity>() // CartEntity tiene una relación con UserEntity
                .WithOne() // UserEntity no tiene una relación inversa
                .HasForeignKey<CartEntity>(c => c.UserId); // Clave foránea en CartEntity

            // Relación uno a muchos entre Cart y CartItem
            modelBuilder.Entity<CartItemEntity>()
                .HasOne<CartEntity>()
                .WithMany()
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Order y OrderItem
            modelBuilder.Entity<OrderItemEntity>()
                .HasOne<OrderEntity>()
                .WithMany()
                .HasForeignKey(oi => oi.OrderId)
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
