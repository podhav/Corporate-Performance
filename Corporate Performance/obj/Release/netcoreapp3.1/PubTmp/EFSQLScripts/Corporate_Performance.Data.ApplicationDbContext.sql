IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200518170657_addProgrammetoDB')
BEGIN
    CREATE TABLE [Programmes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Programmes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200518170657_addProgrammetoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200518170657_addProgrammetoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200518193141_test')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200518193141_test', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519091352_test2')
BEGIN
    ALTER TABLE [Programmes] DROP CONSTRAINT [PK_Programmes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519091352_test2')
BEGIN
    EXEC sp_rename N'[Programmes]', N'Programme';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519091352_test2')
BEGIN
    ALTER TABLE [Programme] ADD CONSTRAINT [PK_Programme] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519091352_test2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200519091352_test2', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519091656_dbprogramme')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200519091656_dbprogramme', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520075922_addKPAtoDB')
BEGIN
    CREATE TABLE [KPA] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_KPA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520075922_addKPAtoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200520075922_addKPAtoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520135918_AddKPItoDb')
BEGIN
    CREATE TABLE [KPI] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [ProgrammeId] int NOT NULL,
        CONSTRAINT [PK_KPI] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_KPI_Programme_ProgrammeId] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520135918_AddKPItoDb')
BEGIN
    CREATE INDEX [IX_KPI_ProgrammeId] ON [KPI] ([ProgrammeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520135918_AddKPItoDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200520135918_AddKPItoDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200521104719_addStatusFieldToViewModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200521104719_addStatusFieldToViewModel', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522144107_AddPeriodtoDB')
BEGIN
    CREATE TABLE [Period] (
        [Id] int NOT NULL IDENTITY,
        [FiscalYear] int NOT NULL,
        [QrtStartDate] datetime2 NOT NULL,
        [QrtEndDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Period] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522144107_AddPeriodtoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200522144107_AddPeriodtoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523083346_UpdateToPeriodDB')
BEGIN
    ALTER TABLE [Period] ADD [Quarter] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523083346_UpdateToPeriodDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200523083346_UpdateToPeriodDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523130348_AddPerformanceToDB')
BEGIN
    CREATE TABLE [Performance] (
        [Id] int NOT NULL IDENTITY,
        [PeriodId] int NOT NULL,
        [KPAId] int NOT NULL,
        [KPIId] int NOT NULL,
        [QrtTarget] int NOT NULL,
        [QrtActual] int NOT NULL,
        [QrtDeviation] int NOT NULL,
        [AnnualTarget] int NOT NULL,
        [AnnualActual] int NOT NULL,
        [AnnualDeviation] int NOT NULL,
        [CorrectiveAction] nvarchar(max) NULL,
        [Comments] nvarchar(max) NULL,
        [Files] nvarchar(max) NULL,
        CONSTRAINT [PK_Performance] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Performance_KPA_KPAId] FOREIGN KEY ([KPAId]) REFERENCES [KPA] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Performance_KPI_KPIId] FOREIGN KEY ([KPIId]) REFERENCES [KPI] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Performance_Period_PeriodId] FOREIGN KEY ([PeriodId]) REFERENCES [Period] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523130348_AddPerformanceToDB')
BEGIN
    CREATE INDEX [IX_Performance_KPAId] ON [Performance] ([KPAId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523130348_AddPerformanceToDB')
BEGIN
    CREATE INDEX [IX_Performance_KPIId] ON [Performance] ([KPIId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523130348_AddPerformanceToDB')
BEGIN
    CREATE INDEX [IX_Performance_PeriodId] ON [Performance] ([PeriodId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200523130348_AddPerformanceToDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200523130348_AddPerformanceToDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [KPI] DROP CONSTRAINT [FK_KPI_Programme_ProgrammeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    DROP INDEX [IX_KPI_ProgrammeId] ON [KPI];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Period]') AND [c].[name] = N'FiscalYear');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Period] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Period] DROP COLUMN [FiscalYear];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KPI]') AND [c].[name] = N'ProgrammeId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [KPI] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [KPI] DROP COLUMN [ProgrammeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Programme] ADD [KPIId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Performance] ADD [FiscalId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Performance] ADD [ProgramId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    CREATE TABLE [Fiscal] (
        [Id] int NOT NULL IDENTITY,
        [FiscalYear] int NOT NULL,
        [YearStartDate] datetime2 NOT NULL,
        [YearEndDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Fiscal] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    CREATE INDEX [IX_Programme_KPIId] ON [Programme] ([KPIId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    CREATE INDEX [IX_Performance_FiscalId] ON [Performance] ([FiscalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    CREATE INDEX [IX_Performance_ProgramId] ON [Performance] ([ProgramId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Fiscal_FiscalId] FOREIGN KEY ([FiscalId]) REFERENCES [Fiscal] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Programme_ProgramId] FOREIGN KEY ([ProgramId]) REFERENCES [Programme] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    ALTER TABLE [Programme] ADD CONSTRAINT [FK_Programme_KPI_KPIId] FOREIGN KEY ([KPIId]) REFERENCES [KPI] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526114349_AddFiscalandChangestoModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526114349_AddFiscalandChangestoModel', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526123720_Update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526123720_Update', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526124325_updateafterDelKPIIdinProgramme')
BEGIN
    ALTER TABLE [Programme] DROP CONSTRAINT [FK_Programme_KPI_KPIId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526124325_updateafterDelKPIIdinProgramme')
BEGIN
    DROP INDEX [IX_Programme_KPIId] ON [Programme];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526124325_updateafterDelKPIIdinProgramme')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Programme]') AND [c].[name] = N'KPIId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Programme] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Programme] DROP COLUMN [KPIId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526124325_updateafterDelKPIIdinProgramme')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526124325_updateafterDelKPIIdinProgramme', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526125939_UpdateProgrammeDB')
BEGIN
    ALTER TABLE [Programme] ADD [KPIId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526125939_UpdateProgrammeDB')
BEGIN
    CREATE INDEX [IX_Programme_KPIId] ON [Programme] ([KPIId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526125939_UpdateProgrammeDB')
BEGIN
    ALTER TABLE [Programme] ADD CONSTRAINT [FK_Programme_KPI_KPIId] FOREIGN KEY ([KPIId]) REFERENCES [KPI] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526125939_UpdateProgrammeDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526125939_UpdateProgrammeDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526140002_AddCheckboxToProgrammeDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526140002_AddCheckboxToProgrammeDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526140429_databaseProgrammetoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526140429_databaseProgrammetoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    ALTER TABLE [Programme] DROP CONSTRAINT [FK_Programme_KPI_KPIId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    DROP INDEX [IX_Programme_KPIId] ON [Programme];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Programme]') AND [c].[name] = N'KPIId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Programme] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Programme] DROP COLUMN [KPIId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    ALTER TABLE [KPI] ADD [KPIId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    ALTER TABLE [KPI] ADD [ProgrammeId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    CREATE INDEX [IX_KPI_ProgrammeId] ON [KPI] ([ProgrammeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    ALTER TABLE [KPI] ADD CONSTRAINT [FK_KPI_Programme_ProgrammeId] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526150507_UpdateModelProgrammeandKPI')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526150507_UpdateModelProgrammeandKPI', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154037_updateKPIDb')
BEGIN
    ALTER TABLE [KPI] DROP CONSTRAINT [FK_KPI_Programme_ProgrammeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154037_updateKPIDb')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KPI]') AND [c].[name] = N'KPIId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [KPI] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [KPI] DROP COLUMN [KPIId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154037_updateKPIDb')
BEGIN
    DROP INDEX [IX_KPI_ProgrammeId] ON [KPI];
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KPI]') AND [c].[name] = N'ProgrammeId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [KPI] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [KPI] ALTER COLUMN [ProgrammeId] int NOT NULL;
    CREATE INDEX [IX_KPI_ProgrammeId] ON [KPI] ([ProgrammeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154037_updateKPIDb')
BEGIN
    ALTER TABLE [KPI] ADD CONSTRAINT [FK_KPI_Programme_ProgrammeId] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154037_updateKPIDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526154037_updateKPIDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Programme_ProgramId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    DROP INDEX [IX_Performance_ProgramId] ON [Performance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'ProgramId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Performance] DROP COLUMN [ProgramId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    ALTER TABLE [Performance] ADD [ProgrammeId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    CREATE INDEX [IX_Performance_ProgrammeId] ON [Performance] ([ProgrammeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Programme_ProgrammeId] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528174554_ProgrammeDBupdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528174554_ProgrammeDBupdate', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528181509_PerformanceDb')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Programme_ProgrammeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528181509_PerformanceDb')
BEGIN
    DROP INDEX [IX_Performance_ProgrammeId] ON [Performance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528181509_PerformanceDb')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'ProgrammeId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Performance] DROP COLUMN [ProgrammeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528181509_PerformanceDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528181509_PerformanceDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603143325_addUserNametoIdentityUserDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603143325_addUserNametoIdentityUserDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603143325_addUserNametoIdentityUserDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200603143325_addUserNametoIdentityUserDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603154014_usertoApplicationUserDb')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603154014_usertoApplicationUserDb')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603154014_usertoApplicationUserDb')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603154014_usertoApplicationUserDb')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200603154014_usertoApplicationUserDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200603154014_usertoApplicationUserDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611072059_updatePerformanceDB')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'QrtDeviation');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Performance] DROP COLUMN [QrtDeviation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611072059_updatePerformanceDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611072059_updatePerformanceDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611073151_updateDB')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'AnnualDeviation');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Performance] DROP COLUMN [AnnualDeviation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611073151_updateDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611073151_updateDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'AnnualActual');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Performance] DROP COLUMN [AnnualActual];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'AnnualTarget');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Performance] DROP COLUMN [AnnualTarget];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'QrtActual');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Performance] DROP COLUMN [QrtActual];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'QrtTarget');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Performance] DROP COLUMN [QrtTarget];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt1Actual] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt1Target] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt2Actual] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt2Target] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt3Actual] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt3Target] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt4Actual] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt4Target] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611083753_AddPerformanceQrtsDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611083753_AddPerformanceQrtsDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611085624_RemoveQuartersPeriodDB')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Period]') AND [c].[name] = N'Quarter');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Period] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Period] DROP COLUMN [Quarter];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611085624_RemoveQuartersPeriodDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611085624_RemoveQuartersPeriodDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611091314_updateModelDb')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Period_PeriodId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611091314_updateModelDb')
BEGIN
    DROP TABLE [Period];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611091314_updateModelDb')
BEGIN
    DROP INDEX [IX_Performance_PeriodId] ON [Performance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611091314_updateModelDb')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'PeriodId');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Performance] DROP COLUMN [PeriodId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611091314_updateModelDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611091314_updateModelDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611095320_qrt1DeviationDb')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt1Deviation] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611095320_qrt1DeviationDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611095320_qrt1DeviationDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [AnnualActual] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [AnnualDeviation] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [AnnualTarget] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt2Deviation] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt3Deviation] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    ALTER TABLE [Performance] ADD [Qrt4Deviation] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611101102_updateQrtsDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611101102_updateQrtsDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200616152709_updatePerformance')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200616152709_updatePerformance', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'Files');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [Performance] DROP COLUMN [Files];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    ALTER TABLE [Performance] ADD [FilesId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    CREATE TABLE [Files] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [FileType] nvarchar(100) NULL,
        [DataFiles] varbinary(max) NULL,
        [CreatedOn] datetime2 NULL,
        CONSTRAINT [PK_Files] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    CREATE INDEX [IX_Performance_FilesId] ON [Performance] ([FilesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Files_FilesId] FOREIGN KEY ([FilesId]) REFERENCES [Files] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621133004_filesUpload')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621133004_filesUpload', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621135011_updateFilesTabletoDB')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Files_FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621135011_updateFilesTabletoDB')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'FilesId');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Performance] ALTER COLUMN [FilesId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621135011_updateFilesTabletoDB')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Files_FilesId] FOREIGN KEY ([FilesId]) REFERENCES [Files] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621135011_updateFilesTabletoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621135011_updateFilesTabletoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621135329_updatetoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621135329_updatetoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621141611_init')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Files_FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621141611_init')
BEGIN
    DROP INDEX [IX_Performance_FilesId] ON [Performance];
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'FilesId');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [Performance] ALTER COLUMN [FilesId] int NOT NULL;
    CREATE INDEX [IX_Performance_FilesId] ON [Performance] ([FilesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621141611_init')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Files_FilesId] FOREIGN KEY ([FilesId]) REFERENCES [Files] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621141611_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621141611_init', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621142435_updateFilesDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621142435_updateFilesDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143255_filesone')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Files_FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143255_filesone')
BEGIN
    DROP INDEX [IX_Performance_FilesId] ON [Performance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143255_filesone')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621143255_filesone', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143937_filestwo')
BEGIN
    CREATE INDEX [IX_Performance_FilesId] ON [Performance] ([FilesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143937_filestwo')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Files_FilesId] FOREIGN KEY ([FilesId]) REFERENCES [Files] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621143937_filestwo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621143937_filestwo', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621144815_nullableFiles')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Files_FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621144815_nullableFiles')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'FilesId');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Performance] ALTER COLUMN [FilesId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621144815_nullableFiles')
BEGIN
    ALTER TABLE [Performance] ADD CONSTRAINT [FK_Performance_Files_FilesId] FOREIGN KEY ([FilesId]) REFERENCES [Files] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621144815_nullableFiles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621144815_nullableFiles', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075641_changeFK')
BEGIN
    ALTER TABLE [Performance] DROP CONSTRAINT [FK_Performance_Files_FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075641_changeFK')
BEGIN
    DROP INDEX [IX_Performance_FilesId] ON [Performance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075641_changeFK')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'FilesId');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Performance] ALTER COLUMN [FilesId] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075641_changeFK')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622075641_changeFK', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075858_removeFiles')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'FilesId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Performance] DROP COLUMN [FilesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622075858_removeFiles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622075858_removeFiles', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622080646_FilesDb')
BEGIN
    ALTER TABLE [Files] ADD [PerformanceId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622080646_FilesDb')
BEGIN
    CREATE INDEX [IX_Files_PerformanceId] ON [Files] ([PerformanceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622080646_FilesDb')
BEGIN
    ALTER TABLE [Files] ADD CONSTRAINT [FK_Files_Performance_PerformanceId] FOREIGN KEY ([PerformanceId]) REFERENCES [Performance] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622080646_FilesDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622080646_FilesDb', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622085911_navigation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622085911_navigation', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622092208_FormFiletoDB')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Files]') AND [c].[name] = N'Name');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Files] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Files] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622092208_FormFiletoDB')
BEGIN
    ALTER TABLE [Files] ADD [FileName] nvarchar(100) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622092208_FormFiletoDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622092208_FormFiletoDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622105046_restore')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622105046_restore', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622105314_setterPrivate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622105314_setterPrivate', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622110602_computed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622110602_computed', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622161417_files')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622161417_files', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622190210_ListFormFile')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622190210_ListFormFile', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623143853_performanceModify')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200623143853_performanceModify', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623144354_FilesModify')
BEGIN
    ALTER TABLE [Files] DROP CONSTRAINT [FK_Files_Performance_PerformanceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623144354_FilesModify')
BEGIN
    DROP INDEX [IX_Files_PerformanceId] ON [Files];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623144354_FilesModify')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Files]') AND [c].[name] = N'PerformanceId');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Files] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Files] DROP COLUMN [PerformanceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623144354_FilesModify')
BEGIN
    ALTER TABLE [Performance] ADD [Files] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200623144354_FilesModify')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200623144354_FilesModify', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200625155244_performanceToDB')
BEGIN
    ALTER TABLE [Files] ADD [PerformanceId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200625155244_performanceToDB')
BEGIN
    CREATE INDEX [IX_Files_PerformanceId] ON [Files] ([PerformanceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200625155244_performanceToDB')
BEGIN
    ALTER TABLE [Files] ADD CONSTRAINT [FK_Files_Performance_PerformanceId] FOREIGN KEY ([PerformanceId]) REFERENCES [Performance] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200625155244_performanceToDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200625155244_performanceToDB', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626154440_FileDelete')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Performance]') AND [c].[name] = N'Files');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Performance] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Performance] DROP COLUMN [Files];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200626154440_FileDelete')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200626154440_FileDelete', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200708171113_paging')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200708171113_paging', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200730130342_deviation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200730130342_deviation', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200730131524_deviationGetSetchanges')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200730131524_deviationGetSetchanges', N'3.1.5');
END;

GO

