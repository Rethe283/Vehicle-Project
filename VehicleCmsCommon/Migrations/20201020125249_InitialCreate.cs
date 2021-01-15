using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCmsCommon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(maxLength: 60, nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Vin = table.Column<string>(maxLength: 17, nullable: false),
                    LicensePlate = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(nullable: false),
                    MaxSpeed = table.Column<string>(nullable: true),
                    Doors = table.Column<string>(nullable: true),
                    Wheels = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehicleDetail_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetail_VehicleID",
                table: "VehicleDetail",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDetail");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
