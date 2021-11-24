using Microsoft.EntityFrameworkCore.Migrations;

namespace DiAndSignalRApp.Migrations
{
    public partial class AddNewModelCustomer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerWithReferrals_Customer_ReferralId1",
                table: "CustomerWithReferrals");

            migrationBuilder.DropIndex(
                name: "IX_CustomerWithReferrals_ReferralId1",
                table: "CustomerWithReferrals");

            migrationBuilder.DropColumn(
                name: "ReferralId1",
                table: "CustomerWithReferrals");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerWithReferrals_Customer_CustomerId",
                table: "CustomerWithReferrals",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerWithReferrals_Customer_CustomerId",
                table: "CustomerWithReferrals");

            migrationBuilder.AddColumn<int>(
                name: "ReferralId1",
                table: "CustomerWithReferrals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWithReferrals_ReferralId1",
                table: "CustomerWithReferrals",
                column: "ReferralId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerWithReferrals_Customer_ReferralId1",
                table: "CustomerWithReferrals",
                column: "ReferralId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
