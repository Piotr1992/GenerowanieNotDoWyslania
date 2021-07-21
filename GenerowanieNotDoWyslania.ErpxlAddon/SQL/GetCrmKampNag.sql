if exists(select 1 from sys.objects where name='T2S_GetCrmKampNag')
begin
	drop procedure CDN.T2S_GetCrmKampNag
end
go

create procedure CDN.T2S_GetCrmKampNag
as
begin
	select ckn_kod Kod,ckn_gidnumer Numer from cdn.crmkampnag  where ckn_gidtyp=4176 order by ckn_kod asc
end
go