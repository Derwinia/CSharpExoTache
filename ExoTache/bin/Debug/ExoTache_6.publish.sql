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
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

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
Use ExoTache

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

insert into Tache (Nom, Categorie, Description, DateCreation, DateFinPrevu, DateFinReel, PersonneAssignee) Values
('ViderPoubelle',1,'Descend et vide les poubelles de la salle', '2022-06-27 08:00:00','2022-06-27 16:00:00','2022-06-27 17:00:00',1),
('EffacerTableau',2,'Effacer et nettoyer les tableaux', '2022-06-27 08:00:00','2022-06-27 16:00:00','2022-06-27 17:00:00',2),
('Csharp',3,'Programmer en Csharp', '2022-03-26 08:00:00','2022-04-07 16:00:00',null,3),
('HTML/CSS',4,'Programmer en HTML/CSS', '2022-04-10 08:00:00','2022-04-18 16:00:00',null,4),
('JavaScript',1,'Programmer en JavaScript', '2022-04-21 08:00:00','2022-05-07 16:00:00',null,5),
('Pion',2,'Créer et préparer le pion', '2022-05-01 08:00:00','2022-06-1 16:00:00',null,6),
('Programme',3,'Créer le programme principale', '2022-05-01 08:00:00','2022-06-10 16:00:00',null,7),
('Manifeste',4,'Ecrire le manifeste et l envoyer', '2022-05-01 08:00:00','2022-06-20 16:00:00',null,8);

GO

GO
PRINT N'Mise à jour terminée.';


GO
