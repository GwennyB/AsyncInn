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
                    Phone = table.Column<int>(nullable: false),
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
                    Layout = table.Column<int>(nullable: false)
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
                    ID = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetsOK = table.Column<bool>(nullable: false),
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
