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
                    id = table.Column<long>(type: "bigint", nullable: false)
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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
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
                    person_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blood_type_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_donor_blood_type_blood_type_id",
                        column: x => x.blood_type_id,
                        principalTable: "blood_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "street",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "session",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donor_center_id = table.Column<long>(type: "bigint", nullable: false),
                    blood_type_id = table.Column<long>(type: "bigint", nullable: false),
                    blood_volume = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_session", x => x.id);
                    table.ForeignKey(
                        name: "FK_session_state_state_id",
                        column: x => x.state_id,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_center",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    house_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_center", x => x.id);
                    table.ForeignKey(
                        name: "FK_donor_center_street_street_id",
                        column: x => x.street_id,
                        principalTable: "street",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    photo_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    house_number = table.Column<int>(type: "int", nullable: false),
                    street_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_street_street_id",
                        column: x => x.street_id,
                        principalTable: "street",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_session",
                columns: table => new
                {
                    session_id = table.Column<long>(type: "bigint", nullable: false),
                    donor_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_session", x => new { x.donor_id, x.session_id });
                    table.ForeignKey(
                        name: "FK_donor_session_donor_donor_id",
                        column: x => x.donor_id,
                        principalTable: "donor",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_session_session_session_id",
                        column: x => x.session_id,
                        principalTable: "session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_center_contact",
                columns: table => new
                {
                    donor_center_id = table.Column<long>(type: "bigint", nullable: false),
                    contact_type_id = table.Column<long>(type: "bigint", nullable: false),
                    contact_value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_center_contact", x => new { x.donor_center_id, x.contact_type_id });
                    table.ForeignKey(
                        name: "FK_donor_center_contact_contact_type_contact_type_id",
                        column: x => x.contact_type_id,
                        principalTable: "contact_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_center_contact_donor_center_donor_center_id",
                        column: x => x.donor_center_id,
                        principalTable: "donor_center",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blood_volume = table.Column<int>(type: "int", nullable: false),
                    donor_center_id = table.Column<long>(type: "bigint", nullable: false),
                    importance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_donor_center_donor_center_id",
                        column: x => x.donor_center_id,
                        principalTable: "donor_center",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "session_donor_center",
                columns: table => new
                {
                    session_id = table.Column<long>(type: "bigint", nullable: false),
                    donor_center_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_session_donor_center", x => new { x.session_id, x.donor_center_id });
                    table.ForeignKey(
                        name: "FK_session_donor_center_donor_center_donor_center_id",
                        column: x => x.donor_center_id,
                        principalTable: "donor_center",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_session_donor_center_session_session_id",
                        column: x => x.session_id,
                        principalTable: "session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_contact",
                columns: table => new
                {
                    peson_id = table.Column<long>(type: "bigint", nullable: false),
                    contact_type_id = table.Column<long>(type: "bigint", nullable: false),
                    contact_value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_contact", x => new { x.peson_id, x.contact_type_id });
                    table.ForeignKey(
                        name: "FK_person_contact_contact_type_contact_type_id",
                        column: x => x.contact_type_id,
                        principalTable: "contact_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_contact_person_peson_id",
                        column: x => x.peson_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donor_order",
                columns: table => new
                {
                    donor_id = table.Column<long>(type: "bigint", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor_order", x => new { x.donor_id, x.order_id });
                    table.ForeignKey(
                        name: "FK_donor_order_donor_donor_id",
                        column: x => x.donor_id,
                        principalTable: "donor",
                        principalColumn: "person_id",
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
                name: "IX_donor_center_street_id",
                table: "donor_center",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_center_contact_contact_type_id",
                table: "donor_center_contact",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_order_order_id",
                table: "donor_order",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_donor_session_session_id",
                table: "donor_session",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_donor_center_id",
                table: "order",
                column: "donor_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_street_id",
                table: "person",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_contact_contact_type_id",
                table: "person_contact",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_state_id",
                table: "session",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_donor_center_donor_center_id",
                table: "session_donor_center",
                column: "donor_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_street_city_id",
                table: "street",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donor_center_contact");

            migrationBuilder.DropTable(
                name: "donor_order");

            migrationBuilder.DropTable(
                name: "donor_session");

            migrationBuilder.DropTable(
                name: "person_contact");

            migrationBuilder.DropTable(
                name: "session_donor_center");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "donor");

            migrationBuilder.DropTable(
                name: "contact_type");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "donor_center");

            migrationBuilder.DropTable(
                name: "blood_type");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "street");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
