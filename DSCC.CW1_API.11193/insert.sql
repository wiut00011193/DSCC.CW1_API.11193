/*******************************************************************************
   Create Tables
********************************************************************************/
USE DSCCAPIDB_00011193;

CREATE TABLE [dbo].[Departments]
(
    [id] INT NOT NULL IDENTITY,
    [name] NVARCHAR(70),
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([id])
);
GO

CREATE TABLE [dbo].[Employees]
(
    [id] INT NOT NULL IDENTITY,
    [firstName] NVARCHAR(40) NOT NULL,
    [lastName] NVARCHAR(40) NOT NULL,
    [gender] INT,
    [salary] decimal,
    [employeeDepartmentId] INT,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [FK_Employees_Departments] FOREIGN KEY ([employeeDepartmentId]) REFERENCES [dbo].[Departments] ([id])
);
GO

/*******************************************************************************
   Populate Tables
********************************************************************************/
INSERT INTO [dbo].[Departments] ([name]) VALUES ('HR');
INSERT INTO [dbo].[Departments] ([name]) VALUES ('Marketing');
INSERT INTO [dbo].[Departments] ([name]) VALUES ('Finance');
INSERT INTO [dbo].[Departments] ([name]) VALUES ('Engineering');
INSERT INTO [dbo].[Departments] ([name]) VALUES ('Sales');

INSERT INTO [dbo].[Employees] ([firstName], [lastName], [gender], [salary], [employeeDepartmentId]) VALUES
('John', 'Doe', 0, 6000, 1),
('Jane', 'Smith', 1, 5500, 2),
('David', 'Williams', 0, 6200, 3),
('Emily', 'Brown', 1, 5800, 5),
('Michael', 'Johnson', 0, 6300, 4),
('Mary', 'Jones', 1, 5700, 2),
('Robert', 'Davis', 0, 6100, 1),
('Jennifer', 'Miller', 1, 5900, 3),
('William', 'Wilson', 0, 6400, 4),
('Linda', 'Lee', 1, 5600, 5),
('James', 'Moore', 0, 6250, 2),
('Patricia', 'Taylor', 1, 5850, 3),
('Charles', 'Martin', 0, 6150, 4),
('Susan', 'Anderson', 1, 5650, 1),
('Richard', 'White', 0, 6200, 2),
('Jessica', 'Harris', 1, 5950, 3),
('Joseph', 'Thompson', 0, 6300, 4),
('Sarah', 'Clark', 1, 5550, 1),
('Thomas', 'Hall', 0, 6150, 5),
('Nancy', 'Young', 1, 5800, 3),
('Daniel', 'King', 0, 6250, 4),
('Karen', 'Baker', 1, 5600, 1),
('Matthew', 'Scott', 0, 6100, 2),
('Lisa', 'Lewis', 1, 5900, 3),
('Donald', 'Walker', 0, 6350, 4),
('Betty', 'Green', 1, 5700, 1),
('Anthony', 'Evans', 0, 6150, 2),
('Dorothy', 'Turner', 1, 5750, 3),
('Mark', 'Wright', 0, 6400, 4),
('Sandra', 'Hall', 1, 5550, 5),
('Paul', 'Adams', 0, 6300, 2),
('Ashley', 'Cook', 1, 5850, 3),
('George', 'Bell', 0, 6200, 4),
('Kimberly', 'Parker', 1, 5650, 5),
('Steven', 'Collins', 0, 6250, 2),
('Donna', 'Edwards', 1, 5750, 3),
('Brian', 'Hill', 0, 6350, 4),
('Lisa', 'Smith', 1, 5900, 1),
('Jason', 'Brown', 0, 6200, 5),
('Sarah', 'Davis', 1, 5550, 3),
('Michael', 'Thomas', 0, 6400, 5),
('Linda', 'Miller', 1, 5650, 1),
('Matthew', 'Harris', 0, 6300, 2);


/*******************************************************************************
   Drop Tables
********************************************************************************/
/*
USE DSCCAPIDB_00011193;

DROP TABLE [dbo].[Employees]
          ,[dbo].[Departments];
*/