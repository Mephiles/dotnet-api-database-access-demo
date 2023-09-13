-- Scaffold-DbContext -Connection "Name=ConnectionStrings:DemoAPI" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ApiDbContext -Force

drop table item
drop table [type]

create table [type] (
	name nvarchar(1) primary key
)
go

create table item (
	id int identity(1, 1) primary key,
	name nvarchar(100) not null,
	[type] nvarchar(1) not null foreign key references [type] (name)
)
go

insert into [type] (name) values ('A')
insert into [type] (name) values ('B')
insert into [type] (name) values ('C')