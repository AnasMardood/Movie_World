using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCity98.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [profilePictur]) VALUES (N'2e07b3ab-3e99-4216-a5b2-706a16783253', N'admin@test.com', N'ADMIN@TEST.COM', N'admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAIAAYagAAAAELoVK8PD0rHuEWYZikq9cWOfJDtdqpghgEZ0EBDjQRXBuciNO2z7qgUlL+nAih+E1A==', N'AMXE4TNFCKFC6ALJSEDLLOFMJFFJKWHI', N'093b6013-f142-4b8a-87e7-d264aeb36dc6', NULL, 0, 0, NULL, 1, 0, N'Admin', N'admin', NULL)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '2e07b3ab-3e99-4216-a5b2-706a16783253'");

        }
    }
}
