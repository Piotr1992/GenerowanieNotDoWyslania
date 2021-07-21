if exists(select 1 from sys.objects where name='T2S_GetGenNotLastNumer')
begin
	drop procedure CDN.T2S_GetGenNotLastNumer
end
go

create procedure CDN.T2S_GetGenNotLastNumer
(
	@Date datetime
)
as
begin
	if not exists(select 1 from CDN.T2S_GenNotNumer where Rok=Year(@Date))
	begin
		insert into CDN.T2S_GenNotNumer(Rok,LastNumer)
		values(Year(@Date),0)
	end
	select LastNumer Result from CDN.T2S_GenNotNumer where Rok=Year(@Date)
end
go