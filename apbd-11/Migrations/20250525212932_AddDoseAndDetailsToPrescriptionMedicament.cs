using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_11.Migrations
{
    /// <inheritdoc />
    public partial class AddDoseAndDetailsToPrescriptionMedicament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "PrescriptionMedicament",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dose",
                table: "PrescriptionMedicament",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "PrescriptionMedicament");

            migrationBuilder.DropColumn(
                name: "Dose",
                table: "PrescriptionMedicament");
        }
    }
}
