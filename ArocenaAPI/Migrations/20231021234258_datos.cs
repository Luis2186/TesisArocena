using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArocenaAPI.Migrations
{
    /// <inheritdoc />
    public partial class datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                        SET IDENTITY_INSERT [AspNetRoles] ON;
                    INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
                    VALUES (N'152fbd65-8f57-4c13-b8d1-80978d032ba8', N'52fe5ca1-12fa-4708-af36-ea959e22c4e6', N'Recursos humanos', N'Recursos humanos'),
                    (N'9aae0b6d-d50c-4d0a-9b90-2a6873e3845d', N'83827425-1ac3-4fef-930e-db3ca7ae6504', N'Administrador', N'Administrador'),
                    (N'd8a09bde-44fa-4874-8f8f-6182fa935123', N'00012f7f-5571-4c5b-bbd2-76aa75bd2949', N'Cajero', N'Cajero');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                        SET IDENTITY_INSERT [AspNetRoles] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                        SET IDENTITY_INSERT [AspNetUsers] ON;
                    INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
                    VALUES (N'2cd9e94a-7944-40eb-9f98-5b321efa57b9', 0, N'3538135e-ad9b-4f36-af5a-16febdbaaa8f', N'Rrhh', CAST(0 AS bit), CAST(0 AS bit), NULL, N'Rrhh', N'Rrhh', N'AQAAAAEAACcQAAAAEFmneg+tqlUYP/FZAxYYyl6bO2UkAQdWlv/ofGvT3pqO++yqukrxueYf/N6KSyESfA==', NULL, CAST(0 AS bit), N'74d4c2c5-8c24-48e2-aad1-6f987490a30c', CAST(0 AS bit), N'Rrhh'),
                    (N'5673b8cf-12de-44f6-92ad-fae4a77932ad', 0, N'dd2e47c2-2e82-4a26-b0dd-c1225c6b3204', N'Administrador', CAST(0 AS bit), CAST(0 AS bit), NULL, N'Administrador', N'Administrador', N'AQAAAAEAACcQAAAAEMHEno5EEHm7mWIyxqEwvwBOmkANlpliRboFK4XJntcsN2kk9QpQ2sUp7CM+7Ah1eQ==', NULL, CAST(0 AS bit), N'e988d7e0-c848-4f26-ac89-1c560acc9a6e', CAST(0 AS bit), N'Administrador'),
                    (N'6205ee89-d078-4940-9c3e-38f71eec8d1a', 0, N'6f610588-9b1b-4f0f-b310-9a82f02531ff', N'Cajero', CAST(0 AS bit), CAST(0 AS bit), NULL, N'Cajero', N'Cajero', N'AQAAAAEAACcQAAAAEFSXMzgc9dq9gpMhw8OQhyxA17sGlTf8fhYOHWDbl/JFfhBQpcxJniuzcNp7vQQIgw==', NULL, CAST(0 AS bit), N'35b951e3-e388-4d6f-8d68-2834656118d2', CAST(0 AS bit), N'Cajero');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                        SET IDENTITY_INSERT [AspNetUsers] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'Celular', N'Direccion', N'EmpresaId', N'FamiliaId', N'MetodoDePagoSugeridoId', N'Nombres', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Clientes]'))
                        SET IDENTITY_INSERT [Clientes] ON;
                    INSERT INTO [Clientes] ([Id], [Apellidos], [Celular], [Direccion], [EmpresaId], [FamiliaId], [MetodoDePagoSugeridoId], [Nombres], [TelefonoFijo])
                    VALUES (10, N'Perez', N'099497159', N'Dir10', null, null, null, N'Andrea', NULL);
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'Celular', N'Direccion', N'EmpresaId', N'FamiliaId', N'MetodoDePagoSugeridoId', N'Nombres', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Clientes]'))
                        SET IDENTITY_INSERT [Clientes] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direccion', N'Nombre', N'Rut', N'Telefono') AND [object_id] = OBJECT_ID(N'[Empresas]'))
                        SET IDENTITY_INSERT [Empresas] ON;
                    INSERT INTO [Empresas] ([Id], [Direccion], [Nombre], [Rut], [Telefono])
                    VALUES (1, N'Misiones 1466', N'Stiler', N'210129280011', N'29162616'),
                    (2, N'Juan Paullier 2378', N'Banifox', N'215441590013', N'22002610'),
                    (3, N'Dr. Alejandro Schroeder 6436', N'Tienda Inglesa', N'210094030014', N'26061111'),
                    (4, N'Av.Italia 6958', N'Devoto', N'210297450018', N'26010443');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direccion', N'Nombre', N'Rut', N'Telefono') AND [object_id] = OBJECT_ID(N'[Empresas]'))
                        SET IDENTITY_INSERT [Empresas] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Direccion', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Familia]'))
                        SET IDENTITY_INSERT [Familia] ON;
                    INSERT INTO [Familia] ([Id], [Apellido], [Direccion], [TelefonoFijo])
                    VALUES (1, N'Stan', N'Dir2', N'26012565'),
                    (2, N'Casanova', N'Dir3', N'26002255'),
                    (3, N'Etcheveria', N'Dir4', N'26001478');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Direccion', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Familia]'))
                        SET IDENTITY_INSERT [Familia] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[MetodosDePagos]'))
                        SET IDENTITY_INSERT [MetodosDePagos] ON;
                    INSERT INTO [MetodosDePagos] ([Id], [Nombre])
                    VALUES (1, N'Efectivo'),
                    (2, N'Tarjeta'),
                    (3, N'Cheque'),
                    (4, N'Transferencia'),
                    (5, N'Pendiente');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[MetodosDePagos]'))
                        SET IDENTITY_INSERT [MetodosDePagos] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                        SET IDENTITY_INSERT [AspNetUserClaims] ON;
                    INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
                    VALUES (1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Administrador', N'5673b8cf-12de-44f6-92ad-fae4a77932ad'),
                    (2, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Rrhh', N'2cd9e94a-7944-40eb-9f98-5b321efa57b9'),
                    (3, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Cajero', N'6205ee89-d078-4940-9c3e-38f71eec8d1a');
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                        SET IDENTITY_INSERT [AspNetUserClaims] OFF;
                    GO

                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'Celular', N'Direccion', N'EmpresaId', N'FamiliaId', N'MetodoDePagoSugeridoId', N'Nombres', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Clientes]'))
                        SET IDENTITY_INSERT [Clientes] ON;
                    INSERT INTO [Clientes] ([Id], [Apellidos], [Celular], [Direccion], [EmpresaId], [FamiliaId], [MetodoDePagoSugeridoId], [Nombres], [TelefonoFijo])
                    VALUES (1, N'Gonzales', N'099555666', N'Dir1', 1, null, null, N'Federico', NULL),
                    (2, N'Stan', N'099665455', N'Dir2', null, 1, null, N'Manuel', NULL),
                    (3, N'Casanova', N'091547355', N'Dir3', 1, 2, null, N'Agustin', NULL),
                    (4, N'Etcheveria', N'098223555', N'Dir4', 2, 3, null, N'Marcia', NULL),
                    (5, N'Perez', N'098566871', N'Dir5', 3, null, null, N'Florencia', NULL),
                    (6, N'Villanueva', N'099357159', N'Dir6', 4, null, null, N'Agustina', NULL),
                    (7, N'Casanova', N'099356136', N'Dir3', 4, 2, null, N'Juan', NULL),
                    (8, N'Casanova', N'099654123', N'Dir3', 4, 2, null, N'Carolina', NULL),
                    (9, N'Etcheveria', N'099357159', N'Dir4', null, 3, null, N'Horacio', NULL),
                    (11, N'Etcheveria', N'099397159', N'Dir4', null, 3, null, N'Maximiliano', NULL),
                    (12, N'Stan', N'099677159', N'Dir2', null, 1, null, N'Raul', NULL);
                    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'Celular', N'Direccion', N'EmpresaId', N'FamiliaId', N'MetodoDePagoSugeridoId', N'Nombres', N'TelefonoFijo') AND [object_id] = OBJECT_ID(N'[Clientes]'))
                        SET IDENTITY_INSERT [Clientes] OFF;
                    GO

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152fbd65-8f57-4c13-b8d1-80978d032ba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aae0b6d-d50c-4d0a-9b90-2a6873e3845d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a09bde-44fa-4874-8f8f-6182fa935123");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MetodosDePagos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MetodosDePagos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MetodosDePagos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MetodosDePagos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MetodosDePagos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cd9e94a-7944-40eb-9f98-5b321efa57b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5673b8cf-12de-44f6-92ad-fae4a77932ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6205ee89-d078-4940-9c3e-38f71eec8d1a");

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Familia",
                keyColumn: "Id",
                keyValue: 3);

        }
    }
}
