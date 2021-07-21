if exists(select 1 from sys.objects where name='T2S_SaveGenNotLastNumer')
begin
	drop procedure CDN.T2S_SaveGenNotLastNumer
end
go

create procedure CDN.T2S_SaveGenNotLastNumer
(
	@Date datetime,
	@Numer int
)
as
begin
	update CDN.T2S_GenNotNumer set LastNumer=@numer from CDN.T2S_GenNotNumer where Rok=Year(@Date)
end
go