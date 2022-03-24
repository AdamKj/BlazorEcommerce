using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class ProductSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Året är 1981 och industristaden Glasgow är nere för räkning. Under Thatchers järnhårda styre måste man kämpa för att överleva. Glamorösa Agnes Bain har alltid haft större drömmar än så, men när hennes man lämnar familjen faller allt samman och det kommer an på barnen att fånga henne. Shuggie Bain, minstingen, är den som håller ut längst. Men Shuggie drömmer sig också bort, från gruvområdet och från den hånfulla omgivning som aldrig låter honom glömma att han är annorlunda.", "https://bilder.akademibokhandeln.se/images_akb/9789100196431_383/shuggie-bain", 99.0, "Shuggie Bain" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Redan någon timme efter larmsamtalet hämtas 14-åriga Dogge till förhör. Jämnåriga Billy är skjuten på lekplatsen där de brukade hänga som små, och Dogge höll i vapnet.", "https://bilder.akademibokhandeln.se/images_akb/9789146237655_383/i-dina-hander", 199.0, "I dina händer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "I skuggan av Mattias Flinks massmord i Falun sker ytterligare ett mord. En kvinna hittas strypt till döds och snart står det klart att hon bara är ett av flera offer som mördats med samma tillvägagångssätt. Det faller på den nyss hemkomne FN-soldaten och polisen Tomas Wolf att hitta mördaren. Till sin hjälp har han Vera Berg - en korrupt kvällstidningsreporter som är på flykt från sin före detta kille och hans MC-gäng.", "https://bilder.akademibokhandeln.se/images_akb/9789137501833_383/till-minne-av-en-mordare", 259.0, "Till minne av en mördare" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
