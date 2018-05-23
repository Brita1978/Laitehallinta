
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2018 14:44:46
-- Generated from EDMX file: C:\Users\Brita\source\repos\Laitehallinta\Laitehallinta\Laitehallinta\Models\HallintaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Seuranta];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Logi_Henkilot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logi] DROP CONSTRAINT [FK_Logi_Henkilot];
GO
IF OBJECT_ID(N'[dbo].[FK_Logi_Laitteet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logi] DROP CONSTRAINT [FK_Logi_Laitteet];
GO
IF OBJECT_ID(N'[dbo].[FK_Logi_Tilat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logi] DROP CONSTRAINT [FK_Logi_Tilat];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Henkilot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Henkilot];
GO
IF OBJECT_ID(N'[dbo].[Laitteet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Laitteet];
GO
IF OBJECT_ID(N'[dbo].[Logi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logi];
GO
IF OBJECT_ID(N'[dbo].[Tilat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tilat];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Henkilot'
CREATE TABLE [dbo].[Henkilot] (
    [HenkiloID] int IDENTITY(1,1) NOT NULL,
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL
);
GO

-- Creating table 'Laitteet'
CREATE TABLE [dbo].[Laitteet] (
    [LaiteID] int IDENTITY(1,1) NOT NULL,
    [Sarjanumero] nvarchar(50)  NULL,
    [Merkki] nvarchar(50)  NULL,
    [Malli] nvarchar(50)  NULL,
    [Muuta] nvarchar(max)  NULL
);
GO

-- Creating table 'Logi'
CREATE TABLE [dbo].[Logi] (
    [LogiID] int  NOT NULL,
    [SijaintiID] int  NULL,
    [PaikkaID] int  NULL,
    [KirjaajaID] int  NULL,
    [Kirjattusisään] datetime  NULL,
    [HenkiloID] int  NULL,
    [LaiteID] int  NULL,
    [TilaID] int  NULL
);
GO

-- Creating table 'Tilat'
CREATE TABLE [dbo].[Tilat] (
    [TilaID] int IDENTITY(1,1) NOT NULL,
    [Tarkennus] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [HenkiloID] in table 'Henkilot'
ALTER TABLE [dbo].[Henkilot]
ADD CONSTRAINT [PK_Henkilot]
    PRIMARY KEY CLUSTERED ([HenkiloID] ASC);
GO

-- Creating primary key on [LaiteID] in table 'Laitteet'
ALTER TABLE [dbo].[Laitteet]
ADD CONSTRAINT [PK_Laitteet]
    PRIMARY KEY CLUSTERED ([LaiteID] ASC);
GO

-- Creating primary key on [LogiID] in table 'Logi'
ALTER TABLE [dbo].[Logi]
ADD CONSTRAINT [PK_Logi]
    PRIMARY KEY CLUSTERED ([LogiID] ASC);
GO

-- Creating primary key on [TilaID] in table 'Tilat'
ALTER TABLE [dbo].[Tilat]
ADD CONSTRAINT [PK_Tilat]
    PRIMARY KEY CLUSTERED ([TilaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HenkiloID] in table 'Logi'
ALTER TABLE [dbo].[Logi]
ADD CONSTRAINT [FK_Logi_Henkilot]
    FOREIGN KEY ([HenkiloID])
    REFERENCES [dbo].[Henkilot]
        ([HenkiloID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Logi_Henkilot'
CREATE INDEX [IX_FK_Logi_Henkilot]
ON [dbo].[Logi]
    ([HenkiloID]);
GO

-- Creating foreign key on [LaiteID] in table 'Logi'
ALTER TABLE [dbo].[Logi]
ADD CONSTRAINT [FK_Logi_Laitteet]
    FOREIGN KEY ([LaiteID])
    REFERENCES [dbo].[Laitteet]
        ([LaiteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Logi_Laitteet'
CREATE INDEX [IX_FK_Logi_Laitteet]
ON [dbo].[Logi]
    ([LaiteID]);
GO

-- Creating foreign key on [TilaID] in table 'Logi'
ALTER TABLE [dbo].[Logi]
ADD CONSTRAINT [FK_Logi_Tilat]
    FOREIGN KEY ([TilaID])
    REFERENCES [dbo].[Tilat]
        ([TilaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Logi_Tilat'
CREATE INDEX [IX_FK_Logi_Tilat]
ON [dbo].[Logi]
    ([TilaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------