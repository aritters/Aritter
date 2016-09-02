﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aritter.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    InvalidLoginAttemptsCount = table.Column<int>(nullable: false),
                    MustChangePassword = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(maxLength: 999, nullable: false),
                    ProfileId = table.Column<int>(nullable: true),
                    UID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    RuleId = table.Column<int>(nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMembers_UserAccounts_MemberId",
                        column: x => x.MemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMembers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allowed = table.Column<bool>(nullable: false),
                    Denied = table.Column<bool>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorizations_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authorizations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_PermissionId",
                table: "Authorizations",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_RoleId",
                table: "Authorizations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_Id_RoleId",
                table: "Authorizations",
                columns: new[] { "Id", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ResourceId",
                table: "Permissions",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RuleId",
                table: "Permissions",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ResourceId_RuleId",
                table: "Permissions",
                columns: new[] { "ResourceId", "RuleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ClientId",
                table: "Resources",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ClientId",
                table: "Roles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_MemberId",
                table: "RoleMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_RoleId",
                table: "RoleMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_RoleId_MemberId",
                table: "RoleMembers",
                columns: new[] { "RoleId", "MemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ClientId",
                table: "Rules",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_Name",
                table: "Rules",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_ProfileId",
                table: "UserAccounts",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Username",
                table: "UserAccounts",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorizations");

            migrationBuilder.DropTable(
                name: "RoleMembers");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}