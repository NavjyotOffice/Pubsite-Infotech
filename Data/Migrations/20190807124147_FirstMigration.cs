using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfotechVision.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "ContentDetails",
                columns: table => new
                {
                    ContentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Author = table.Column<string>(maxLength: 1000, nullable: true),
                    Image = table.Column<string>(maxLength: 1000, nullable: true),
                    URL = table.Column<string>(maxLength: 1000, nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    HideOnSite = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDetails", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_ContentDetails_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentDetails_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailCampaignLandingPageTracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Revenue = table.Column<string>(nullable: true),
                    EmployeeSize = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    Device = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    AssetName = table.Column<string>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    Track = table.Column<string>(nullable: true),
                    OptIn = table.Column<bool>(nullable: true),
                    CustomQuestion1 = table.Column<string>(nullable: true),
                    CustomQuestion2 = table.Column<string>(nullable: true),
                    CustomQuestion3 = table.Column<string>(nullable: true),
                    CustomQuestion4 = table.Column<string>(nullable: true),
                    CustomQuestion5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCampaignLandingPageTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DetailAddress = table.Column<string>(maxLength: 1000, nullable: true),
                    City = table.Column<string>(maxLength: 1000, nullable: true),
                    State = table.Column<string>(maxLength: 1000, nullable: true),
                    Country = table.Column<string>(maxLength: 1000, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true),
                    Contact = table.Column<int>(nullable: true),
                    Contact1ContactID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Contacts_Contact1ContactID",
                        column: x => x.Contact1ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsDate = table.Column<DateTime>(nullable: true),
                    ContentID = table.Column<int>(nullable: true),
                    NewsType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_News_ContentDetails_ContentID",
                        column: x => x.ContentID,
                        principalTable: "ContentDetails",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourcesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResourceFile = table.Column<string>(maxLength: 1000, nullable: true),
                    ContentID = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ResourceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourcesID);
                    table.ForeignKey(
                        name: "FK_Resources_ContentDetails_ContentID",
                        column: x => x.ContentID,
                        principalTable: "ContentDetails",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WebsiteURL = table.Column<string>(maxLength: 1000, nullable: true),
                    LogoImage = table.Column<string>(maxLength: 1000, nullable: true),
                    HideOnSite = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ContentID = table.Column<int>(nullable: true),
                    EventType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_ContentDetails_ContentID",
                        column: x => x.ContentID,
                        principalTable: "ContentDetails",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Contact1ContactID",
                table: "Addresses",
                column: "Contact1ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressID",
                table: "Companies",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedById",
                table: "Companies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_CreatedById",
                table: "ContentDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_UpdatedById",
                table: "ContentDetails",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddressID",
                table: "Events",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ContentID",
                table: "Events",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_News_ContentID",
                table: "News",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ContentID",
                table: "Resources",
                column: "ContentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "EmailCampaignLandingPageTracks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ContentDetails");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
