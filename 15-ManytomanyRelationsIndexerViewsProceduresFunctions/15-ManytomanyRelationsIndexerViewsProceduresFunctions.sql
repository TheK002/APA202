--CREATE DATABASE CompanyMM;

--USE CompanyMM;

--CREATE TABLE Employees (
--    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
--    FirstName NVARCHAR(50) NOT NULL,
--    LastName NVARCHAR(50) NOT NULL,
--    BirthDate DATE NOT NULL,
--    Email NVARCHAR(100) UNIQUE NOT NULL,
--    CHECK (BirthDate > '1920-01-01') 
--);

--CREATE TABLE Projects (
--    ProjectID INT PRIMARY KEY IDENTITY(1,1),
--    ProjectName NVARCHAR(100) NOT NULL,
--    StartDate DATE NOT NULL,
--    EndDate DATE NOT NULL,
--    CHECK (EndDate >= StartDate) 
--);

--CREATE TABLE EmployeeProjects (
--    EmployeeID INT,
--    ProjectID INT,
--    AssignedDate DATE NOT NULL,
--    PRIMARY KEY (EmployeeID, ProjectID),
--    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
--    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE
--);


--INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
--(N'Ali', N'Mammadov', '1985-04-12', 'ali.mammadov@example.com'),
--(N'Nigar', N'Aliyeva', '1990-07-23', 'nigar.aliyeva@example.com'),
--(N'Elvin', N'Hasanov', '1992-11-02', 'elvin.hasanov@example.com'),
--(N'Leyla', N'Qasimova', '1988-09-15', 'leyla.qasimova@example.com'),
--(N'Tural', N'Ismayilov', '1995-01-30', 'tural.ismayilov@example.com');



--INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
--(N'AI Platform', '2024-01-10', '2024-12-20'),
--(N'Mobile App', '2024-02-01', '2024-10-15'),
--(N'Data Warehouse', '2024-03-05', '2025-01-10');


--INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate) VALUES
--(1, 1, '2024-01-15'),
--(1, 2, '2024-02-10'),
--(2, 1, '2024-01-20'),
--(2, 3, '2024-03-10'),
--(3, 2, '2024-02-15'),
--(4, 2, '2024-02-20'),
--(4, 3, '2024-03-15'),
--(5, 1, '2024-01-25');

--SELECT * FROM Employees;

--SELECT * FROM Projects; 

--SELECT e.EmployeeID, e.FirstName, e.LastName, p.ProjectName
--FROM Employees e
--JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
--JOIN Projects p ON ep.ProjectID = p.ProjectID
--ORDER BY e.EmployeeID;

--SELECT p.ProjectID, p.ProjectName, COUNT(ep.EmployeeID) AS EmployeeCount
--FROM Projects p
--LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
--GROUP BY p.ProjectID, p.ProjectName;

--SELECT e.EmployeeID, e.FirstName, e.LastName, COUNT(ep.ProjectID) AS ProjectCount
--FROM Employees e
--JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
--GROUP BY e.EmployeeID, e.FirstName, e.LastName
--HAVING COUNT(ep.ProjectID) > 2;

--CREATE VIEW EmployeeProjectView AS
--SELECT 
--    e.EmployeeID,
--    CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
--    p.ProjectID,
--    p.ProjectName,
--    ep.AssignedDate
--FROM Employees e
--JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
--JOIN Projects p ON ep.ProjectID = p.ProjectID;

--SELECT * FROM EmployeeProjectView WHERE EmployeeID = 1;

--CREATE PROCEDURE sp_AssignEmployeeToProject
--    @empId INT,
--    @projId INT
--AS
--BEGIN
--    IF NOT EXISTS (
--        SELECT 1 FROM EmployeeProjects 
--        WHERE EmployeeID = @empId AND ProjectID = @projId
--    )
--    BEGIN
--        INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
--        VALUES (@empId, @projId, GETDATE());
--        PRINT 'Assignment added successfully.';
--    END
--    ELSE
--    BEGIN
--        PRINT 'Assignment already exists.';
--    END
--END;

--CREATE FUNCTION fn_GetProjectCount(@empId INT)
--RETURNS INT
--AS
--BEGIN
--    DECLARE @projectCount INT;
    
--    SELECT @projectCount = COUNT(*)
--    FROM EmployeeProjects
--    WHERE EmployeeID = @empId;
    
--    RETURN @projectCount;
--END;

--SELECT 
--    EmployeeID, 
--    FirstName, 
--    LastName, 
--    dbo.fn_GetProjectCount(EmployeeID) AS ProjectCount
--FROM Employees;
--EXEC sp_AssignEmployeeToProject @empId = 3, @projId = 3;

--SELECT * FROM EmployeeProjectView WHERE EmployeeID = 3;

--DELETE FROM EmployeeProjects WHERE EmployeeID = 4;

--SELECT * FROM EmployeeProjectView WHERE EmployeeID = 4;
