-- Script de création des tables pour SenSoutenance
-- Base de données: soutenance_db

USE soutenance_db;

-- Table Departement
CREATE TABLE IF NOT EXISTS departements (
    IdDepartement INT AUTO_INCREMENT PRIMARY KEY,
    LibelleDepartement VARCHAR(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table AnneeAcademique
CREATE TABLE IF NOT EXISTS anneeAcademiques (
    IdAnneeAcademique INT AUTO_INCREMENT PRIMARY KEY,
    LibelleAnneeAcademique VARCHAR(10) NULL,
    AnneeAcademiqueVal INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table Session
CREATE TABLE IF NOT EXISTS sessions (
    IdSession INT AUTO_INCREMENT PRIMARY KEY,
    LibelleSession VARCHAR(50) NULL,
    IdAnneeAcademique INT NULL,
    CONSTRAINT FK_Session_AnneeAcademique FOREIGN KEY (IdAnneeAcademique)
        REFERENCES anneeAcademiques(IdAnneeAcademique) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table Utilisateur (table de base pour l'héritage TPH)
CREATE TABLE IF NOT EXISTS utilisateurs (
    IdUtilisateur INT AUTO_INCREMENT PRIMARY KEY,
    NomUtilisateur VARCHAR(80) NOT NULL,
    PrenomUtilisateur VARCHAR(80) NOT NULL,
    TelUtilisateur VARCHAR(15) NOT NULL,
    EmailUtilisateur VARCHAR(80) NOT NULL,
    MotDeUtilisateur VARCHAR(300) NOT NULL,
    -- Colonnes pour l'héritage TPH (Table Per Hierarchy)
    Discriminator VARCHAR(128) NOT NULL,
    -- Colonne pour Candidat
    MatriculeCandidat VARCHAR(20) NULL,
    -- Colonne pour Professeur
    SpecialiteProfesseur VARCHAR(80) NULL,
    -- Colonne pour ChefDepartement
    IdDepartement INT NULL,
    CONSTRAINT FK_Utilisateur_Departement FOREIGN KEY (IdDepartement)
        REFERENCES departements(IdDepartement) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table Memoire
CREATE TABLE IF NOT EXISTS memoires (
    IdMemoire INT AUTO_INCREMENT PRIMARY KEY,
    SujetMemoire VARCHAR(500) NOT NULL,
    DocumentMemoire LONGBLOB NULL,
    IdAnneeAcademique INT NULL,
    IdSession INT NULL,
    CONSTRAINT FK_Memoire_AnneeAcademique FOREIGN KEY (IdAnneeAcademique)
        REFERENCES anneeAcademiques(IdAnneeAcademique) ON DELETE SET NULL,
    CONSTRAINT FK_Memoire_Session FOREIGN KEY (IdSession)
        REFERENCES sessions(IdSession) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table Soutenance
CREATE TABLE IF NOT EXISTS soutenances (
    IdSoutenance INT AUTO_INCREMENT PRIMARY KEY,
    DateSoutenance DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    LieuSoutenance VARCHAR(2000) NULL,
    ResultatSoutenance VARCHAR(50) NULL,
    MentionSoutenance VARCHAR(100) NULL,
    ObservationSoutenance VARCHAR(5000) NULL,
    IdMemoire INT NULL,
    CONSTRAINT FK_Soutenance_Memoire FOREIGN KEY (IdMemoire)
        REFERENCES memoires(IdMemoire) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Table __MigrationHistory pour Entity Framework
CREATE TABLE IF NOT EXISTS __MigrationHistory (
    MigrationId VARCHAR(150) NOT NULL PRIMARY KEY,
    ContextKey VARCHAR(300) NOT NULL,
    Model LONGBLOB NOT NULL,
    ProductVersion VARCHAR(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Insérer un admin par défaut pour les tests
INSERT INTO utilisateurs (NomUtilisateur, PrenomUtilisateur, TelUtilisateur, EmailUtilisateur, MotDeUtilisateur, Discriminator)
VALUES ('Admin', 'System', '771234567', 'admin@soutenance.sn', 'admin123', 'Admin');

SELECT 'Tables créées avec succès!' AS Resultat;
