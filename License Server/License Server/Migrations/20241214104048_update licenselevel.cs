using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License_Server.Migrations
{
    /// <inheritdoc />
    public partial class updatelicenselevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Map existing string values to integer values
            migrationBuilder.Sql(
                @"
                UPDATE Licenses
                SET LicenseLevel = 
                    CASE 
                        WHEN LicenseLevel = 'basic' THEN 0
                        WHEN LicenseLevel = 'standard' THEN 1
                        WHEN LicenseLevel = 'premium' THEN 2
                        ELSE NULL
                    END;
                ");

            // Alter column to integer
            migrationBuilder.AlterColumn<int>(
                name: "LicenseLevel",
                table: "Licenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert column back to string
            migrationBuilder.AlterColumn<string>(
                name: "LicenseLevel",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Map integer values back to string values
            migrationBuilder.Sql(
                @"
                UPDATE Licenses
                SET LicenseLevel = 
                    CASE 
                        WHEN LicenseLevel = 0 THEN 'basic'
                        WHEN LicenseLevel = 1 THEN 'standard'
                        WHEN LicenseLevel = 2 THEN 'premium'
                        ELSE NULL
                    END;
                ");
        }

    }
}
