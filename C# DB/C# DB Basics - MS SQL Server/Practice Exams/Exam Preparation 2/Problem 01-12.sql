
-- Problem 01

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age TINYINT NOT NULL CHECK (Age > 0),
[Address] NVARCHAR(50),
Phone NVARCHAR(10)
)

CREATE TABLE Subjects
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT CHECK (Lessons>0)
)

CREATE TABLE StudentsSubjects
(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams
(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
CONSTRAINT PK_StudentsExamsPK PRIMARY KEY (StudentId,ExamId)
)

CREATE TABLE Teachers
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone NVARCHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL
CONSTRAINT PK_StudentsTeachersPK PRIMARY KEY (StudentId,TeacherId)
)

-- Problem 02

INSERT INTO Teachers
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146,	6),
('Gerrard',	'Lowin', '370 Talisman Plaza', 3324874824, 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

-- Problem 03

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) AND Grade >= 5.50

-- Problem 04

DELETE FROM StudentsTeachers
WHERE TeacherId IN(SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

-- Problem 05

SELECT 
  FirstName,
  LastName,
  Age 
FROM Students
WHERE Age >= 12
ORDER BY 
  FirstName, 
  LastName

-- Problem 06

SELECT 
  s.FirstName,
  s.LastName, 
  COUNT(t.Id) AS [TeachersCount] 
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
JOIN Teachers AS t ON t.Id = st.TeacherId
GROUP BY 
  s.FirstName, 
  s.LastName


-- Problem 07

SELECT 
  (s.FirstName + ' ' + s.LastName) AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

-- Problem 08

SELECT TOP 10 
FirstName AS [First Name], 
LastName AS [Last Name], 
FORMAT(AVG(Grade),'N2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY FirstName,LastName
ORDER BY Grade DESC, FirstName, LastName

-- Problem 09

SELECT CONCAT(COALESCE(FirstName + ' ', ''), 
              COALESCE(MiddleName + ' ', ''), 
              COALESCE(Lastname, '')) AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

-- Problem 10

SELECT s.[Name],AVG(ss.Grade) AS Grade 
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY SubjectId,[Name]
ORDER BY SubjectId

-- Problem 11

GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
  DECLARE @studentExist INT = (SELECT TOP(1) StudentId FROM StudentsExams WHERE StudentId = @studentId);

  IF @studentExist IS NULL
  BEGIN
    RETURN ('The student with provided id does not exist in the school!')
  END
  
  IF @grade > 6.00
  BEGIN
    RETURN ('Grade cannot be above 6.00!')
  END

  DECLARE @studentFirstName NVARCHAR(20) = (SELECT TOP(1) FirstName FROM Students WHERE Id = @studentId);
  DECLARE @biggestGrade DECIMAL(15,2) = @grade + 0.50;
  DECLARE @count INT = (SELECT Count(Grade) FROM StudentsExams
                        WHERE StudentId = @studentId 
						AND Grade >= @grade AND Grade <= @biggestGrade)
  RETURN ('You have to update ' + CAST(@count AS nvarchar(10)) + ' grades for the student ' + @studentFirstName)
END

GO

-- Problem 12

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
DECLARE @studentExists INT = (SELECT Id FROM Students
                   WHERE Id = @StudentId)
IF @studentExists IS NULL
BEGIN
  RAISERROR('This school has no student with the provided id!',16,1)
  RETURN
END

DELETE FROM StudentsExams
WHERE StudentId = 1

DELETE FROM StudentsSubjects
WHERE StudentId = 1

DELETE FROM StudentsTeachers
WHERE StudentId = 1

DELETE FROM Students
WHERE Id = 1

GO