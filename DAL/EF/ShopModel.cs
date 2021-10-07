using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModel")
        {
            Database.SetInitializer(new ShopModelInitializer());
        }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public decimal Money { get; set; }
        // Navigation property
        public virtual Role Role { get; set; }

    }
    public class ShoppingCart
    {
        [Required]
        public int UserId { get; set; }
        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }

    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte Discount { get; set; }
        public string[] Description { get; set; }
        public byte[] ProductImage { get; set; }
    }

    public class Role
    {
        [Key]
        public string Name { get; set; }
        // Navigation properties

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}