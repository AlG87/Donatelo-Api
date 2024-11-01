﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donatelo.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    DonacionId = table.Column<int>(type: "int", nullable: false),
                    DonanteId = table.Column<int>(type: "int", nullable: false),
                    BeneficiadoId = table.Column<int>(type: "int", nullable: false),
                    PublicacionId = table.Column<int>(type: "int", nullable: false),
                    MetodoEntregaId = table.Column<int>(type: "int", nullable: false),
                    sedeid = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonacionId", x => x.DonacionId);
                    table.ForeignKey(
                        name: "Fk_donanteid",
                        column: x => x.DonanteId,
                        principalTable:"usuarios",
                        principalColumn:"UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_beneficiadoid",
                        column: x => x.BeneficiadoId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_publicacionid",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "PublicacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_sedeid",
                        column: x => x.sedeid,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_estadoDonacionid",
                        column: x => x.Estado,
                        principalTable: "EstadoDonacion",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDonacion",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FK_EstadoDID", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPublicacion",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FK_EstadoPID", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    NotificacionId = table.Column<int>(type: "int", nullable: false),
                    usuariod = table.Column<int>(type: "int", nullable: false),
                    Mnesaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacionId", x => x.NotificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    PublicacionId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionId", x => x.PublicacionId);
                    table.ForeignKey(
                         name: "Fk_usuarioid",
                         column: x => x.UsuarioId,
                         principalTable: "usuarios",
                         principalColumn: "UsuarioId",
                         onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_estadoid",
                        column: x => x.Estado,
                        principalTable: "EstadoPublicacion",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roltype",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolId", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeId", x => x.SedeId);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesDonacion",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    donacionid = table.Column<int>(type: "int", nullable: false),
                    beneficiadoid = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    fechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudId", x => x.SolicitudId);
                    table.ForeignKey(
                        name: "Fk_donacionid",
                        column: x => x.donacionid,
                        principalTable: "Donaciones",
                        principalColumn: "DonacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_benficiadoid",
                        column: x => x.beneficiadoid,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_estadoid",
                        column: x => x.Estado,
                        principalTable: "EstadoPublicacion",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioId", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "Fk_roltypeId",
                        column: x => x.Rol,
                        principalTable: "roltype",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DropTable(
                name: "EstadoDonacion");

            migrationBuilder.DropTable(
                name: "EstadoPublicacion");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "roltype");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "SolicitudesDonacion");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
