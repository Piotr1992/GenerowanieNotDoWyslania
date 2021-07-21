if exists(select * from sys.objects where name='T2S_UpdateAtrybut')
begin
	drop procedure [CDN].[T2S_UpdateAtrybut]
end
go

create PROCEDURE [CDN].[T2S_UpdateAtrybut]
(
	@typ int,
	@numer int,
	@lp int,
	@sublp int,
	@klasa nvarchar(100),
	@wartosc nvarchar(512),
	@login nvarchar(100),
	@autoCreateGidTyp int	--	trzeba podać GidTyp obiektu do którego zostanie dodany atrybut z tabeli Obiekty np. ZS to 9472, Erap CRM-4176
)
as
begin
	declare @AtkId int
	declare @AtkTyp int
	declare @AtwId int
	declare @AtrId int
	declare @AtrWielowart int
	declare @opetyp int
	declare @opefirma int
	declare @openumer int
	set @AtkId=null
	select 
		@opetyp=Ope_gidtyp,
		@opefirma=Ope_GIDFirma,
		@openumer=Ope_GIDNumer
	from cdn.OpeKarty where Ope_ident=@login
	set @AtwId=0
	select 
		@AtkId=atk_id, 
		@AtkTyp=atk_typ,
		@AtrWielowart=AtK_Wielowart
	from cdn.atrybutyklasy where atk_nazwa=@Klasa
	if @AtkId is null and @autoCreateGidTyp>0
	begin
		declare @ts int
		set @ts=(select datediff(second,'1990-01-01',getdate()))
		set @AtkId=(SELECT isnull(MAX(AtK_ID),0)+1 FROM CDN.AtrybutyKlasy)

		insert into CDN.AtrybutyKlasy(
			AtK_ID,					AtK_Typ, 
			AtK_Nazwa,				AtK_Opis, 
			AtK_Format,				AtK_ZListy, 
			AtK_Zamknieta,			AtK_Wymagany, 
			AtK_Controlling,		AtK_Automat, 
			AtK_Nieaktywny,			AtK_SQL, 
			AtK_Historia,			AtK_Domyslna, 
			AtK_DomyslnaAPI,		AtK_DomTyp, 
			AtK_DomFirma,			AtK_DomNumer, 
			AtK_DomLp,				AtK_DomAPITyp, 
			AtK_DomApiFirma,		AtK_DomAPINumer, 
			AtK_DomAPILp,			AtK_DomyslnaSQL, 
			AtK_DomyslnaAPISQL,		AtK_TypDom, 
			AtK_TypDomApi,			AtK_CharSet, 
			AtK_OptimaId,			AtK_Okresowe, 
			AtK_Wielowart,			AtK_ReadOnly, 
			AtK_iZam,				AtK_eSklep, 
			AtK_CzasModyfikacji,	AtK_MOBMPrawa, 
			AtK_MOBSPrawa,			AtK_PRACPrawa, 
			AtK_OddZrdID,			AtK_iMall,
			AtK_Synchronizowany,	AtK_WMS,
			AtK_MOBZPrawa,			AtK_DataDodania)
		values(
		@AtkId,	2,
		@klasa,	@klasa, '@s100',
		0,		0,
		0,		0,
		0,		0,
		'',		0,
		'',		'',
		0,		0,
		0,		0,
		0,		0,
		0,		0,
		'',		'',
		0,		0,	
		238,	0,
		0,		0,
		0,		1,
		0,		@ts,
		0,		0,
		0,		0,
		0,		0,
		0,		0,
		@ts)
		declare @Element int
		if @sublp>0
		begin 
			set @Element=1
		end
		else if @Lp>0
		begin
			set @Element=1
		end
		else
		begin
			set @Element=0
		end
		declare @AtoLp int
		set @AtoLp=10
		if exists(select * from CDN.AtrybutyObiekty where AtO_GIDTyp=@autoCreateGidTyp and AtO_Element=@Element)
		begin
			set @AtoLp=(select max(AtO_Lp)+10 from CDN.AtrybutyObiekty where AtO_GIDTyp=@autoCreateGidTyp and AtO_Element=@Element)
		end
		INSERT INTO CDN.AtrybutyObiekty (AtO_GIDTyp,AtO_Element,AtO_AtKId,AtO_Lp,ATO_Wymagany,ATO_Automat,ATO_ReadOnly,ATO_ATZID,ATO_Akcja,ATO_Online,ATO_CzasModyfikacji,ATO_Miara,ATO_Agregacja,ATO_Rozbijanie,ATO_Format,ATO_Korekty,ATO_PusteWartosci) 
		VALUES (@autoCreateGidTyp,@Element,@AtkId,@AtoLp,-1,-1,-1,0,-1,1,@ts,0,0,0,0,0,0)
	end
	if(@AtkId>0)
	begin
		declare @wartoscAtrybuty nvarchar(512)
		if @AtrWielowart=1 set @wartoscAtrybuty='<...>'
		else set @wartoscAtrybuty=@wartosc
		if exists(select * from cdn.Atrybuty where Atr_ObiTyp=@typ and Atr_ObiNumer=@numer and Atr_ObiLp=@lp and Atr_ObiSubLp=@sublp  and Atr_AtkId=@AtkId)
			begin
				update cdn.Atrybuty
					set Atr_Wartosc=@wartoscAtrybuty
				where  Atr_ObiTyp=@typ and Atr_ObiNumer=@numer and Atr_ObiLp=@lp and Atr_ObiSubLp=@sublp and Atr_AtkId=@AtkId
				set @AtrId=(select top 1 Atr_id from cdn.Atrybuty where  Atr_ObiTyp=@typ and Atr_ObiNumer=@numer and Atr_ObiLp=@lp and Atr_ObiSubLp=@sublp and Atr_AtkId=@AtkId)
			end
			else
			begin
				insert into CDN.atrybuty(Atr_ObiTyp, Atr_ObiFirma, Atr_ObiNumer, Atr_ObiLp, Atr_ObiSubLp, Atr_AtkId, Atr_Wartosc, Atr_AtrTyp, Atr_AtrFirma, Atr_AtrNumer, Atr_AtrLp, Atr_AtrSubLp, Atr_OptimaId)
				values(@typ,352257,	@numer,	@lp,	@sublp ,	@AtkId,	@wartoscAtrybuty,	0,	0,	0,	0,	0,	0)
				set @AtrId=@@IDENTITY
			end
		if @AtkTyp=4 and @AtrId>0
		begin
			if not exists(select AtW_ID from cdn.AtrybutyWartosci where AtW_AtKId=@AtkId and AtW_Wartosc=@wartosc)
			begin
				insert into cdn.AtrybutyWartosci(AtW_AtKId, AtW_Wartosc, AtW_OddZrdID)
				select @AtkId,@wartosc,0
				set @AtwId=@@IDENTITY
			end
			else
			begin
				set @AtwId=(select AtW_ID from cdn.AtrybutyWartosci where AtW_AtKId=@AtkId and AtW_Wartosc=@wartosc)
			end
		end
		if @AtrWielowart=1 and @AtrId>0
		begin
			declare @TempTS int
			if exists(select * from cdn.AtrybutyHist where AtH_ObiTyp=@typ and AtH_ObiNumer=@numer and Ath_ObiLp=@lp and Ath_ObiSubLp=@sublp and AtH_AtkId=@AtkId)
			begin
				set @TempTS=(select max(ath_timestamp) from cdn.AtrybutyHist where AtH_ObiTyp=@typ and AtH_ObiNumer=@numer and Ath_ObiLp=@lp and Ath_ObiSubLp=@sublp and AtH_AtkId=@AtkId)+1
			end
			else
			begin
				set @TempTS=1
			end
			insert into cdn.AtrybutyHist(AtH_Id,AtH_ObiTyp, AtH_ObiFirma, AtH_ObiNumer, AtH_ObiLp, AtH_ObiSubLp, AtH_AtkId, AtH_Wartosc, AtH_AtrTyp, AtH_AtrFirma, AtH_AtrNumer, AtH_AtrLp, AtH_AtrSubLp, AtH_TimeStamp, AtH_OpeTyp, AtH_OpeFirma, AtH_OpeNumer, AtH_OpeLp, AtH_TimeStampDo)
			select @AtrId,@typ,352257,@numer,@lp,@sublp,@AtkId,@wartosc,0,0,0,0,0,@TempTS,@Opetyp,@opefirma,@openumer,0,@TempTS
		end
	end
	select @AtrId AtrId,@AtwId AtwId
end
go