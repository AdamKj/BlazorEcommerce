namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new {p.ProductId, p.ProductTypeId});

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Default" },
                new ProductType { Id = 2, Name = "Paperback" },
                new ProductType { Id = 3, Name = "E-Book" },
                new ProductType { Id = 4, Name = "Audiobook" },
                new ProductType { Id = 5, Name = "Stream" },
                new ProductType { Id = 6, Name = "Blu-ray" },
                new ProductType { Id = 7, Name = "VHS" },
                new ProductType { Id = 8, Name = "PC" },
                new ProductType { Id = 9, Name = "PlayStation" },
                new ProductType { Id = 10, Name = "Xbox" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Shuggie Bain",
                    Description = "Året är 1981 och industristaden Glasgow är nere för räkning. Under Thatchers järnhårda styre måste man kämpa för att överleva. Glamorösa Agnes Bain har alltid haft större drömmar än så, men när hennes man lämnar familjen faller allt samman och det kommer an på barnen att fånga henne. Shuggie Bain, minstingen, är den som håller ut längst. Men Shuggie drömmer sig också bort, från gruvområdet och från den hånfulla omgivning som aldrig låter honom glömma att han är annorlunda.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789100196431_383/shuggie-bain",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "I dina händer",
                    Description = "Redan någon timme efter larmsamtalet hämtas 14-åriga Dogge till förhör. Jämnåriga Billy är skjuten på lekplatsen där de brukade hänga som små, och Dogge höll i vapnet.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789146237655_383/i-dina-hander",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Till minne av en mördare",
                    Description = "I skuggan av Mattias Flinks massmord i Falun sker ytterligare ett mord. En kvinna hittas strypt till döds och snart står det klart att hon bara är ett av flera offer som mördats med samma tillvägagångssätt. Det faller på den nyss hemkomne FN-soldaten och polisen Tomas Wolf att hitta mördaren. Till sin hjälp har han Vera Berg - en korrupt kvällstidningsreporter som är på flykt från sin före detta kille och hans MC-gäng.",
                    ImageUrl = "https://bilder.akademibokhandeln.se/images_akb/9789137501833_383/till-minne-av-en-mordare",
                    CategoryId = 1,
                    Featured = true
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Title = "The Matrix",
                    Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                    Featured = true
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Title = "Back to the Future",
                    Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                    Featured = true
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 2,
                    Title = "Toy Story",
                    Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",

                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Title = "Half-Life 2",
                    Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",

                },
                new Product
                {
                    Id = 8,
                    CategoryId = 3,
                    Title = "Diablo II",
                    Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                    Featured = true
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 3,
                    Title = "Day of the Tentacle",
                    Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg"
                },
                new Product
                {
                    Id = 10,
                    CategoryId = 3,
                    Title = "Xbox",
                    Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                },
                new Product
                {
                    Id = 11,
                    CategoryId = 3,
                    Title = "Super Nintendo Entertainment System",
                    Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                }
            );
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 99,
                    OriginalPrice = 199
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 79
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 199,
                    OriginalPrice = 299
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 79,
                    OriginalPrice = 149
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 69
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 39
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 99
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 199
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 39,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 29
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 199,
                    OriginalPrice = 299
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 699
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 499,
                    OriginalPrice = 599
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 99,
                    OriginalPrice = 249,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 149
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 1,
                    Price = 1599,
                    OriginalPrice = 2999
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    Price = 799,
                    OriginalPrice = 3999
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
