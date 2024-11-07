using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Netflis.Series;
using Netflis.ListaSeguimientos;
using Netflis.Temporadas;
using Netflis.Capitulos;
using Netflis.Notificaciones;

namespace Netflis.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NetflisDbContext :
    AbpDbContext<NetflisDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Serie> Series { get; set; }
    public DbSet<Temporada> Temporadas { get; set; }
    public DbSet<Capitulo> Capitulos { get; set; }
    public DbSet<ListaSeguimiento> ListaSeguimientos { get; set; }
    public DbSet<SerieUpdated> SerieUpdated { get; set; }
    public DbSet<TemporadaAdded> TemporadaAdded { get; set; }
    public DbSet<CapituloAdded> CapituloAdded { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public NetflisDbContext(DbContextOptions<NetflisDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */
        builder.Entity<Serie>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "Series", NetflisConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(s => s.ImdbId).IsRequired().HasMaxLength(10);
            b.Property(s => s.title).IsRequired().HasMaxLength(128);
            b.Property(s => s.fechaLanzamiento).IsRequired().HasMaxLength(10);
            b.Property(s => s.directores).IsRequired().HasMaxLength(128);
            b.Property(s => s.escritores).IsRequired().HasMaxLength(128);
            b.Property(s => s.elenco).IsRequired().HasMaxLength(128);
            b.Property(s => s.portada).IsRequired().HasMaxLength(128);
            b.Property(s => s.paisOrigen).IsRequired().HasMaxLength(50);
            b.Property(s => s.calificacionImdb).IsRequired().HasMaxLength(128);
            b.Property(s => s.duracion).IsRequired().HasMaxLength(10);
            b.Property(s => s.generos).IsRequired().HasMaxLength(128);
            b.Property(s => s.trama).IsRequired().HasMaxLength(128);
            b.Property(s => s.idioma).IsRequired().HasMaxLength(128);
            b.Property(s => s.totalTemporadas).IsRequired();

            b.HasMany(s => s.Temporadas)
                .WithOne(t => t.Serie)
                .HasForeignKey(t => t.serieId);
        });

        builder.Entity<Temporada>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "Temporadas", NetflisConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(t => t.numero).IsRequired();
            b.Property(t => t.titulo).IsRequired().HasMaxLength(128);
            b.Property(t => t.fechaLanzamiento).IsRequired().HasMaxLength(10);
            b.Property(t => t.descripcion).IsRequired().HasMaxLength(128);
            b.Property(t => t.serieId).IsRequired();

            b.HasOne(t => t.Serie)
                .WithMany(s => s.Temporadas)
                .HasForeignKey(t => t.serieId)
                .IsRequired();

            b.HasMany(t => t.Capitulos)
                .WithOne(c => c.Temp)
                .HasForeignKey(c => c.temporadaID);
        });

        builder.Entity<Capitulo>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "Capitulos", NetflisConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(c => c.numeroEpisodio).IsRequired();
            b.Property(c => c.titulo).IsRequired().HasMaxLength(128);
            b.Property(c => c.fechaEstreno).IsRequired().HasMaxLength(10);
            b.Property(c => c.directores).IsRequired().HasMaxLength(128);
            b.Property(c => c.escritores).IsRequired().HasMaxLength(128);
            b.Property(c => c.duracion).IsRequired().HasMaxLength(10);
            b.Property(c => c.resumen).IsRequired().HasMaxLength(128);
            b.Property(c => c.temporadaID).IsRequired();

            b.HasOne(c => c.Temp)
                .WithMany(t => t.Capitulos)
                .HasForeignKey(c => c.temporadaID)
                .IsRequired();
        });

        builder.Entity<ListaSeguimiento>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "ListaSeguimiento",
                NetflisConsts.DbSchema);
            b.ConfigureByConvention(); //Establece una configuracion por defecto
        });

        builder.Entity<SerieUpdated>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "SerieUpdated",
                NetflisConsts.DbSchema);
            b.ConfigureByConvention(); //Establece una configuracion por defecto
            b.Property(s => s.serieId).IsRequired().HasMaxLength(10);
            b.Property(s => s.updateTitle).IsRequired().HasMaxLength(128);
            b.Property(s => s.updateType).IsRequired().HasMaxLength(128);
        });

        builder.Entity<TemporadaAdded>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "TemporadaAdded",
                NetflisConsts.DbSchema);
            b.ConfigureByConvention(); //Establece una configuracion por defecto
            b.Property(t => t.serieId).IsRequired().HasMaxLength(10);
            b.Property(t => t.numeroTemporada).IsRequired();
        });

        builder.Entity<CapituloAdded>(b =>
        {
            b.ToTable(NetflisConsts.DbTablePrefix + "CapituloAdded",
                NetflisConsts.DbSchema);
            b.ConfigureByConvention(); //Establece una configuracion por defecto
            b.Property(c => c.temporadaId).IsRequired().HasMaxLength(10);
            b.Property(c => c.capituloNumero).IsRequired();
            b.Property(c => c.titulo).IsRequired().HasMaxLength(128);
        });


        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(NetflisConsts.DbTablePrefix + "YourEntities", NetflisConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
