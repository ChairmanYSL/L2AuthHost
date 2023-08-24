using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Text;

namespace AuthHost
{
    public partial class MainWnd : Form
    {
        // 定义一个静态的 MainWnd 对象
        string curDir = Application.StartupPath;
        XmlDocument doc;
        private Config config = new Config();
        private TCPServer tcpServer;
        private enum MsgType
        {
            FINANCE_REQ_SEND = 1,
            AUTHORIZE_REQ_SEND,
            FINANCE_CONFIRM_SEND,
            BATCH_UPLOAD_SEND,
            ADVICE_SEND,
            REDO_SEND,
            FIALFLOW_UPLOAD_SEND,
            RC_DOWNLOAD_CONFIG = 10,

            FINANCE_REQ_RECV = 65, //0x41
            AUTHORIZE_REQ_RECV,
            FINANCE_CONFIRM_RECV,
            BATCH_UPLOAD_RECV,
            ADVICE_RECV,
            REDO_RECV,
            FIALFLOW_UPLOAD_RECV,

            TRANS_REQ_SEND = 128, //0x80
            TRANS_RESULT_SEND,
            CAPK_DOWNLOAD_SEND,
            AID_DOWNLOAD_SEND,
            SIMDATA_DOWNLOAD_SEND,
            BLACKLIST_DOWNLOAD_SEND,
            REVOKEY_DOWNLOAD_SEND,
            ELECCHIP_ELECSIGN_SEND,
            DRL_DOWNLOAD_SEND,
            TERM_OUTCOME_SEND,

            TRANS_REQ_RECV = 192, //0xC0
            TRANS_RESULT_RECV,
            CAPK_DOWNLOAD_RECV,
            AID_DOWNLOAD_RECV,
            SIMDATA_DOWNLOAD_RECV,
            BLACKLIST_DOWNLOAD_RECV,
            REVOKEY_DOWNLOAD_RECV,
            ELECCHIP_ELECSIGN_RECV,
            DRL_DOWNLOAD_RECV,
            TERM_OUTCOME_RECV,
            RC_UPLOAD_RESULT,
        };

        public MainWnd()
        {
            InitializeComponent();
            Logger.Instance.SetEnabled(true);
            this.openToolStripMenuItem1.Checked = true;
            tcpServer = new TCPServer();
            tcpServer.LogNeeded += AppendLog;
            tcpServer.DataReceived += OnDataReceived;
            tcpServer.ErrorOccurred += OnErrorOccurred;
            config.LogNeeded += AppendLog;
            this.FormClosing += MainWnd_FormClosing;
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpServer?.CloseConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1317, 717);
            UpdateMess("Welcome");
            LoadBaudComboBox();
            LoadCommunicateSettings();
            LoadConfigList();
            LoadTransParam();
            LoadCheckBoxs();
        }

        private void LoadCommunicateSettings()
        {
            this.textBox_TCPPort.Text = "8182";
            string hostName = Dns.GetHostName();
            Logger.Instance.Log("Cur host name: " + hostName);
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
            Logger.Instance.Log("IP Address in local computer: ");
            List<string> IPAddrList = new List<string>();
            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)  // IPv4地址
                {
                    Logger.Instance.Log(ip.ToString());
                    IPAddrList.Add(ip.ToString());
                }
            }
            UpdateIPAddrList(IPAddrList);
            this.comboBox_IPAddr.SelectedIndex = 0;
            string[] ports = SerialPort.GetPortNames();
            List<string> portList = new List<string>();
            foreach (string port in ports)
            {
                portList.Add(port);
            }
            UpdateSerialPortList(portList);
            this.comboBox_SerialPort.SelectedIndex = 0;
        }

        private void LoadTransParam()
        {
            this.textBox_Amt.Text = "0.01";
            this.textBox_AmtOth.Text = "0.00";
            this.textBox_TransType.Text = "00";
            this.textBox_ISRespCode.Text = "00";
        }

        private void LoadConfigList()
        {
            Logger.Instance.Log("curDir: " + curDir);

            this.config.initDir(curDir);
            this.config.initBrand();

            //this.comboBox_Brand.DataSource = config.BrandList;
            UpdateBrand(config.BrandList);
            Logger.Instance.Log("comboBox_Brand.Items.Count: " + comboBox_Brand.Items.Count);
            if (this.comboBox_Brand.Items.Count > 0)
            {
                this.comboBox_Brand.SelectedIndex = 0;
            }

            Logger.Instance.Log("comboBox_Brand.SelectedIndex: " + this.comboBox_Brand.SelectedIndex);
            this.config.SetBrandLocaliton(this.comboBox_Brand.SelectedItem.ToString());

            this.config.initConfig();
            UpdateAIDConfig(config.AIDList);
            //this.comboBox_AIDCfg.DataSource = this.config.AIDList;
            if (this.comboBox_AIDCfg.Items.Count > 0)
            {
                this.comboBox_AIDCfg.SelectedIndex = 0;
            }

            UpdateCAPKConfig(config.CAPKList);
            //this.comboBox_CAPKCfg.DataSource = this.config.CAPKList;
            if (this.comboBox_CAPKCfg.Items.Count > 0)
            {
                this.comboBox_CAPKCfg.SelectedIndex = 0;
            }

            UpdateDRLConfig(config.DRLList);
            //this.comboBox_DRLCfg.DataSource = this.config.DRLList;
            if (this.comboBox_DRLCfg.Items.Count > 0)
            {
                this.comboBox_DRLCfg.SelectedIndex = 0;
            }

            UpdateExcpFileConfig(config.ExcpFileList);
            //this.comboBox_ExcpFileCfg.DataSource = this.config.ExcpFileList;
            if (this.comboBox_ExcpFileCfg.Items.Count > 0)
            {
                this.comboBox_ExcpFileCfg.SelectedIndex = 0;
            }

            UpdateRevoKeyConfig(config.RevokeyList);
            //this.comboBox_RevoKeyCfg.DataSource = this.config.RevokeyList;
            if (this.comboBox_RevoKeyCfg.Items.Count > 0)
            {
                this.comboBox_RevoKeyCfg.SelectedIndex = 0;
            }

            UpdateTermParmConfig(config.TermParList);
            //this.comboBox_TermParmCfg.DataSource = this.config.TermParList;
            if (this.comboBox_TermParmCfg.Items.Count > 0)
            {
                this.comboBox_TermParmCfg.SelectedIndex = 0;
            }
        }

        private void LoadCheckBoxs()
        {
            this.checkBox_AmtPres.Checked = true;
            this.checkBox_AmtOthPres.Checked = true;
            this.checkBox_TransTypePres.Checked = true;
        }

        private void LoadBaudComboBox()
        {
            List<String> BaudRate = new List<string>
            {
                "1200",
                "2400",
                "4800",
                "9600",
                "14400",
                "19200",
                "38400",
                "56000",
                "576000",
                "115200",
                "230400",
                "460800",
                "921600"
            };

            UpdateBaud(BaudRate);
            this.comboBox_SerialBaud.SelectedIndex = 0;
        }

        public void UpdateBaud(List<string> baudList)
        {
            if (this.comboBox_SerialBaud.Items.Count > 0)
            {
                this.comboBox_SerialBaud.Items.Clear();
            }
            foreach (string baud in baudList)
            {
                this.comboBox_SerialBaud.Items.Add(baud);
            }
        }

        public void UpdateBrand(List<string> brandList)
        {
            if (this.comboBox_Brand.Items.Count > 0)
            {
                this.comboBox_Brand.Items.Clear();
            }
            foreach (string brand in brandList)
            {
                this.comboBox_Brand.Items.Add(brand);
            }
        }

        public void UpdateAIDConfig(List<string> aidCfgList)
        {
            if (this.comboBox_AIDCfg.Items.Count > 0)
            {
                this.comboBox_AIDCfg.Items.Clear();
            }
            foreach (string aidCfg in aidCfgList)
            {
                this.comboBox_AIDCfg.Items.Add(aidCfg);
            }
        }
        public void UpdateCAPKConfig(List<string> capkCfgList)
        {
            if (this.comboBox_CAPKCfg.Items.Count > 0)
            {
                this.comboBox_CAPKCfg.Items.Clear();
            }
            foreach (string capkCfg in capkCfgList)
            {
                this.comboBox_CAPKCfg.Items.Add(capkCfg);
            }
        }

        public void UpdateDRLConfig(List<string> drlCfgList)
        {
            if (this.comboBox_DRLCfg.Items.Count > 0)
            {
                this.comboBox_DRLCfg.Items.Clear();
            }
            this.comboBox_DRLCfg.Items.Clear();
            foreach (string drlCfg in drlCfgList)
            {
                this.comboBox_DRLCfg.Items.Add(drlCfg);
            }
        }
        public void UpdateExcpFileConfig(List<string> excpCfgList)
        {
            if (this.comboBox_ExcpFileCfg.Items.Count > 0)
            {
                this.comboBox_ExcpFileCfg.Items.Clear();
            }
            foreach (string excpCfg in excpCfgList)
            {
                this.comboBox_ExcpFileCfg.Items.Add(excpCfg);
            }
        }

        public void UpdateTermParmConfig(List<string> termparCfgList)
        {
            if (this.comboBox_TermParmCfg.Items.Count > 0)
            {
                this.comboBox_TermParmCfg.Items.Clear();
            }
            foreach (string termparCfg in termparCfgList)
            {
                this.comboBox_TermParmCfg.Items.Add(termparCfg);
            }
        }

        public void UpdateRevoKeyConfig(List<string> revokeyCfgList)
        {
            if (this.comboBox_RevoKeyCfg.Items.Count > 0)
            {
                this.comboBox_RevoKeyCfg.Items.Clear();
            }
            foreach (string revokeyCfg in revokeyCfgList)
            {
                this.comboBox_RevoKeyCfg.Items.Add(revokeyCfg);
            }
        }

        public void UpdateMess(string msg)
        {
            Logger.Instance.Log(msg);
            this.richTextBox_Message.AppendText(msg + "\r\n");
        }

        public void UpdateMessNolog(string msg)
        {
            this.richTextBox_Message.AppendText(msg + "\r\n");
        }

        private void comboBox_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curBrand = this.comboBox_Brand.SelectedItem.ToString();
            this.config.SetBrandLocaliton(curBrand);
            this.config.initConfig();
            UpdateAIDConfig(this.config.AIDList);
            if (comboBox_AIDCfg.Items.Count > 0)
            {
                comboBox_AIDCfg.SelectedIndex = 0;
            }
            UpdateCAPKConfig(this.config.CAPKList);
            if (comboBox_CAPKCfg.Items.Count > 0)
            {
                comboBox_CAPKCfg.SelectedIndex = 0;
            }
            UpdateDRLConfig(this.config.DRLList);
            if (comboBox_DRLCfg.Items.Count > 0)
            {
                comboBox_DRLCfg.SelectedIndex = 0;
            }
            UpdateExcpFileConfig(this.config.ExcpFileList);
            if (comboBox_ExcpFileCfg.Items.Count > 0)
            {
                comboBox_ExcpFileCfg.SelectedIndex = 0;
            }
            UpdateRevoKeyConfig(this.config.RevokeyList);
            if (comboBox_RevoKeyCfg.Items.Count > 0)
            {
                comboBox_RevoKeyCfg.SelectedIndex = 0;
            }
            UpdateTermParmConfig(this.config.TermParList);
            {
                comboBox_TermParmCfg.SelectedIndex = 0;
            }
        }
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logger.Instance.SetEnabled(true);
            this.openToolStripMenuItem1.Checked = true;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logger.Instance.SetEnabled(false);
            this.closeToolStripMenuItem1.Checked = false;
        }

        public string GetCurBrand()
        {
            Logger.Instance.Log("comboBox_Brand.SelectedItem: " + comboBox_Brand.SelectedItem);
            if (this.comboBox_Brand.SelectedItem != null)
            {
                return this.comboBox_Brand.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }

        public void UpdateIPAddrList(List<string> IPAddrList)
        {
            if (this.comboBox_IPAddr.Items.Count > 0)
            {
                this.comboBox_IPAddr.Items.Clear();
            }
            foreach (string IPAddr in IPAddrList)
            {
                this.comboBox_IPAddr.Items.Add(IPAddr);
            }
        }

        public void UpdateSerialPortList(List<string> SerialPortList)
        {
            if (this.comboBox_SerialPort.Items.Count > 0)
            {
                this.comboBox_SerialPort.Items.Clear();
            }
            if (SerialPortList != null)
            {
                foreach (string SerialPort in SerialPortList)
                {
                    this.comboBox_SerialPort.Items.Add(SerialPort);
                }
            }

        }

        private void button_ClrMess_Click(object sender, EventArgs e)
        {
            this.richTextBox_Message.Clear();
        }

        private void button_AIDDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgAID, this.comboBox_AIDCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.AIDCfgName);
            //UpdateMessNolog("Load AID File:" + files[this.comboBox_AIDCfg.SelectedIndex]);
        }

        private void button_CAPKDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgCAPK, this.comboBox_CAPKCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.CAPKCfgName);
            //UpdateMessNolog("Load CAPK File:" + files[this.comboBox_CAPKCfg.SelectedIndex]);
        }

        private void button_ExcpFileDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgExcpFile, this.comboBox_ExcpFileCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.ExcpFileCfgName);
            //UpdateMessNolog("Load Excption File:" + files[this.comboBox_ExcpFileCfg.SelectedIndex]);
        }

        private void button_DRLDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgDRL, this.comboBox_DRLCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.DRLCfgName);
            //UpdateMessNolog("Load DRL File:" + files[this.comboBox_DRLCfg.SelectedIndex]);
        }

        private void button_TermParmDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgTermParm, this.comboBox_TermParmCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.TermParCfgName);
            //UpdateMessNolog("Load Term Param File:" + files[this.comboBox_TermParmCfg.SelectedIndex]);
        }

        private void button_RevoKeyDownld_Click(object sender, EventArgs e)
        {
            this.config.LoadXml(Config.CfgType.CfgRevokey, this.comboBox_RevoKeyCfg.SelectedIndex);
            string[] files = Directory.GetFiles(this.config.RevokeyCfgName);
            //UpdateMessNolog("Load Revokey File:" + files[this.comboBox_RevoKeyCfg.SelectedIndex]);
        }

        private void button_ListenTCP_Click(object sender, EventArgs e)
        {
            string ipAddressString = this.comboBox_IPAddr.SelectedItem.ToString();
            int port;
            if (int.TryParse(this.textBox_TCPPort.Text, out port) == false)
            {
                Logger.Instance.Log("Error: cant parse TCP Port from textBox");
                return;
            }

            tcpServer.Listen(ipAddressString, port);

            // 禁用按钮，防止多次点击
            button_ListenTCP.Enabled = false;
            button_CloseTCP.Enabled = true;
        }

        private void button_CloseTCP_Click(object sender, EventArgs e)
        {
            tcpServer.ClearBuffer();
            tcpServer.CloseConnection();

            // 更新按钮状态
            button_CloseTCP.Enabled = false;
            button_ListenTCP.Enabled = true;
        }

        public void AppendLog(string logMessage)
        {
            if (this.richTextBox_Message.InvokeRequired)
            {
                richTextBox_Message.Invoke(new Action<string>(AppendLog), logMessage);
            }
            else
            {
                this.richTextBox_Message.AppendText(logMessage + Environment.NewLine);
            }
        }

        private void DownloadAID()
        {
            this.config.DownloadXml(Config.CfgType.CfgAID, this.tcpServer);
        }

        private void DownloadCAPK()
        {
            this.config.DownloadXml(Config.CfgType.CfgCAPK, this.tcpServer);
        }

        private void DownloadDRL()
        {
            this.config.DownloadXml(Config.CfgType.CfgDRL, tcpServer);
        }

        private void DownloadExceptionFile()
        {
            this.config.DownloadXml(Config.CfgType.CfgExcpFile, tcpServer);
        }

        private void DownloadTermParam()
        {
            this.config.DownloadXml(Config.CfgType.CfgTermParm, tcpServer);
        }

        private void DownloadRevokey()
        {
            this.config.DownloadXml(Config.CfgType.CfgRevokey, tcpServer);
        }

        private void DownloadBlacklist()
        {
            this.config.DownloadXml(Config.CfgType.CfgExcpFile, tcpServer);
        }

        private void StartTrans()
        {

        }

        private void DealFinanceRequest(byte[] tlvs)
        {

        }

        private void DealAuthorizeRequst(byte[] tlvs)
        {

        }

        private void DealBatchUpload(byte[] tlvs)
        {

        }

        private void DealTransResult(byte[] tlvs)
        {

        }

        private void DealTermOutcome(byte[] tlvs)
        {

        }

        private void DealFinanceConfirm(byte[] tlvs)
        {

        }

        private void comboBox_IPAddr_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
            List<string> IPAddrList = new List<string>();
            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)  // IPv4地址
                {
                    Logger.Instance.Log(ip.ToString());
                    IPAddrList.Add(ip.ToString());
                }
            }
            UpdateIPAddrList(IPAddrList);
            this.comboBox_IPAddr.SelectedIndex = 0;
        }

        private void OnDataReceived(object sender, byte[] data)
        {
            string receivedData = Tool.ByteArrayToBcdString(data);
            bool needParseTLV = true;

            AppendLog("Recv TCP Data: "+ receivedData);

            if(data.Length == 4)
            {
                needParseTLV = false;
            }

            if (needParseTLV)
            {
                byte[] tlvs = new byte[data.Length-4];
                Array.Copy(data, 4, tlvs, 0, tlvs.Length);
                switch (data[1])
                {
                    case (byte)MsgType.FINANCE_REQ_RECV:
                        DealFinanceRequest(tlvs);
                        break;
                    case (byte)MsgType.AUTHORIZE_REQ_RECV:
                        DealAuthorizeRequst(tlvs);
                        break;
                    case (byte)MsgType.FINANCE_CONFIRM_RECV:
                        DealFinanceConfirm(tlvs);
                        break;
                    case (byte)MsgType.BATCH_UPLOAD_RECV:
                        DealBatchUpload(tlvs);
                        break;
                    case (byte)MsgType.TRANS_RESULT_RECV:
                        DealTransResult(tlvs);
                        break;
                    case (byte)MsgType.TERM_OUTCOME_RECV:
                        DealTermOutcome(tlvs);
                        break;
                    case (byte)MsgType.SIMDATA_DOWNLOAD_RECV:
                        DownloadTermParam();
                        break;

                    default:
                        return ;
                }
            }
            else
            {
                switch (data[1])
                {
                    case (byte)MsgType.AID_DOWNLOAD_RECV:
                        DownloadAID();
                        break;
                    case (byte)MsgType.CAPK_DOWNLOAD_RECV:
                        DownloadCAPK();
                        break;
                    case (byte)MsgType.DRL_DOWNLOAD_RECV:
                        DownloadDRL();
                        break;
                    case (byte)MsgType.BLACKLIST_DOWNLOAD_RECV:
                        DownloadBlacklist();
                        break;
                    case (byte)MsgType.REVOKEY_DOWNLOAD_RECV:
                        DownloadRevokey();
                        break;
                    case (byte)MsgType.TRANS_REQ_RECV:
                        StartTrans();
                        break;
                    default:
                        return ;
                }
            }
        }

        // Event handler for error occurred
        private void OnErrorOccurred(object sender, string errorMessage)
        {
            AppendLog(errorMessage);
        }
    }
}
