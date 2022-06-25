using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Final2.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            //=========================ENTITIES=========================
            migrationBuilder.CreateTable(
               name: "Donor",
               columns: table => new
               {
                   dSsn = table.Column<int>(type: "int", nullable: false),
                   dGender = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   dName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   dLastName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Donor", x => x.dSsn);
               });

            migrationBuilder.CreateTable(
               name: "Seeker",
               columns: table => new
               {
                   sSsn = table.Column<int>(type: "int", nullable: false),
                   sGender = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   sName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   sLastName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Seeker", x => x.sSsn);
               });

            migrationBuilder.CreateTable(
               name: "Hospital",
               columns: table => new
               {
                   hId = table.Column<int>(type: "int", nullable: false),
                   hName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   hAddress = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Hospital", x => x.hId);
               });

            migrationBuilder.CreateTable(
               name: "BloodBank",
               columns: table => new
               {
                   bbId = table.Column<int>(type: "int", nullable: false),
                   bbName = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true),
                   bbAddress = table.Column<string>(type: "nvarchar(max)", maxLength: 256, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_BloodBank", x => x.bbId);
               });

            migrationBuilder.CreateTable(
               name: "Blood",
               columns: table => new
               {
                   dSsn = table.Column<int>(type: "int", nullable: false),
                   bType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   rhType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   bTubeid = table.Column<int>(type: "int", nullable: false),
                   bAmount = table.Column<int>(type: "int", nullable: false),
                   hId = table.Column<int>(type: "int", nullable: false),
                   bbId = table.Column<int>(type: "int", maxLength: 256, nullable: true),
                   sSsn = table.Column<int>(type: "int", maxLength: 256, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Blood", x => x.bTubeid);
                   table.ForeignKey(
                        name: "FK_Blood_Donor_dSsn",
                        column: x => x.dSsn,
                        principalTable: "Donor",
                        principalColumn: "dSsn",
                        onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                        name: "FK_Blood_Hospital_hId",
                        column: x => x.hId,
                        principalTable: "Hospital",
                        principalColumn: "hId",
                        onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                        name: "FK_Blood_Seeker_sSsn",
                        column: x => x.sSsn,
                        principalTable: "Seeker",
                        principalColumn: "sSsn",
                        onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                        name: "FK_Blood_BloodBank_bbId",
                        column: x => x.bbId,
                        principalTable: "BloodBank",
                        principalColumn: "bbId",
                        onDelete: ReferentialAction.Cascade);
               });
            //========================================================


            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
            //---------TABLE INDEXES---------

            migrationBuilder.CreateIndex(
                name: "IX_Donor_dSsn",
                table: "Donor",
                column: "dSsn");

            migrationBuilder.CreateIndex(
                name: "IX_Seeker_sSsn",
                table: "Seeker",
                column: "sSsn");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_hId",
                table: "Hospital",
                column: "hId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBank_bbId",
                table: "BloodBank",
                column: "bbId");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_bTubeid",
                table: "Blood",
                column: "bTubeid");

            //-------------------------------


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
            //----TABLE DROPS----
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Seeker");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "BloodBank");

            migrationBuilder.DropTable(
                name: "Blood");

            //-------------------


        }
    }
}
