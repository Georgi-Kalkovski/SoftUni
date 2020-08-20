CREATE DATABASE School
USE School

-- Problem 01

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT NOT NULL CHECK(Age > 0),
[Address] NVARCHAR(50),
Phone NVARCHAR(10)
)
CREATE TABLE Subjects
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL
)

CREATE TABLE StudentsSubjects
(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
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
Grade DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
CONSTRAINT PK_StudentsExamsPK  PRIMARY KEY (StudentId, ExamId)
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
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
CONSTRAINT PK_StudentsTeachersPK  PRIMARY KEY (StudentId, TeacherId)
)

-- Problem 02

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId)
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects(Name, Lessons)
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

-- Problem 03

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) 
      AND Grade >= 5.50

-- Problem 04

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

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
  (FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName) AS [Full Name],
  [Address]
FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY 
  FirstName,
  LastName,
  [Address]

-- Problem 07

SELECT
  FirstName,
  [Address],
  Phone
FROM Students
WHERE Phone LIKE '42%'
      AND MiddleName IS NOT NULL
ORDER BY
  FirstName

-- Problem 08

SELECT
  s.FirstName,
  s.LastName,
  COUNT(t.Id) AS TeachersCount
FROM StudentsTeachers AS st
JOIN Students AS s ON s.Id = st.StudentId
JOIN Teachers AS t ON t.Id = st.TeacherId
GROUP BY 
  s.FirstName,
  s.LastName

-- Problem 09

SELECT
  (t.FirstName + ' ' + t.LastName) AS FullName,
  CONCAT(s.[Name], '-' ,s.Lessons) AS Subjects,
  COUNT(st.StudentId) AS Students
FROM Teachers AS t
JOIN Subjects AS s ON s.Id = t.SubjectId
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY 
  t.FirstName,
  t.LastName,
  s.[Name], 
  Lessons
ORDER BY 
  COUNT(StudentId) DESC, 
  FullName,
  Subjects

-- Problem 10

SELECT 
  (FirstName + ' ' + LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS sx ON sx.StudentId = s.Id
WHERE sx.ExamId IS NULL
ORDER BY
  [Full Name]

-- Problem 11

SELECT TOP(10)
  FirstName,
  LastName,
  COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY 
  FirstName, 
  LastName
ORDER BY  
  StudentsCount DESC, 
  FirstName, 
  LastName

-- Problem 12

SELECT TOP(10)
  FirstName,
  LastName,
  FORMAT(AVG(Grade), 'F2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY 
  FirstName, 
  LastName
ORDER BY  
  AVG(Grade) DESC,
  FirstName, 
  LastName

-- Problem 13

SELECT 
  FirstName, 
  LastName,
  Grade 
  FROM (SELECT 
           FirstName, 
		   LastName,
		   Grade, 
           ROW_NUMBER() OVER(PARTITION BY FirstName 
		                     ORDER BY Grade DESC) AS [Rank] 
        FROM Students AS s
	    JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId) AS t
WHERE [Rank] = 2
ORDER BY  
  FirstName, 
  LastName

-- Problem 14

SELECT 
  CONCAT(s.FirstName,  + ISNULL ((' ' + s.MiddleName),''),' ', s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY
  [Full Name]
