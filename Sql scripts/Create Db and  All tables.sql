CREATE DATABASE RetroDbTest;

CREATE TABLE [dbo].[Artists]
(
	[ArtistId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[Name] NVARCHAR(50) NOT NULL,
	[AlbumVkId] INT NOT NULL,
	[LanguageArtistId] INT NOT NULL,
	[PhotoUrl] VARCHAR(MAX) NOT NULL,
)

CREATE TABLE dbo.[Audios]
(
	[AudioId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ArtistName] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Url] NVARCHAR(MAX) NOT NULL,
	[ArtistId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Artists(ArtistId)
)

CREATE TABLE [dbo].[AspNetUsers] 
(
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[AspNetRoles] 
(
    [Id]            NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (256) NOT NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[AspNetUserRoles] 
(
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE [dbo].[AspNetUserLogins] 
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE [dbo].[AspNetUserClaims] 
(
    [Id]         INT            NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
)


