using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Linked_Gates.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_devices_DeviceCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "DeviceCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_categoryProperties_DeviceCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "DeviceCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryProperties_properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "devicePropertyValues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devicePropertyValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_devicePropertyValues_devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devicePropertyValues_properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeviceCategories",
                columns: new[] { "ID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Printer" },
                    { 2, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "properties",
                columns: new[] { "ID", "PropertyDescription" },
                values: new object[,]
                {
                    { 1, "HD" },
                    { 2, "Processor" },
                    { 3, "RAM" },
                    { 4, "Display" },
                    { 5, "IP Address" },
                    { 6, "Brand" },
                    { 7, "Current User" },
                    { 8, "Is Color" }
                });

            migrationBuilder.InsertData(
                table: "categoryProperties",
                columns: new[] { "ID", "CategoryID", "PropertyID" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 1, 8 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 2, 4 },
                    { 6, 2, 5 },
                    { 7, 2, 6 },
                    { 8, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "ID", "AcquisitionDate", "CategoryID", "DeviceName", "Memo" },
                values: new object[,]
                {
                    { 1, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HP Laptop 1190", "Office use" },
                    { 2, new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Canon Printer X", "Print room" },
                    { 3, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dell Desktop 3000", "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "devicePropertyValues",
                columns: new[] { "ID", "DeviceID", "PropertyID", "PropertyValue" },
                values: new object[,]
                {
                    { 1, 1, 2, "Core i7" },
                    { 2, 1, 3, "16 GB" },
                    { 3, 1, 4, "15.6 inches" },
                    { 4, 1, 5, "192.168.1.5" },
                    { 5, 1, 6, "HP" },
                    { 6, 1, 7, "Mohamed Mohsen" },
                    { 7, 2, 5, "192.168.1.10" },
                    { 8, 2, 6, "Canon" },
                    { 9, 3, 2, "AMD Ryzen 5" },
                    { 10, 3, 3, "8 GB" },
                    { 11, 3, 6, "Dell" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryProperties_CategoryID",
                table: "categoryProperties",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_categoryProperties_PropertyID",
                table: "categoryProperties",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_devicePropertyValues_DeviceID",
                table: "devicePropertyValues",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_devicePropertyValues_PropertyID",
                table: "devicePropertyValues",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_devices_CategoryID",
                table: "devices",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryProperties");

            migrationBuilder.DropTable(
                name: "devicePropertyValues");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "DeviceCategories");
        }
    }
}
