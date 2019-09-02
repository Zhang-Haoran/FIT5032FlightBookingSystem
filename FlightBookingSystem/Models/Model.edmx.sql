
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/02/2019 18:58:15
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [role] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [price] int  NOT NULL,
    [rating] int  NOT NULL,
    [UsersId] int  NOT NULL,
    [FlightsId] int  NOT NULL
);
GO

-- Creating table 'Flights'
CREATE TABLE [dbo].[Flights] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [departure] nvarchar(max)  NOT NULL,
    [departureDate] datetime  NOT NULL,
    [destination] nvarchar(max)  NOT NULL,
    [arrivalDate] datetime  NOT NULL,
    [flightNumber] nvarchar(max)  NOT NULL,
    [totalSeats] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [PK_Flights]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsersId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_UsersBookings]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersBookings'
CREATE INDEX [IX_FK_UsersBookings]
ON [dbo].[Bookings]
    ([UsersId]);
GO

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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------