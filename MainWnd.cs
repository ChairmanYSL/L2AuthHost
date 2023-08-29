﻿using System;
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
using System.Linq;

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
            if(this.comboBox_SerialPort.Items.Count > 0)
            {
                this.comboBox_SerialPort.SelectedIndex = 0;
            }
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
            tcpServer.Stop();
            tcpServer.Dispose();

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
            string transAmt = this.textBox_Amt.Text;
            string transAmtOth = this.textBox_AmtOth.Text;
            string transType = this.textBox_TransType.Text;
            int tmpLen;

            if(transAmt == null)
            {
                AlertHelper.ShowAlert("Warning", "Trans Amount 9F02 is null");
                return;
            }
            else if(transAmtOth == null)
            {
                AlertHelper.ShowAlert("Warning", "Trans Amount Other 9F03 is null");
                return;
            }
            else if(transType == null)
            {
                AlertHelper.ShowAlert("Warning", "Trans Type 9C is null");
                return;
            }

            if(this.checkBox_AmtPres.Checked)
            {
                transAmt = transAmt.Replace(".", "");
                if (transAmt.Length < 12)
                {
                    tmpLen = transAmt.Length;
                    for (int i = 0; i < tmpLen; i++)
                    {
                        transAmt = transAmt.Insert(0, "0");
                    }
                }
                AppendLog("Current Trans Amount 9F02:" + transAmt);

            }

            if(this.checkBox_AmtOthPres.Checked)
            {
                transAmtOth = transAmtOth.Replace(".", "");
                if (transAmtOth.Length < 12)
                {
                    tmpLen = transAmtOth.Length;
                    for (int i = 0; i < tmpLen; i++)
                    {
                        transAmtOth = transAmtOth.Insert(0, "0");
                    }
                }
                AppendLog("Current Trans Amount Other 9F03:" + transAmtOth);

            }

            if(this.checkBox_TransTypePres.Checked)
            {
                AppendLog("Current Trans Type 9C:" + transType);
            }

            byte[] sendData = new byte[25];
            byte[] bcdCode;
            int sendLen=0;

            sendData[0] = 0x02;
            sendData[1] = 0x80;
            sendData[2] = 0x00;

            sendLen += 4;

            if(this.checkBox_AmtPres.Checked)
            {
                byte[] tmp = new byte[]{0x9F,0x02,0x06};
                Array.Copy(tmp,0,sendData,sendLen,tmp.Length);
                sendLen += tmp.Length;
                bcdCode = Tool.StringToBCD(transAmt);
                Array.Copy(bcdCode, 0, sendData, sendLen, bcdCode.Length);
                sendLen += bcdCode.Length;
            }

            if( this.checkBox_AmtOthPres.Checked)
            {
                byte[] tmp = new byte[] { 0x9F, 0X03, 0x06 };
                Array.Copy(tmp, 0, sendData, sendLen, tmp.Length);
                sendLen += tmp.Length;
                bcdCode = Tool.StringToBCD(transAmtOth);
                Array.Copy(bcdCode,0, sendData, sendLen,bcdCode.Length);
                sendLen += bcdCode.Length;
            }

            if(this.checkBox_TransTypePres.Checked)
            {
                byte[] tmp = new byte[] { 0x9C, 0x01 };
                Array.Copy(tmp, 0, sendData, sendLen, tmp.Length);
                sendLen += tmp.Length;
                bcdCode = Tool.StringToBCD(transType);
                Array.Copy(bcdCode, 0, sendData, sendLen, bcdCode.Length);
                sendLen += bcdCode.Length;
            }
            
            this.tcpServer.SendData(sendData);
        }

        private void DealFinanceRequest(byte[] tlvs)
        {
            int index;

            if ( (index = Array.IndexOf(tlvs, (byte)0x99)) >= 0)
            {
                byte[] tmp = new byte[tlvs[index+1]];
                Array.Copy(tlvs, index + 2, tmp, 0, tmp.Length);
                AppendLog("Online Encrypted PIN:" + Tool.HexByteArrayToString(tmp));
            }

            if(this.comboBox_Brand.SelectedItem.ToString() == "ExpressPay")
            {
                if((index = Array.IndexOf(tlvs, (byte)0x56)) >= 0)
                {
                    byte[] tmp = new byte[tlvs[index + 1]];
                    Array.Copy(tlvs, index + 2, tmp, 0, tmp.Length);
                    AppendLog("Track 1 Data:"+Tool.HexByteArrayToString(tmp));
                }
                if(TLVObject.ContainsSequence(tlvs,(byte)0x9F, (byte)0x5B))
                {
                    byte[] tmp = TLVObject.GetTLVValue(tlvs, (byte)0x9F, (byte)0x6B);
                    AppendLog("Track 2 Equivalent Data:" + Tool.HexByteArrayToString(tmp));
                }
            }

            string respCode = this.textBox_ISRespCode.Text;
            string authData = this.textBox_ISAuthData.Text;
            string script = this.textBox_ISScript.Text;
            byte high, low;
            string sendData = "";
            int len;

            if(respCode != null)
            {
                sendData += "8A02";
                sendData += respCode;
                AppendLog("Current Response Code 8A:" + respCode);
            }
            if(authData != null)
            {
                sendData += "91";
                len = authData.Length / 2;
                sendData += len.ToString("X2");
                sendData += authData;
                AppendLog("Current Authorization Response Code 91:" + authData);
            }
            if(script != null)
            {
                sendData += "71";
                len = script.Length / 2;
                sendData += len.ToString("X2");
                sendData += script;
                AppendLog("Current Script 71:" + script);
            }

            if(sendData.Length > 0)
            {
                high = (byte)(sendData.Length / 2 / 256);
                low = (byte)(sendData.Length / 2 % 256);
                sendData = "02" + "01" + high.ToString("X2") + low.ToString("X2") + sendData;
                this.tcpServer.SendData(Tool.StringToHexByteArray(sendData));
            }
        }

        private void DealAuthorizeRequst(byte[] tlvs)
        {
            int index;

            if ((index = Array.IndexOf(tlvs, (byte)0x99)) >= 0)
            {
                byte[] tmp = new byte[tlvs[index + 1]];
                Array.Copy(tlvs, index + 2, tmp, 0, tmp.Length);
                AppendLog("Online Encrypted PIN:" + Tool.HexByteArrayToString(tmp));
            }

            if (this.comboBox_Brand.SelectedItem.ToString() == "ExpressPay")
            {
                if ((index = Array.IndexOf(tlvs, (byte)0x56)) >= 0)
                {
                    byte[] tmp = new byte[tlvs[index + 1]];
                    Array.Copy(tlvs, index + 2, tmp, 0, tmp.Length);
                    AppendLog("Track 1 Data:" + Tool.HexByteArrayToString(tmp));
                }
                if (TLVObject.ContainsSequence(tlvs, (byte)0x9F, (byte)0x5B))
                {
                    byte[] tmp = TLVObject.GetTLVValue(tlvs, (byte)0x9F, (byte)0x6B);
                    AppendLog("Track 2 Equivalent Data:" + Tool.HexByteArrayToString(tmp));
                }
            }

            string respCode = this.textBox_ISRespCode.Text;
            string authData = this.textBox_ISAuthData.Text;
            string script = this.textBox_ISScript.Text;
            byte high, low;
            string sendData = "";
            int len;

            if (respCode != null)
            {
                sendData += "8A02";
                sendData += respCode;
                AppendLog("Current Response Code 8A:" + respCode);
            }
            if (authData != null)
            {
                sendData += "91";
                len = authData.Length / 2;
                sendData += len.ToString("X2");
                sendData += authData;
                AppendLog("Current Authorization Response Code 91:" + authData);
            }
            if (script != null)
            {
                sendData += "71";
                len = script.Length / 2;
                sendData += len.ToString("X2");
                sendData += script;
                AppendLog("Current Script 71:" + script);
            }

            if (sendData.Length > 0)
            {
                high = (byte)(sendData.Length / 2 / 256);
                low = (byte)(sendData.Length / 2 % 256);
                sendData = "02" + "02" + high.ToString("X2") + low.ToString("X2") + sendData;
                this.tcpServer.SendData(Tool.StringToHexByteArray(sendData));
            }
        }

        private void DealBatchUpload(byte[] tlvs)
        {
            TLVObject tLVObject = new TLVObject();
            AppendLog("Batch Up Record:");
            if (tLVObject.parse_tlvBCD(tlvs, tlvs.Length))
            {
                foreach(KeyValuePair<string, string> kvp in tLVObject.tlvDic)
                {
                    AppendLog(kvp.Key +": " + kvp.Value);
                }
            }
            else
            {
                AppendLog("Parse TLV Data Error");
            }
            
        }

        private void ShowTransResult(string result)
        {
            string cardBrand = this.comboBox_Brand.SelectedItem.ToString();
            //TODO:完善其他卡组的交易结果处理
            switch(cardBrand)
            {
                case "Discover":
                    if(result == "61")
                    {
                        AppendLog("TransResult:  Offline Approved");
                    }
                    else if(result == "62")
                    {
                        AppendLog("TransResult:  Offline Declined");
                    }
                    else if(result == "63")
                    {

                    }
                    break;
                default:
                    break;
            }   
        }

        private void ShowTransOutcome(string cardBrand, string outcome)
        {
            string tmp = "";
            tmp = outcome.Substring(0, 2);
            AppendLog("TransOutcome: ");

            if(tmp == "10")
            {
                AppendLog("Status:  Approved");
            }
            else if(tmp == "20")
            {
                AppendLog("Status:  Declined");
            }
            else if(tmp == "30")
            {
                AppendLog("Status:  Online Request");
            }
            else if(tmp == "40")
            {
                AppendLog("Status:  End Application");
            }
            else if(tmp == "50")
            {
                AppendLog("Status:  Select Next");
            }
            else if(tmp == "60")
            {
                AppendLog("Status:  Try Another Interface");
            }
            else if(tmp == "70")
            {
                AppendLog("Status:  Try Again");
            }
            else if(tmp == "A0")
            {
                AppendLog("Status:  End Application (with restart – communication error)");
            }
            else if(tmp == "B0")
            {
                AppendLog("Status:  End Application (with restart - On-Device CVM)");
            }
            else if(tmp == "C0")
            {
                AppendLog("Status:  Online Request (Two Presentments)");
            }
            else if(tmp == "D0")
            {
                AppendLog("Status:  Online Request (Present and Hold)");
            }
            else if(tmp == "F0")
            {
                AppendLog("Status:  Online Request (No Additional Tap)");
            }
            else if(tmp == "FF")
            {
                AppendLog("Status:  N/A");
            }
            else
            {
                AppendLog("Status:  Invalid Data");
            }

            tmp = outcome.Substring(2, 2);
            if(tmp == "00")
            {
                AppendLog("Start:  A");
            }
            else if(tmp == "10")
            {
                AppendLog("Start:  B");
            }
            else if(tmp == "20")
            {
                AppendLog("Start:  C");
            }
            else if (tmp == "30")
            {
                AppendLog("Start:  D");
            }
            else if (tmp == "F0")
            {
                AppendLog("Start:  N/A");
            }
            else
            {
                AppendLog("Start:  Invalid Data");
            }
            //TODO:完善交易结果的outcome处理

        }

        private void ShowTransOutcome(string outcome)
        {
            string tmp = "";
            tmp = outcome.Substring(0, 2);
            AppendLog("TransOutcome: ");
            //Status
            if (tmp == "10")
            {
                AppendLog("Status:  Approved");
            }
            else if (tmp == "20")
            {
                AppendLog("Status:  Declined");
            }
            else if (tmp == "30")
            {
                AppendLog("Status:  Online Request");
            }
            else if (tmp == "40")
            {
                AppendLog("Status:  End Application");
            }
            else if (tmp == "50")
            {
                AppendLog("Status:  Select Next");
            }
            else if (tmp == "60")
            {
                AppendLog("Status:  Try Another Interface");
            }
            else if (tmp == "70")
            {
                AppendLog("Status:  Try Again");
            }
            else if (tmp == "A0")
            {
                AppendLog("Status:  End Application (with restart – communication error)");
            }
            else if (tmp == "B0")
            {
                AppendLog("Status:  End Application (with restart - On-Device CVM)");
            }
            else if (tmp == "C0")
            {
                AppendLog("Status:  Online Request (Two Presentments)");
            }
            else if (tmp == "D0")
            {
                AppendLog("Status:  Online Request (Present and Hold)");
            }
            else if (tmp == "F0")
            {
                AppendLog("Status:  Online Request (No Additional Tap)");
            }
            else if (tmp == "FF")
            {
                AppendLog("Status:  N/A");
            }
            else
            {
                AppendLog("Status:  Invalid Data");
            }
            //Start
            tmp = outcome.Substring(2, 2);
            if (tmp == "00")
            {
                AppendLog("Start:  A");
            }
            else if (tmp == "10")
            {
                AppendLog("Start:  B");
            }
            else if (tmp == "20")
            {
                AppendLog("Start:  C");
            }
            else if (tmp == "30")
            {
                AppendLog("Start:  D");
            }
            else if (tmp == "F0")
            {
                AppendLog("Start:  N/A");
            }
            else
            {
                AppendLog("Start:  Invalid Data");
            }
            //Online Response Data
            tmp = outcome.Substring(4, 2);
            if (tmp == "10")
            {
                AppendLog("Online Response Data:  EMV Data");
            }
            else if (tmp == "20")
            {
                AppendLog("Online Response Data:  Any");
            }
            else if (tmp == "30")
            {
                AppendLog("Online Response Data:  N/A");
            }
            else
            {
                AppendLog("Online Response Data:  Invalid Data");
            }
            //CVM
            tmp = outcome.Substring(6, 2);
            if (tmp == "00")
            {
                AppendLog("CVM:  No CVM");
            }
            else if (tmp == "10")
            {
                AppendLog("CVM:  Obtain Signature");
            }
            else if (tmp == "20")
            {
                AppendLog("CVM:  Online PIN");
            }
            else if (tmp == "30")
            {
                AppendLog("CVM:  Confirmation Code Verified");
            }
            else if (tmp == "F0")
            {
                AppendLog("CVM:  N/A");
            }
            else
            {
                AppendLog("CVM:  Invalid Data");
            }
            //Flag
            tmp = outcome.Substring(8, 2);
            byte flag = Convert.ToByte(tmp, 16);
            if ((flag & (0x80)) == 0x80)
            {
                AppendLog("UI Request on Outcome Present:yes");
            }
            else
            {
                AppendLog("UI Request on Outcome Present:no");
            }
            if((flag & (0x40)) == 0x40)
            {
                AppendLog("UI Request on Restart Present:yes");
            }
            else
            {
                AppendLog("UI Request on Restart Present:no");
            }
            if((flag& (0x20)) == 0x20)
            {
                AppendLog("Data Record Present:yes");
            }
            else
            {
                AppendLog("Data Record Present:no");
            }
            if((flag&(0x10)) == 0x10)
            {
                AppendLog("Discretionary Data Present:yes");
            }
            else
            {
                AppendLog("Discretionary Data Present:no");
            }
            if((flag&(0x08)) == 0x08)
            {
                AppendLog("Receipt:yes");
            }
            else
            {
                AppendLog("Receipt:N/A");
            }
            //AIP
            tmp = outcome.Substring(10, 2);
            if(tmp == "10")
            {
                AppendLog("AIP: Contant Chip");
            }
            else if(tmp == "F0")
            {
                AppendLog("AIP: N/A");
            }
            else
            {
                AppendLog("AIP: Invalid Data");
            }
            //Field Off Request
            tmp = outcome.Substring(12, 2);
            if(tmp == "FF")
            {
                AppendLog("Field Off Request: N/A");
            }
            else
            {
                AppendLog("Field Off Request: " + tmp);
            }
            //Removal Timeout:
            tmp = outcome.Substring(14, 4);
            AppendLog("Removal Timeout: " + tmp);
        }

        private void ShowUIRequest(string msg, bool restart) 
        { 
            if(restart)
            {
                AppendLog("UI Request On Restart:");
            }
            else
            {
                AppendLog("UI Request On Outcome:");
            }
            //Message Identifier
            string tmp = "";
            tmp = msg.Substring(0, 2);
            if(tmp == "03")
            {
                AppendLog("Message Identifier:  03(Approved)");
            }
            else if(tmp == "07")
            {
                AppendLog("Message Identifier:  07(Not Authorised)");
            }
            else if (tmp == "09")
            {
                AppendLog("Message Identifier:  09(Please enter your PIN)");
            }
            else if (tmp == "15")
            {
                AppendLog("Message Identifier:  15(Present Card)");
            }
            else if (tmp == "16")
            {
                AppendLog("Message Identifier:  16(Processing)");
            }
            else if (tmp == "17")
            {
                AppendLog("Message Identifier:  17(Card Read OK)");
            }
            else if (tmp == "19")
            {
                AppendLog("Message Identifier:  19(Please Present One Card Only)");
            }
            else if (tmp == "1A")
            {
                AppendLog("Message Identifier:  1A(Approved – Please Sign)");
            }
            else if (tmp == "1B")
            {
                AppendLog("Message Identifier:  1B(Authorising, Please Wait)");
            }
            else if (tmp == "1C")
            {
                AppendLog("Message Identifier:  1C(Insert, Swipe or Try another card)");
            }
            else if (tmp == "1D")
            {
                AppendLog("Message Identifier:  1D(Please insert card)");
            }
            else if (tmp == "20")
            {
                AppendLog("Message Identifier:  20(See Phone for Instructions)");
            }
            else if (tmp == "21")
            {
                AppendLog("Message Identifier:  21(Present Card Again)");
            }
            else if (tmp == "FF")
            {
                AppendLog("Message Identifier:  N/A");
            }
            else
            {
                AppendLog("Message Identifier:  Invalid Data");
            }
            //Status:
            tmp = msg.Substring(2, 2);
            if (tmp == "00")
            {
                AppendLog("Status:  NOT READY\n");
            }
            else if (tmp == "01")
            {
                AppendLog("Status:  IDLE\n");
            }
            else if (tmp == "02")
            {
                AppendLog("Status:  READY TO READ\n");
            }
            else if (tmp == "03")
            {
                AppendLog("Status:  PROCESSING\n");
            }
            else if (tmp == "04")
            {
                AppendLog("Status:  CARD READ SUCCESSFULLY\n");
            }
            else if (tmp == "05")
            {
                AppendLog("Status:  PROCESSING ERROR\n");
            }
            else if (tmp == "FF")
            {
                AppendLog("Status:  N/A\n");
            }
            else
            {
                AppendLog("Status:  Invalid Data\n");
            }
            //Hold Time:
            tmp = msg.Substring(4, 6);
            try
            {
                AppendLog("Hold Time:" + tmp);
            }
            catch (ArgumentOutOfRangeException e)
            {
                AppendLog("Show Hold Time fail!length invalid!");
            }
            //Language Preference:
            tmp = msg.Substring(10, 16);
            try
            {
                AppendLog("Language Preference:" + tmp);
            }
            catch (ArgumentOutOfRangeException e)
            {
                AppendLog("Show Language Preference fail!length invalid!");
            }
            //Value Qualifier:
            tmp = msg.Substring(26, 2);
            try
            {
                AppendLog("Value Qualifier:" + tmp);
            }
            catch (ArgumentOutOfRangeException e)
            {
                AppendLog("Show Value Qualifier fail!length invalid!");
            }
            //Value
            tmp = msg.Substring(28, 12);
            try
            {
                if(tmp != "FFFFFFFFFFFF")
                {
                    AppendLog("Value :" + tmp);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                AppendLog("Show Value fail!length invalid!");
            }
            //Currency Code
            tmp = msg.Substring(40, 4);
            try
            {
                if (tmp != "FFFFFFFFFFFF")
                {
                    AppendLog("Currency Code :" + tmp);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                AppendLog("Show Currency Code fail!length invalid!");
            }

        }

        private void ShowDataRecord(string msg)
        {
            TLVObject tLVObject = new TLVObject();
            tLVObject.parse_tlvstring(msg);

            foreach (KeyValuePair<string, string> kvp in tLVObject.tlvDic)
            {
                if(kvp.Key == "DF43")
                {
                    if(kvp.Value == "01")
                    {
                        AppendLog("Transaction Mode:  EMV Mode");
                    }
                    else if(kvp.Value == "02")
                    {
                        AppendLog("Transaction Mode:  Magstripe Mode");
                    }
                    else if(kvp.Value == "04")
                    {
                        AppendLog("Transaction Mode:  Legacy Mode");
                    }
                    else
                    {
                        AppendLog("Transaction Mode:  Invalid Data");
                    }
                }
                else
                {
                    AppendLog(kvp.Key + ": " + kvp.Value);
                }
            }
        }

        private void DealTransResult(byte[] tlvs)
        {
            AppendLog("Trans Result:");
            TLVObject tLVObject = new TLVObject();
            if(tLVObject.parse_tlvBCD(tlvs, tlvs.Length))
            {
                foreach (KeyValuePair<string, string> kvp in tLVObject.tlvDic)
                {
                    if(kvp.Key == "03")
                    {
                        ShowTransResult(kvp.Value);
                    }
                    else if(kvp.Key == "DF23")
                    {
                        ShowTransOutcome(kvp.Value);
                    }
                    else if(kvp.Key == "FF8109")
                    {
                        if(kvp.Value == "00")
                        {
                            AppendLog("CVM:  No CVM");
                        }
                        else if(kvp.Value == "10")
                        {
                            AppendLog("CVM:  Signature");
                        }
                        else if(kvp.Value == "20")
                        {
                            AppendLog("CVM:  Online PIN");
                        }
                        else if(kvp.Value == "30")
                        {
                            AppendLog("CVM:  CDCVM");
                        }
                        else if(kvp.Key == "40")
                        {
                            AppendLog("CVM:  N/A");
                        }
                        else
                        {
                            AppendLog("CVM:   Invalid data");
                        }
                    }
                    else if(kvp.Key == "DF31")
                    {
                        AppendLog("Script Result:" + kvp.Value);
                    }
                    else if(kvp.Key == "DFC10B")
                    {
                        if(kvp.Value == "00")
                        {
                            AppendLog("ODA Result:   ODA not Performed");
                        }
                        else if(kvp.Value == "01")
                        {
                            AppendLog("ODA Result:   fDDA Succeed");
                        }
                        else if(kvp.Value == "02")
                        {
                            AppendLog("ODA Result:   fDDA Failed");
                        }
                        else if(kvp.Value == "03")
                        {
                            AppendLog("ODA Result:   SDA Succeed");
                        }
                        else if(kvp.Value == "04")
                        {
                            AppendLog("ODA Result:   SDA Failed");
                        }
                        else if(kvp.Value == "05")
                        {
                            AppendLog("ODA Result:   DDA Succeed");
                        }
                        else if(kvp.Value == "06")
                        {
                            AppendLog("ODA Result:   DDA Failed");
                        }
                        else if(kvp.Value == "07")
                        {
                            AppendLog("ODA Result:   CDA Succeed");
                        }
                        else if(kvp.Value == "08")
                        {
                            AppendLog("ODA Result:   CDA Failed");
                        }
                        else if(kvp.Value == "09")
                        {
                            AppendLog("ODA Result:   Online fDDA Succeed and Display");
                        }
                        else if(kvp.Value == "0A")
                        {
                            AppendLog("ODA Result:   Online fDDA Failed and Display");
                        }
                        else if(kvp.Value == "0B")
                        {
                            AppendLog("ODA Result:   Online SDA Succeed and Display");
                        }
                        else if(kvp.Value == "0C")
                        {
                            AppendLog("ODA Result:   Online SDA Failed and Display");
                        }
                        else if(kvp.Value == "0D")
                        {
                            AppendLog("ODA Result:   Online ODA Failed and Display");
                        }
                        else
                        {
                            AppendLog("ODA Result:   Invalid Data");
                        }
                    }
                    else if(kvp.Key == "DF8129")
                    {
                        ShowTransOutcome(kvp.Value);
                    }
                    else if(kvp.Key == "DF8116")
                    {
                        ShowUIRequest(kvp.Value, false);
                    }
                    else if(kvp.Key == "DF8117")
                    {
                        ShowUIRequest(kvp.Value, true);
                    }
                    else if(kvp.Key == "FF8105")
                    {
                        ShowDataRecord(kvp.Value);
                    }
                    else
                    {
                        AppendLog(kvp.Key + ": " + kvp.Value);
                    }
                }
            }
            else
            {
                AppendLog("Parse TLV Data Error");
            }

        }

        private void DealTermOutcome(byte[] tlvs)
        {
            //AppendLog("Start DealTermOutcome");
            string s = Tool.HexByteArrayToString(tlvs);
            //AppendLog("After HexByteArrayToString s:"+s);
            TLVObject tLVObject = new TLVObject();
            //AppendLog("Parse TLV result:" + tLVObject.parse_tlvstring(s));
            if (tLVObject.parse_tlvstring(s))
            {
                if(tLVObject.Exist("DF8129"))
                {
                    AppendLog("________________________________________________");
                    ShowTransOutcome(tLVObject.Get("DF8129"));
                    AppendLog("________________________________________________");
                }
                if (tLVObject.Exist("DF8116"))
                {
                    AppendLog("________________________________________________");
                    ShowUIRequest(tLVObject.Get("DF8116"), false);
                    AppendLog("________________________________________________");
                }
                if (tLVObject.Exist("DF8117"))
                {
                    AppendLog("________________________________________________");
                    ShowUIRequest(tLVObject.Get("DF8117"), true);
                    AppendLog("________________________________________________");
                }
            }
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
