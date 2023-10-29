CREATE DATABASE CL2
GO 
drop database cl2
use cl2
go
CREATE TABLE Account(
	Id int primary key identity(1,1),
	AccountNumber varchar(100),
	Amount decimal,
	Active bit)
go
select * from Account
go

insert into Account values ('A00001',100, 1)