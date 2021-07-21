if exists(select 1 from sys.objects where name='T2S_GetGenNotEtapInfo')
begin
	drop procedure CDN.T2S_GetGenNotEtapInfo
end
go

create procedure CDN.T2S_GetGenNotEtapInfo
(
	@KampNumer int,
	@KampLp int,
	@OpeNumer int
)
as
begin
	
	select
		*,
		(select ope_ident from cdn.OpeKarty where Ope_gidnumer=@OpeNumer) OpeIdent
	from CDN.T2S_GetNagEtapInfoView 
	where ckenumer=@KampNumer and cketyp=4176 and ckelp=@KampLp
end
go