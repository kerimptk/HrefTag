using Blog.Domain.Configuration;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Infrastructure.Context
{
    public class BlogContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BlogContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration["ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new EtiketConfiguration());
            modelBuilder.ApplyConfiguration(new EtiketYaziConfiguration());
            modelBuilder.ApplyConfiguration(new KategoriConfiguration());
            modelBuilder.ApplyConfiguration(new KategoriYaziConfiguration());
            modelBuilder.ApplyConfiguration(new YaziConfiguration());
            modelBuilder.ApplyConfiguration(new YorumConfiguration());
            modelBuilder.ApplyConfiguration(new SayfaConfiguration());
            modelBuilder.ApplyConfiguration(new SosyalMedyaConfiguration());
            modelBuilder.ApplyConfiguration(new ReklamAlanlariConfiguration());
            modelBuilder.ApplyConfiguration(new PostaKutusuConfiguration());
            modelBuilder.ApplyConfiguration(new IletisimBilgileriConfiguration());
            modelBuilder.ApplyConfiguration(new GenelAyarlarConfiguration());
            modelBuilder.ApplyConfiguration(new SeoAyarlariConfiguration());
            modelBuilder.ApplyConfiguration(new CekilisSonuclariConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListConfiguration());

        }

        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<EtiketYazi> EtiketYazilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KategoriYazi> KategoriYazilar { get; set; }
        public DbSet<Yazi> Yazilar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Sayfa> Sayfalar { get; set; }
        public DbSet<SosyalMedya> SosyalMedya { get; set; }
        public DbSet<ReklamAlanlari> ReklamAlanlari { get; set; }
        public DbSet<PostaKutusu> PostaKutusu { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileri { get; set; }
        public DbSet<GenelAyarlar> GenelAyarlar { get; set; }
        public DbSet<SeoAyarlari> SeoAyarlari { get; set; }
        public DbSet<CekilisSonuclari> CekilisSonuclari { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        
    }
}
