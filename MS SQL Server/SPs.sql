----------------------                 Store Procedures            ------------------------------------------------

ALTER PROCEDURE SPAstitvaEmployees2904_SaveEmployee
	@EmployeeName Varchar(30),
	@CompanyName varchar(50),
	@CompanyAddress varchar(500),
	@Month varchar(10),
	@Year int,
	@DOJ Date,
	@DesignationId int ,
	@DepartmentId int,
	@UAN varchar(40),
	@PFNo varchar(40),
	@BankName varchar(40),
	@AccountNo int,
	@ESINo int,
	@BasicWages Decimal,
	@HRA Decimal
AS
BEGIN
	Insert INTO AstitvaEmployees2904(Prefix,EmployeeName, CompanyName, CompanyAddress, Month, Year, DOJ, DesignationId, DepartmentId, UAN, PFNo, BankName, AccountNo, ESINo, BasicWages, HRA, EPF, ESI, TotalEarning, TotalDeduction, NetSalary, IsActive, IsDeleted, CreatedBy, CreatedDate)
	VALUES('E',@EmployeeName,@CompanyName,@CompanyAddress, @Month, @Year, @DOJ, @DesignationId, @DepartmentId, @UAN, @PFNo, @BankName, @AccountNo, @ESINo, @BasicWages, @HRA, ((@BasicWages * 15)/100), ((@BasicWages * 5)/100), (@BasicWages+@HRA), (((@BasicWages * 15)/100)+((@BasicWages * 5)/100)), ((@BasicWages+@HRA)-(((@BasicWages * 15)/100)+((@BasicWages * 5)/100))), 1, 0, 'SDD', GETDATE())
END

-----------------------------------------   Update Procedure   -----------------------------------------------

ALTER PROCEDURE SPAstitvaEmployees2904_UpdateEmployee 
	@EmployeeId Varchar(10),
	@EmployeeName Varchar(30),
	@CompanyName varchar(50),
	@CompanyAddress varchar(500),
	@Month varchar(10),
	@Year int,
	@DOJ Date,
	@DesignationId int ,
	@DepartmentId int,
	@UAN varchar(40),
	@PFNo varchar(40),
	@BankName varchar(40),
	@AccountNo int,
	@ESINo int,
	@BasicWages Decimal,
	@HRA Decimal
AS
BEGIN
	Update AstitvaEmployees2904 
	SET EmployeeName = @EmployeeName,
	CompanyName = @CompanyName,
	CompanyAddress = @CompanyAddress,
	Month = @Month,
	Year = @Year, 
	DOJ = @DOJ, 
	DesignationId = @DesignationId,
	DepartmentId = @DepartmentId, 
	UAN = @UAN,
	PFNo = @PFNo, 
	BankName = @BankName,
	AccountNo = @AccountNo,
	ESINo = @ESINo, 
	BasicWages = @BasicWages, 
	HRA = @HRA,
	EPF = ((@BasicWages * 15)/100),
	ESI = ((@BasicWages * 5)/100) ,        
	TotalEarning  = (@BasicWages+@HRA), 
	TotalDeduction = (((@BasicWages * 15)/100)+((@BasicWages * 5)/100)),
	NetSalary = ((@BasicWages+@HRA)-(((@BasicWages * 15)/100)+((@BasicWages * 5)/100))), 
	IsActive  = 1,
	IsDeleted = 0,
	UpdatedBy = 'SDD_EMPLOYEE',
	UpdatedDate = GetDate()

	Where EmployeeId =@EmployeeId
END 