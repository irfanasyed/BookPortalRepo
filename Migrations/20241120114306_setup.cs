using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boo_Store_Portal_Api.Migrations
{
    /// <inheritdoc />
    public partial class setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLvl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLvl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PubId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StorId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    JobLvl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PubId = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_Employees_Publishers_PubId",
                        column: x => x.PubId,
                        principalTable: "Publishers",
                        principalColumn: "PubId");
                });

            migrationBuilder.CreateTable(
                name: "PubInfos",
                columns: table => new
                {
                    PubId = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubInfos", x => x.PubId);
                    table.ForeignKey(
                        name: "FK_PubInfos_Publishers_PubId",
                        column: x => x.PubId,
                        principalTable: "Publishers",
                        principalColumn: "PubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PubId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Advance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Royalty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YtdSales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pubdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_Titles_Publishers_PubId",
                        column: x => x.PubId,
                        principalTable: "Publishers",
                        principalColumn: "PubId");
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dicounttype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorId = table.Column<int>(type: "int", nullable: true),
                    Lowqty = table.Column<int>(type: "int", nullable: true),
                    Highqty = table.Column<int>(type: "int", nullable: true),
                    Discount1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DisId);
                    table.ForeignKey(
                        name: "FK_Discounts_Stores_StorId",
                        column: x => x.StorId,
                        principalTable: "Stores",
                        principalColumn: "StorId");
                });

            migrationBuilder.CreateTable(
                name: "Royscheds",
                columns: table => new
                {
                    RoyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    Lorange = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hirange = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Royalty = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Royscheds", x => x.RoyId);
                    table.ForeignKey(
                        name: "FK_Royscheds_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "TitleId");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    OrdNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorId = table.Column<int>(type: "int", nullable: true),
                    OrdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Payterms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.OrdNum);
                    table.ForeignKey(
                        name: "FK_Sales_Stores_StorId",
                        column: x => x.StorId,
                        principalTable: "Stores",
                        principalColumn: "StorId");
                    table.ForeignKey(
                        name: "FK_Sales_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "TitleId");
                });

            migrationBuilder.CreateTable(
                name: "Titleauthors",
                columns: table => new
                {
                    TitleAuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuId = table.Column<int>(type: "int", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    AuOrd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Royaltyper = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titleauthors", x => x.TitleAuId);
                    table.ForeignKey(
                        name: "FK_Titleauthors_Authors_AuId",
                        column: x => x.AuId,
                        principalTable: "Authors",
                        principalColumn: "AuId");
                    table.ForeignKey(
                        name: "FK_Titleauthors_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "TitleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_StorId",
                table: "Discounts",
                column: "StorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PubId",
                table: "Employees",
                column: "PubId");

            migrationBuilder.CreateIndex(
                name: "IX_Royscheds_TitleId",
                table: "Royscheds",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StorId",
                table: "Sales",
                column: "StorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_TitleId",
                table: "Sales",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Titleauthors_AuId",
                table: "Titleauthors",
                column: "AuId");

            migrationBuilder.CreateIndex(
                name: "IX_Titleauthors_TitleId",
                table: "Titleauthors",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_PubId",
                table: "Titles",
                column: "PubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PubInfos");

            migrationBuilder.DropTable(
                name: "Royscheds");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Titleauthors");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
