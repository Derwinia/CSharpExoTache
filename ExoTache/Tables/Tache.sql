CREATE TABLE [dbo].[Tache]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Nom] VARCHAR(50) NOT NULL, 
    [Categorie] INT NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [DateCreation] DATETIME2 NOT NULL, 
    [DateFinPrevu] DATETIME2 NOT NULL, 
    [DateFinReel] DATETIME2 NULL, 
    [PersonneAssignee] INT NOT NULL, 
    CONSTRAINT [FK_Tache_Categorie] FOREIGN KEY ([Categorie]) REFERENCES [Categorie]([Id]), 
    CONSTRAINT [FK_Tache_Personne] FOREIGN KEY ([PersonneAssignee]) REFERENCES [Personne]([Id]),
    CONSTRAINT [ck_Tache_DateFinReel] check (DateFinReel > DateCreation),
    CONSTRAINT [ck_Tache_DateFinPrevu] check (DateFinPrevu > DateCreation)
)
