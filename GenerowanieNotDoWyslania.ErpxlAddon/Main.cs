using GenerowanieNotDoWyslania.ErpxlAddon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using cdn_api;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Hydra;



namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    public partial class Main : Form
    {
        public bool nudIlDniclik { get; set; }
        public bool dtSkladkaTerminclik { get; set; }

        private DataService _ds;

        private string _opeLogin;
        private int _opeNumer;
        private int _wersja = 20182;

        private Atrybut _WalneZgromadzenie;
        private Atrybut _Folder;
        private Atrybut _InfoDodatkowePL;
        private Atrybut _InfoDodatkoweDE;
        private Atrybut _NazwaBankuPL;
        private Atrybut _NazwaBankuDE;
        private Atrybut _NumerRachunkuPL;
        private Atrybut _NumerRachunkuDE;
        private Atrybut _PodpisPL;
        private Atrybut _PodpisDE;
        private Atrybut _PodstawaPrawnaPL;
        private Atrybut _PodstawaPrawnaDE;
        private Atrybut _SkładkaKoszty;
        private Atrybut _SkładkaRok;
        private Atrybut _SkładkaTermin;
        private Atrybut _SkładkaWysokość;
        private Atrybut _SkładkaWysokośćEURO;
        private Atrybut _Typ;



        private Atrybut _TypCheckBoxNrRachunkuPL;
        private Atrybut _TypCheckBoxNrRachunkuDE;



        private Atrybut _TypCheckboxPLN;
        private Atrybut _TypCheckboxEURO;

        private Atrybut _TypCheckboxZbiorczaNota;

        private Atrybut _DataNota;
        private Atrybut _SchematNumer;
        private Atrybut _IloscDni;
        private Atrybut _NazwaNoty;

        int counter = 0;

        string Data = "";
        string DataTermin = "";







        private Atrybut WalneZgromadzenie
        {
            get
            {
                _WalneZgromadzenie.Wartosc = Convert.ToString(nudWalneZgromadzenie.Value);
                return _WalneZgromadzenie;
            }
            set
            {
                _WalneZgromadzenie = value;
                decimal rok = 2018;
                Decimal.TryParse(_WalneZgromadzenie.Wartosc, out rok);
                nudWalneZgromadzenie.Value = (nudWalneZgromadzenie.Minimum > rok ? nudWalneZgromadzenie.Minimum : rok);
            }
        }

        private Atrybut Folder
        {
            get
            {
                _Folder.Wartosc = tbDirectory.Text;
                return _Folder;
            }
            set
            {
                _Folder = value;
                tbDirectory.Text = _Folder.Wartosc;
            }
        }

        private Atrybut NazwaBankuPL
        {
            get
            {
                _NazwaBankuPL.Wartosc = tbBankPL.Text;
                return _NazwaBankuPL;
            }
            set
            {
                _NazwaBankuPL = value;
                tbBankPL.Text = _NazwaBankuPL.Wartosc;
            }
        }

        private Atrybut NazwaBankuDE
        {
            get
            {
                _NazwaBankuDE.Wartosc = tbBankDE.Text;
                return _NazwaBankuDE;
            }
            set
            {
                _NazwaBankuDE = value;
                tbBankDE.Text = _NazwaBankuDE.Wartosc;
            }
        }

        private Atrybut NumerRachunkuPL
        {
            get
            {
                _NumerRachunkuPL.Wartosc = tbRachunekPL.Text;
                return _NumerRachunkuPL;
            }
            set
            {
                _NumerRachunkuPL = value;
                tbRachunekPL.Text = _NumerRachunkuPL.Wartosc;
            }
        }

        private Atrybut NumerRachunkuDE
        {
            get
            {
                _NumerRachunkuDE.Wartosc = tbRachunekDE.Text;
                return _NumerRachunkuDE;
            }
            set
            {
                _NumerRachunkuDE = value;
                tbRachunekDE.Text = _NumerRachunkuDE.Wartosc;
            }
        }

        private Atrybut PodpisPL
        {
            get
            {
                _PodpisPL.Wartosc = tbPodpisPL.Text;
                return _PodpisPL;
            }
            set
            {
                _PodpisPL = value;
                tbPodpisPL.Text = _PodpisPL.Wartosc;
            }
        }

        private Atrybut PodpisDE
        {
            get
            {
                _PodpisDE.Wartosc = tbPodpisDE.Text;
                return _PodpisDE;
            }
            set
            {
                _PodpisDE = value;
                tbPodpisDE.Text = _PodpisDE.Wartosc;
            }
        }

        private Atrybut PodstawaPrawnaPL
        {
            get
            {
                _PodstawaPrawnaPL.Wartosc = tbPodstawaPrawnaPL.Text;
                return _PodstawaPrawnaPL;
            }
            set
            {
                _PodstawaPrawnaPL = value;
                tbPodstawaPrawnaPL.Text = _PodstawaPrawnaPL.Wartosc;
            }
        }

        private Atrybut PodstawaPrawnaDE
        {
            get
            {
                _PodstawaPrawnaDE.Wartosc = tbPodstawaPrawnaDE.Text;
                return _PodstawaPrawnaDE;
            }
            set
            {
                _PodstawaPrawnaDE = value;
                tbPodstawaPrawnaDE.Text = _PodstawaPrawnaDE.Wartosc;
            }
        }

        private Atrybut SkładkaKoszty
        {
            get
            {
                _SkładkaKoszty.Wartosc = Convert.ToString(nudKosztyRok.Value);
                return _SkładkaKoszty;
            }
            set
            {
                _SkładkaKoszty = value;
            }
        }

        private Atrybut SkładkaRok
        {
            get
            {
                _SkładkaRok.Wartosc = Convert.ToString(nudSkladkaRok.Value);
                return _SkładkaRok;
            }
            set
            {
                _SkładkaRok = value;
                decimal rok = 2018;
                Decimal.TryParse(_SkładkaRok.Wartosc, out rok);
                nudSkladkaRok.Value = (nudSkladkaRok.Minimum > rok ? nudSkladkaRok.Minimum : rok);
            }
        }

        private Atrybut SkładkaWysokość
        {
            get
            {
                _SkładkaWysokość.Wartosc = Convert.ToString(nudWysoksc.Value);
                return _SkładkaWysokość;
            }
            set
            {
                _SkładkaWysokość = value;
                decimal wysokosc = 0;
                Decimal.TryParse(_SkładkaWysokość.Wartosc, out wysokosc);
                nudWysoksc.Value = (nudWysoksc.Minimum > wysokosc ? nudWysoksc.Minimum : wysokosc);
            }
        }

        private Atrybut SkładkaWysokośćEURO
        {
            get
            {
                _SkładkaWysokośćEURO.Wartosc = Convert.ToString(nudWysokoscEURO.Value);
                return _SkładkaWysokośćEURO;
            }
            set
            {
                _SkładkaWysokośćEURO = value;
                decimal wysokosc = 0;
                Decimal.TryParse(_SkładkaWysokośćEURO.Wartosc, out wysokosc);
                nudWysokoscEURO.Value = (nudWysokoscEURO.Minimum > wysokosc ? nudWysokoscEURO.Minimum : wysokosc);
            }
        }

        private Atrybut Typ
        {
            get
            {
                if (rbToEMail.Checked)
                {
                    _Typ.Wartosc = "2";
                }
                else if (rbToFile.Checked)
                {
                    _Typ.Wartosc = "1";
                }
                return _Typ;
            }
            set
            {
                _Typ = value;
                switch (_Typ.Wartosc)
                {
                    case "1":
                        rbToFile.Checked = true;
                        break;
                    case "2":
                        rbToEMail.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private Atrybut TypCheckboxPLN
        {
            get
            {
                return _TypCheckboxPLN;
            }
            set
            {
                _TypCheckboxPLN = value;
                if (nudWysoksc.Value == 0)
                {
                    checkboxPLN.Checked = false;
                }
                else if (nudWysoksc.Value > 0)
                {
                    checkboxPLN.Checked = true;
                }
            }
        }

        private Atrybut TypCheckboxEURO
        {
            get
            {
                return _TypCheckboxEURO;
            }
            set
            {
                _TypCheckboxEURO = value;
                if (nudWysokoscEURO.Value == 0)
                {
                    checkboxEURO.Checked = false;
                }
                else if (nudWysokoscEURO.Value > 0)
                {
                    checkboxEURO.Checked = true;
                }
            }
        }

        //private Atrybut TypCheckboxZbiorczaNota
        //{
        //    get
        //    {
        //        return _TypCheckboxZbiorczaNota;
        //    }
        //    set
        //    {
        //        _TypCheckboxZbiorczaNota = value;
        //        if (nudWysoksc.Value == 0)
        //        {
        //            checkZbiorczaNota.Checked = false;
        //        }
        //        else if (nudWysoksc.Value > 0)
        //        {
        //            checkZbiorczaNota.Checked = true;
        //        }
        //    }
        //}

        private Atrybut DataNota
        {
            get
            {
                _DataNota.Wartosc = Convert.ToString(dtDataNota.Value);
                return _DataNota;
            }
            set
            {
                _DataNota = value;

            }
        }

        private Atrybut SchematNumer
        {
            get
            {
                _SchematNumer.Wartosc = tbSchematNumer.Text;
                return _SchematNumer;
            }
            set
            {
                _SchematNumer = value;
                tbSchematNumer.Text = _SchematNumer.Wartosc;
            }
        }

        private Atrybut IloscDni
        {
            get
            {
                _IloscDni.Wartosc = Convert.ToString(nudIlDni.Value);
                return _IloscDni;
            }
            set
            {
                _IloscDni = value;
            }
        }

        private Atrybut SkładkaTermin
        {
            get
            {
                _SkładkaTermin.Wartosc = Convert.ToString(dtSkladkaTermin.Value);
                return _SkładkaTermin;
            }
            set
            {
                _SkładkaTermin = value;
            }
        }

        private Atrybut NazwaNoty
        {
            get
            {
                _NazwaNoty.Wartosc = Convert.ToString(cbNazwaNoty.SelectedItem);
                return _NazwaNoty;
            }
            set
            {
                _NazwaNoty = value;

                if (cbNazwaNoty.DataSource != null)
                {
                    List<PrintReportSettings> reports = (List<PrintReportSettings>)cbNazwaNoty.DataSource;
                    var item = reports.Where(x => x.Nazwa == _NazwaNoty.Wartosc).FirstOrDefault();
                    int index = reports.IndexOf(item);
                    cbNazwaNoty.SelectedIndex = index;
                    cbNazwaNoty.SelectedItem = item;
                }
            }
        }













        public Main(string _connectionString, int opeNumer)
        {     
            InitializeComponent();

            _ds = new DataService(_connectionString);            

            _opeNumer = opeNumer;
        }



        private void Main_Load(object sender, EventArgs e)
        {
            nudStartNumer.Value = _ds.CounterGenerateNots(0, false);

            cbKampanie.DataSource = _ds.GetKampNagList();
            cbNazwaNoty.DataSource = _ds.GetReports();
        }
        private void cbKampanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEtap.DataSource = _ds.GetKampNagEtapy((KampNag)cbKampanie.SelectedItem);
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbToEMail.Checked || rbToFile.Checked)
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            int numer = Convert.ToInt32(nudStartNumer.Value);

            if (String.IsNullOrEmpty(tbSchematNumer.Text))
            {
                MessageBox.Show("Pole schemat numeracji nie może być puste");
            }
            else if (cbNazwaNoty.SelectedItem == null)
            {
                MessageBox.Show("Wybierz rodzaj noty");
            }
            else
            {
                _ds.SaveAtrybut(WalneZgromadzenie, _opeLogin);

                _ds.SaveAtrybut(Folder, _opeLogin);
                _ds.SaveAtrybut(NazwaBankuPL, _opeLogin);
                _ds.SaveAtrybut(NumerRachunkuPL, _opeLogin);

                _ds.SaveAtrybut(NazwaBankuDE, _opeLogin);
                _ds.SaveAtrybut(NumerRachunkuDE, _opeLogin);
                _ds.SaveAtrybut(PodpisPL, _opeLogin);
                _ds.SaveAtrybut(PodpisDE, _opeLogin);
                _ds.SaveAtrybut(PodstawaPrawnaPL, _opeLogin);
                _ds.SaveAtrybut(SkładkaKoszty, _opeLogin);
                _ds.SaveAtrybut(SkładkaRok, _opeLogin);
                _ds.SaveAtrybut(SkładkaTermin, _opeLogin);
                _ds.SaveAtrybut(SkładkaWysokość, _opeLogin);
                _ds.SaveAtrybut(SkładkaWysokośćEURO, _opeLogin);
                _ds.SaveAtrybut(Typ, _opeLogin);

                _ds.SaveAtrybut(DataNota, _opeLogin);
                _ds.SaveAtrybut(SchematNumer, _opeLogin);

                _ds.SaveAtrybut(PodstawaPrawnaDE, _opeLogin);

                _ds.SaveAtrybut(IloscDni, _opeLogin);
                _ds.SaveAtrybut(NazwaNoty, _opeLogin);

                string schematnumeracji = tbSchematNumer.Text;

                if (schematnumeracji.Substring(schematnumeracji.Length - 1, 1) == "/")
                {
                    schematnumeracji = schematnumeracji.Substring(0, schematnumeracji.Length - 1);
                }

                string rokNumeru = Convert.ToString(nudSkladkaRok.Value).Substring(2, 2);
                if (String.IsNullOrEmpty(tbDirectory.Text))
                {
                    MessageBox.Show("W celu wygenerowania noty(not) należy zaznaczyć opcję nota zbiorcza lub wskazać folder docelowy gdzie będą zapisane ich kopie.");
                }
                else
                {

                    List<EtapKnt> kntList = _ds.GetKntList((KampEtap)cbEtap.SelectedItem);

                    //List<EtapKnt> kntList_nie = _ds.GetKntLisNIE((KampEtap)cbEtap.SelectedItem);

                    //List<EtapKnt> kntList_tak = _ds.GetKntLisTAK((KampEtap)cbEtap.SelectedItem);

                    //if (rbToFile.Checked)
                    //{

                        //string message = "Czy chcesz wygenerować " + (kntList_nie.Count) + " not? Potwierdź!";
                        string message = "Czy chcesz wygenerować " + (kntList.Count) + " not? Potwierdź!";
                        string caption = "Potwierdzenie!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult dialog_result = MessageBox.Show(message, caption, buttons);

                        if (dialog_result == System.Windows.Forms.DialogResult.Yes)
                        {

                            string login = "", email = "";

                            int knt_id = 0;

                            XLLoginInfo_20182 sesja_logowania = new XLLoginInfo_20182 { ProgramID = "GenerowanieNot", Wersja = _wersja, UtworzWlasnaSesje = 0 };
                            int sesjaId = 0;
                            int result = cdn_api.cdn_api.XLLogin(sesja_logowania, ref sesjaId);

                            if (result != 0)
                            {
                                MessageBox.Show("Wystąpił błąd logowania do bazy:" + Convert.ToString(result));
                            }
                            else
                            {

                                numer = Convert.ToInt32(nudStartNumer.Value);

                                List<Object> infos;


                            //string connectionString = "Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;";

                            //DataService ds = new DataService(connectionString);

                            //foreach (EtapKnt knt in kntList_nie)

                            //foreach (EtapKnt knt in kntList.OrderBy(o => o.Knt_Akronim).ToList())


                            //string zm_str = "";


                            foreach (EtapKnt knt in kntList)
                            {
                                    nudStartNumer.Value = numer;

                                    infos = _ds.GetEmailNotaStatut(knt.Knt_GIDNumer, Runtime.Config.NumerOperatora);

                                    login = infos.ElementAt(0).ToString();
                                    email = infos.ElementAt(1).ToString();

                                    Atrybut atr = new Atrybut
                                    {
                                        Klasa = "NotaNumer",
                                        Typ = 4176,
                                        Lp = 0,
                                        Numer = (int)knt.CEK_ID,
                                        SubLp = 32,
                                        Wartosc = numer.ToString()
                                    };



                                    _ds.SaveAtrybut(atr, _opeLogin);

                                    string file = String.Format("{0}_{1}_{2}_{3}_{4}.pdf", nudSkladkaRok.Value.ToString(), "NOTA", "AHK", knt.Knt_Akronim, numer.ToString());

                                    file = string.Join("_", file.Split(Path.GetInvalidFileNameChars()));
                                    file = System.IO.Path.Combine(tbDirectory.Text, file);

                                    string printResult = print(knt, file);

                                    //string printResult = printUzupelnionaENota(knt, file);

                                    //UzupelnionaENota

                                    saveFileToKnt(knt, file);

                                    //_ds.PobierzAdresMailowyOdbiorcy((long)knt.CEK_ID.Value);



                                    //zm_str = _ds.PobierzAdresMailowyOdbiorcy((long)knt.CEK_KntNumer.Value).ToString();



                                    if (rbToEMail.Checked)
                                    {
                                        prepareEMail(file, knt.Subject_Email, knt.Message_EMail, email);                                        
                                        //prepareEMail(file, String.Format(@"{0}_{1}_{2}_{3}_{4}.pdf", nudSkladkaRok.Value.ToString(), "NOTA", "AHK", knt.Knt_Akronim, numer), "piotr.szyperek@t2s.pl");
                                    }

                                    _ds.CounterGenerateNots(numer, true);

                                    numer += 1;

                                }



                                cdn_api.cdn_api.XLLogout(sesjaId);

                                nudStartNumer.Value = numer;

                            }

                            MessageBox.Show("Operacja zakończona");

                        }
                        else if (dialog_result == System.Windows.Forms.DialogResult.No)
                        {

                            dialog_result = System.Windows.Forms.DialogResult.Cancel;

                        }
                    //tutaj}
                    /*else if (rbToEMail.Checked)
                    {

                        //List<EtapKnt> kntList_tak = _ds.GetKntListTAK((KampEtap)cbEtap.SelectedItem);

                        string message = "Czy chcesz wygenerować " + (kntList_tak.Count) + " not? Potwierdź!";
                        string caption = "Potwierdzenie!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult dialog_result = MessageBox.Show(message, caption, buttons);

                        if (dialog_result == System.Windows.Forms.DialogResult.Yes)
                        {

                            string login = "", email = "";

                            int knt_id = 0;

                            XLLoginInfo_20182 sesja_logowania = new XLLoginInfo_20182 { ProgramID = "GenerowanieNot", Wersja = _wersja, UtworzWlasnaSesje = 0 };
                            int sesjaId = 0;
                            int result = cdn_api.cdn_api.XLLogin(sesja_logowania, ref sesjaId);

                            if (result != 0)
                            {
                                MessageBox.Show("Wystąpił błąd logowania do bazy:" + Convert.ToString(result));
                            }
                            else
                            {

                                numer = Convert.ToInt32(nudStartNumer.Value);

                                List<Object> infos;

                                //foreach (EtapKnt knt in kntList.OrderBy(o => o.Knt_Akronim).ToList())



                                foreach (EtapKnt knt in kntList_tak)
                                {                                                                       

                                    nudStartNumer.Value = numer;

                                    infos = _ds.GetEmailNotaStatut(knt.Knt_GIDNumer, Runtime.Config.NumerOperatora);

                                    login = infos.ElementAt(0).ToString();
                                    email = infos.ElementAt(1).ToString();

                                    Atrybut atr = new Atrybut
                                    {
                                        Klasa = "NotaNumer",
                                        Typ = 4176,
                                        Lp = 0,
                                        Numer = (int)knt.CEK_ID,
                                        SubLp = 32,
                                        Wartosc = numer.ToString()
                                    };



                                    _ds.SaveAtrybut(atr, _opeLogin);

                                    string file = String.Format("{0}_{1}_{2}_{3}_{4}.pdf", nudSkladkaRok.Value.ToString(), "NOTA", "AHK", knt.Knt_Akronim, numer.ToString());

                                    file = string.Join("_", file.Split(Path.GetInvalidFileNameChars()));
                                    file = System.IO.Path.Combine(tbDirectory.Text, file);

                                    string printResult = print(knt, file);

                                    //string printResult = printUzupelnionaENota(knt, file);

                                    //UzupelnionaENota

                                    saveFileToKnt(knt, file);

                                    //if (rbToEMail.Checked)
                                    //{
                                    prepareEMail(file, knt.Subject_Email, knt.Message_EMail, knt.Email);
                                    ////    //prepareEMail(file, String.Format(@"{0}_{1}_{2}_{3}_{4}.pdf", nudSkladkaRok.Value.ToString(), "NOTA", "AHK", knt.Knt_Akronim, numer), "piotr.szyperek@t2s.pl");
                                    //}

                                    _ds.CounterGenerateNots(numer, true);

                                    numer += 1;

                                }



                                cdn_api.cdn_api.XLLogout(sesjaId);

                                nudStartNumer.Value = numer;

                            }

                            MessageBox.Show("Operacja zakończona");

                        }
                        else if (dialog_result == System.Windows.Forms.DialogResult.No)
                        {

                            dialog_result = System.Windows.Forms.DialogResult.Cancel;

                        }

                    }               */

                }
            }
        }

        private void cbEtap_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Atrybut> infos = _ds.GetKampEtapInfo((KampEtap)cbEtap.SelectedItem, _opeNumer, out _opeLogin);

            WalneZgromadzenie = infos.Where(x => x.Klasa == "WalneZgromadzenieRok").FirstOrDefault();

            Folder = infos.Where(x => x.Klasa == "Folder").FirstOrDefault();
            NazwaBankuPL = infos.Where(x => x.Klasa == "NazwaBanku").FirstOrDefault();
            NumerRachunkuPL = infos.Where(x => x.Klasa == "NumerRachunku").FirstOrDefault();
            NazwaBankuDE = infos.Where(x => x.Klasa == "NazwaBankuDE").FirstOrDefault();
            NumerRachunkuDE = infos.Where(x => x.Klasa == "NumerRachunkuDE").FirstOrDefault();
            PodpisPL = infos.Where(x => x.Klasa == "Podpis").FirstOrDefault();
            PodpisDE = infos.Where(x => x.Klasa == "PodpisDE").FirstOrDefault();

            SkładkaKoszty = infos.Where(x => x.Klasa == "SkładkaKoszty").FirstOrDefault();

            SkładkaRok = infos.Where(x => x.Klasa == "SkładkaRok").FirstOrDefault();
            SkładkaTermin = infos.Where(x => x.Klasa == "SkładkaTermin").FirstOrDefault();
            SkładkaWysokość = infos.Where(x => x.Klasa == "SkładkaWysokość").FirstOrDefault();
            SkładkaWysokośćEURO = infos.Where(x => x.Klasa == "SkładkaWysokośćEURO").FirstOrDefault();
            Typ = infos.Where(x => x.Klasa == "Typ").FirstOrDefault();
            TypCheckboxPLN = infos.Where(x => x.Klasa == "TypCheckboxPLN").FirstOrDefault();
            TypCheckboxEURO = infos.Where(x => x.Klasa == "TypCheckboxEURO").FirstOrDefault();
         
            DataNota = infos.Where(x => x.Klasa == "DataNota").FirstOrDefault();

            SchematNumer = infos.Where(x => x.Klasa == "SchematNumer").FirstOrDefault();

            IloscDni = infos.Where(x => x.Klasa == "IloscDni").FirstOrDefault();

            PodstawaPrawnaDE = infos.Where(x => x.Klasa == "PodstawaPrawnaDE").FirstOrDefault();
            PodstawaPrawnaPL = infos.Where(x => x.Klasa == "PodstawaPrawna").FirstOrDefault();

            NazwaNoty = infos.Where(x => x.Klasa == "NazwaNoty").FirstOrDefault();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void dtDataNota_ValueChanged(object sender, EventArgs e)
        {

 /*           String s = nudStartNumer.Value.ToString();
            DateTime data = Convert.ToDateTime(s); 

            //DateTime data = ObjectToDateTime(data222, someDateTime);

            if (dtSkladkaTermin.Value.Date < data)
            {
                //nudIlDni.Value = Convert.ToDecimal(nudKosztyRok.Value.Date);
                nudStartNumer.Value = 0;
            }
            else
            {
                decimal test = Convert.ToDecimal((dtSkladkaTermin.Value.Date - data).TotalDays);
                nudStartNumer.Value = (test < 0) ? 0 : test;
            }                           */

            //nudStartNumer.Value = _ds.GetStartNumer(dtDataNota.Value);
        }



        public static DateTime ObjectToDateTime(object o, DateTime defaultValue)
        {
            DateTime result;
            if (DateTime.TryParse((o ?? "").ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }



        private string print(EtapKnt etapKnt, string file)
        {
            PrintReportSettings prs = (PrintReportSettings)cbNazwaNoty.SelectedItem;
            prs.FileName = file;
            prs.FiltrSQL = etapKnt.FiltrSQL;
            return generatePrint(prs);
        }

        private string printUzupelnionaENota(EtapKnt etapKntUzupelnionaENota, string file)
        {
            PrintReportSettings prs = (PrintReportSettings)cbNazwaNoty.SelectedItem;
            prs.FileName = file;
            prs.FiltrSQL = etapKntUzupelnionaENota.FiltrSQL;
            return generatePrint(prs);
        }
        //_ds.GetKntListUzupelnionaENota

        public string generatePrint(PrintReportSettings printReportSettings)
        {
            string result = "OK";
            cdn_api.XLWydrukInfo_20182 wydruk = new cdn_api.XLWydrukInfo_20182();
            wydruk.DrukujDoPliku = 1;
            wydruk.Wersja = _wersja;
            wydruk.Zrodlo = printReportSettings.Zrodlo;
            wydruk.Wydruk = printReportSettings.Wydruk;
            wydruk.Format = printReportSettings.Format;
            wydruk.FiltrSQL = printReportSettings.FiltrSQL;
            wydruk.PlikDocelowy = printReportSettings.FileName;

            int printresult = cdn_api.cdn_api.XLWykonajPodanyWydruk(wydruk);
            if (printresult != 0)
            {
                result = "Błąd generowania wydruku do pliku:" + getErrorMessage(87, printresult);
            }
            return result;
        }
        private string getErrorMessage(int fun, int error)
        {
            try
            {
                cdn_api.XLKomunikatInfo_20182 kom = new cdn_api.XLKomunikatInfo_20182();
                kom.Wersja = _wersja;
                kom.Funkcja = fun;
                kom.Blad = error;
                cdn_api.cdn_api.XLOpisBledu(kom);
                return kom.OpisBledu;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void saveFileToKnt(EtapKnt knt, string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            string articleShortName = fileInfo.Name;

            byte[] file;

            using (var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            _ds.SaveData(new BinaryData
            {
                ShortName = fileInfo.Name,
                Name = fileInfo.Name,
                Extension = fileInfo.Extension.Replace(".", ""),
                Data = file,
                PK = 1,
                GidTyp = knt.Knt_GIDTyp,
                GidNumer = knt.Knt_GIDNumer
            });

        }
        private void saveFile(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            string articleShortName = fileInfo.Name;

            byte[] file;
            
            using (var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int) stream.Length);
                }
            }
        }
        private void prepareEMail(string file,string subject,string message, string email)
        {
            /*            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                        Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        oMsg.Subject = subject;

                        //oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                        //string MessageBody = "<p>Szanowni Państwo,<br />w załączeniu przesyłamy notę statutową za członkostwo w AHK Polska na rok ……… .<br /><br />Sehr geehrte Damen und Herren,<br />im Anhang erhalten Sie eine Belastungsnote für den Mitgliedsbeitrag AHK Polen für das Jahr ………. .<br /><br />Pozdrawiam serdecznie,<br />Mit freundlichen Grüssen,<br /><br />Administracja Serwisu Członkowskiego<br />Mitgliederbetreuung<br /><br />Polsko - Niemiecka Izba Przemysłowo-Handlowa(AHK Polska)<br />Deutsch - Polnische Industrie - und Handelskammer(AHK Polen)<br />ul. Miodowa 14, 00 - 246 Warszawa, T.<a href=''>+ 48(22) 53 10 501</a>, F.+ 48(22) 53 10 600, E - Mail: <a href=''>ms@ahk.pl</a><br />Biura regionalne / Regionalbüros: Katowice, München, Poznań, Wrocław<br />Sąd Rejonowy dla m.st.Warszawy, XII Wydział Gospodarczy KRS 0000093438 / Amtsgericht für die Landeshauptstadt Warschau, Register-Mr.: 0000093438<br /><a href='www.ahk.pl/pl/politykaprywatnosci'>www.ahk.pl/pl/politykaprywatnosci</a>    <a href='www.ahk.pl/datenschutzerklaerung'>www.ahk.pl/datenschutzerklaerung</a><br /><br /><br /><a href='www.ahk.pl'>www.ahk.pl</a>    <a href='www.marktplatz.pl'>www.marktplatz.pl</a><br /><br />Partnerzy Premium / Premium Partner:<br />Lufthansa - Santander Bank - STU ERGO Hestia  -T - Mobile</p>";

                        oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                        oMsg.HTMLBody = message;         

                        if (!String.IsNullOrEmpty(email))
                        {
                            Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oMsg.Recipients.Add(email);
                            oRecip.Resolve();                
                        }

                        if (System.IO.File.Exists(file))
                        {
                            oMsg.Attachments.Add(file, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                        }

                        oMsg.Send();

                        oMsg.SaveSentMessageFolder.;

                        oMsg.SaveS

                        //oMsg.SenderEmailType = MailSendType.SendDirect;

                        //oMsg.Display(false);
                        //oMsg.Close(Microsoft.Office.Interop.Outlook.OlInspectorClose.olSave);                             */



                        string MessageBody = "<p>Szanowni Państwo,<br />w załączeniu przesyłamy notę statutową za członkostwo w AHK Polska na rok " + SkładkaRok + ".<br /><br />Sehr geehrte Damen und Herren,<br />im Anhang erhalten Sie eine Belastungsnote für den Mitgliedsbeitrag AHK Polen für das Jahr " + SkładkaRok + ".<br /><br />Pozdrawiam serdecznie,<br />Mit freundlichen Grüssen,<br /><br />Administracja Serwisu Członkowskiego<br />Mitgliederbetreuung<br /><br />Polsko - Niemiecka Izba Przemysłowo-Handlowa(AHK Polska)<br />Deutsch - Polnische Industrie - und Handelskammer(AHK Polen)<br />ul.Miodowa 14, 00 - 246 Warszawa, T.<a href=''>+ 48(22) 53 10 501</a>, F.+ 48(22) 53 10 600, E - Mail: <a href=''>ms@ahk.pl</a><br />Biura regionalne / Regionalbüros: Katowice, München, Poznań, Wrocław<br />Sąd Rejonowy dla m.st.Warszawy, XII Wydział Gospodarczy KRS 0000093438 / Amtsgericht für die Landeshauptstadt Warschau, Register-Mr.: 0000093438<br /><a href='www.ahk.pl/pl/politykaprywatnosci'>www.ahk.pl/pl/politykaprywatnosci</a>    <a href='www.ahk.pl/datenschutzerklaerung'>www.ahk.pl/datenschutzerklaerung</a><br /><br /><br /><a href='www.ahk.pl'>www.ahk.pl</a>    <a href='www.marktplatz.pl'>www.marktplatz.pl</a><br /><br />Partnerzy Premium / Premium Partner:<br />Lufthansa - Santander Bank - STU ERGO Hestia  -T - Mobile</p>";

                        Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                        Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        oMsg.Subject = "Nota statutowa AHK Polska / Mitgliedsbeitrag AHK Polen";

                        if (!String.IsNullOrEmpty(email))
                        {
                            Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oMsg.Recipients.Add(email);
                            oRecip.Resolve();
                        }

                        //Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oMsg.Recipients.Add(email);

                        //oRecip.Resolve();

                        //oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                        oMsg.HTMLBody = MessageBody;

                        //oMsg.HTMLBody = message;

                        if (System.IO.File.Exists(file))
                        {
                            oMsg.Attachments.Add(file, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                        }

                        oMsg.Display(false);
                        oMsg.Close(Microsoft.Office.Interop.Outlook.OlInspectorClose.olSave);







        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxPLN.Checked)
            {                
                nudWysoksc.Enabled = true;
            }
            else
            {             
                nudWysoksc.Enabled = false;
            }

            if (checkboxEURO.Checked)
            {                
                nudWysokoscEURO.Enabled = true;
            }
            else
            {                
                nudWysokoscEURO.Enabled = false;
            }

                      

        }



        private void dtSkladkaTermin_ValueChanged(object sender, EventArgs e)
        {

/*            DateTime data = Convert.ToDateTime(nudStartNumer.Value);

            if (!nudIlDniclik)
            {
                dtSkladkaTerminclik = true;                

                decimal test = (decimal)(dtSkladkaTermin.Value.Date - data).TotalDays;
                nudIlDni.Value = (test < 0) ? 0 : test;

                //nudIlDni.Value < 0 && 

                if ( dtSkladkaTermin.Value.Date < data )
                {
                    //nudIlDni.Value = Convert.ToDecimal(nudKosztyRok.Value.Date);
                    nudIlDni.Value = 0;
                }

                dtSkladkaTerminclik = true;
            }                               */
        }



        private void nudIlDni_ValueChanged(object sender, EventArgs e)
        {
/*            if (!dtSkladkaTerminclik)
            {
                nudIlDniclik = true;

                try
                {
                    //dtSkladkaTermin.Value = Convert.ToDateTime(dtDataNota.Value);

                    //dtSkladkaTermin.Value = Convert.ToDateTime(dtSkladkaTermin.Value.AddDays((double)nudIlDni.Value));

                    //dtSkladkaTermin.Value = Convert.ToDateTime(nudKosztyRok.Value.AddDays((double)nudIlDni.Value));

                    dtSkladkaTermin.Value = Convert.ToDateTime(nudStartNumer.Value).AddDays((double)nudIlDni.Value);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                nudIlDniclik = false;
            }
            else
            {
                //dtSkladkaTermin.Value = Convert.ToDateTime(dtDataNota.Value);

                dtSkladkaTermin.Value = Convert.ToDateTime(nudKosztyRok.Value.AddDays((double)nudIlDni.Value));
            }                           */
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nudKosztyRok_ValueChanged(object sender, EventArgs e)
        {
/*            if (dtSkladkaTermin.Value.Date < nudKosztyRok.Value.Date)
            {
                //nudIlDni.Value = Convert.ToDecimal(nudKosztyRok.Value.Date);
                nudIlDni.Value = 0;
            }
            else
            {
                decimal test = (decimal)(dtSkladkaTermin.Value.Date - nudKosztyRok.Value.Date).TotalDays;
                nudIlDni.Value = (test < 0) ? 0 : test;
            }           */
        }
    }
}
