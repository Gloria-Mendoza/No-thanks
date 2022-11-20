
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2022 21:13:36
-- Generated from EDMX file: C:\Users\yo\Desktop\JP_Desktop\Universidad\Semestre-5\Construccion\ProyectoJuego\No-thanks\NoThanksServer\Data\NoThanksDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NoThanks];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Friends__idPlaye__29572725]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__idPlaye__29572725];
GO
IF OBJECT_ID(N'[dbo].[FK__Friends__idPlaye__2A4B4B5E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__idPlaye__2A4B4B5E];
GO
IF OBJECT_ID(N'[dbo].[FK__MatchsHis__idGam__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchsHistory] DROP CONSTRAINT [FK__MatchsHis__idGam__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__MatchsHis__idPla__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchsHistory] DROP CONSTRAINT [FK__MatchsHis__idPla__2E1BDC42];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[MatchsHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchsHistory];
GO
IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [idFriend] int IDENTITY(1,1) NOT NULL,
    [idPlayer1] int  NOT NULL,
    [idPlayer2] int  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [idGame] int IDENTITY(1,1) NOT NULL,
    [result] int  NOT NULL
);
GO

-- Creating table 'MatchsHistories'
CREATE TABLE [dbo].[MatchsHistories] (
    [idMatch] int  NOT NULL,
    [point] int  NOT NULL,
    [result] varchar(8)  NOT NULL,
    [idGame] int  NOT NULL,
    [idPlayer] int  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [idPlayer] int IDENTITY(1,1) NOT NULL,
    [nickname] nvarchar(45)  NOT NULL,
    [password] nvarchar(128)  NOT NULL,
    [email] nvarchar(100)  NOT NULL,
    [totalScore] int  NOT NULL,
    [name] nvarchar(1)  NOT NULL,
    [lastName] nvarchar(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idFriend] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([idFriend] ASC);
GO

-- Creating primary key on [idGame] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([idGame] ASC);
GO

-- Creating primary key on [idMatch] in table 'MatchsHistories'
ALTER TABLE [dbo].[MatchsHistories]
ADD CONSTRAINT [PK_MatchsHistories]
    PRIMARY KEY CLUSTERED ([idMatch] ASC);
GO

-- Creating primary key on [idPlayer] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([idPlayer] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idPlayer1] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK__Friends__idPlaye__29572725]
    FOREIGN KEY ([idPlayer1])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Friends__idPlaye__29572725'
CREATE INDEX [IX_FK__Friends__idPlaye__29572725]
ON [dbo].[Friends]
    ([idPlayer1]);
GO

-- Creating foreign key on [idPlayer2] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK__Friends__idPlaye__2A4B4B5E]
    FOREIGN KEY ([idPlayer2])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Friends__idPlaye__2A4B4B5E'
CREATE INDEX [IX_FK__Friends__idPlaye__2A4B4B5E]
ON [dbo].[Friends]
    ([idPlayer2]);
GO

-- Creating foreign key on [idGame] in table 'MatchsHistories'
ALTER TABLE [dbo].[MatchsHistories]
ADD CONSTRAINT [FK__MatchsHis__idGam__2D27B809]
    FOREIGN KEY ([idGame])
    REFERENCES [dbo].[Games]
        ([idGame])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MatchsHis__idGam__2D27B809'
CREATE INDEX [IX_FK__MatchsHis__idGam__2D27B809]
ON [dbo].[MatchsHistories]
    ([idGame]);
GO

-- Creating foreign key on [idPlayer] in table 'MatchsHistories'
ALTER TABLE [dbo].[MatchsHistories]
ADD CONSTRAINT [FK__MatchsHis__idPla__2E1BDC42]
    FOREIGN KEY ([idPlayer])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MatchsHis__idPla__2E1BDC42'
CREATE INDEX [IX_FK__MatchsHis__idPla__2E1BDC42]
ON [dbo].[MatchsHistories]
    ([idPlayer]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------