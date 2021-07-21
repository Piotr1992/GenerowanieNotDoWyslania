USE [CDNXL_PNIPH_KSI]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [CDN].[T2S_DaneDoGenerowaniaNot](@CDN_Filtr varchar(2048))
AS
begin
	SET NOCOUNT ON


	CREATE TABLE #TmpCRMKampEtapy
	(
			Typ int,
			GIDNumer int,
			Lp int,
			CEK_KntNumer int,
			CEK_KntTyp int,
			CEK_ID int
	)

	IF IsNull(@CDN_Filtr,'')<>''
	  EXEC (N'Insert Into #TmpCRMKampEtapy Select CKE_GIDTyp, CKE_GidNumer, CKE_GidLp,CEK_KntNumer,CEK_KntTyp,CEK_ID from  CDN.CRMKampEtapy 
			inner join CDN.CRMKntEtapy With(nolock) on CKE_GIDNumer=CEK_CKENumer AND CKE_GIDLp=CEK_CKELp and  CEK_Status=0 Where ' + @CDN_Filtr)

	SET NOCOUNT OFF

	select
		ROW_NUMBER() OVER( ORDER BY CEK_KntNumer ) Lp,
		Knt_Nazwa1	KntNazwa1,
		Knt_Nazwa2	KntNazwa2,
		Knt_Nazwa3	KntNazwa3,
		Knt_Ulica	KntUlica,
		Knt_Adres   KntAdresy,
		Knt_Kraj	KntKraj,
		Knt_KodP	KntKodP,
		Knt_Miasto	KntMiasto,
		(select top 1 IIF(kns_tytul<>'',kns_tytul+' ','')+KnS_Nazwa from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) Osoba,		
		(select top 1 ('Sz. P. '+KnS_Nazwa) from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) SzPOsoba,
		(select top 1 ('Frau '+KnS_Nazwa) from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) FrauOsoba,
		(select top 1 ('dw. '+KnS_Nazwa) from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) DwOsoba,
		(select top 1 ('zK. '+KnS_Nazwa) from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) zKOsoba,
		(select top 1 ('Herrn '+KnS_Nazwa) from CDN.KntOsoby where KnS_KntTyp=Knt_GIDTyp and KnS_KntNumer=Knt_GIDNumer and KnS_Upowazniona=1 and KnS_Archiwalny=0) HerrnOsoba,
		KnA_Nazwa1	KnaNazwa1,
		KnA_Nazwa2	KnaNazwa2,
		KnA_Nazwa3	KnaNazwa3,		
		KnA_Ulica	KnaUlica,
		KnA_Adres	KnaAdres,
		KnA_Kraj	KnaKraj,
		KnA_KodP	KnaKodP,
		KnA_Miasto	KnaMiasto,
		KnS_Nazwa	KnSNazwa,		
		KnS_UpoDoK	KnSUpoDoK,
		[WalneZgromadzenieRok], 
		[SkładkaRok], 
		[SkładkaWysokość], 
		[SkładkaWysokośćEURO], 		
		LEFT([SkładkaTermin],10) AS SkładkaTermin,
		[SkładkaKoszty], 
		[NumerRachunku],
		[NumerRachunkuDE] NumerRachunkuDE, 
		[NazwaBanku], 
		[NazwaBankuDE], 
		[InfoDodatkowe], 
		[PodstawaPrawna], 
		[Podpis],
		[PodpisDE], 
		[Folder], 		
		LEFT([DataNota],10) AS DataNota,	
		[SchematNumer]+iif(right([SchematNumer],1)='/','','/')+atr_wartosc+iif(len([DataNota])>2,'/'+RIGHT(LEFT( [DataNota], 10 ), 2), '') [SchematNumer], 		
		[CkeNumer], 
		[CkeTyp], 
		[CkeLp],
		'MB'+iif(len([SkładkaRok])>2,RIGHT([SkładkaRok],2),'')+'/'+Knt_Ean TytulZaplatyEan,
		'MB'+iif(len([SkładkaRok])>2,RIGHT([SkładkaRok],2),'')+' '+Knt_Akronim TytulZaplatyAkronim,
		'MB'+iif(len([SkładkaRok])>2,[SkładkaRok],'')+'/'+Knt_Ean TytulZaplatyCalyRokEan,
		'MB'+iif(len([SkładkaRok])>2,[SkładkaRok],'')+' '+Knt_Akronim TytulZaplatyCalyRokAkronim,
		[InfoDodatkoweDE], 
		[PodstawaPrawnaDE],
		CEK_KntNumer,
		atr_wartosc Numer,
		CEK_ID,
		IloscDni
	from #TmpCRMKampEtapy ke
	inner join CDN.CRMKampNag With(nolock) on CKN_GIDNumer=GIDNumer
	inner join CDN.T2S_GetNagEtapInfoView EIV on ke.GIDNumer=ckenumer and ke.Typ=cketyp and ke.lp=ckelp
	inner join CDN.KntKarty on Knt_GIDNumer=CEK_KntNumer and Knt_GIDTyp=CEK_KntTyp	
	inner join CDN.Atrybuty on atr_obityp=4176 and atr_obinumer=CEK_ID and atr_obilp=0 and Atr_ObiSubLp=32 and isnumeric(Atr_Wartosc)=1
	inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='NotaNumer'
	left outer join CDN.KntAdresy on KnA_KntTyp=Knt_GIDTyp and KnA_KntNumer=Knt_GIDNumer and KnA_Wysylkowy=1 and KnA_DataArc=0
	left outer join CDN.KntOsoby on Knt_GIDNumer=KnS_KntNumer and KnS_UpoDoK = 1
end