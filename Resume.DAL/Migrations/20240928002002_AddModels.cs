using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resume.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediumImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInTrash = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowAboutSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowStatsSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowSkillsSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowResumeSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowPortfolioSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowServicesSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowTestimonialsSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowContactSection = table.Column<bool>(type: "bit", nullable: false),
                    ShowFooter1Section = table.Column<bool>(type: "bit", nullable: false),
                    ShowFooter2Section = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyTitles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentJobTitleDescriptionTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentJobTitleDescriptionBottom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                    table.ForeignKey(
                        name: "FK_About_ImageFiles_ImageFileId",
                        column: x => x.ImageFileId,
                        principalTable: "ImageFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Answer", "CreateDate", "Email", "FullName", "Message", "Title", "UpdateDate" },
                values: new object[] { 1, null, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8144), "reza.armani75@gmail.com", "Reza Nazeri", "hi\nhow are you doin?", "Test 1", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8144) });

            migrationBuilder.InsertData(
                table: "ImageFiles",
                columns: new[] { "Id", "Alt", "CreateDate", "IsInTrash", "LargeImage", "MaxImage", "MediumImage", "ThumbnailImage", "UpdateDate" },
                values: new object[] { 1, "profile image", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8069), false, "/Site/assets/img/profile-img.jpg", "/Site/assets/img/profile-img.jpg", "/Site/assets/img/profile-img.jpg", "/Site/assets/img/profile-img.jpg", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8069) });

            migrationBuilder.InsertData(
                table: "SiteConfigs",
                columns: new[] { "Id", "CreateDate", "ShowAboutSection", "ShowContactSection", "ShowFooter1Section", "ShowFooter2Section", "ShowPortfolioSection", "ShowResumeSection", "ShowServicesSection", "ShowSkillsSection", "ShowStatsSection", "ShowTestimonialsSection", "SiteIcon", "SiteTitle", "Tagline", "UpdateDate" },
                values: new object[] { 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8051), true, true, true, true, true, true, true, false, true, false, "/Site/assets/img/favicon.png", "John Doe Resume", "My Portfolio", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "FirstName", "IsActive", "LastName", "Mobile", "Password", "UpdateDate" },
                values: new object[] { 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(7865), "admin@gmail.com", "Admin", true, "Admin", "+989123456789", "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(7874) });

            migrationBuilder.InsertData(
                table: "About",
                columns: new[] { "Id", "BirthDate", "CreateDate", "CurrentJobTitle", "CurrentJobTitleDescriptionBottom", "CurrentJobTitleDescriptionTop", "Email", "FirstName", "ImageFileId", "LastName", "Location", "Mobile", "MyTitles", "Summary", "UpdateDate" },
                values: new object[] { 1, new DateOnly(1996, 4, 10), new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8100), "Software Engineer at <a href=\"https://dotin.ir\" target=\"_blank\" style=\"color:green;\">Dotin</a>", "Therefore, choosing the services of labor and pains is the choice of the services. Anyone can get everything and that. There are no complaints from the prosecutors about their services at the time. And all his Because of desire, as said, most offices indeed. But those who are not to be repulsed will therefore be pursued.", "It is important to take care of the patient, to be followed by the doctor, but it is a time of great pain and suffering.", "reza.armani75@gmail.com", "Reza", 1, "Nazeri", "Mashhad, Iran", "+989123456789", "Developer, Teacher", "It takes great pains to benefit. His needs result from something that actually drives him away. Let them be what they want. Anyone whom anyone desires. And no one who hinders receives the others. Because he should flee in this office of convenience, which is here.", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "AboutId", "CreateDate", "IconName", "IsActive", "LinkAddress", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8116), "bi-linkedin", true, "https://linkedin.com/in/rezanazeri", "Linkedin", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8116) },
                    { 2, 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8117), "bi-youtube", true, "https://youtube.com/@naazeri", "Youtube", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8118) },
                    { 3, 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8119), "bi-github", true, "https://github.com/naazeri", "Github", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8120) },
                    { 4, 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8121), "bi-twitter-x", true, "https://x.com/r_nazeri", "X", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8121) },
                    { 5, 1, new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8124), "bi-instagram", true, "https://instagram.com/re_nazeri", "Instagram", new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8125) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_About_ImageFileId",
                table: "About",
                column: "ImageFileId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_AboutId",
                table: "SocialLinks",
                column: "AboutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "SiteConfigs");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "ImageFiles");
        }
    }
}
