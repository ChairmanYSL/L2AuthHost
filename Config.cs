using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace AuthHost
{
    class Config
    {
        public string AIDCfgName;
        public string CAPKCfgName;
        public string DRLCfgName;
        public string ExcpFileCfgName;
        public string TermParCfgName;
        public string RevokeyCfgName;
        public List<string> BrandList = new List<string>();
        public List<string> AIDList = new List<string>();
        public List<string> CAPKList = new List<string>();
        public List<string> DRLList = new List<string>();
        public List<string> ExcpFileList = new List<string>();
        public List<string> TermParList = new List<string>();
        public List<string> RevokeyList = new List<string>();
        public string CfgDir;
        public string curBrandName;
        public XmlDocument docAID;
        public XmlDocument docCAPK;
        public XmlDocument docDRL;
        public XmlDocument docExcpfile;
        public XmlDocument docTermparam;
        public XmlDocument docRevokey;
        public int AIDNum;
        public int CAPKNum;
        public int DRLNum;
        public int ExcpFileNum;
        public int TermParNum;
        public int RevokeyNum;

        public enum CfgType
        {
            CfgAID,
            CfgCAPK,
            CfgDRL,
            CfgExcpFile,
            CfgTermParm,
            CfgRevokey
        };

        public void initDir(string CfgDir)
        {
            this.CfgDir = CfgDir + "\\Config";
        }

        public void initBrand()
        {
            Logger.Instance.Log("Config Dir: " + this.CfgDir);
            if (Directory.Exists(this.CfgDir))
            {
                string[] files = Directory.GetDirectories(this.CfgDir);
                foreach (string file in files)
                {
                    Logger.Instance.Log("Brand Name: " + Path.GetFileName(file));
                    this.BrandList.Add(Path.GetFileName(file));
                }
            }
        }

        public void SetBrandLocaliton(string curBrand)
        {
            Logger.Instance.Log("info: Input Brand Name: " + curBrand);
            this.curBrandName = curBrand;
        }

        public void initConfig()
        {
            if(Directory.Exists(this.CfgDir))
            {
                if (this.curBrandName == null)
                {
                    AlertHelper.ShowAlert("Warning", "Cur Brand is null");
                    Logger.Instance.Log("Error: Get Cur Brand From ComboBox Error");
                    return;
                }

                Logger.Instance.Log("Cur Brand Name:" + this.curBrandName);
                string curBrandDir = this.CfgDir + "\\" + this.curBrandName;

                this.AIDCfgName = curBrandDir + "\\AID";
                this.CAPKCfgName = curBrandDir + "\\CAPK";
                this.DRLCfgName = curBrandDir + "\\DRL";
                this.ExcpFileCfgName = curBrandDir + "\\Exception_File";
                this.TermParCfgName = curBrandDir + "\\SimData";
                this.RevokeyCfgName = curBrandDir + "\\Revocation_CAPK";

                Logger.Instance.Log("AID Dir Name: " + this.AIDCfgName);
                Logger.Instance.Log("CAPK Dir Name: " + this.CAPKCfgName);
                Logger.Instance.Log("Exception_File Dir Name: " + this.ExcpFileCfgName);
                Logger.Instance.Log("SimData Dir Name: " + this.TermParCfgName);
                Logger.Instance.Log("Revocation_CAPK Dir Name: " + this.RevokeyCfgName);
                Logger.Instance.Log("DRL Dir Name: " + this.DRLCfgName);

                if (Directory.Exists(this.AIDCfgName))
                {
                    string [] files = Directory.GetFiles(this.AIDCfgName);
                    if(this.AIDList.Count > 0)
                    {
                        this.AIDList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.AIDList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no AID File,Plz Check");
                    Logger.Instance.Log("Warning: AID DIR path not exist");

                }
                if (Directory.Exists(this.CAPKCfgName))
                {
                    string[] files = Directory.GetFiles(this.CAPKCfgName);
                    if(this.CAPKList.Count > 0)
                    {
                        this.CAPKList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.CAPKList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no CAPK File,Plz Check");
                    Logger.Instance.Log("Warning: CAPK DIR path not exist");
                }
                if (Directory.Exists(this.DRLCfgName))
                {
                    string[] files = Directory.GetFiles(this.DRLCfgName);
                    if(this.DRLList.Count > 0)
                    {
                        this.DRLList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.DRLList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no DRL File,Plz Check");
                    Logger.Instance.Log("Warning: DRL DIR path not exist");
                }
                if (Directory.Exists(this.ExcpFileCfgName))
                {
                    string[] files = Directory.GetFiles(this.ExcpFileCfgName);
                    if(this.ExcpFileList.Count > 0)
                    {
                        this.ExcpFileList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.ExcpFileList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no Excption File,Plz Check");
                    Logger.Instance.Log("Warning: Excption File DIR path not exist");
                }
                if (Directory.Exists(this.TermParCfgName))
                {
                    string[] files = Directory.GetFiles(this.TermParCfgName);
                    if(this.TermParList.Count > 0)
                    {
                        this.TermParList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.TermParList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no Term Param File,Plz Check");
                    Logger.Instance.Log("Warning: Term Param DIR path not exist");
                }
                if (Directory.Exists(this.RevokeyCfgName))
                {
                    string[] files = Directory.GetFiles(this.RevokeyCfgName);
                    if(this.RevokeyList.Count > 0)
                    {
                        this.RevokeyList.Clear();
                    }
                    foreach (string file in files)
                    {
                        this.RevokeyList.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    AlertHelper.ShowAlert("Warning", "Detect no Revokey File,Plz Check");
                    Logger.Instance.Log("Warning: Revokey DIR path not exist");
                }
            }
            else
            {
                AlertHelper.ShowAlert("Warning", "Detect no Config Dir,Plz Check");
                Logger.Instance.Log("Warning: Config DIR path is null");
            }
            docAID = new XmlDocument();
            docCAPK = new XmlDocument();
            docDRL = new XmlDocument();
            docExcpfile = new XmlDocument();
            docRevokey = new XmlDocument();
            docTermparam = new XmlDocument();
        }

        public void LoadXml(CfgType type, int index)
        {
            string directoryPath;
            string[] files;
            switch (type)
            {
                case CfgType.CfgAID:
                    directoryPath = AIDCfgName;
                    if(Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docAID.Load(files[index]);
                        Logger.Instance.Log("Load AID File:" + files[index]);
                    }
                    break;
                case CfgType.CfgCAPK:
                    directoryPath = CAPKCfgName;
                    if (Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docCAPK.Load(files[index]);
                        Logger.Instance.Log("Load CAPK File:" + files[index]);
                        MainWnd.Instance.UpdateMessNolog("Load CAPK File:" + files[index]);
                    }
                    break;
                case CfgType.CfgDRL:
                    directoryPath = DRLCfgName;
                    if (Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docDRL.Load(files[index]);
                        Logger.Instance.Log("Load DRL File:" + files[index]);
                        MainWnd.Instance.UpdateMessNolog("Load DRL File:" + files[index]);
                    }
                    break;
                case CfgType.CfgExcpFile:
                    directoryPath = ExcpFileCfgName;
                    if (Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docExcpfile.Load(files[index]);
                        Logger.Instance.Log("Load Exception File:" + files[index]);
                        MainWnd.Instance.UpdateMessNolog("Load Exception File:" + files[index]);
                    }
                    break;
                case CfgType.CfgTermParm:
                    directoryPath = TermParCfgName;
                    if (Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docTermparam.Load(files[index]);
                        Logger.Instance.Log("Load Term Param File:" + files[index]);
                        MainWnd.Instance.UpdateMessNolog("Load Term Param File:" + files[index]);
                    }
                    break;
                case CfgType.CfgRevokey:
                    directoryPath = RevokeyCfgName;
                    if (Directory.Exists(directoryPath))
                    {
                        files = Directory.GetFiles(directoryPath);
                        docRevokey.Load(files[index]);
                        Logger.Instance.Log("Load Revokey File:" + files[index]);
                        MainWnd.Instance.UpdateMessNolog("Load Revokey File:" + files[index]);
                    }
                    break;
                default:
                    MainWnd mainWnd = new MainWnd();
                    Logger.Instance.Log("Error: Input Cfg Type invalid");
                    break;
            }
        }
    }

}
