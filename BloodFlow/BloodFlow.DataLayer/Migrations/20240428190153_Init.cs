using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodFlow.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blood_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "importance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_importance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "donor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_type_id = table.Column<int>(type: "int", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor", x => x.id);
                    table.ForeignKey(
                        name: "FK_donor_blood_type_blood_type_id",
                        column: x => x.blood_type_id,
                        principalTable: "blood_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "street",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_street", x => x.id);
                    table.ForeignKey(
                        name: "FK_street_city_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_center",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    house_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_id = table.Column<int>(type: "int", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_center", x => x.id);
                    table.ForeignKey(
                        name: "FK_donor_center_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_donor_center_street_street_id",
                        column: x => x.street_id,
                        principalTable: "street",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    photo_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    house_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street_id = table.Column<int>(type: "int", nullable: true),
                    contact_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_person_donor_id",
                        column: x => x.id,
                        principalTable: "donor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_street_street_id",
                        column: x => x.street_id,
                        principalTable: "street",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blood_volume = table.Column<int>(type: "int", nullable: false),
                    current_blood_volume = table.Column<int>(type: "int", nullable: false),
                    donor_center_id = table.Column<int>(type: "int", nullable: false),
                    importance_id = table.Column<int>(type: "int", nullable: false),
                    blood_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_blood_type_blood_type_id",
                        column: x => x.blood_type_id,
                        principalTable: "blood_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_donor_center_donor_center_id",
                        column: x => x.donor_center_id,
                        principalTable: "donor_center",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_importance_importance_id",
                        column: x => x.importance_id,
                        principalTable: "importance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donor_center_id = table.Column<int>(type: "int", nullable: false),
                    blood_volume = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    donor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_session", x => x.id);
                    table.ForeignKey(
                        name: "FK_session_donor_center_donor_center_id",
                        column: x => x.donor_center_id,
                        principalTable: "donor_center",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_session_donor_donor_id",
                        column: x => x.donor_id,
                        principalTable: "donor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_session_state_state_id",
                        column: x => x.state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_order",
                columns: table => new
                {
                    donor_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_order", x => new { x.donor_id, x.order_id });
                    table.ForeignKey(
                        name: "FK_donor_order_donor_donor_id",
                        column: x => x.donor_id,
                        principalTable: "donor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_order_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donor_blood_type_id",
                table: "donor",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_center_contact_id",
                table: "donor_center",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_center_street_id",
                table: "donor_center",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_order_order_id",
                table: "donor_order",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_blood_type_id",
                table: "order",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_donor_center_id",
                table: "order",
                column: "donor_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_importance_id",
                table: "order",
                column: "importance_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_contact_id",
                table: "person",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_street_id",
                table: "person",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_donor_center_id",
                table: "session",
                column: "donor_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_donor_id",
                table: "session",
                column: "donor_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_state_id",
                table: "session",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_street_city_id",
                table: "street",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donor_order");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "donor");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "donor_center");

            migrationBuilder.DropTable(
                name: "importance");

            migrationBuilder.DropTable(
                name: "blood_type");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "street");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
