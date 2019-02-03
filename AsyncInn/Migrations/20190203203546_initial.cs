using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Layout = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPlan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(nullable: false),
                    HotelID = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PetsOK = table.Column<bool>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    RoomPlanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => new { x.HotelID, x.RoomNumber });
                    table.ForeignKey(
                        name: "FK_Inventory_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_RoomPlan_RoomPlanID",
                        column: x => x.RoomPlanID,
                        principalTable: "RoomPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomConfig",
                columns: table => new
                {
                    RoomPlanID = table.Column<int>(nullable: false),
                    AmenityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomConfig", x => new { x.RoomPlanID, x.AmenityID });
                    table.ForeignKey(
                        name: "FK_RoomConfig_Amenity_AmenityID",
                        column: x => x.AmenityID,
                        principalTable: "Amenity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomConfig_RoomPlan_RoomPlanID",
                        column: x => x.RoomPlanID,
                        principalTable: "RoomPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "coffee maker" },
                    { 2, "mini bar" },
                    { 3, "refrigerator" },
                    { 4, "air conditioning" },
                    { 5, "charging station" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "ID", "Address", "City", "Country", "Name", "Phone", "State" },
                values: new object[,]
                {
                    { 1, "100 Main St", "Austin", 0, "Hotel AAA", 1112222L, 44 },
                    { 2, "200 Main St", "Birmingham", 0, "Hotel BBB", 1112223333L, 1 },
                    { 3, "300 Main St", "Cancun", 2, "Hotel CCC", 1112221111L, 0 },
                    { 4, "400 Main St", "Vancouver", 1, "Hotel DDD", 2223332222L, 0 },
                    { 5, "500 Main St", "Toronto", 1, "Hotel EEE", 3334443333L, 0 }
                });

            migrationBuilder.InsertData(
                table: "RoomPlan",
                columns: new[] { "ID", "Layout", "RoomType" },
                values: new object[,]
                {
                    { 1, 0, "Studio A" },
                    { 2, 0, "Studio B" },
                    { 3, 1, "One Bedroom A" },
                    { 4, 1, "One Bedroom B" },
                    { 5, 2, "Two Bedroom A" },
                    { 6, 2, "Two Bedroom B" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_RoomPlanID",
                table: "Inventory",
                column: "RoomPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomConfig_AmenityID",
                table: "RoomConfig",
                column: "AmenityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "RoomConfig");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "RoomPlan");
        }
    }
}
