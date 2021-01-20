CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(40)
)

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students ([Name]) VALUES
('Mila'),                                      
('Toni'),
('Ron')

INSERT INTO Exams([Name]) VALUES
('SpringMVC'),                                      
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
(1,	101),
(1,	102),
(2,	101),
(3,	103),
(2,	102),
(2,	103)
