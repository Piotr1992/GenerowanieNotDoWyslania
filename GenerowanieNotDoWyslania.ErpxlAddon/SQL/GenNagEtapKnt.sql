if exists(select 1 from sys.objects where name='T2S_GenNagEtapKnt')
begin
	drop procedure CDN.T2S_GenNagEtapKnt
end
go

create procedure CDN.T2S_GenNagEtapKnt
(
	@Numer int,
	@Lp int
)
as
select 
		CEK_KntNumer,
		CEK_ID,
		'CEK_ID='+cast(cek_id as nvarchar(100)) FiltrSQL,
		SchematNumer,
		Knt_Akronim,
		Knt_GIDTyp,
		Knt_GIDNumer,
		isnull((select atr_wartosc from cdn.atrybuty inner join cdn.atrybutyklasy on atr_atkid=atk_id and atk_nazwa='E-mail noty statutowe' where atr_obityp=knt_gidtyp and atr_obinumer=knt_gidnumer),'') Email
from 
(Select 
	CEK_KntNumer,
	Knt_Akronim,
	Knt_GidTyp,
	Knt_GidNumer,
	SchematNumer,
	min(CEK_ID) CEK_ID
from CDN.CRMKntEtapy With(nolock) 
inner join CDN.T2S_GetNagEtapInfoView on CEK_CKENumer=CkeNumer and CEK_CKELp=CkeLp
inner join CDN.KntKarty on CEK_KntTyp=Knt_GIDTyp and CEK_KntNumer=Knt_GIDNumer
where CEK_CKENumer=@Numer AND CEK_CKELp=@Lp and  CEK_Status=0
group by CEK_KntNumer,Knt_Akronim,Knt_Gidtyp,Knt_Gidnumer,SchematNumer) Temp

go

exec CDN.T2S_GenNagEtapKnt 4840,1