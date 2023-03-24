﻿using Microsoft.EntityFrameworkCore;
using ShopEcommerce.Configurations.Inventories;
using ShopEcommerce.Configurations.InventoryTickets;
using ShopEcommerce.Configurations.Manufacturers;
using ShopEcommerce.Configurations.Orders;
using ShopEcommerce.Configurations.ProductAttributes;
using ShopEcommerce.Configurations.ProductCategories;
using ShopEcommerce.Configurations.Products;
using ShopEcommerce.Configurations.Promotions;
using ShopEcommerce.Inventories;
using ShopEcommerce.InventoryTickets;
using ShopEcommerce.Manufacturers;
using ShopEcommerce.Orders;
using ShopEcommerce.ProductAttributes;
using ShopEcommerce.ProductCategories;
using ShopEcommerce.Products;
using ShopEcommerce.Promotions;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ShopEcommerce.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ShopEcommerceDbContext :
    AbpDbContext<ShopEcommerceDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

 

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    //Ecommerce
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryTicket> InventoryTickets { get; set; }
    public DbSet<InventoryTicketItem> InventoryTicketItems { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderTransaction> OrderTransactions { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttributeDateTime> ProductAttributeDateTimes { get; set; }
    public DbSet<ProductAttributeDecimal> ProductAttributeDecimals { get; set; }
    public DbSet<ProductAttributeInt> ProductAttributeInts { get; set; }
    public DbSet<ProductAttributeVarchar> ProductAttributeVarchars { get; set; }
    public DbSet<ProductAttributeText> ProductAttributeTexts { get; set; }
    public DbSet<ProductLink> ProductLinks { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionCategory> PromotionCategories { get; set; }
    public DbSet<PromotionManufacturer> PromotionManufacturers { get; set; }
    public DbSet<PromotionProduct> PromotionProducts { get; set; }
    public DbSet<PromotionUsageHistory> PromotionUsageHistories { get; set; }

    #endregion

    public ShopEcommerceDbContext(DbContextOptions<ShopEcommerceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.ApplyConfiguration(new ProductAttributeConfiguration());

        builder.ApplyConfiguration(new InventoryConfiguration());

        builder.ApplyConfiguration(new InventoryTicketConfiguration());
        builder.ApplyConfiguration(new InventoryTicketItemConfiguration());

        builder.ApplyConfiguration(new ManufacturerConfiguration());

        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new OrderTransactionConfiguration());

        builder.ApplyConfiguration(new ProductCategoryConfiguration());

        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new ProductLinkConfiguration());
        builder.ApplyConfiguration(new ProductReviewConfiguration());
        builder.ApplyConfiguration(new ProductTagConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDateTimeConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDecimalConfiguration());
        builder.ApplyConfiguration(new ProductAttributeIntConfiguration());
        builder.ApplyConfiguration(new ProductAttributeTextConfiguration());
        builder.ApplyConfiguration(new ProductAttributeVarcharConfiguration());

        builder.ApplyConfiguration(new PromotionConfiguration());
        builder.ApplyConfiguration(new PromotionCategoryConfiguration());
        builder.ApplyConfiguration(new PromotionManufacturerConfiguration());
        builder.ApplyConfiguration(new PromotionProductConfiguration());
        builder.ApplyConfiguration(new PromotionUsageHistoryConfiguration());
    }
}
