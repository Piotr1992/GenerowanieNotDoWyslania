if exists(select 1 from sys.objects where name='T2S_GetEmailNotaStatut')
begin
	drop procedure CDN.T2S_GetEmailNotaStatut
end
go

create procedure CDN.T2S_GetEmailNotaStatut
(
	@kntnumer int,
	@openumer int
)
as
begin
	select Ope_ident,
	(select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='E-mail noty statutowe' where atr_obityp=32 and atr_obinumer=@kntnumer) Email
	from cdn.OpeKarty where ope_gidnumer=@openumer
end
go