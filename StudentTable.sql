CREATE PROCEDURE sp_GetStudentById
@Id INT
AS 
BEGIN
SELECT
Id,
Name,
Email,
MobileNumber,
StateId,
Gender,
DOB
FROM StudentInformation
WHERE Id = @id;
END


SP_GETALLSTUDENT





CREATE PROCEDURE sp_GetAllStudent
AS
BEGIN
SELECT
Id,
Name,
Email,
MobileNumber,
StateId,
Gender,
DOB
FROM StudentInformation;
END



CREATE PROCEDURE sp_DeleteStudent
@Id INT
AS
BEGIN
DELETE FROM StudentInformation
WHERE Id = @Id;
END
SP_getallstudent

CREATE PROCEDURE sp_UpdateStudent
@Id INT,
@Name NVARCHAR(100),
@Email NVARCHAR (100),
@MobileNumber VARCHAR(20),
@StateId INT,
@Gender NVARCHAR(10),
@DOB DATE
AS
BEGIN
UPDATE StudentInformation 
SET
Name = @Name,
Email = @Email,
@MobileNumber = @MobileNumber,
StateId = @StateId,
Gender = @Gender,
DOB = @DOB
WHERE Id = @Id;
END


CREATE PROCEDURE sp_AddStudent
@Name NVARCHAR(100),
@Email NVARCHAR(100),
@MobileNumber VARCHAR(20),
@StateId INT,
@Gender NVARCHAR(10),
@DOB NVARCHAR(50)
AS
BEGIN
INSERT INTO StudentInformation(Name,Email,MobileNumber,StateId,Gender,DOB)
VALUES (@Name,@Email,@MobileNumber,@StateId,@Gender,@DOB)
END

CREATE TABLE StudentInformation(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Email VARCHAR(100) UNIQUE NOT NULL,
MobileNumber VARCHAR(100) NOT NULL,
StateId INT NOT NULL,
Gender VARCHAR(10) NOT NULL,
DOB DATE NOT NULL);

DROP table StudentInformation
DROP PROCEDURE sp_DeleteStudent
DROP PROCEDURE sp_GetStudentById
DROP PROCEDURE sp_AddStudent
DROP PROCEDURE sp_UpdateStudent
DROP PROCEDURE sp_GetAllStudent


CREATE TABLE States(
StateId INT PRIMARY KEY IDENTITY(1,1),
StateName VARCHAR(100))




CREATE PROCEDURE sp_States
AS
BEGIN
INSERT INTO States(StateName)
VALUES
('Andhra Pradesh'),
('Assam'),
('Goa'),
('Haryana'),
('Kerala'),
('Manipur'),
('Tamil Nadu'),
('Punjab'),
('Rajasthan'),
('Uttar Pradesh'),
('Sikkim'),
('West Bengal'),
('Uttarakhand');
END
DROP PROCEDURE sp_States

CREATE PROCEDURE sp_GetStates
AS
BEGIN
SELECT StateName FROM States
END


TRUNCATE TABLE StudentInformation;