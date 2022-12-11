
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2022 11:01:58
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

IF OBJECT_ID(N'[dbo].[FK__Friends__idPlaye__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__idPlaye__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__Friends__idPlaye__59FA5E80]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK__Friends__idPlaye__59FA5E80];
GO
IF OBJECT_ID(N'[dbo].[FK__MatchsHis__idGam__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchsHistory] DROP CONSTRAINT [FK__MatchsHis__idGam__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__MatchsHis__idPla__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchsHistory] DROP CONSTRAINT [FK__MatchsHis__idPla__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__Request__receive__778AC167]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK__Request__receive__778AC167];
GO
IF OBJECT_ID(N'[dbo].[FK__Request__senders__76969D2E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK__Request__senders__76969D2E];
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
IF OBJECT_ID(N'[dbo].[Requests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requests];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [idFriend] int IDENTITY(1,1) NOT NULL,
    [idPlayer1] int  DEFAULT 0,
    [idPlayer2] int  DEFAULT 0
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [idGame] int IDENTITY(1,1) NOT NULL,
    [result] int DEFAULT 0 
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [idPlayer] int IDENTITY(1,1) NOT NULL,
    [nickname] nvarchar(45)  DEFAULT "",
    [password] nvarchar(128)  DEFAULT "",
    [email] nvarchar(100)  DEFAULT "",
    [totalScore] int  DEFAULT 0,
    [name] nvarchar(50)  DEFAULT "",
    [lastName] nvarchar(50)  DEFAULT "",
    [photo] nvarchar(50)  DEFAULT ""
);
GO

-- Creating table 'MatchsHistory'
CREATE TABLE [dbo].[MatchsHistory] (
    [idMatch] int  IDENTITY(1,1) NOT NULL,
    [point] int  DEFAULT 0,
    [result] varchar(8)  DEFAULT "",
    [idGame] int  DEFAULT 0,
    [idPlayer] int  DEFAULT 0
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [idRequest] int IDENTITY(1,1) NOT NULL,
    [senders] int  DEFAULT 0,
    [receives] int DEFAULT 0 ,
    [states] int  DEFAULT 0
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

-- Creating primary key on [idPlayer] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([idPlayer] ASC);
GO

-- Creating primary key on [idMatch] in table 'MatchsHistory'
ALTER TABLE [dbo].[MatchsHistory]
ADD CONSTRAINT [PK_MatchsHistory]
    PRIMARY KEY CLUSTERED ([idMatch] ASC);
GO

-- Creating primary key on [idRequest] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([idRequest] ASC);
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

-- Creating foreign key on [idGame] in table 'MatchsHistory'
ALTER TABLE [dbo].[MatchsHistory]
ADD CONSTRAINT [FK__MatchsHis__idGam__2D27B809]
    FOREIGN KEY ([idGame])
    REFERENCES [dbo].[Games]
        ([idGame])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MatchsHis__idGam__2D27B809'
CREATE INDEX [IX_FK__MatchsHis__idGam__2D27B809]
ON [dbo].[MatchsHistory]
    ([idGame]);
GO

-- Creating foreign key on [idPlayer] in table 'MatchsHistory'
ALTER TABLE [dbo].[MatchsHistory]
ADD CONSTRAINT [FK__MatchsHis__idPla__2E1BDC42]
    FOREIGN KEY ([idPlayer])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MatchsHis__idPla__2E1BDC42'
CREATE INDEX [IX_FK__MatchsHis__idPla__2E1BDC42]
ON [dbo].[MatchsHistory]
    ([idPlayer]);
GO

-- Creating foreign key on [receives] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK__Request__receive__778AC167]
    FOREIGN KEY ([receives])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Request__receive__778AC167'
CREATE INDEX [IX_FK__Request__receive__778AC167]
ON [dbo].[Requests]
    ([receives]);
GO

-- Creating foreign key on [senders] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK__Request__senders__76969D2E]
    FOREIGN KEY ([senders])
    REFERENCES [dbo].[Players]
        ([idPlayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Request__senders__76969D2E'
CREATE INDEX [IX_FK__Request__senders__76969D2E]
ON [dbo].[Requests]
    ([senders]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------