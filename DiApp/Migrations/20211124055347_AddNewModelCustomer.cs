using Microsoft.EntityFrameworkCore.Migrations;

namespace DiAndSignalRApp.Migrations
{
    public partial class AddNewModelCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerWithReferrals",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReferralId = table.Column<int>(type: "int", nullable: false),
                    ReferralId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWithReferrals", x => new { x.CustomerId, x.ReferralId });
                    table.ForeignKey(
                        name: "FK_CustomerWithReferrals_Customer_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerWithReferrals_Customer_ReferralId1",
                        column: x => x.ReferralId1,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWithReferrals_ReferralId",
                table: "CustomerWithReferrals",
                column: "ReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWithReferrals_ReferralId1",
                table: "CustomerWithReferrals",
                column: "ReferralId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerWithReferrals");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
