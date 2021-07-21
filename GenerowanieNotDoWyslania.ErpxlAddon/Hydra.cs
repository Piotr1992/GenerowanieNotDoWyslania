using Hydra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data;
using ADODB;

[assembly: CallbackAssemblyDescription("GenerowanieNotDoWyslania", "56. Generowanie not do wysłania", "T2S Sp. z o.o.", "1", "2018.2", "05-11-2018")]
namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    [SubscribeProcedure((Procedures)Procedures.CRMListaObslugi, "Generowanie not do wysłania")]
    public class HydraCRMListaObslugi : Callback
    {
        static string connectionString = "Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;";        
        ClaWindow _Parent;
        ClaWindow _Button;
        Label _Label;
        TextBox _TextBox;

        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow));
            AddSubscription(true, 0, Events.ResizeWindow, new TakeEventDelegate(OnResizeWindow));
        }
        public override void Cleanup()
        {

        }
        private bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {
            _Parent = GetWindow();
            _Button = _Parent.AllChildren.Add(ControlTypes.button);
            _Button.TextRaw = "GENEROWANIE NOT";
            _Button.ToolTipRaw = "GENEROWANIE NOT(2018.2)";
            _Button.Enabled = true;
            _Button.Visible = true;
            _Button.OnAfterAccepted += new TakeEventDelegate(OnButtonAccepted);

            return true;
        }
        private bool OnResizeWindow(Procedures ProcId, int ControlId, Events Event)
        {
            if (_Button != null)
            {
                Rectangle mWndBnd = GetWindow().Bounds;
                _Button.Bounds = new Rectangle(mWndBnd.Width - 95, mWndBnd.Height - 40, 70, 15);
            }

            return true;
        }

        private bool OnButtonAccepted(Procedures ProcId, int ControlId, Events Event)
        {
            Main main = new Main(connectionString, Runtime.Config.NumerOperatora);
            main.ShowDialog();

            return true;
        }

    }


    [SubscribeProcedure((Procedures)Procedures.KntEdycja, "Pole do uzupełniania adresu e-mail dla not człownkowskich")]
    public class HydraKntEdycja : Callback
    {
        string connectionString;
        string login;
        string email;

        ClaWindow _Parent;
        ClaWindow _Label;
        ClaWindow _TextBox;

        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow));
            AddSubscription(true, 0, Events.ResizeWindow, new TakeEventDelegate(OnResizeWindow));
        }
        public override void Cleanup()
        {
        }
        private bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {
            connectionString = "Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("CDN.T2S_GetEmailNotaStatut", conn);
            conn.Open();
            comm.Parameters.AddWithValue("@kntnumer", KntKarty.Knt_GIDNumer);
            comm.Parameters.AddWithValue("@openumer", Runtime.Config.NumerOperatora);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                email = Convert.ToString(reader["Email"]);
                login = Convert.ToString(reader["Ope_ident"]);
            }
            conn.Close();
            _Parent = GetWindow();
            ClaWindow kontakty = _Parent.AllChildren["?TabOsoby"];
            ClaWindow save = _Parent.AllChildren["?Cli_Zapisz"];
            _Label = kontakty.AllChildren.Add(ControlTypes.prompt);
            _Label.TextRaw = "Noty statutowe przesyłane elektronicznie na adres:";
            _Label.ToolTipRaw = "(2018.2)";
            _Label.Enabled = true;
            _Label.Visible = true;
            _Label.BackgroundRaw = "16777215";
            _TextBox = kontakty.AllChildren.Add(ControlTypes.text);
            _TextBox.ToolTipRaw = "(2018.2)";
            _TextBox.ScreenTextRaw = email;
            _TextBox.TextRaw = email;
            _TextBox.Enabled = true;
            _TextBox.Visible = true;
            OnResizeWindow(ProcId, ControlId, Event);
            save.OnAfterAccepted += Save_OnAfterAccepted;
            return true;
        }


        private bool Save_OnAfterAccepted(Procedures ProcedureId, int ControlId, Events Event)
        {
            string email = string.Empty;
            if (!String.IsNullOrEmpty(_TextBox.ScreenTextRaw))
            {
                email = _TextBox.ScreenTextRaw;
            }
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("CDN.T2S_UpdateAtrybut", conn);
            comm.Parameters.AddWithValue("@typ", KntKarty.Knt_GIDTyp);
            comm.Parameters.AddWithValue("@numer", KntKarty.Knt_GIDNumer);
            comm.Parameters.AddWithValue("@lp", KntKarty.Knt_GIDLp);
            comm.Parameters.AddWithValue("@sublp", 0);
            comm.Parameters.AddWithValue("@klasa", "E-mail noty statutowe");
            comm.Parameters.AddWithValue("@wartosc", email);
            comm.Parameters.AddWithValue("@login", login);
            comm.Parameters.AddWithValue("@autoCreateGidTyp", 32);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return true;
        }


        private bool OnResizeWindow(Procedures ProcId, int ControlId, Events Event)
        {
            Rectangle mWndBnd = _Parent.Bounds;
            if (_Label != null)
            {
                _Label.Bounds = new Rectangle(10, mWndBnd.Height - 40, 170, 15);
            }
            if (_TextBox != null)
            {
                _TextBox.Bounds = new Rectangle(180, mWndBnd.Height - 40, 240, 10);
            }
            return true;
        }
    }


    [SubscribeProcedure((Procedures)Procedures.ListaPlatnosci, "Generowanie not do wysłania")]
    public class HydraPreliminarz : Callback
    {
        string connectionString;
        ClaWindow _Parent;
        ClaWindow _Button;

        Label _Label;
        TextBox _TextBox;

        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow));
            AddSubscription(true, 0, Events.ResizeWindow, new TakeEventDelegate(OnResizeWindow));
        }
        public override void Cleanup()
        {

        }
        private bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {
            connectionString = "Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;";
            _Parent = GetWindow();
            _Button = _Parent.AllChildren.Add(ControlTypes.button);
            _Button.TextRaw = "Wyślij e-mail";
            _Button.ToolTipRaw = "Wyślij e-mail";
            _Button.Enabled = true;
            _Button.Visible = true;
            _Button.OnAfterAccepted += new TakeEventDelegate(OnButtonAccepted);

            return true;
        }
        private bool OnResizeWindow(Procedures ProcId, int ControlId, Events Event)
        {
            if (_Button != null)
            {
                Rectangle mWndBnd = GetWindow().Bounds;
                _Button.Bounds = new Rectangle(mWndBnd.Width - 500, mWndBnd.Height - 50, 70, 15);
            }

            return true;
        }

        private bool OnButtonAccepted(Procedures ProcId, int ControlId, Events Event)
        {

            string connectionString = "Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;";

            DataService ds = new DataService(connectionString);

            ADODB._Recordset recordset = Runtime.WindowController.GetQueueMarked((int)ProcId, GetWindow().AllChildren["?Platnosci"].Id, GetCallbackThread());

            int count = recordset.RecordCount;

            if (count == 0)
                return true;
            
            List<string> selectedOrders = new List<string>();

            String KntAdresMail = "";

            try
            {
                if (recordset != null && recordset.RecordCount > 0)
                {
                    recordset.MoveFirst();
                    while (recordset.EOF == false)
                    {
                        ADODB.Fields fields = recordset.Fields;
                        for (int i = 0; i < fields.Count; i++)
                        {
                            string sName = fields[i].Name;
                            string sValue = fields[i].Value.ToString();
                                                       
                            if (sName == "NUMER")
                            {
                                int gidnumer = 0;
                                if (Int32.TryParse(sValue, out gidnumer))
                                {
                                    selectedOrders.Add(sValue);

                                    MessageBox.Show("sValue = " + sValue + " ; sName = " + sName + " ; Knt_Email = " + ds.PobierzAdresMailowy(TraPlat.TrP_GIDNumer));
                                }
                            }
                            else
                            {
                                int gidnumer = 0;
                                if (Int32.TryParse(sValue, out gidnumer))
                                {
                                    selectedOrders.Add(sValue);                                    
                                }                                
                            }
                        }
                        recordset.MoveNext();
                    }
                }
                else {

                }
            }
            catch (Exception ex)
            {                            
                if (recordset != null && recordset.RecordCount > 0)
                {
                    recordset.MoveFirst();
                    while (recordset.EOF == false)
                    {
                        ADODB.Fields fields = recordset.Fields;
                        for (int i = 0; i < fields.Count; i++)
                        {
                            string sName = fields[i].Name;
                            string sValue = fields[i].Value.ToString();

                            if (sName == "NUMER")
                            {
                                int gidnumer = 0;
                                if (Int32.TryParse(sValue, out gidnumer))
                                {
                                    selectedOrders.Add(sValue);
                                }                                
                            }
                            else
                            {
                                int gidnumer = 0;
                                if (Int32.TryParse(sValue, out gidnumer))
                                {
                                    selectedOrders.Add(sValue);
                                }                                
                            }
                        }
                        recordset.MoveNext();
                    }
                }
            }

            return true;
        }


        private bool WykonajAkcje(Procedures ProcId, int ControlId, Events Event)
        {
            MessageBox.Show("Execute action!");

            return true;
        }

    }

}

