using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testNETCORE.Migrations
{
    /// <inheritdoc />
    public partial class updatedbTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__6DB3A68A0405C12A", x => x.ID_Category);
                });

            migrationBuilder.CreateTable(
                name: "Country_Cities",
                columns: table => new
                {
                    ID = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country___3214EC27F08A2066", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Navigation_Bar",
                columns: table => new
                {
                    ID_Menu = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Tinh",
                columns: table => new
                {
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TravelGuide",
                columns: table => new
                {
                    ID_TravelGuide = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cover_Image = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TravelGu__BC5EA68C0A7AB681", x => x.ID_TravelGuide);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B97FFDFB38522D60", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    ID_Tour = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_Category = table.Column<int>(type: "int", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Destination1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Destination2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Destination3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Image2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Image3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PriceForAdult = table.Column<double>(type: "float", nullable: false),
                    PriceForChildren = table.Column<double>(type: "float", nullable: false),
                    NdaysNnights = table.Column<string>(type: "ntext", nullable: false),
                    JourneyHightlight = table.Column<string>(type: "ntext", nullable: false),
                    TravelingSchedule = table.Column<string>(type: "ntext", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    Link = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tour__D4CD957E39F747E9", x => x.ID_Tour);
                    table.ForeignKey(
                        name: "FK__Tour__ID_Categor__52593CB8",
                        column: x => x.ID_Category,
                        principalTable: "Categories",
                        principalColumn: "ID_Category");
                });

            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    ID_Search = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SearchHi__1BB97D065DD79A20", x => x.ID_Search);
                    table.ForeignKey(
                        name: "FK__SearchHis__ID_Us__5070F446",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "Statistical",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    DomesticTours = table.Column<int>(type: "int", nullable: false),
                    OverseasTour = table.Column<int>(type: "int", nullable: false),
                    CustomersNumber = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statisti__86A56E75B50EB986", x => x.CreatedDate);
                    table.ForeignKey(
                        name: "FK__Statistic__ID_Us__5165187F",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    ID_Cart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    ID_Tour = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Like__72140ECF98CDAB72", x => x.ID_Cart);
                    table.ForeignKey(
                        name: "FK__Like__ID_Tour__4E88ABD4",
                        column: x => x.ID_Tour,
                        principalTable: "Tour",
                        principalColumn: "ID_Tour");
                    table.ForeignKey(
                        name: "FK__Like__ID_UserI__4F7CD00D",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    ID_Invoice = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ID_Tour = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    StaticsticDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuantityAdult = table.Column<int>(type: "int", nullable: true),
                    QuantityChildren = table.Column<int>(type: "int", nullable: true),
                    StarDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceD__0540CA604785406E", x => x.ID_Invoice);
                    table.ForeignKey(
                        name: "FK__InvoiceDe__Creat__4BAC3F29",
                        column: x => x.StaticsticDate,
                        principalTable: "Statistical",
                        principalColumn: "CreatedDate");
                    table.ForeignKey(
                        name: "FK__InvoiceDe__ID_To__4CA06362",
                        column: x => x.ID_Tour,
                        principalTable: "Tour",
                        principalColumn: "ID_Tour");
                    table.ForeignKey(
                        name: "FK__InvoiceDe__ID_Us__4D94879B",
                        column: x => x.ID_User,
                        principalTable: "User",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ID_Tour",
                table: "InvoiceDetails",
                column: "ID_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ID_User",
                table: "InvoiceDetails",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_StaticsticDate",
                table: "InvoiceDetails",
                column: "StaticsticDate");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ID_Tour",
                table: "Like",
                column: "ID_Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ID_User",
                table: "Like",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_ID_User",
                table: "SearchHistory",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Statistical_ID_User",
                table: "Statistical",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_ID_Category",
                table: "Tour",
                column: "ID_Category");

            migrationBuilder.CreateIndex(
                name: "UQ__User__85FB4E38470993A8",
                table: "User",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__A9D105348EDC7728",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country_Cities");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Navigation_Bar");

            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.DropTable(
                name: "Tinh");

            migrationBuilder.DropTable(
                name: "TravelGuide");

            migrationBuilder.DropTable(
                name: "Statistical");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
