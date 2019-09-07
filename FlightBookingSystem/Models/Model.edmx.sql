
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/07/2019 18:29:46
-- Generated from EDMX file: C:\Users\61402\source\repos\FlightBookingSystem\FlightBookingSystem\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingsFlights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_BookingsFlights];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentsFlights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_CommentsFlights];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Flights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flights];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Flights'
CREATE TABLE [dbo].[Flights] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [departure] nvarchar(max)  NULL,
    [departureDate] datetime  NULL,
    [destination] nvarchar(max)  NULL,
    [arrivalDate] datetime  NULL,
    [flightNumber] nvarchar(max)  NULL,
    [totalSeats] int  NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [seats] int  NULL,
    [status] nvarchar(max)  NULL,
    [price] int  NULL,
    [rating] int  NULL,
    [FlightsId] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [content] nvarchar(max)  NULL,
    [rating] int  NULL,
    [FlightsId] int  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [path] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [BookingsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [PK_Flights]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FlightsId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_BookingsFlights]
    FOREIGN KEY ([FlightsId])
    REFERENCES [dbo].[Flights]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingsFlights'
CREATE INDEX [IX_FK_BookingsFlights]
ON [dbo].[Bookings]
    ([FlightsId]);
GO

-- Creating foreign key on [FlightsId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_CommentsFlights]
    FOREIGN KEY ([FlightsId])
    REFERENCES [dbo].[Flights]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentsFlights'
CREATE INDEX [IX_FK_CommentsFlights]
ON [dbo].[Comments]
    ([FlightsId]);
GO

-- Creating foreign key on [BookingsId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_ImagesBookings]
    FOREIGN KEY ([BookingsId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImagesBookings'
CREATE INDEX [IX_FK_ImagesBookings]
ON [dbo].[Files]
    ([BookingsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------