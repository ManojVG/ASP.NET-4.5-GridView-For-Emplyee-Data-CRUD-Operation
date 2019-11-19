CREATE TABLE [dbo].[Employee] (
    [EmployeeID]    INT          NOT NULL,
    [EmployeeName]  VARCHAR (50) NULL,
    [Gender]        VARCHAR (50) NULL,
    [DOB]           VARCHAR (50) NULL,
    [EmailID]       VARCHAR (50) NULL,
    [ContactNumber] VARCHAR (50) NULL,
    [Address]       VARCHAR (50) NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

