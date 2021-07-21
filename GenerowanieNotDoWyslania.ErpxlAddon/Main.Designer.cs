namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEtap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKampanie = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudWalneZgromadzenie = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudWysoksc = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSkladkaRok = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dtSkladkaTermin = new System.Windows.Forms.DateTimePicker();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnSetDirectory = new System.Windows.Forms.Button();
            this.rbToFile = new System.Windows.Forms.RadioButton();
            this.rbToEMail = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dtDataNota = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSchematNumer = new System.Windows.Forms.TextBox();
            this.nudStartNumer = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.nudIlDni = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.cbNazwaNoty = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudKosztyRok = new System.Windows.Forms.DateTimePicker();
            this.tbRachunekPL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbBankPL = new System.Windows.Forms.TextBox();
            this.tbRachunekDE = new System.Windows.Forms.TextBox();
            this.tbBankDE = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.nudWysokoscEURO = new System.Windows.Forms.NumericUpDown();
            this.checkboxPLN = new System.Windows.Forms.CheckBox();
            this.checkboxEURO = new System.Windows.Forms.CheckBox();
            this.tbPodpisPL = new System.Windows.Forms.TextBox();
            this.tbPodstawaPrawnaDE = new System.Windows.Forms.TextBox();
            this.tbPodstawaPrawnaPL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPodpisDE = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.CheckBoxPodstawaPrawnaPL = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalneZgromadzenie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWysoksc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSkladkaRok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartNumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIlDni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWysokoscEURO)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbEtap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbKampanie);
            this.groupBox1.Location = new System.Drawing.Point(42, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wybór Kampanii/Etapu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Etap:";
            // 
            // cbEtap
            // 
            this.cbEtap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEtap.FormattingEnabled = true;
            this.cbEtap.Location = new System.Drawing.Point(500, 19);
            this.cbEtap.Name = "cbEtap";
            this.cbEtap.Size = new System.Drawing.Size(288, 21);
            this.cbEtap.TabIndex = 2;
            this.cbEtap.SelectedIndexChanged += new System.EventHandler(this.cbEtap_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kampania:";
            // 
            // cbKampanie
            // 
            this.cbKampanie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKampanie.FormattingEnabled = true;
            this.cbKampanie.Location = new System.Drawing.Point(114, 19);
            this.cbKampanie.Name = "cbKampanie";
            this.cbKampanie.Size = new System.Drawing.Size(288, 21);
            this.cbKampanie.TabIndex = 0;
            this.cbKampanie.SelectedIndexChanged += new System.EventHandler(this.cbKampanie_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(38, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(484, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rok kiedy zapadła decyzja (Walnego Zgromadzenia Członków AHK Polska) o wysokości " +
    "składki:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudWalneZgromadzenie
            // 
            this.nudWalneZgromadzenie.Location = new System.Drawing.Point(794, 132);
            this.nudWalneZgromadzenie.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudWalneZgromadzenie.Minimum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudWalneZgromadzenie.Name = "nudWalneZgromadzenie";
            this.nudWalneZgromadzenie.Size = new System.Drawing.Size(65, 21);
            this.nudWalneZgromadzenie.TabIndex = 3;
            this.nudWalneZgromadzenie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudWalneZgromadzenie.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 190);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(125, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Wysokość składki:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nudWysoksc
            // 
            this.nudWysoksc.DecimalPlaces = 2;
            this.nudWysoksc.Enabled = false;
            this.nudWysoksc.Location = new System.Drawing.Point(582, 188);
            this.nudWysoksc.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWysoksc.Name = "nudWysoksc";
            this.nudWysoksc.Size = new System.Drawing.Size(98, 21);
            this.nudWysoksc.TabIndex = 5;
            this.nudWysoksc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rok w którym obowiązuje składka:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSkladkaRok
            // 
            this.nudSkladkaRok.Location = new System.Drawing.Point(795, 159);
            this.nudSkladkaRok.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudSkladkaRok.Minimum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudSkladkaRok.Name = "nudSkladkaRok";
            this.nudSkladkaRok.Size = new System.Drawing.Size(64, 21);
            this.nudSkladkaRok.TabIndex = 7;
            this.nudSkladkaRok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSkladkaRok.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(42, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 47);
            this.label6.TabIndex = 8;
            this.label6.Text = "Termin płatności:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtSkladkaTermin
            // 
            this.dtSkladkaTermin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSkladkaTermin.Location = new System.Drawing.Point(755, 233);
            this.dtSkladkaTermin.Name = "dtSkladkaTermin";
            this.dtSkladkaTermin.Size = new System.Drawing.Size(98, 21);
            this.dtSkladkaTermin.TabIndex = 9;
            this.dtSkladkaTermin.ValueChanged += new System.EventHandler(this.dtSkladkaTermin_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(349, 736);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 26);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Wygeneruj";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(468, 735);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 26);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Anuluj";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(109, 635);
            this.tbDirectory.Multiline = true;
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.ReadOnly = true;
            this.tbDirectory.Size = new System.Drawing.Size(491, 23);
            this.tbDirectory.TabIndex = 25;
            // 
            // btnSetDirectory
            // 
            this.btnSetDirectory.Location = new System.Drawing.Point(639, 635);
            this.btnSetDirectory.Name = "btnSetDirectory";
            this.btnSetDirectory.Size = new System.Drawing.Size(41, 23);
            this.btnSetDirectory.TabIndex = 26;
            this.btnSetDirectory.Text = "...";
            this.btnSetDirectory.UseVisualStyleBackColor = true;
            this.btnSetDirectory.Click += new System.EventHandler(this.btnSetDirectory_Click);
            // 
            // rbToFile
            // 
            this.rbToFile.AutoSize = true;
            this.rbToFile.Location = new System.Drawing.Point(109, 670);
            this.rbToFile.Name = "rbToFile";
            this.rbToFile.Size = new System.Drawing.Size(425, 17);
            this.rbToFile.TabIndex = 27;
            this.rbToFile.TabStop = true;
            this.rbToFile.Text = "Generuj noty do wydrukowania - pliki (pdf) zapiszą się w wskazanym wyżej folderze" +
    "";
            this.rbToFile.UseVisualStyleBackColor = true;
            this.rbToFile.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbToEMail
            // 
            this.rbToEMail.AutoSize = true;
            this.rbToEMail.Location = new System.Drawing.Point(109, 693);
            this.rbToEMail.Name = "rbToEMail";
            this.rbToEMail.Size = new System.Drawing.Size(202, 17);
            this.rbToEMail.TabIndex = 29;
            this.rbToEMail.TabStop = true;
            this.rbToEMail.Text = "Generuj noty do wysłania jako E-mail";
            this.rbToEMail.UseVisualStyleBackColor = true;
            this.rbToEMail.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // dtDataNota
            // 
            this.dtDataNota.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataNota.Location = new System.Drawing.Point(539, 63);
            this.dtDataNota.Name = "dtDataNota";
            this.dtDataNota.Size = new System.Drawing.Size(98, 21);
            this.dtDataNota.TabIndex = 31;
            this.dtDataNota.ValueChanged += new System.EventHandler(this.dtDataNota_ValueChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(503, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Data:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(29, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(266, 25);
            this.label15.TabIndex = 33;
            this.label15.Text = "Schemat numeracji dokumentów (np.: MSB/WCU):";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSchematNumer
            // 
            this.tbSchematNumer.Location = new System.Drawing.Point(634, 97);
            this.tbSchematNumer.Name = "tbSchematNumer";
            this.tbSchematNumer.Size = new System.Drawing.Size(225, 21);
            this.tbSchematNumer.TabIndex = 32;
            // 
            // nudStartNumer
            // 
            this.nudStartNumer.Location = new System.Drawing.Point(760, 63);
            this.nudStartNumer.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudStartNumer.Name = "nudStartNumer";
            this.nudStartNumer.Size = new System.Drawing.Size(98, 21);
            this.nudStartNumer.TabIndex = 37;
            this.nudStartNumer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(637, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 18);
            this.label17.TabIndex = 36;
            this.label17.Text = "Numer początkowy:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(715, 230);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 30);
            this.label20.TabIndex = 38;
            this.label20.Text = "Data:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudIlDni
            // 
            this.nudIlDni.Location = new System.Drawing.Point(601, 235);
            this.nudIlDni.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudIlDni.Name = "nudIlDni";
            this.nudIlDni.Size = new System.Drawing.Size(56, 21);
            this.nudIlDni.TabIndex = 39;
            this.nudIlDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIlDni.ValueChanged += new System.EventHandler(this.nudIlDni_ValueChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(539, 234);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 20);
            this.label21.TabIndex = 40;
            this.label21.Text = "Ilość dni:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbNazwaNoty
            // 
            this.cbNazwaNoty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNazwaNoty.FormattingEnabled = true;
            this.cbNazwaNoty.Location = new System.Drawing.Point(142, 737);
            this.cbNazwaNoty.Name = "cbNazwaNoty";
            this.cbNazwaNoty.Size = new System.Drawing.Size(169, 21);
            this.cbNazwaNoty.TabIndex = 41;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(90, 739);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 21);
            this.label22.TabIndex = 42;
            this.label22.Text = "Nota:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(42, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 43);
            this.label7.TabIndex = 10;
            this.label7.Text = "Data kursu NBP:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudKosztyRok
            // 
            this.nudKosztyRok.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nudKosztyRok.Location = new System.Drawing.Point(755, 272);
            this.nudKosztyRok.Name = "nudKosztyRok";
            this.nudKosztyRok.Size = new System.Drawing.Size(98, 21);
            this.nudKosztyRok.TabIndex = 11;
            this.nudKosztyRok.ValueChanged += new System.EventHandler(this.nudKosztyRok_ValueChanged);
            // 
            // tbRachunekPL
            // 
            this.tbRachunekPL.Location = new System.Drawing.Point(203, 313);
            this.tbRachunekPL.Name = "tbRachunekPL";
            this.tbRachunekPL.Size = new System.Drawing.Size(309, 21);
            this.tbRachunekPL.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(42, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nr rachunku bankowego:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(42, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nazwa banku:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(42, 611);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(707, 21);
            this.label13.TabIndex = 24;
            this.label13.Text = "Wybierz folder w którym zostaną zapisane kopie not. Z tego miejsca są pobierane d" +
    "o załączników e-mail i można je też wydrukować.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(346, 293);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "PL";
            // 
            // tbBankPL
            // 
            this.tbBankPL.Location = new System.Drawing.Point(203, 347);
            this.tbBankPL.Multiline = true;
            this.tbBankPL.Name = "tbBankPL";
            this.tbBankPL.Size = new System.Drawing.Size(309, 91);
            this.tbBankPL.TabIndex = 14;
            // 
            // tbRachunekDE
            // 
            this.tbRachunekDE.Location = new System.Drawing.Point(550, 313);
            this.tbRachunekDE.Name = "tbRachunekDE";
            this.tbRachunekDE.Size = new System.Drawing.Size(308, 21);
            this.tbRachunekDE.TabIndex = 50;
            // 
            // tbBankDE
            // 
            this.tbBankDE.Location = new System.Drawing.Point(550, 347);
            this.tbBankDE.Multiline = true;
            this.tbBankDE.Name = "tbBankDE";
            this.tbBankDE.Size = new System.Drawing.Size(309, 91);
            this.tbBankDE.TabIndex = 51;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(701, 293);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(20, 13);
            this.label28.TabIndex = 52;
            this.label28.Text = "DE";
            // 
            // nudWysokoscEURO
            // 
            this.nudWysokoscEURO.DecimalPlaces = 2;
            this.nudWysokoscEURO.Enabled = false;
            this.nudWysokoscEURO.Location = new System.Drawing.Point(761, 189);
            this.nudWysokoscEURO.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWysokoscEURO.Name = "nudWysokoscEURO";
            this.nudWysokoscEURO.Size = new System.Drawing.Size(98, 21);
            this.nudWysokoscEURO.TabIndex = 54;
            this.nudWysokoscEURO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkboxPLN
            // 
            this.checkboxPLN.AutoSize = true;
            this.checkboxPLN.Location = new System.Drawing.Point(535, 190);
            this.checkboxPLN.Name = "checkboxPLN";
            this.checkboxPLN.Size = new System.Drawing.Size(44, 17);
            this.checkboxPLN.TabIndex = 55;
            this.checkboxPLN.Text = "PLN";
            this.checkboxPLN.UseVisualStyleBackColor = true;
            this.checkboxPLN.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // checkboxEURO
            // 
            this.checkboxEURO.AutoSize = true;
            this.checkboxEURO.Location = new System.Drawing.Point(704, 192);
            this.checkboxEURO.Name = "checkboxEURO";
            this.checkboxEURO.Size = new System.Drawing.Size(54, 17);
            this.checkboxEURO.TabIndex = 56;
            this.checkboxEURO.Text = "EURO";
            this.checkboxEURO.UseVisualStyleBackColor = true;
            this.checkboxEURO.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // tbPodpisPL
            // 
            this.tbPodpisPL.Location = new System.Drawing.Point(203, 537);
            this.tbPodpisPL.Multiline = true;
            this.tbPodpisPL.Name = "tbPodpisPL";
            this.tbPodpisPL.Size = new System.Drawing.Size(309, 59);
            this.tbPodpisPL.TabIndex = 20;
            // 
            // tbPodstawaPrawnaDE
            // 
            this.tbPodstawaPrawnaDE.Location = new System.Drawing.Point(347, 0);
            this.tbPodstawaPrawnaDE.Multiline = true;
            this.tbPodstawaPrawnaDE.Name = "tbPodstawaPrawnaDE";
            this.tbPodstawaPrawnaDE.Size = new System.Drawing.Size(308, 66);
            this.tbPodstawaPrawnaDE.TabIndex = 18;
            // 
            // tbPodstawaPrawnaPL
            // 
            this.tbPodstawaPrawnaPL.Location = new System.Drawing.Point(0, 0);
            this.tbPodstawaPrawnaPL.Multiline = true;
            this.tbPodstawaPrawnaPL.Name = "tbPodstawaPrawnaPL";
            this.tbPodstawaPrawnaPL.Size = new System.Drawing.Size(309, 66);
            this.tbPodstawaPrawnaPL.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPodstawaPrawnaDE);
            this.groupBox3.Controls.Add(this.tbPodstawaPrawnaPL);
            this.groupBox3.Location = new System.Drawing.Point(203, 452);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(656, 66);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // tbPodpisDE
            // 
            this.tbPodpisDE.Location = new System.Drawing.Point(550, 537);
            this.tbPodpisDE.Multiline = true;
            this.tbPodpisDE.Name = "tbPodpisDE";
            this.tbPodpisDE.Size = new System.Drawing.Size(309, 59);
            this.tbPodpisDE.TabIndex = 20;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(43, 558);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 49;
            this.label27.Text = "Podpis:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(42, 477);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(97, 13);
            this.label30.TabIndex = 58;
            this.label30.Text = "Podstawa prawna:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxPodstawaPrawnaPL
            // 
            this.CheckBoxPodstawaPrawnaPL.AutoSize = true;
            this.CheckBoxPodstawaPrawnaPL.Location = new System.Drawing.Point(182, 487);
            this.CheckBoxPodstawaPrawnaPL.Name = "CheckBoxPodstawaPrawnaPL";
            this.CheckBoxPodstawaPrawnaPL.Size = new System.Drawing.Size(18, 17);
            this.CheckBoxPodstawaPrawnaPL.TabIndex = 61;
            this.CheckBoxPodstawaPrawnaPL.UseVisualStyleBackColor = true;
            this.CheckBoxPodstawaPrawnaPL.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(898, 774);
            this.Controls.Add(this.tbRachunekPL);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.checkboxEURO);
            this.Controls.Add(this.checkboxPLN);
            this.Controls.Add(this.nudWysokoscEURO);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tbBankDE);
            this.Controls.Add(this.tbRachunekDE);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbBankPL);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbPodpisDE);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cbNazwaNoty);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.nudStartNumer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbSchematNumer);
            this.Controls.Add(this.dtDataNota);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.rbToEMail);
            this.Controls.Add(this.rbToFile);
            this.Controls.Add(this.btnSetDirectory);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbPodpisPL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudKosztyRok);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtSkladkaTermin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudSkladkaRok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudWysoksc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudWalneZgromadzenie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nudIlDni);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalneZgromadzenie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWysoksc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSkladkaRok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartNumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIlDni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWysokoscEURO)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEtap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKampanie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudWalneZgromadzenie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudWysoksc;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.NumericUpDown nudSkladkaRok;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtSkladkaTermin;

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnSetDirectory;
        private System.Windows.Forms.RadioButton rbToFile;
        private System.Windows.Forms.RadioButton rbToEMail;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker dtDataNota;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSchematNumer;
        private System.Windows.Forms.NumericUpDown nudStartNumer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudIlDni;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbNazwaNoty;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.DateTimePicker nudKosztyRok;

        private System.Windows.Forms.TextBox tbRachunekPL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbBankPL;
        private System.Windows.Forms.TextBox tbRachunekDE;
        private System.Windows.Forms.TextBox tbBankDE;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown nudWysokoscEURO;
        private System.Windows.Forms.CheckBox checkboxPLN;
        private System.Windows.Forms.CheckBox checkboxEURO;
        private System.Windows.Forms.TextBox tbPodpisPL;
        private System.Windows.Forms.TextBox tbPodstawaPrawnaDE;
        private System.Windows.Forms.TextBox tbPodstawaPrawnaPL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbPodpisDE;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox CheckBoxPodstawaPrawnaPL;        
    }
}