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
    [Guid] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [AantalGewonnen] int NOT NULL,
    [AantalVerloren] int NOT NULL,
    [AantalGelijk] int NOT NULL,
    CONSTRAINT [PK_Spelers] PRIMARY KEY ([Guid])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220316125218_InitialCreate', N'6.0.3');
GO

COMMIT;
GO

