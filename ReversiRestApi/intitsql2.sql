IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Spelers] (
    [Token] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Spelers] PRIMARY KEY ([Token])
);
GO

CREATE TABLE [Spellen] (
    [Token] nvarchar(450) NOT NULL,
    [Omschrijving] nvarchar(max) NULL,
    [Speler1] nvarchar(max) NULL,
    [NavigationProperty1Token] nvarchar(450) NULL,
    [Speler2] nvarchar(max) NULL,
    [NavigationProperty2Token] nvarchar(450) NULL,
    [Aandebeurd] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Spellen] PRIMARY KEY ([Token]),
    CONSTRAINT [FK_Spellen_Spelers_NavigationProperty1Token] FOREIGN KEY ([NavigationProperty1Token]) REFERENCES [Spelers] ([Token]),
    CONSTRAINT [FK_Spellen_Spelers_NavigationProperty2Token] FOREIGN KEY ([NavigationProperty2Token]) REFERENCES [Spelers] ([Token])
);
GO

CREATE TABLE [Bord] (
    [Token] nvarchar(450) NOT NULL,
    [SpelToken] nvarchar(450) NOT NULL,
    [BespeeldBord] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Bord] PRIMARY KEY ([Token]),
    CONSTRAINT [FK_Bord_Spellen_SpelToken] FOREIGN KEY ([SpelToken]) REFERENCES [Spellen] ([Token]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Bord_SpelToken] ON [Bord] ([SpelToken]);
GO

CREATE INDEX [IX_Spellen_NavigationProperty1Token] ON [Spellen] ([NavigationProperty1Token]);
GO

CREATE INDEX [IX_Spellen_NavigationProperty2Token] ON [Spellen] ([NavigationProperty2Token]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220315180714_initialcreate', N'6.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Spellen]') AND [c].[name] = N'Speler1');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Spellen] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Spellen] DROP COLUMN [Speler1];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Spellen]') AND [c].[name] = N'Speler2');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Spellen] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Spellen] DROP COLUMN [Speler2];
GO

EXEC sp_rename N'[Spellen].[Aandebeurd]', N'Speler2Token', N'COLUMN';
GO

ALTER TABLE [Spellen] ADD [AandeBeurt] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Spellen] ADD [ID] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Spellen] ADD [Speler1Token] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220325133344_init', N'6.0.3');
GO

COMMIT;
GO

