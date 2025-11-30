use ExamPlannerDB;

drop table if exists Teachers;
drop table if exists Classes;
drop table if exists Exams;
drop table if exists Designations;

create table Teachers (
	TeacherID int primary key identity(1,1) not null,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Initials varchar(5) not null,
	Email varchar(100) unique not null
);

create table Classes (
	ClassID int primary key identity(1,1) not null,
	ClassName varchar(100) not null
);

create table Exams (
	ExamID int primary key identity(1,1) not null,
	ClassID int foreign key references Classes(ClassID),
	ExamName varchar(100) not null,	
	EstimatedNumberStudents int not null,
	TypeOfExam varchar(1) not null, -- 'E'(External) or 'I'(Internal)
	Supervision bit not null,  -- 1 = Yes, 0 = No
	TypeOfSupervisor varchar(50) not null,
	ExamSubmissionDate date not null,
	ExamDate date not null,
	ExamStartTime time not null,
	ExamEndTime time not null,
	ReExamSubmissionDate date not null,
	ReExamDate date not null,
	ReExamStartTime time not null,
	ReExamEndTime time not null,
	constraint chk_EstimatedNumberStudents check (EstimatedNumberStudents > 0),
	constraint chk_TypeOfExam check (TypeOfExam in ('E', 'I')),	
	constraint chk_Supervision check ((Supervision = 1 and TypeOfSupervisor <> 'Yes') or (Supervision = 0 and TypeOfSupervisor = 'No')),
	constraint chk_ReExamSubmissionDate check (ExamSubmissionDate < ReExamSubmissionDate),
	constraint chk_ExamDate check (ExamDate < ReExamDate),	
	constraint chk_ExamTimes check (ExamStartTime < ExamEndTime),	
	constraint chk_ReExamTimes check (ReExamStartTime < ReExamEndTime)
);

create table Designations (
	DesignationID int primary key identity(1,1) not null,
	TeacherID int foreign key references Teachers(TeacherID),
	ExamId int foreign key references Exams(ExamID),
	DesignationRole varchar(100) not null
);