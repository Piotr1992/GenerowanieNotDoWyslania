using GenerowanieNotDoWyslania.ErpxlAddon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    class DataService
    {
        SQLDataDataContext linq;        
                
        public DataService(string connection)
        {
            linq = new SQLDataDataContext(connection);
            linq.CommandTimeout = 180;
        }
        
        public int CounterGenerateNots(int numer_noty, bool pf)
        {
            int nastepny_numer = Convert.ToInt32(linq.T2S_Procedure_CounterGenerateNots(numer_noty, pf).ReturnValue) + 1;

            return nastepny_numer;
        }

        public List<KampNag> GetKampNagList()
        {
            return linq.T2S_GetCrmKampNag().Select(x=>new KampNag { Kod=x.Kod,Numer=x.Numer}).ToList();
        }
        public List<KampEtap> GetKampNagEtapy(KampNag kampNag)
        {
            return linq.T2S_GetKampNagEtapy(kampNag.Numer).Select(x => new KampEtap { Kod = x.Kod, Numer=kampNag.Numer,Lp = x.Lp }).ToList();
        }
        public void SaveAtrybut(Atrybut atrybut,string login)
        {          
            linq.T2S_UpdateAtrybut(atrybut.Typ, atrybut.Numer, atrybut.Lp, atrybut.SubLp,atrybut.Klasa, atrybut.Wartosc, login, 4176);            
        }
        
        public List<Atrybut> GetKampEtapInfo(KampEtap etap,int opeNumer, out string opeIdent)
        {
            var item = linq.T2S_GetGenNotEtapInfo(etap.Numer, etap.Lp,opeNumer).FirstOrDefault();

            List<Atrybut> result = new List<Atrybut>();
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "WalneZgromadzenieRok", Wartosc = item.WalneZgromadzenieRok });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "Folder", Wartosc = item.Folder });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "InfoDodatkowe", Wartosc = item.InfoDodatkowe });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "InfoDodatkoweDE", Wartosc = item.InfoDodatkoweDE });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "NazwaBanku", Wartosc = item.NazwaBanku });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "NazwaBankuDE", Wartosc = item.NazwaBankuDE });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "NumerRachunku", Wartosc = item.NumerRachunku });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "NumerRachunkuDE", Wartosc = item.NumerRachunkuDE });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "Podpis", Wartosc = item.Podpis });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "PodpisDE", Wartosc = item.PodpisDE });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "PodstawaPrawna", Wartosc = item.PodstawaPrawna });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "PodstawaPrawnaDE", Wartosc = item.PodstawaPrawnaDE });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SkładkaKoszty", Wartosc = item.SkładkaKoszty });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SkładkaRok", Wartosc = item.SkładkaRok });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SkładkaTermin", Wartosc = item.SkładkaTermin });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SkładkaWysokość", Wartosc = item.SkładkaWysokość });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SkładkaWysokośćEURO", Wartosc = item.SkładkaWysokośćEURO });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "Typ", Wartosc = item.Typ });

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "DataNota", Wartosc = item.DataNota });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "SchematNumer", Wartosc = item.SchematNumer });            

            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "IloscDni", Wartosc = item.IloscDni });
            result.Add(new Atrybut { Typ = 4176, Numer = etap.Numer, Lp = etap.Lp, Klasa = "NazwaNoty", Wartosc = item.NazwaNoty });
            opeIdent = item.OpeIdent;
            return result;
        }
        public int GetStartNumer(DateTime date)
        {    
            return (int)linq.T2S_GetGenNotLastNumer(date).FirstOrDefault().Result+1;
        }

        public List<EtapKnt> GetKntList(KampEtap etap)
        {
            return linq.T2S_GenNagEtapKnt(etap.Numer, etap.Lp).Select(x => new EtapKnt
            {
                CEK_KntNumer = x.CEK_KntNumer,
                FiltrSQL = x.FiltrSQL,
                CEK_ID = x.CEK_ID,
                SchematNumer = x.SchematNumer,
                Knt_Akronim = x.Knt_Akronim,
                Knt_GIDNumer = x.Knt_GIDNumer,
                Knt_GIDTyp = x.Knt_GIDTyp,
                Email = x.Email,
                Message_EMail = x.Message_EMail,
                Subject_Email = x.Subject_Email
            }).ToList();
        }        

        public void SaveGenNotLastNumer(DateTime date,int numer)
        {
            linq.T2S_SaveGenNotLastNumer(date, numer);
        }
        public void SaveData(BinaryData bd)     //      zapisywanie wygenerowanych not do załączników
        {
            linq.T2S_AddBinaryData(
                bd.ShortName,
                bd.Name,
                bd.Extension,
                bd.Data,
                bd.PK,
                bd.GidTyp,
                bd.GidNumer);                                                   
        }
        public List<PrintReportSettings> GetReports()
        {
            return linq.T2S_GetReportsGenNot().Select(x => new PrintReportSettings { Nazwa = x.ReportName,Wydruk=(int)x.Wydruk,Zrodlo=(int)x.Zrodlo,Format=(int)x.Format}).ToList();
        }

        public List<Object> GetEmailNotaStatut(int kntNumer, int opeNumer)        
        {            
            List<Object> result = new List<Object>();
            var item = linq.T2S_GetEmailNotaStatut(kntNumer, opeNumer).FirstOrDefault();
            result.Add(item.Ope_ident);
            result.Add(item.Email);           
            
            return result;
        }

        public string PobierzAdresMailowy(long TrP_GIDNumer)
        {
            return linq.T2S_Procedure_PobierzAdresMailowy(TrP_GIDNumer).ToString();
        }

        public string PobierzAdresMailowyOdbiorcy(long CEK_ID)
        {
            return linq.T2S_Procedure_PobierzAdresMailowyOdbiorcy(CEK_ID).ToString();
        }
    }
}
