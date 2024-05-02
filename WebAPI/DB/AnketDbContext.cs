using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DB
{
    public class AnketDbContext: DbContext
    {
        public DbSet<Questions> Sorular {  get; set; }
        public DbSet<Options> Secenekler { get; set; }
        public DbSet<Answer> Cevaplar { get; set; }
        public DbSet<Answer_View> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answer_View>()
                .ToView("Cevap_tumlec")
                .HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YOSHI\\YOSHI;Database=anket;Trusted_Connection=True;Encrypt=Optional;");
            base.OnConfiguring(optionsBuilder);
        }
        public AnketDbContext(DbContextOptions options):base(options) { }
        
    }
}
