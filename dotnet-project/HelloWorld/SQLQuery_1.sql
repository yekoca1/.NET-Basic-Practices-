USE master
DROP DATABASE DotNetCourseDatabase

CREATE DATABASE DotNetCourseDatabase
GO
 
USE DotNetCourseDatabase
GO
 
CREATE SCHEMA TutorialAppSchema
GO
 
CREATE TABLE TutorialAppSchema.Computer(
    ComputerId INT IDENTITY(1,1) PRIMARY KEY, 
    Motherboard NVARCHAR(50),
    CPUCores INT,
    HasWifi BIT,
    HasLTE BIT,
    ReleaseDate DATE,
    Price DECIMAL(18,4),
    VideoCard NVARCHAR(50)
);

SELECT * FROM TutorialAppSchema.Computer

SELECT GETDATE()

INSERT INTO TutorialAppSchema.Computer(
    MotherBoard, 
    HasWiFi,
    HasLTE,
    ReleaseDate,
    Price,
    VideoCard
)
VALUES(
    'Z690',          -- MotherBoard (metin)
    1,               -- HasWiFi (1 = True, 0 = False)
    1,               -- HasLTE (1 = True, 0 = False)
    '2024-10-02',    -- ReleaseDate (yyyy-MM-dd formatı)
    14.055,          -- Price (ondalık sayı, . kullanılır)
    'RTX 2060'       -- VideoCard (metin)
);


