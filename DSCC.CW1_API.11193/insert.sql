/*******************************************************************************
   Create Tables
********************************************************************************/
CREATE TABLE [dbo].[Department]
(
    [ID] INT NOT NULL IDENTITY,
    [Title] NVARCHAR(70),
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId])
);
GO
CREATE TABLE [dbo].[Employee]
(
    [ID] INT NOT NULL IDENTITY,
    [FirstName] NVARCHAR(40) NOT NULL,
    [LastName] NVARCHAR(40) NOT NULL,
    [Gender] INT,
    [Salary] decimal,
    [EmployeeDepartmentId] INT,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeId])
);
GO