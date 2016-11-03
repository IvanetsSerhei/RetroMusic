﻿CREATE DATABASE RetroDbTest;

CREATE TABLE [dbo].[Artists]
(
	[ArtistId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[Name] NVARCHAR(50) NOT NULL,
	[AlbumVkId] INT NOT NULL,
	[LanguageArtistId] INT NOT NULL
)

CREATE TABLE dbo.[Audios]
(
	[AudioId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ArtistName] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Url] NVARCHAR(MAX) NOT NULL,
	[ArtistId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Artists(ArtistId)
)