/*
Script de déploiement pour ExoTache

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ExoTache"
:setvar DefaultFilePrefix "ExoTache"
:setvar DefaultDataPath "C:\Users\denis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\ExoTache\"
:setvar DefaultLogPath "C:\Users\denis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\ExoTache\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Suppression de Clé étrangère [dbo].[FK_Tache_Categorie]...';


GO
ALTER TABLE [dbo].[Tache] DROP CONSTRAINT [FK_Tache_Categorie];


GO
PRINT N'Suppression de Clé étrangère [dbo].[FK_Tache_Personne]...';


GO
ALTER TABLE [dbo].[Tache] DROP CONSTRAINT [FK_Tache_Personne];


GO
PRINT N'Début de la régénération de la table [dbo].[Categorie]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Categorie] (
    [Id]  INT          IDENTITY (1, 1) NOT NULL,
    [nom] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Categorie])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Categorie] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Categorie] ([Id], [nom])
        SELECT   [Id],
                 [nom]
        FROM     [dbo].[Categorie]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Categorie] OFF;
    END

DROP TABLE [dbo].[Categorie];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Categorie]', N'Categorie';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Début de la régénération de la table [dbo].[Personne]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Personne] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Nom]    VARCHAR (50) NOT NULL,
    [Prenom] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Personne])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Personne] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Personne] ([Id], [Nom], [Prenom])
        SELECT   [Id],
                 [Nom],
                 [Prenom]
        FROM     [dbo].[Personne]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Personne] OFF;
    END

DROP TABLE [dbo].[Personne];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Personne]', N'Personne';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Début de la régénération de la table [dbo].[Tache]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Tache] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Nom]              VARCHAR (50)  NOT NULL,
    [Categorie]        INT           NOT NULL,
    [Description]      VARCHAR (50)  NOT NULL,
    [DateCreation]     DATETIME2 (7) NOT NULL,
    [DateFinPrevu]     DATETIME2 (7) NOT NULL,
    [DateFinReel]      DATETIME2 (7) NULL,
    [PersonneAssignee] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Tache])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tache] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Tache] ([Id], [Nom], [Categorie], [Description], [DateCreation], [DateFinPrevu], [DateFinReel], [PersonneAssignee])
        SELECT   [Id],
                 [Nom],
                 [Categorie],
                 [Description],
                 [DateCreation],
                 [DateFinPrevu],
                 [DateFinReel],
                 [PersonneAssignee]
        FROM     [dbo].[Tache]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tache] OFF;
    END

DROP TABLE [dbo].[Tache];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Tache]', N'Tache';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Tache_Categorie]...';


GO
ALTER TABLE [dbo].[Tache] WITH NOCHECK
    ADD CONSTRAINT [FK_Tache_Categorie] FOREIGN KEY ([Categorie]) REFERENCES [dbo].[Categorie] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Tache_Personne]...';


GO
ALTER TABLE [dbo].[Tache] WITH NOCHECK
    ADD CONSTRAINT [FK_Tache_Personne] FOREIGN KEY ([PersonneAssignee]) REFERENCES [dbo].[Personne] ([Id]);


GO
PRINT N'Création de Contrainte de validation [dbo].[ck_Tache_DateFinReel]...';


GO
ALTER TABLE [dbo].[Tache] WITH NOCHECK
    ADD CONSTRAINT [ck_Tache_DateFinReel] CHECK (DateFinReel > DateCreation);


GO
PRINT N'Création de Contrainte de validation [dbo].[ck_Tache_DateFinPrevu]...';


GO
ALTER TABLE [dbo].[Tache] WITH NOCHECK
    ADD CONSTRAINT [ck_Tache_DateFinPrevu] CHECK (DateFinPrevu > DateCreation);


GO
Use ExoTache

insert into Tache (Nom, Categorie, Description, DateCreation, DateFinPrevu, DateFinReel, PersonneAssignee) Values
('ViderPoubelle',1,'Descend et vide les poubelles de la salle', '2022-06-27 08:00:00','2022-06-27 16:00:00','2022-06-27 17:00:00',1),
('EffacerTableau',2,'Effacer et nettoyer les tableaux', '2022-06-27 08:00:00','2022-06-27 16:00:00','2022-06-27 17:00:00',2),
('Csharp',3,'Programmer en Csharp', '2022-03-26 08:00:00','2022-04-07 16:00:00',null,3),
('HTML/CSS',4,'Programmer en HTML/CSS', '2022-04-10 08:00:00','2022-04-18 16:00:00',null,4),
('JavaScript',1,'Programmer en JavaScript', '2022-04-21 08:00:00','2022-05-07 16:00:00',null,5),
('Pion',2,'Créer et préparer le pion', '2022-05-01 08:00:00','2022-06-1 16:00:00',null,6),
('Programme',3,'Créer le programme principale', '2022-05-01 08:00:00','2022-06-10 16:00:00',null,7),
('Manifeste',4,'Ecrire le manifeste et l envoyer', '2022-05-01 08:00:00','2022-06-20 16:00:00',null,8);

insert into Personne (Nom, Prenom) Values
('Callin','Denis'),
('Dubrin','Benjamin'),
('Albin','Nabil'),
('Lozer','Ryan'),
('Mabite','Bryan'),
('Varumby','Antonio'),
('PoigneeDePorte','Nathalie'),
('Faucon','Sylvain'),
('Commander','Mailys'),
('Touriste','Paulin'),
('Barbaux','Olivier');

insert into Categorie (nom) values
('Entretien'),
('Programmer'),
('ICC'),
('Rendez-Vous');
GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Tache] WITH CHECK CHECK CONSTRAINT [FK_Tache_Categorie];

ALTER TABLE [dbo].[Tache] WITH CHECK CHECK CONSTRAINT [FK_Tache_Personne];

ALTER TABLE [dbo].[Tache] WITH CHECK CHECK CONSTRAINT [ck_Tache_DateFinReel];

ALTER TABLE [dbo].[Tache] WITH CHECK CHECK CONSTRAINT [ck_Tache_DateFinPrevu];


GO
PRINT N'Mise à jour terminée.';


GO
