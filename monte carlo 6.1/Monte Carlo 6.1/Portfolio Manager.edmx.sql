
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/20/2016 13:33:09
-- Generated from EDMX file: C:\Users\Yutong\Desktop\Monte Carlo 6.1\Monte Carlo 6.1\Portfolio Manager.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Portfolio_Manager2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InstrumentInstType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Instruments] DROP CONSTRAINT [FK_InstrumentInstType];
GO
IF OBJECT_ID(N'[dbo].[FK_InstrumentTrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trades] DROP CONSTRAINT [FK_InstrumentTrade];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Instruments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Instruments];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[Trades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trades];
GO
IF OBJECT_ID(N'[dbo].[InterestRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterestRates];
GO
IF OBJECT_ID(N'[dbo].[InstTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InstTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Instruments'
CREATE TABLE [dbo].[Instruments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NULL,
    [Ticker] nvarchar(max)  NOT NULL,
    [Exchange] nvarchar(max)  NOT NULL,
    [Strike] float  NOT NULL,
    [Tenor] float  NOT NULL,
    [IsCall] bit  NULL,
    [InstTypeId] int  NOT NULL,
    [Barrier] float  NULL,
    [Rebate] float  NULL,
    [PriceId] int  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [ClosingPrice] float  NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Trades'
CREATE TABLE [dbo].[Trades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsBuy] bit  NOT NULL,
    [Quantity] float  NOT NULL,
    [Price] float  NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [InstrumentId] int  NOT NULL
);
GO

-- Creating table 'InterestRates'
CREATE TABLE [dbo].[InterestRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tenor] float  NOT NULL,
    [Rate] float  NOT NULL
);
GO

-- Creating table 'InstTypes'
CREATE TABLE [dbo].[InstTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [PK_Instruments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [PK_Trades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InterestRates'
ALTER TABLE [dbo].[InterestRates]
ADD CONSTRAINT [PK_InterestRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InstTypes'
ALTER TABLE [dbo].[InstTypes]
ADD CONSTRAINT [PK_InstTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InstTypeId] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_InstrumentInstType]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentInstType'
CREATE INDEX [IX_FK_InstrumentInstType]
ON [dbo].[Instruments]
    ([InstTypeId]);
GO

-- Creating foreign key on [InstrumentId] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [FK_InstrumentTrade]
    FOREIGN KEY ([InstrumentId])
    REFERENCES [dbo].[Instruments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentTrade'
CREATE INDEX [IX_FK_InstrumentTrade]
ON [dbo].[Trades]
    ([InstrumentId]);
GO

-- Creating foreign key on [PriceId] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_InstrumentPrice]
    FOREIGN KEY ([PriceId])
    REFERENCES [dbo].[Prices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentPrice'
CREATE INDEX [IX_FK_InstrumentPrice]
ON [dbo].[Instruments]
    ([PriceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------