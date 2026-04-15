--create database Company 

USE Company;

--CREATE TABLE Employees (
--    EmployeeID INT PRIMARY KEY,
--    FirstName VARCHAR(50),
--    LastName VARCHAR(50),
--    Email VARCHAR(100),
--    PhoneNumber VARCHAR(20),
--    HireDate DATE,
--    JobTitle VARCHAR(50),
--    Salary DECIMAL(10,2),
--    Department VARCHAR(50)
--);

--INSERT INTO Employees VALUES
--(1, 'Ali', 'Mammadov', 'ali.mammadov@company.az', '+994501234567', '2019-05-15', 'Software Engineer', 2500.00, 'IT'),
--(2, 'Leyla', 'Hasanova', 'leyla.hasanova@company.az', '+994502345678', '2020-08-20', 'HR Specialist', 1800.00, 'HR'),
--(3, 'Elnur', 'Aliyev', 'elnur.aliyev@company.az', '+994503456789', '2021-02-10', 'Accountant', 2200.00, 'Finance'),
--(4, 'Nigar', 'Guliyeva', 'nigar.guliyeva@company.az', '+994504567890', '2018-11-01', 'IT Manager', 3200.00, 'IT'),
--(5, 'Tural', 'Huseynov', 'tural.huseynov@company.az', '+994505678901', '2022-07-12', 'Junior Developer', 1600.00, 'IT'),
--(6, 'Sevinc', 'Mahmudova', 'sevinc.mahmudova@company.az', '+994506789012', '2023-01-25', 'Finance Analyst', 1450.00, 'Finance');

--SELECT Query-lər:

SELECT * FROM Employees;

--SELECT * FROM Employees WHERE Salary > 2000;

--SELECT * FROM Employees WHERE Department = 'IT';

--SELECT * FROM Employees ORDER BY Salary DESC;

--SELECT FirstName, Salary FROM Employees;

--SELECT * FROM Employees WHERE HireDate > '2020-12-31';

--SELECT * FROM Employees WHERE Email LIKE '%company.az%';

--Aggregate Functions (Toplama funksiyaları):

--SELECT MAX(Salary) AS HighestSalary FROM Employees;

--SELECT MIN(Salary) AS LowestSalary FROM Employees;

--SELECT AVG(Salary) AS AverageSalary FROM Employees;

--SELECT COUNT(*) AS TotalEmployees FROM Employees;

--SELECT SUM(Salary) AS TotalSalary FROM Employees;

--GROUP BY Query-lər:

--SELECT Department, COUNT(*) AS EmployeeCount FROM Employees GROUP BY Department;

--SELECT Department, AVG(Salary) AS AverageSalary FROM Employees GROUP BY Department;

--SELECT Department, MAX(Salary) AS HighestSalary FROM Employees GROUP BY Department;

--UPDATE Query-lər:

--UPDATE Employees SET Salary = 2800.00 WHERE EmployeeID = 1;

--UPDATE Employees SET Salary = Salary * 1.10 WHERE Department = 'IT';

--UPDATE Employees SET JobTitle = 'HR Meneceri' WHERE FirstName = 'Leyla' AND LastName = 'Hasanova';

--DELETE Query-lər:

--DELETE FROM Employees WHERE EmployeeID = 5;

--DELETE FROM Employees WHERE Salary < 1500;

--Əlavə:

--SELECT * FROM Employees WHERE FirstName LIKE '%a%';

--SELECT * FROM Employees WHERE Salary BETWEEN 2000 AND 2500;

--SELECT * FROM Employees WHERE Department IN ('Finance', 'IT');