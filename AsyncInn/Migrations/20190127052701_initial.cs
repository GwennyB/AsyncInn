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
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
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
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotel_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
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
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(nullable: false),
                    HotelID = table.Column<int>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "RoomPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Layout = table.Column<int>(nullable: false),
                    InventoryHotelID = table.Column<int>(nullable: true),
                    InventoryRoomNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomPlan_Inventory_InventoryHotelID_InventoryRoomNumber",
                        columns: x => new { x.InventoryHotelID, x.InventoryRoomNumber },
                        principalTable: "Inventory",
                        principalColumns: new[] { "HotelID", "RoomNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_LocationID",
                table: "Hotel",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_RoomPlanID",
                table: "Inventory",
                column: "RoomPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomConfig_AmenityID",
                table: "RoomConfig",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPlan_InventoryHotelID_InventoryRoomNumber",
                table: "RoomPlan",
                columns: new[] { "InventoryHotelID", "InventoryRoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomConfig_RoomPlan_RoomPlanID",
                table: "RoomConfig",
                column: "RoomPlanID",
                principalTable: "RoomPlan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_RoomPlan_RoomPlanID",
                table: "Inventory",
                column: "RoomPlanID",
                principalTable: "RoomPlan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Location_LocationID",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Hotel_HotelID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_RoomPlan_RoomPlanID",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "RoomConfig");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "RoomPlan");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
