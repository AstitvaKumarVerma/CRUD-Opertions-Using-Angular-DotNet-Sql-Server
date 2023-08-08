CREATE TABLE AstitvaEmployees2904(
	Prefix varchar DEFAULT 'E',
	EmployeeNumber int NOT NULL Primary Key Identity(1,1),
	EmployeeId As (Prefix+Right('0000'+CAST(EmployeeNumber As Varchar(4)), 4)) Persisted,
	EmployeeName Varchar(30),
	CompanyName varchar(50),
	CompanyAddress varchar(500),
	Month varchar(10),
	Year int,
	DOJ Date Not Null,
	DesignationId int Not Null,
	DepartmentId int Not Null,
	UAN varchar(40),
	PFNo varchar(40),
	BankName varchar(40) Not Null,
	AccountNo int Not NUll,
	ESINo int Not Null,
	BasicWages Decimal Not Null,
	HRA Decimal Not Null,
	EPF Decimal,
	ESI Decimal,
	TotalEarning Decimal,
	TotalDeduction Decimal,
	NetSalary Decimal,
	IsActive BIT NOT NULL DEFAULT 1,
	CreatedBy varchar(20),
	CreatedDate Date,
	UpdatedBy varchar(20),
	UpdatedDate Date,
	IsDeleted BIT NOT NULL DEFAULT 0,
	DeletedBy varchar(20),
	DeletedDate Date,
	FOREIGN KEY (DesignationId) REFERENCES AstitvaDesignation2904(DesignationId),
	FOREIGN KEY (DepartmentId) REFERENCES AstitvaDepartment2904(DepartmentId),
)

Create Table AstitvaDepartment2904(
	DepartmentId int Not Null Identity(1001,1) Primary Key,
	Department Varchar(20)
)

Create Table AstitvaDesignation2904(
	DesignationId int Not Null Identity(101,1) Primary Key,
	Designation varchar(20)
)



Select * From AstitvaEmployees2904
Select * From AstitvaDepartment2904
Select * From AstitvaDesignation2904


Insert into AstitvaDepartment2904 Values('MS')
Insert into AstitvaDepartment2904 Values('OSBD')

Insert into AstitvaDesignation2904 Values('Angular Developer')
Insert into AstitvaDesignation2904 Values('DotNet Developer')
Insert into AstitvaDesignation2904 Values('IOS Developer')
Insert into AstitvaDesignation2904 Values('Android Developer')
Insert into AstitvaDesignation2904 Values('Full Stack Developer')
Insert into AstitvaDesignation2904 Values('HR')





