use ExamPlannerDB;

create table Teachers (
	TeacherID int primary key auto_increment ID,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Initials varchar(5) not null,
	Email varchar(100) unique not null
);

create table Exams (
	ExamID int primary key auto_increment ID,
	ExamName varchar(100) not null,
	ExamDate date not null,
	StartTime time not null,
	EndTime time not null,
	EstimatedNumberStudents int not null,
	TypeOfExam varchar(1) not null,
	Supervision boolean not null,
	TypeOfSupervisor varchar(50) not null,
	ExamSubmissionDate date not null,
	ReExamSubmissionDate date,
	ReExamDate date,
	ReExamStartTime time,
	ReExamEndTime time
);

create table Designations (
	DesignationID int primary key auto_increment ID,
	TeacherID int foreign key references Teachers(TeacherID),
	ExamId int foreign key references Exams(ExamID),
	DesignationRole varchar(100) not null
);

create table Classes (
	ClassID int primary key auto_increment ID,
	ClassName varchar(100) not null
);