namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new()
                {
                    Id = 1,
                    Title = "Shuggie Bain",
                    Description = "Året är 1981 och industristaden Glasgow är nere för räkning. Under Thatchers järnhårda styre måste man kämpa för att överleva. Glamorösa Agnes Bain har alltid haft större drömmar än så, men när hennes man lämnar familjen faller allt samman och det kommer an på barnen att fånga henne. Shuggie Bain, minstingen, är den som håller ut längst. Men Shuggie drömmer sig också bort, från gruvområdet och från den hånfulla omgivning som aldrig låter honom glömma att han är annorlunda.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789100196431_383/shuggie-bain",
                    Price = 99
                },
                new()
                {
                    Id = 2,
                    Title = "I dina händer",
                    Description = "Redan någon timme efter larmsamtalet hämtas 14-åriga Dogge till förhör. Jämnåriga Billy är skjuten på lekplatsen där de brukade hänga som små, och Dogge höll i vapnet.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789146237655_383/i-dina-hander",
                    Price = 199
                },
                new()
                {
                    Id = 3,
                    Title = "Till minne av en mördare",
                    Description = "I skuggan av Mattias Flinks massmord i Falun sker ytterligare ett mord. En kvinna hittas strypt till döds och snart står det klart att hon bara är ett av flera offer som mördats med samma tillvägagångssätt. Det faller på den nyss hemkomne FN-soldaten och polisen Tomas Wolf att hitta mördaren. Till sin hjälp har han Vera Berg - en korrupt kvällstidningsreporter som är på flykt från sin före detta kille och hans MC-gäng.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789137501833_383/till-minne-av-en-mordare",
                    Price = 259
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
