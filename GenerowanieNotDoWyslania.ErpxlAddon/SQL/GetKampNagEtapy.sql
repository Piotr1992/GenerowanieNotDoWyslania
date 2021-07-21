if exists(select 1 from sys.objects where name='T2S_GetKampNagEtapy')
begin
	drop procedure CDN.T2S_GetKampNagEtapy
end
go

create procedure CDN.T2S_GetKampNagEtapy
(
	@KampNagNumer int
)
as
begin
	select cke_kod Kod,cke_gidlp Lp from cdn.crmkampetapy where cke_gidnumer=@KampNagNumer and cke_gidtyp=4176 order by cke_pozycja asc
end
go