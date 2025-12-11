use ExamPlannerDB;

--Add 1 by 1 otherwise not working;

insert into Teachers (FirstName, LastName, Initials, Email) values
('Anna', 'Jensen', 'AJ', 'anna.jensen@school.dk'),
('Mark', 'Thomsen', 'MT', 'mark.thomsen@school.dk');

insert into Classes (ClassName) values
('DAT-RO-F-V25B'),
('DATO-ROS-BA-B25S'); 

insert into Exams (
  ClassID, ExamName, EstimatedNumberStudents, TypeOfExam, Supervision, TypeOfSupervisor,
  ExamSubmissionDate, ExamDate, ExamStartTime, ExamEndTime,
  ReExamSubmissionDate, ReExamDate, ReExamStartTime, ReExamEndTime
) values (
  (select ClassID from Classes where ClassName = 'C# Fundamentals'),
  'C# Fundamentals Midterm',
  25,
  'I',
  1,
  'Lead Instructor',
  '2026-02-15',
  '2026-03-01',
  '09:00:00',
  '11:00:00',
  '2026-03-10',
  '2026-03-15',
  '09:00:00',
  '11:00:00'
);

insert into Exams (
  ClassID, ExamName, EstimatedNumberStudents, TypeOfExam, Supervision, TypeOfSupervisor,
  ExamSubmissionDate, ExamDate, ExamStartTime, ExamEndTime,
  ReExamSubmissionDate, ReExamDate, ReExamStartTime, ReExamEndTime
) values (
  (select ClassID from Classes where ClassName = 'ASP.NET Core Web API'),
  'ASP.NET Core Project Defense',
  18,
  'E',
  0,
  'No',
  '2026-02-20',
  '2026-03-05',
  '13:00:00',
  '14:30:00',
  '2026-03-12',
  '2026-03-20',
  '13:00:00',
  '14:30:00'
);


INSERT INTO Designations (TeacherID, ExamID, DesignationRole)
VALUES
(
  1,  -- Anna Jensen
  (SELECT ExamID FROM Exams WHERE ExamName = 'C# Fundamentals Midterm'),
  'Teacher'
),
(
  2,  -- Mark Thomsen
  (SELECT ExamID FROM Exams WHERE ExamName = 'ASP.NET Core Project Defense'),
  'Censor'
);