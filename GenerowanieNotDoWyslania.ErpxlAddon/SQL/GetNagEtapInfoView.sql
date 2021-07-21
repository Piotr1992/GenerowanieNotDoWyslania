if exists(select 1 from sys.objects where name='T2S_GetNagEtapInfoView')
begin
	drop view CDN.T2S_GetNagEtapInfoView
end
go
create view  CDN.T2S_GetNagEtapInfoView
as
	select
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='WalneZgromadzenieRok' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') WalneZgromadzenieRok,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SkładkaRok' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SkładkaRok,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SkładkaWysokość' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SkładkaWysokość,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SkładkaWysokośćEURO' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SkładkaWysokośćEURO,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SkładkaTermin' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SkładkaTermin,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SkładkaKoszty' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SkładkaKoszty,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NumerRachunku' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') NumerRachunku,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NumerRachunkuDE' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') NumerRachunkuDE,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NazwaBanku' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') NazwaBanku,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NazwaBankuDE' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') NazwaBankuDE,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='InfoDodatkowe' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') InfoDodatkowe,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='InfoDodatkoweDE' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') InfoDodatkoweDE,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='PodstawaPrawna' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') PodstawaPrawna,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='PodstawaPrawnaDE' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') PodstawaPrawnaDE,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='Podpis' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') Podpis,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='PodpisDE' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') PodpisDE,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='Folder' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') Folder,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='Typ' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') Typ,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='DataNota' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') DataNota,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='SchematNumer' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') SchematNumer,			
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='IloscDni' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') IloscDni,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NazwaNoty' and atr_obityp=4176 and atr_obinumer=cke_gidnumer and atr_obilp=cke_gidlp),'') NazwaNoty,
		cke_gidnumer CkeNumer,
		cke_gidtyp CkeTyp,
		cke_gidlp CkeLp
	from cdn.crmkampetapy 