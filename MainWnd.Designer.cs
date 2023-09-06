
namespace AuthHost
{
    partial class MainWnd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_LogSwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ShowLogScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_WriteLog = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_Brand = new System.Windows.Forms.GroupBox();
            this.comboBox_Brand = new System.Windows.Forms.ComboBox();
            this.groupBox_Amount = new System.Windows.Forms.GroupBox();
            this.textBox_Amt = new System.Windows.Forms.TextBox();
            this.groupBox_AmtOth = new System.Windows.Forms.GroupBox();
            this.textBox_AmtOth = new System.Windows.Forms.TextBox();
            this.groupBox_TransType = new System.Windows.Forms.GroupBox();
            this.textBox_TransType = new System.Windows.Forms.TextBox();
            this.checkBox_AmtPres = new System.Windows.Forms.CheckBox();
            this.checkBox_AmtOthPres = new System.Windows.Forms.CheckBox();
            this.checkBox_TransTypePres = new System.Windows.Forms.CheckBox();
            this.button_StartTrans = new System.Windows.Forms.Button();
            this.button_ClrMess = new System.Windows.Forms.Button();
            this.groupBox_Message = new System.Windows.Forms.GroupBox();
            this.richTextBox_Message = new System.Windows.Forms.RichTextBox();
            this.groupBox_Config = new System.Windows.Forms.GroupBox();
            this.groupBox_ISAuthData = new System.Windows.Forms.GroupBox();
            this.textBox_ISAuthData = new System.Windows.Forms.TextBox();
            this.groupBox_ISScript = new System.Windows.Forms.GroupBox();
            this.textBox_ISScript = new System.Windows.Forms.TextBox();
            this.groupBox_ISRespCode = new System.Windows.Forms.GroupBox();
            this.textBox_ISRespCode = new System.Windows.Forms.TextBox();
            this.button_PreProDownld = new System.Windows.Forms.Button();
            this.button_RevoKeyDownld = new System.Windows.Forms.Button();
            this.button_TermParmDownld = new System.Windows.Forms.Button();
            this.button_DRLDownld = new System.Windows.Forms.Button();
            this.button_ExcpFileDownld = new System.Windows.Forms.Button();
            this.button_CAPKDownld = new System.Windows.Forms.Button();
            this.button_AIDDownld = new System.Windows.Forms.Button();
            this.comboBox_PreProCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_RevoKeyCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_TermParmCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_DRLCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_ExcpFileCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_CAPKCfg = new System.Windows.Forms.ComboBox();
            this.comboBox_AIDCfg = new System.Windows.Forms.ComboBox();
            this.label_PreProcess = new System.Windows.Forms.Label();
            this.label_Revokey = new System.Windows.Forms.Label();
            this.label_SimData = new System.Windows.Forms.Label();
            this.label_DRL = new System.Windows.Forms.Label();
            this.label_Excpfile = new System.Windows.Forms.Label();
            this.label_CAPK = new System.Windows.Forms.Label();
            this.label_AID = new System.Windows.Forms.Label();
            this.tabControl_CommuType = new System.Windows.Forms.TabControl();
            this.tabPage_SerialSetting = new System.Windows.Forms.TabPage();
            this.button_OpenSerial = new System.Windows.Forms.Button();
            this.button_ScanSerial = new System.Windows.Forms.Button();
            this.comboBox_SerialBaud = new System.Windows.Forms.ComboBox();
            this.comboBox_SerialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_TCPSetting = new System.Windows.Forms.TabPage();
            this.button_CloseTCP = new System.Windows.Forms.Button();
            this.button_ListenTCP = new System.Windows.Forms.Button();
            this.textBox_TCPPort = new System.Windows.Forms.TextBox();
            this.comboBox_IPAddr = new System.Windows.Forms.ComboBox();
            this.label_IPPort = new System.Windows.Forms.Label();
            this.label_IPAddr = new System.Windows.Forms.Label();
            this.groupBox_CurrencyCode = new System.Windows.Forms.GroupBox();
            this.textBox_CurrencyCode = new System.Windows.Forms.TextBox();
            this.groupBox_CurrencyExp = new System.Windows.Forms.GroupBox();
            this.textBox_CurrencyExp = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox_Brand.SuspendLayout();
            this.groupBox_Amount.SuspendLayout();
            this.groupBox_AmtOth.SuspendLayout();
            this.groupBox_TransType.SuspendLayout();
            this.groupBox_Message.SuspendLayout();
            this.groupBox_Config.SuspendLayout();
            this.groupBox_ISAuthData.SuspendLayout();
            this.groupBox_ISScript.SuspendLayout();
            this.groupBox_ISRespCode.SuspendLayout();
            this.tabControl_CommuType.SuspendLayout();
            this.tabPage_SerialSetting.SuspendLayout();
            this.tabPage_TCPSetting.SuspendLayout();
            this.groupBox_CurrencyCode.SuspendLayout();
            this.groupBox_CurrencyExp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1301, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logToolStripMenuItem1
            // 
            this.logToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_LogSwitch});
            this.logToolStripMenuItem1.Name = "logToolStripMenuItem1";
            this.logToolStripMenuItem1.Size = new System.Drawing.Size(53, 21);
            this.logToolStripMenuItem1.Text = "File(F)";
            // 
            // ToolStripMenuItem_LogSwitch
            // 
            this.ToolStripMenuItem_LogSwitch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ShowLogScreen,
            this.ToolStripMenuItem_WriteLog});
            this.ToolStripMenuItem_LogSwitch.Name = "ToolStripMenuItem_LogSwitch";
            this.ToolStripMenuItem_LogSwitch.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_LogSwitch.Text = "Log Switch";
            // 
            // ToolStripMenuItem_ShowLogScreen
            // 
            this.ToolStripMenuItem_ShowLogScreen.Name = "ToolStripMenuItem_ShowLogScreen";
            this.ToolStripMenuItem_ShowLogScreen.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_ShowLogScreen.Text = "Print Screen";
            this.ToolStripMenuItem_ShowLogScreen.Click += new System.EventHandler(this.ToolStripMenuItem_ShowLogScreen_Click);
            // 
            // ToolStripMenuItem_WriteLog
            // 
            this.ToolStripMenuItem_WriteLog.Name = "ToolStripMenuItem_WriteLog";
            this.ToolStripMenuItem_WriteLog.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_WriteLog.Text = "Write File";
            this.ToolStripMenuItem_WriteLog.Click += new System.EventHandler(this.ToolStripMenuItem_WriteLog_Click);
            // 
            // groupBox_Brand
            // 
            this.groupBox_Brand.Controls.Add(this.comboBox_Brand);
            this.groupBox_Brand.Location = new System.Drawing.Point(13, 29);
            this.groupBox_Brand.Name = "groupBox_Brand";
            this.groupBox_Brand.Size = new System.Drawing.Size(273, 53);
            this.groupBox_Brand.TabIndex = 2;
            this.groupBox_Brand.TabStop = false;
            this.groupBox_Brand.Text = "Brand";
            // 
            // comboBox_Brand
            // 
            this.comboBox_Brand.FormattingEnabled = true;
            this.comboBox_Brand.Location = new System.Drawing.Point(9, 20);
            this.comboBox_Brand.Name = "comboBox_Brand";
            this.comboBox_Brand.Size = new System.Drawing.Size(253, 20);
            this.comboBox_Brand.TabIndex = 0;
            this.comboBox_Brand.SelectedIndexChanged += new System.EventHandler(this.comboBox_Brand_SelectedIndexChanged);
            // 
            // groupBox_Amount
            // 
            this.groupBox_Amount.Controls.Add(this.textBox_Amt);
            this.groupBox_Amount.Location = new System.Drawing.Point(13, 100);
            this.groupBox_Amount.Name = "groupBox_Amount";
            this.groupBox_Amount.Size = new System.Drawing.Size(142, 53);
            this.groupBox_Amount.TabIndex = 3;
            this.groupBox_Amount.TabStop = false;
            this.groupBox_Amount.Text = "Amount";
            // 
            // textBox_Amt
            // 
            this.textBox_Amt.Location = new System.Drawing.Point(7, 20);
            this.textBox_Amt.Name = "textBox_Amt";
            this.textBox_Amt.Size = new System.Drawing.Size(127, 21);
            this.textBox_Amt.TabIndex = 0;
            // 
            // groupBox_AmtOth
            // 
            this.groupBox_AmtOth.Controls.Add(this.textBox_AmtOth);
            this.groupBox_AmtOth.Location = new System.Drawing.Point(13, 170);
            this.groupBox_AmtOth.Name = "groupBox_AmtOth";
            this.groupBox_AmtOth.Size = new System.Drawing.Size(142, 53);
            this.groupBox_AmtOth.TabIndex = 4;
            this.groupBox_AmtOth.TabStop = false;
            this.groupBox_AmtOth.Text = "Amount Other";
            // 
            // textBox_AmtOth
            // 
            this.textBox_AmtOth.Location = new System.Drawing.Point(7, 20);
            this.textBox_AmtOth.Name = "textBox_AmtOth";
            this.textBox_AmtOth.Size = new System.Drawing.Size(127, 21);
            this.textBox_AmtOth.TabIndex = 0;
            // 
            // groupBox_TransType
            // 
            this.groupBox_TransType.Controls.Add(this.textBox_TransType);
            this.groupBox_TransType.Location = new System.Drawing.Point(13, 241);
            this.groupBox_TransType.Name = "groupBox_TransType";
            this.groupBox_TransType.Size = new System.Drawing.Size(142, 53);
            this.groupBox_TransType.TabIndex = 5;
            this.groupBox_TransType.TabStop = false;
            this.groupBox_TransType.Text = "TransType";
            // 
            // textBox_TransType
            // 
            this.textBox_TransType.Location = new System.Drawing.Point(9, 21);
            this.textBox_TransType.Name = "textBox_TransType";
            this.textBox_TransType.Size = new System.Drawing.Size(125, 21);
            this.textBox_TransType.TabIndex = 0;
            // 
            // checkBox_AmtPres
            // 
            this.checkBox_AmtPres.AutoSize = true;
            this.checkBox_AmtPres.Location = new System.Drawing.Point(197, 121);
            this.checkBox_AmtPres.Name = "checkBox_AmtPres";
            this.checkBox_AmtPres.Size = new System.Drawing.Size(96, 16);
            this.checkBox_AmtPres.TabIndex = 6;
            this.checkBox_AmtPres.Text = "9F02 present";
            this.checkBox_AmtPres.UseVisualStyleBackColor = true;
            // 
            // checkBox_AmtOthPres
            // 
            this.checkBox_AmtOthPres.AutoSize = true;
            this.checkBox_AmtOthPres.Location = new System.Drawing.Point(197, 191);
            this.checkBox_AmtOthPres.Name = "checkBox_AmtOthPres";
            this.checkBox_AmtOthPres.Size = new System.Drawing.Size(96, 16);
            this.checkBox_AmtOthPres.TabIndex = 7;
            this.checkBox_AmtOthPres.Text = "9F03 present";
            this.checkBox_AmtOthPres.UseVisualStyleBackColor = true;
            // 
            // checkBox_TransTypePres
            // 
            this.checkBox_TransTypePres.AutoSize = true;
            this.checkBox_TransTypePres.Location = new System.Drawing.Point(197, 262);
            this.checkBox_TransTypePres.Name = "checkBox_TransTypePres";
            this.checkBox_TransTypePres.Size = new System.Drawing.Size(84, 16);
            this.checkBox_TransTypePres.TabIndex = 8;
            this.checkBox_TransTypePres.Text = "9C present";
            this.checkBox_TransTypePres.UseVisualStyleBackColor = true;
            // 
            // button_StartTrans
            // 
            this.button_StartTrans.Location = new System.Drawing.Point(187, 323);
            this.button_StartTrans.Name = "button_StartTrans";
            this.button_StartTrans.Size = new System.Drawing.Size(97, 42);
            this.button_StartTrans.TabIndex = 9;
            this.button_StartTrans.Text = "Start";
            this.button_StartTrans.UseVisualStyleBackColor = true;
            // 
            // button_ClrMess
            // 
            this.button_ClrMess.Location = new System.Drawing.Point(187, 387);
            this.button_ClrMess.Name = "button_ClrMess";
            this.button_ClrMess.Size = new System.Drawing.Size(97, 42);
            this.button_ClrMess.TabIndex = 10;
            this.button_ClrMess.Text = "Clear";
            this.button_ClrMess.UseVisualStyleBackColor = true;
            this.button_ClrMess.Click += new System.EventHandler(this.button_ClrMess_Click);
            // 
            // groupBox_Message
            // 
            this.groupBox_Message.Controls.Add(this.richTextBox_Message);
            this.groupBox_Message.Location = new System.Drawing.Point(319, 29);
            this.groupBox_Message.Name = "groupBox_Message";
            this.groupBox_Message.Size = new System.Drawing.Size(490, 620);
            this.groupBox_Message.TabIndex = 11;
            this.groupBox_Message.TabStop = false;
            this.groupBox_Message.Text = "Message";
            // 
            // richTextBox_Message
            // 
            this.richTextBox_Message.Location = new System.Drawing.Point(6, 20);
            this.richTextBox_Message.Name = "richTextBox_Message";
            this.richTextBox_Message.Size = new System.Drawing.Size(478, 594);
            this.richTextBox_Message.TabIndex = 0;
            this.richTextBox_Message.Text = "";
            // 
            // groupBox_Config
            // 
            this.groupBox_Config.Controls.Add(this.groupBox_ISAuthData);
            this.groupBox_Config.Controls.Add(this.groupBox_ISScript);
            this.groupBox_Config.Controls.Add(this.groupBox_ISRespCode);
            this.groupBox_Config.Controls.Add(this.button_PreProDownld);
            this.groupBox_Config.Controls.Add(this.button_RevoKeyDownld);
            this.groupBox_Config.Controls.Add(this.button_TermParmDownld);
            this.groupBox_Config.Controls.Add(this.button_DRLDownld);
            this.groupBox_Config.Controls.Add(this.button_ExcpFileDownld);
            this.groupBox_Config.Controls.Add(this.button_CAPKDownld);
            this.groupBox_Config.Controls.Add(this.button_AIDDownld);
            this.groupBox_Config.Controls.Add(this.comboBox_PreProCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_RevoKeyCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_TermParmCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_DRLCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_ExcpFileCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_CAPKCfg);
            this.groupBox_Config.Controls.Add(this.comboBox_AIDCfg);
            this.groupBox_Config.Controls.Add(this.label_PreProcess);
            this.groupBox_Config.Controls.Add(this.label_Revokey);
            this.groupBox_Config.Controls.Add(this.label_SimData);
            this.groupBox_Config.Controls.Add(this.label_DRL);
            this.groupBox_Config.Controls.Add(this.label_Excpfile);
            this.groupBox_Config.Controls.Add(this.label_CAPK);
            this.groupBox_Config.Controls.Add(this.label_AID);
            this.groupBox_Config.Location = new System.Drawing.Point(831, 29);
            this.groupBox_Config.Name = "groupBox_Config";
            this.groupBox_Config.Size = new System.Drawing.Size(458, 614);
            this.groupBox_Config.TabIndex = 12;
            this.groupBox_Config.TabStop = false;
            this.groupBox_Config.Text = "Config";
            // 
            // groupBox_ISAuthData
            // 
            this.groupBox_ISAuthData.Controls.Add(this.textBox_ISAuthData);
            this.groupBox_ISAuthData.Location = new System.Drawing.Point(97, 523);
            this.groupBox_ISAuthData.Name = "groupBox_ISAuthData";
            this.groupBox_ISAuthData.Size = new System.Drawing.Size(245, 56);
            this.groupBox_ISAuthData.TabIndex = 23;
            this.groupBox_ISAuthData.TabStop = false;
            this.groupBox_ISAuthData.Text = "Issuer Authenticate Data";
            // 
            // textBox_ISAuthData
            // 
            this.textBox_ISAuthData.Location = new System.Drawing.Point(7, 22);
            this.textBox_ISAuthData.Name = "textBox_ISAuthData";
            this.textBox_ISAuthData.Size = new System.Drawing.Size(232, 21);
            this.textBox_ISAuthData.TabIndex = 0;
            // 
            // groupBox_ISScript
            // 
            this.groupBox_ISScript.Controls.Add(this.textBox_ISScript);
            this.groupBox_ISScript.Location = new System.Drawing.Point(97, 441);
            this.groupBox_ISScript.Name = "groupBox_ISScript";
            this.groupBox_ISScript.Size = new System.Drawing.Size(245, 56);
            this.groupBox_ISScript.TabIndex = 22;
            this.groupBox_ISScript.TabStop = false;
            this.groupBox_ISScript.Text = "Issuer Script";
            // 
            // textBox_ISScript
            // 
            this.textBox_ISScript.Location = new System.Drawing.Point(7, 21);
            this.textBox_ISScript.Name = "textBox_ISScript";
            this.textBox_ISScript.Size = new System.Drawing.Size(232, 21);
            this.textBox_ISScript.TabIndex = 0;
            // 
            // groupBox_ISRespCode
            // 
            this.groupBox_ISRespCode.Controls.Add(this.textBox_ISRespCode);
            this.groupBox_ISRespCode.Location = new System.Drawing.Point(97, 358);
            this.groupBox_ISRespCode.Name = "groupBox_ISRespCode";
            this.groupBox_ISRespCode.Size = new System.Drawing.Size(245, 53);
            this.groupBox_ISRespCode.TabIndex = 21;
            this.groupBox_ISRespCode.TabStop = false;
            this.groupBox_ISRespCode.Text = "Issuer Response Code";
            // 
            // textBox_ISRespCode
            // 
            this.textBox_ISRespCode.Location = new System.Drawing.Point(6, 19);
            this.textBox_ISRespCode.Name = "textBox_ISRespCode";
            this.textBox_ISRespCode.Size = new System.Drawing.Size(233, 21);
            this.textBox_ISRespCode.TabIndex = 0;
            // 
            // button_PreProDownld
            // 
            this.button_PreProDownld.Location = new System.Drawing.Point(281, 303);
            this.button_PreProDownld.Name = "button_PreProDownld";
            this.button_PreProDownld.Size = new System.Drawing.Size(75, 23);
            this.button_PreProDownld.TabIndex = 20;
            this.button_PreProDownld.Text = "Download";
            this.button_PreProDownld.UseVisualStyleBackColor = true;
            // 
            // button_RevoKeyDownld
            // 
            this.button_RevoKeyDownld.Location = new System.Drawing.Point(281, 248);
            this.button_RevoKeyDownld.Name = "button_RevoKeyDownld";
            this.button_RevoKeyDownld.Size = new System.Drawing.Size(75, 23);
            this.button_RevoKeyDownld.TabIndex = 19;
            this.button_RevoKeyDownld.Text = "Download";
            this.button_RevoKeyDownld.UseVisualStyleBackColor = true;
            this.button_RevoKeyDownld.Click += new System.EventHandler(this.button_RevoKeyDownld_Click);
            // 
            // button_TermParmDownld
            // 
            this.button_TermParmDownld.Location = new System.Drawing.Point(281, 200);
            this.button_TermParmDownld.Name = "button_TermParmDownld";
            this.button_TermParmDownld.Size = new System.Drawing.Size(75, 23);
            this.button_TermParmDownld.TabIndex = 18;
            this.button_TermParmDownld.Text = "Download";
            this.button_TermParmDownld.UseVisualStyleBackColor = true;
            this.button_TermParmDownld.Click += new System.EventHandler(this.button_TermParmDownld_Click);
            // 
            // button_DRLDownld
            // 
            this.button_DRLDownld.Location = new System.Drawing.Point(281, 162);
            this.button_DRLDownld.Name = "button_DRLDownld";
            this.button_DRLDownld.Size = new System.Drawing.Size(75, 23);
            this.button_DRLDownld.TabIndex = 17;
            this.button_DRLDownld.Text = "Download";
            this.button_DRLDownld.UseVisualStyleBackColor = true;
            this.button_DRLDownld.Click += new System.EventHandler(this.button_DRLDownld_Click);
            // 
            // button_ExcpFileDownld
            // 
            this.button_ExcpFileDownld.Location = new System.Drawing.Point(281, 111);
            this.button_ExcpFileDownld.Name = "button_ExcpFileDownld";
            this.button_ExcpFileDownld.Size = new System.Drawing.Size(75, 23);
            this.button_ExcpFileDownld.TabIndex = 16;
            this.button_ExcpFileDownld.Text = "Download";
            this.button_ExcpFileDownld.UseVisualStyleBackColor = true;
            this.button_ExcpFileDownld.Click += new System.EventHandler(this.button_ExcpFileDownld_Click);
            // 
            // button_CAPKDownld
            // 
            this.button_CAPKDownld.Location = new System.Drawing.Point(281, 59);
            this.button_CAPKDownld.Name = "button_CAPKDownld";
            this.button_CAPKDownld.Size = new System.Drawing.Size(75, 23);
            this.button_CAPKDownld.TabIndex = 15;
            this.button_CAPKDownld.Text = "Download";
            this.button_CAPKDownld.UseVisualStyleBackColor = true;
            this.button_CAPKDownld.Click += new System.EventHandler(this.button_CAPKDownld_Click);
            // 
            // button_AIDDownld
            // 
            this.button_AIDDownld.Location = new System.Drawing.Point(281, 19);
            this.button_AIDDownld.Name = "button_AIDDownld";
            this.button_AIDDownld.Size = new System.Drawing.Size(75, 23);
            this.button_AIDDownld.TabIndex = 14;
            this.button_AIDDownld.Text = "Download";
            this.button_AIDDownld.UseVisualStyleBackColor = true;
            this.button_AIDDownld.Click += new System.EventHandler(this.button_AIDDownld_Click);
            // 
            // comboBox_PreProCfg
            // 
            this.comboBox_PreProCfg.FormattingEnabled = true;
            this.comboBox_PreProCfg.Location = new System.Drawing.Point(97, 303);
            this.comboBox_PreProCfg.Name = "comboBox_PreProCfg";
            this.comboBox_PreProCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_PreProCfg.TabIndex = 13;
            // 
            // comboBox_RevoKeyCfg
            // 
            this.comboBox_RevoKeyCfg.FormattingEnabled = true;
            this.comboBox_RevoKeyCfg.Location = new System.Drawing.Point(97, 255);
            this.comboBox_RevoKeyCfg.Name = "comboBox_RevoKeyCfg";
            this.comboBox_RevoKeyCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_RevoKeyCfg.TabIndex = 12;
            // 
            // comboBox_TermParmCfg
            // 
            this.comboBox_TermParmCfg.FormattingEnabled = true;
            this.comboBox_TermParmCfg.Location = new System.Drawing.Point(97, 207);
            this.comboBox_TermParmCfg.Name = "comboBox_TermParmCfg";
            this.comboBox_TermParmCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_TermParmCfg.TabIndex = 11;
            // 
            // comboBox_DRLCfg
            // 
            this.comboBox_DRLCfg.FormattingEnabled = true;
            this.comboBox_DRLCfg.Location = new System.Drawing.Point(97, 157);
            this.comboBox_DRLCfg.Name = "comboBox_DRLCfg";
            this.comboBox_DRLCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_DRLCfg.TabIndex = 10;
            // 
            // comboBox_ExcpFileCfg
            // 
            this.comboBox_ExcpFileCfg.FormattingEnabled = true;
            this.comboBox_ExcpFileCfg.Location = new System.Drawing.Point(98, 108);
            this.comboBox_ExcpFileCfg.Name = "comboBox_ExcpFileCfg";
            this.comboBox_ExcpFileCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_ExcpFileCfg.TabIndex = 9;
            // 
            // comboBox_CAPKCfg
            // 
            this.comboBox_CAPKCfg.FormattingEnabled = true;
            this.comboBox_CAPKCfg.Location = new System.Drawing.Point(97, 67);
            this.comboBox_CAPKCfg.Name = "comboBox_CAPKCfg";
            this.comboBox_CAPKCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_CAPKCfg.TabIndex = 8;
            // 
            // comboBox_AIDCfg
            // 
            this.comboBox_AIDCfg.FormattingEnabled = true;
            this.comboBox_AIDCfg.Location = new System.Drawing.Point(97, 19);
            this.comboBox_AIDCfg.Name = "comboBox_AIDCfg";
            this.comboBox_AIDCfg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_AIDCfg.TabIndex = 7;
            // 
            // label_PreProcess
            // 
            this.label_PreProcess.AutoSize = true;
            this.label_PreProcess.Location = new System.Drawing.Point(19, 306);
            this.label_PreProcess.Name = "label_PreProcess";
            this.label_PreProcess.Size = new System.Drawing.Size(65, 12);
            this.label_PreProcess.TabIndex = 6;
            this.label_PreProcess.Text = "PreProcess";
            // 
            // label_Revokey
            // 
            this.label_Revokey.AutoSize = true;
            this.label_Revokey.Location = new System.Drawing.Point(19, 260);
            this.label_Revokey.Name = "label_Revokey";
            this.label_Revokey.Size = new System.Drawing.Size(47, 12);
            this.label_Revokey.TabIndex = 5;
            this.label_Revokey.Text = "RevoKey";
            // 
            // label_SimData
            // 
            this.label_SimData.AutoSize = true;
            this.label_SimData.Location = new System.Drawing.Point(17, 212);
            this.label_SimData.Name = "label_SimData";
            this.label_SimData.Size = new System.Drawing.Size(47, 12);
            this.label_SimData.TabIndex = 4;
            this.label_SimData.Text = "SimData";
            // 
            // label_DRL
            // 
            this.label_DRL.AutoSize = true;
            this.label_DRL.Location = new System.Drawing.Point(17, 161);
            this.label_DRL.Name = "label_DRL";
            this.label_DRL.Size = new System.Drawing.Size(23, 12);
            this.label_DRL.TabIndex = 3;
            this.label_DRL.Text = "DRL";
            // 
            // label_Excpfile
            // 
            this.label_Excpfile.AutoSize = true;
            this.label_Excpfile.Location = new System.Drawing.Point(6, 111);
            this.label_Excpfile.Name = "label_Excpfile";
            this.label_Excpfile.Size = new System.Drawing.Size(89, 12);
            this.label_Excpfile.TabIndex = 2;
            this.label_Excpfile.Text = "Exception File";
            // 
            // label_CAPK
            // 
            this.label_CAPK.AutoSize = true;
            this.label_CAPK.Location = new System.Drawing.Point(19, 71);
            this.label_CAPK.Name = "label_CAPK";
            this.label_CAPK.Size = new System.Drawing.Size(29, 12);
            this.label_CAPK.TabIndex = 1;
            this.label_CAPK.Text = "CAPK";
            // 
            // label_AID
            // 
            this.label_AID.AutoSize = true;
            this.label_AID.Location = new System.Drawing.Point(17, 27);
            this.label_AID.Name = "label_AID";
            this.label_AID.Size = new System.Drawing.Size(23, 12);
            this.label_AID.TabIndex = 0;
            this.label_AID.Text = "AID";
            // 
            // tabControl_CommuType
            // 
            this.tabControl_CommuType.Controls.Add(this.tabPage_SerialSetting);
            this.tabControl_CommuType.Controls.Add(this.tabPage_TCPSetting);
            this.tabControl_CommuType.Location = new System.Drawing.Point(13, 497);
            this.tabControl_CommuType.Name = "tabControl_CommuType";
            this.tabControl_CommuType.SelectedIndex = 0;
            this.tabControl_CommuType.Size = new System.Drawing.Size(284, 156);
            this.tabControl_CommuType.TabIndex = 13;
            // 
            // tabPage_SerialSetting
            // 
            this.tabPage_SerialSetting.Controls.Add(this.button_OpenSerial);
            this.tabPage_SerialSetting.Controls.Add(this.button_ScanSerial);
            this.tabPage_SerialSetting.Controls.Add(this.comboBox_SerialBaud);
            this.tabPage_SerialSetting.Controls.Add(this.comboBox_SerialPort);
            this.tabPage_SerialSetting.Controls.Add(this.label2);
            this.tabPage_SerialSetting.Controls.Add(this.label1);
            this.tabPage_SerialSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SerialSetting.Name = "tabPage_SerialSetting";
            this.tabPage_SerialSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SerialSetting.Size = new System.Drawing.Size(276, 130);
            this.tabPage_SerialSetting.TabIndex = 0;
            this.tabPage_SerialSetting.Text = "Serial Port";
            this.tabPage_SerialSetting.UseVisualStyleBackColor = true;
            // 
            // button_OpenSerial
            // 
            this.button_OpenSerial.Location = new System.Drawing.Point(192, 70);
            this.button_OpenSerial.Name = "button_OpenSerial";
            this.button_OpenSerial.Size = new System.Drawing.Size(75, 44);
            this.button_OpenSerial.TabIndex = 5;
            this.button_OpenSerial.Text = "Open";
            this.button_OpenSerial.UseVisualStyleBackColor = true;
            this.button_OpenSerial.Click += new System.EventHandler(this.button_OpenSerial_Click);
            // 
            // button_ScanSerial
            // 
            this.button_ScanSerial.Location = new System.Drawing.Point(192, 19);
            this.button_ScanSerial.Name = "button_ScanSerial";
            this.button_ScanSerial.Size = new System.Drawing.Size(75, 45);
            this.button_ScanSerial.TabIndex = 4;
            this.button_ScanSerial.Text = "Scan";
            this.button_ScanSerial.UseVisualStyleBackColor = true;
            this.button_ScanSerial.Click += new System.EventHandler(this.button_ScanSerial_Click);
            // 
            // comboBox_SerialBaud
            // 
            this.comboBox_SerialBaud.FormattingEnabled = true;
            this.comboBox_SerialBaud.Location = new System.Drawing.Point(58, 83);
            this.comboBox_SerialBaud.Name = "comboBox_SerialBaud";
            this.comboBox_SerialBaud.Size = new System.Drawing.Size(121, 20);
            this.comboBox_SerialBaud.TabIndex = 3;
            // 
            // comboBox_SerialPort
            // 
            this.comboBox_SerialPort.FormattingEnabled = true;
            this.comboBox_SerialPort.Location = new System.Drawing.Point(58, 21);
            this.comboBox_SerialPort.Name = "comboBox_SerialPort";
            this.comboBox_SerialPort.Size = new System.Drawing.Size(121, 20);
            this.comboBox_SerialPort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // tabPage_TCPSetting
            // 
            this.tabPage_TCPSetting.Controls.Add(this.button_CloseTCP);
            this.tabPage_TCPSetting.Controls.Add(this.button_ListenTCP);
            this.tabPage_TCPSetting.Controls.Add(this.textBox_TCPPort);
            this.tabPage_TCPSetting.Controls.Add(this.comboBox_IPAddr);
            this.tabPage_TCPSetting.Controls.Add(this.label_IPPort);
            this.tabPage_TCPSetting.Controls.Add(this.label_IPAddr);
            this.tabPage_TCPSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TCPSetting.Name = "tabPage_TCPSetting";
            this.tabPage_TCPSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TCPSetting.Size = new System.Drawing.Size(276, 130);
            this.tabPage_TCPSetting.TabIndex = 1;
            this.tabPage_TCPSetting.Text = "TCP";
            this.tabPage_TCPSetting.UseVisualStyleBackColor = true;
            // 
            // button_CloseTCP
            // 
            this.button_CloseTCP.Location = new System.Drawing.Point(197, 74);
            this.button_CloseTCP.Name = "button_CloseTCP";
            this.button_CloseTCP.Size = new System.Drawing.Size(75, 41);
            this.button_CloseTCP.TabIndex = 5;
            this.button_CloseTCP.Text = "Close";
            this.button_CloseTCP.UseVisualStyleBackColor = true;
            this.button_CloseTCP.Click += new System.EventHandler(this.button_CloseTCP_Click);
            // 
            // button_ListenTCP
            // 
            this.button_ListenTCP.Location = new System.Drawing.Point(197, 20);
            this.button_ListenTCP.Name = "button_ListenTCP";
            this.button_ListenTCP.Size = new System.Drawing.Size(75, 41);
            this.button_ListenTCP.TabIndex = 4;
            this.button_ListenTCP.Text = "Listen";
            this.button_ListenTCP.UseVisualStyleBackColor = true;
            this.button_ListenTCP.Click += new System.EventHandler(this.button_ListenTCP_Click);
            // 
            // textBox_TCPPort
            // 
            this.textBox_TCPPort.Location = new System.Drawing.Point(70, 85);
            this.textBox_TCPPort.Name = "textBox_TCPPort";
            this.textBox_TCPPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_TCPPort.TabIndex = 3;
            // 
            // comboBox_IPAddr
            // 
            this.comboBox_IPAddr.FormattingEnabled = true;
            this.comboBox_IPAddr.Location = new System.Drawing.Point(70, 22);
            this.comboBox_IPAddr.Name = "comboBox_IPAddr";
            this.comboBox_IPAddr.Size = new System.Drawing.Size(121, 20);
            this.comboBox_IPAddr.TabIndex = 2;
            this.comboBox_IPAddr.Click += new System.EventHandler(this.comboBox_IPAddr_Click);
            // 
            // label_IPPort
            // 
            this.label_IPPort.AutoSize = true;
            this.label_IPPort.Location = new System.Drawing.Point(18, 85);
            this.label_IPPort.Name = "label_IPPort";
            this.label_IPPort.Size = new System.Drawing.Size(29, 12);
            this.label_IPPort.TabIndex = 1;
            this.label_IPPort.Text = "Port";
            // 
            // label_IPAddr
            // 
            this.label_IPAddr.AutoSize = true;
            this.label_IPAddr.Location = new System.Drawing.Point(16, 22);
            this.label_IPAddr.Name = "label_IPAddr";
            this.label_IPAddr.Size = new System.Drawing.Size(47, 12);
            this.label_IPAddr.TabIndex = 0;
            this.label_IPAddr.Text = "Address";
            // 
            // groupBox_CurrencyCode
            // 
            this.groupBox_CurrencyCode.Controls.Add(this.textBox_CurrencyCode);
            this.groupBox_CurrencyCode.Location = new System.Drawing.Point(13, 312);
            this.groupBox_CurrencyCode.Name = "groupBox_CurrencyCode";
            this.groupBox_CurrencyCode.Size = new System.Drawing.Size(142, 53);
            this.groupBox_CurrencyCode.TabIndex = 14;
            this.groupBox_CurrencyCode.TabStop = false;
            this.groupBox_CurrencyCode.Text = "CurrencyCode";
            // 
            // textBox_CurrencyCode
            // 
            this.textBox_CurrencyCode.Location = new System.Drawing.Point(9, 21);
            this.textBox_CurrencyCode.Name = "textBox_CurrencyCode";
            this.textBox_CurrencyCode.Size = new System.Drawing.Size(125, 21);
            this.textBox_CurrencyCode.TabIndex = 0;
            this.textBox_CurrencyCode.TextChanged += new System.EventHandler(this.textBox_CurrencyCode_TextChanged);
            this.textBox_CurrencyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CurrencyCode_KeyPress);
            // 
            // groupBox_CurrencyExp
            // 
            this.groupBox_CurrencyExp.Controls.Add(this.textBox_CurrencyExp);
            this.groupBox_CurrencyExp.Location = new System.Drawing.Point(13, 387);
            this.groupBox_CurrencyExp.Name = "groupBox_CurrencyExp";
            this.groupBox_CurrencyExp.Size = new System.Drawing.Size(142, 53);
            this.groupBox_CurrencyExp.TabIndex = 15;
            this.groupBox_CurrencyExp.TabStop = false;
            this.groupBox_CurrencyExp.Text = "CurrencyExponent";
            // 
            // textBox_CurrencyExp
            // 
            this.textBox_CurrencyExp.Location = new System.Drawing.Point(9, 21);
            this.textBox_CurrencyExp.Name = "textBox_CurrencyExp";
            this.textBox_CurrencyExp.Size = new System.Drawing.Size(125, 21);
            this.textBox_CurrencyExp.TabIndex = 0;
            this.textBox_CurrencyExp.TextChanged += new System.EventHandler(this.textBox_CurrencyExp_TextChanged);
            this.textBox_CurrencyExp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CurrencyExp_KeyPress);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 678);
            this.Controls.Add(this.groupBox_CurrencyExp);
            this.Controls.Add(this.groupBox_CurrencyCode);
            this.Controls.Add(this.tabControl_CommuType);
            this.Controls.Add(this.groupBox_Config);
            this.Controls.Add(this.groupBox_Message);
            this.Controls.Add(this.button_ClrMess);
            this.Controls.Add(this.button_StartTrans);
            this.Controls.Add(this.checkBox_TransTypePres);
            this.Controls.Add(this.checkBox_AmtOthPres);
            this.Controls.Add(this.checkBox_AmtPres);
            this.Controls.Add(this.groupBox_TransType);
            this.Controls.Add(this.groupBox_AmtOth);
            this.Controls.Add(this.groupBox_Amount);
            this.Controls.Add(this.groupBox_Brand);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWnd";
            this.Text = "AuthHost product by bruce";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_Brand.ResumeLayout(false);
            this.groupBox_Amount.ResumeLayout(false);
            this.groupBox_Amount.PerformLayout();
            this.groupBox_AmtOth.ResumeLayout(false);
            this.groupBox_AmtOth.PerformLayout();
            this.groupBox_TransType.ResumeLayout(false);
            this.groupBox_TransType.PerformLayout();
            this.groupBox_Message.ResumeLayout(false);
            this.groupBox_Config.ResumeLayout(false);
            this.groupBox_Config.PerformLayout();
            this.groupBox_ISAuthData.ResumeLayout(false);
            this.groupBox_ISAuthData.PerformLayout();
            this.groupBox_ISScript.ResumeLayout(false);
            this.groupBox_ISScript.PerformLayout();
            this.groupBox_ISRespCode.ResumeLayout(false);
            this.groupBox_ISRespCode.PerformLayout();
            this.tabControl_CommuType.ResumeLayout(false);
            this.tabPage_SerialSetting.ResumeLayout(false);
            this.tabPage_SerialSetting.PerformLayout();
            this.tabPage_TCPSetting.ResumeLayout(false);
            this.tabPage_TCPSetting.PerformLayout();
            this.groupBox_CurrencyCode.ResumeLayout(false);
            this.groupBox_CurrencyCode.PerformLayout();
            this.groupBox_CurrencyExp.ResumeLayout(false);
            this.groupBox_CurrencyExp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_LogSwitch;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowLogScreen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_WriteLog;
        private System.Windows.Forms.GroupBox groupBox_Brand;
        private System.Windows.Forms.ComboBox comboBox_Brand;
        private System.Windows.Forms.GroupBox groupBox_Amount;
        private System.Windows.Forms.GroupBox groupBox_AmtOth;
        private System.Windows.Forms.GroupBox groupBox_TransType;
        private System.Windows.Forms.CheckBox checkBox_AmtPres;
        private System.Windows.Forms.CheckBox checkBox_AmtOthPres;
        private System.Windows.Forms.CheckBox checkBox_TransTypePres;
        private System.Windows.Forms.Button button_StartTrans;
        private System.Windows.Forms.Button button_ClrMess;
        private System.Windows.Forms.GroupBox groupBox_Message;
        private System.Windows.Forms.RichTextBox richTextBox_Message;
        private System.Windows.Forms.GroupBox groupBox_Config;
        private System.Windows.Forms.TabControl tabControl_CommuType;
        private System.Windows.Forms.TabPage tabPage_SerialSetting;
        private System.Windows.Forms.TabPage tabPage_TCPSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OpenSerial;
        private System.Windows.Forms.Button button_ScanSerial;
        private System.Windows.Forms.ComboBox comboBox_SerialBaud;
        private System.Windows.Forms.ComboBox comboBox_SerialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Amt;
        private System.Windows.Forms.TextBox textBox_AmtOth;
        private System.Windows.Forms.TextBox textBox_TransType;
        private System.Windows.Forms.Button button_CloseTCP;
        private System.Windows.Forms.Button button_ListenTCP;
        private System.Windows.Forms.TextBox textBox_TCPPort;
        private System.Windows.Forms.ComboBox comboBox_IPAddr;
        private System.Windows.Forms.Label label_IPPort;
        private System.Windows.Forms.Label label_IPAddr;
        private System.Windows.Forms.GroupBox groupBox_ISAuthData;
        private System.Windows.Forms.TextBox textBox_ISAuthData;
        private System.Windows.Forms.GroupBox groupBox_ISScript;
        private System.Windows.Forms.TextBox textBox_ISScript;
        private System.Windows.Forms.GroupBox groupBox_ISRespCode;
        private System.Windows.Forms.TextBox textBox_ISRespCode;
        private System.Windows.Forms.Button button_PreProDownld;
        private System.Windows.Forms.Button button_RevoKeyDownld;
        private System.Windows.Forms.Button button_TermParmDownld;
        private System.Windows.Forms.Button button_DRLDownld;
        private System.Windows.Forms.Button button_CAPKDownld;
        private System.Windows.Forms.Button button_AIDDownld;
        private System.Windows.Forms.ComboBox comboBox_PreProCfg;
        private System.Windows.Forms.ComboBox comboBox_RevoKeyCfg;
        private System.Windows.Forms.ComboBox comboBox_TermParmCfg;
        private System.Windows.Forms.ComboBox comboBox_DRLCfg;
        private System.Windows.Forms.ComboBox comboBox_ExcpFileCfg;
        private System.Windows.Forms.ComboBox comboBox_CAPKCfg;
        private System.Windows.Forms.ComboBox comboBox_AIDCfg;
        private System.Windows.Forms.Label label_PreProcess;
        private System.Windows.Forms.Label label_Revokey;
        private System.Windows.Forms.Label label_SimData;
        private System.Windows.Forms.Label label_DRL;
        private System.Windows.Forms.Label label_Excpfile;
        private System.Windows.Forms.Label label_CAPK;
        private System.Windows.Forms.Label label_AID;
        private System.Windows.Forms.Button button_ExcpFileDownld;
        private System.Windows.Forms.GroupBox groupBox_CurrencyCode;
        private System.Windows.Forms.TextBox textBox_CurrencyCode;
        private System.Windows.Forms.GroupBox groupBox_CurrencyExp;
        private System.Windows.Forms.TextBox textBox_CurrencyExp;
    }
}

