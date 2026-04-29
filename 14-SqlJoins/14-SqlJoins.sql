--CREATE DATABASE TCompany ;


--USE TCompany;

---- Countries tablosu
--CREATE TABLE Countries
--(
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Name NVARCHAR(100) NOT NULL
--);

--CREATE TABLE Cities
--(
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Name NVARCHAR(100) NOT NULL,
--    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
--);

--CREATE TABLE Employees
--(
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Name NVARCHAR(50) NOT NULL,
--    Surname NVARCHAR(50) NOT NULL,
--    Age INT CHECK (Age >= 18),
--    Salary DECIMAL(10,2),
--    Position NVARCHAR(50),
--    IsDeleted BIT DEFAULT 0, 
--    CityId INT FOREIGN KEY REFERENCES Cities(Id)
--);


--SELECT 
--    e.Name,
--    e.Surname,
--    e.Age,
--    e.Salary,
--    e.Position,
--    c.Name AS CityName,
--    co.Name AS CountryName
--FROM Employees e
--INNER JOIN Cities c ON e.CityId = c.Id
--INNER JOIN Countries co ON c.CountryId = co.Id;

--SELECT 
--    e.Name,
--    e.Surname,
--    co.Name AS CountryName
--FROM Employees e
--INNER JOIN Cities c ON e.CityId = c.Id
--INNER JOIN Countries co ON c.CountryId = co.Id
--WHERE e.Salary > 2000;

--INSERT INTO Countries (Name) VALUES 
--('Azərbaycan'),
--('Türkiyə'),
--('Rusiya'),
--('Gürcüstan'),
--('Almaniya');

--INSERT INTO Cities (Name, CountryId) VALUES 
--('Bakı', 1),    
--('Gəncə', 1),
--('Sumqayıt', 1),
--('İstanbul', 2),  
--('Ankara', 2),
--('Moskva', 3),   
--('Tbilisi', 4),  
--('Berlin', 5);    

--INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) VALUES
--('Nigar', 'Məmmədova', 25, 2500.00, 'Reception', 0, 1),  
--('Tural', 'Həsənov', 30, 1800.00, 'Driver', 0, 2),       
--('Leyla', 'Quliyeva', 28, 3200.00, 'Manager', 0, 4),     
--('Orxan', 'Əliyev', 35, 1500.00, 'Security', 1, 5),       
--('Səbinə', 'Rüstəmova', 26, 2200.00, 'Reception', 0, 1),   
--('Rəşad', 'İsmayılov', 40, 4000.00, 'Director', 0, 7),    
--('Aynur', 'Tağıyeva', 29, 1900.00, 'Accountant', 1, 3),    
--('Elvin', 'Səfərov', 32, 2100.00, 'Reception', 0, 6),     
--('Günay', 'Hüseynova', 27, 2700.00, 'HR', 0, 8),          
--('Fərid', 'Kərimov', 33, 1700.00, 'Reception', 1, 2);      

--select * from Employees;

SELECT 
    e.Name,
    e.Surname,
    e.Age,
    e.Salary,
    e.Position,
    c.Name AS CityName,
    co.Name AS CountryName
FROM Employees e
INNER JOIN Cities c ON e.CityId = c.Id
INNER JOIN Countries co ON c.CountryId = co.Id;

SELECT 
    e.Name,
    e.Surname,
    co.Name AS CountryName
FROM Employees e
INNER JOIN Cities c ON e.CityId = c.Id
INNER JOIN Countries co ON c.CountryId = co.Id
WHERE e.Salary > 2000;

SELECT 
    c.Name AS CityName,
    co.Name AS CountryName
FROM Cities c
INNER JOIN Countries co ON c.CountryId = co.Id;

SELECT 
    Name,
    Surname,
    Age,
    Salary,
    Position,
    IsDeleted,
    CityId
FROM Employees
WHERE Position = 'Reception';

SELECT 
    e.Name,
    e.Surname,
    c.Name AS CityName,
    co.Name AS CountryName
FROM Employees e
INNER JOIN Cities c ON e.CityId = c.Id
INNER JOIN Countries co ON c.CountryId = co.Id
WHERE e.IsDeleted = 1;