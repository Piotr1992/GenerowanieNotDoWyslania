SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'T2S_AddBinaryData')
DROP PROCEDURE CDN.T2S_AddBinaryData
GO
create procedure [CDN].[T2S_AddBinaryData]
(
	@Kod varchar(39),
	@Nazwa varchar(99),
	@Rozszerzenie varchar(31),
	@Plik image,
	@PK int,
	@GidTyp int,
	@GidNumer int
)
as
begin
	declare @Result int
	set @Result=-1;
	if exists(select * from cdn.DaneBinarne
		inner join cdn.DaneObiekty on DAB_ID=DAO_DABId and DAO_ObiNumer=@GidNumer and DAO_ObiTyp=@GidTyp
		where DAB_Kod=@Kod)
	begin
		update cdn.DaneBinarne
			set DAB_Nazwa=@Nazwa,DAB_Rozszerzenie=@Rozszerzenie,DAB_Dane=@Plik
		from cdn.DaneBinarne
		inner join cdn.DaneObiekty on DAB_ID=DAO_DABId and DAO_ObiNumer=@GidNumer and DAO_ObiTyp=@GidTyp
		where DAB_Kod=@Kod
		set @Result=(select top 1 dab_id from cdn.DaneBinarne 
									inner join cdn.DaneObiekty on DAB_ID=DAO_DABId and DAO_ObiNumer=@GidNumer and DAO_ObiTyp=@GidTyp
									where DAB_Kod=@Kod)
	end
	else
	begin
		declare @Grupa int
		declare @Id int
		declare @Typ int

		set @Grupa=0
		set @Typ=345
		if(select count(*) from cdn.DaneBinarne)=0
		begin
			set @id=1
		end
		else
		begin
			set @Id=(select MAX(dab_id) from CDN.DaneBinarne)+1
		end
		insert into CDN.DaneBinarne(DAB_Nazwa, DAB_TypId, DAB_Rozszerzenie, DAB_Rozmiar, DAB_Dane, DAB_Kod, DAB_CzasModyfikacji, DAB_OpeNumer, DAB_Usuwac, DAB_Archiwalny,DAB_Tlumaczenie,DAB_Jezyk,DAB_CzasArchiwizacji,DAB_DBGId,DAB_PKPrawa)
		select @Nazwa,@Typ,@Rozszerzenie,0,@Plik,@Kod,(select datediff(s,'1990-01-01',getdate())),1,0,0,(select max(dab_id)+1 from CDN.DaneBinarne),0,2000000000,@Grupa,@PK
		set @Result=SCOPE_IDENTITY()
		insert into [CDN].[DaneObiekty](DAO_DABId, DAO_ObiTyp, DAO_ObiNumer, DAO_ObiLp, DAO_Domyslna, DAO_Blokada, DAO_PPPrawa,  DAO_eSklep, DAO_ObiSubLp, DAO_iMall, DAO_MobSpr, DAO_Systemowa,DAO_PKPrawa)
		select @Id,@GidTyp,@GidNumer,0,0,0,0,0,0,0,0,0,@PK
	end
	select @Result
end
go