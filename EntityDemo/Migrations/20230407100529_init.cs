using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityDemo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                    table.CheckConstraint("CK_Plate", "[Plate] NOT LIKE '%@%'");
                });

            migrationBuilder.InsertData(
                table: "Voitures",
                columns: new[] { "Id", "Brand", "Color", "Hp", "Model", "Plate" },
                values: new object[,]
                {
                    { 1, "Tesla", "White", 570, "Model X", "IMTESLA" },
                    { 2, "BMW", "Purple", 120, "Serie 1", "Gossip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
