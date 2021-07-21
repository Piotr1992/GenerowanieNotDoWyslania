--GetReportsGenNot.sql
if exists(select 1 from sys.objects where name='T2S_GetReportsGenNot')
begin
	drop procedure CDN.T2S_GetReportsGenNot
end
go

create procedure CDN.T2S_GetReportsGenNot

as
begin
	declare @Result table
	(
		ReportName nvarchar(100),
		Zrodlo int,
		Wydruk int,
		[Format] int
	)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota PL+DE',1,55,1)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota PL',1,55,2)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota DE',1,55,3)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota PL+DE skan podpisu',1,55,4)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota PL skan podpisu',1,55,5)
	insert into @Result(ReportName,Zrodlo,Wydruk,[Format])
	values('Nota DE skan podpisu',1,55,6)
	select * from @Result
end
go