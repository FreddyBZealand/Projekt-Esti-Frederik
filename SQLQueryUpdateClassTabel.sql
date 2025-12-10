use ExamPlannerDB;

UPDATE Classes
SET ClassName = 'DAT-RO-F-V25B' 
WHERE ClassID = 1;

use ExamPlannerDB;

UPDATE Classes
SET ClassName = 'DATO-ROS-BA-B25S' 
WHERE ClassID = 2;

UPDATE Exams
SET ExamName = 'DAT-RO-F-V25B' 
WHERE ExamID = 1;

UPDATE Exams
SET ExamName = 'DATO-ROS-BA-B25S' 
WHERE ExamID = 3;