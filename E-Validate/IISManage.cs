using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
namespace E_Validate
{
    public class IISManage
    {
        private string _server, _website, _AnonymousUserPass, _AnonymousUserName;

        protected DirectoryEntry rootfolder;
        private string _serverip, _domain, _webSiteName, _port, _path;

        
        #region 构造函数
        public void IISManager()
        {
            //默认情况下使用localhost，即访问本地机
             _server = "localhost";
             _website = "1";
        }



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strServer">服务器</param>
        public void IISManager(string strServer)
        {
            _server = strServer;
            _website = "1"; 
        }



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strServer">服务器</param>
        /// <param name="website">站点，每一个站点为1，第二个站点为2，依此类推</param>
        public void IISManager(string strServer,int website)
        {
            _server = strServer;
            _website = website.ToString(); 

        }
        #endregion

        #region 新建一个网站的参数
        /// <summary>
        /// 用于网站标题,描述
        /// </summary>
        public string WebSiteName
        {
            get { return _webSiteName; }
            set { _webSiteName = value; }
        }

        /// <summary>
        /// 新建立网站的端口,一般设置为80
        /// </summary>
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /// <summary>
        /// 新建立网站的物理路径
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// 服务器的IP地址
        /// </summary>
        public string ServerIP
        {
            get { return _serverip; }
            set { _serverip = value; }
        }

        /// <summary>
        /// 网站访问的域名
        /// </summary>
        public string DoMain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        /// <summary>
        /// 匿名访问用户
        /// </summary>

        public string AnonymousUserName
        {
            get { return _AnonymousUserName; }
            set { _AnonymousUserName = value; }
        }



        /// <summary>
        /// 匿名访问用户密码
        /// </summary>
        public string AnonymousUserPass
        {
            get { return _AnonymousUserPass; }
            set { _AnonymousUserPass = value; }
        }



        /// <summary>
        /// 服务器，可以是IP或计算名
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }



        /// <summary>
        /// 站点，一般来说第一台主机为1,第二台主机为2，依次类推
        /// </summary>
        public int WebSite
        {
            get { return Convert.ToInt32(_website); }
            set { _website = Convert.ToString(value); }
        }
        #endregion

        #region 获取新网站id的方法

        /// <summary>
        /// 获取网站系统里面可以使用的最小的ID。
        /// 这是因为每个网站都需要有一个唯一的编号，而且这个编号越小越好。
        /// 这里面的算法经过了测试是没有问题的。
        /// </summary>
        /// <returns>最小的id</returns>
        public string GetNewWebSiteID()
        {
            ArrayList list = new ArrayList();
            string tmpStr;
            string entPath = String.Format("IIS://{0}/w3svc", this._server);
            DirectoryEntry ent = new DirectoryEntry(entPath);
            foreach (DirectoryEntry child in ent.Children)
            {
                if (child.SchemaClassName == "IIsWebServer")
                {
                    tmpStr = child.Name.ToString();
                    list.Add(Convert.ToInt32(tmpStr));
                }
            }
            list.Sort();
            int i = 1;
            foreach (int j in list)
            {
                if (i == j)
                {
                    i++;
                }
            }
            return i.ToString();
        }
        #endregion
        
        #region 新建立一个IIS WEB站点
        /// <summary>
        /// 添加一个站点
        /// </summary>
        public string CreateWebSite()
        {
            int siteID = int.Parse(GetNewWebSiteID());
            try
            {
                DirectoryEntry root = new DirectoryEntry("IIS://" + this._server + "/W3SVC");
                if (!EnsureNewSiteEnavaible(this._serverip + ":" + this._port + ":" + this._domain))
                {
                    return "此用户名的网站已经存在！";
                }
                else
                {
                    DirectoryEntry site = (DirectoryEntry)root.Invoke("Create", "IIsWebServer", siteID);
                    site.Invoke("Put", "ServerComment", this._webSiteName);
                    site.Invoke("Put", "KeyType", "IIsWebServer");
                    site.Invoke("Put", "ServerBindings", this._serverip + ":" + this._port + ":" + this._domain);
                    site.Invoke("Put", "ServerState", 2);
                    site.Invoke("Put", "FrontPageWeb", 1);
                    site.Invoke("Put", "DefaultDoc", "index.aspx,index.html,index.html,default.aspx,default.htm,default.html");
                    site.Invoke("Put", "ServerAutoStart", 1);
                    site.Invoke("Put", "ServerSize", 1);
                    site.Invoke("SetInfo");
                    DirectoryEntry siteVDir = site.Children.Add("Root", "IISWebVirtualDir");
                    siteVDir.Properties["AppIsolated"][0] = 2;
                    siteVDir.Properties["Path"][0] = this._path;
                    siteVDir.Properties["AccessFlags"][0] = 513;
                    siteVDir.Properties["FrontPageWeb"][0] = 1;
                    siteVDir.Properties["AppRoot"][0] = "LM/W3SVC/" + siteID + "/Root";
                    siteVDir.Properties["AppFriendlyName"][0] = "ROOT";
                    siteVDir.CommitChanges();
                    site.CommitChanges();
                    return "创建站点成功！";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 删除一个网站
        /// <summary>
        /// 删除一个网站。根据网站名称删除。
        /// </summary>
        /// <param name="siteName">网站名称</param>

        public void DeleteWebSiteByName(string siteName)
        {
            string siteNum = GetWebSiteNum(siteName);
            string siteEntPath = String.Format("IIS://{0}/w3svc/{1}", this._server, siteNum);
            DirectoryEntry siteEntry = new DirectoryEntry(siteEntPath);
            string rootPath = String.Format("IIS://{0}/w3svc", this._server);
            DirectoryEntry rootEntry = new DirectoryEntry(rootPath);
            rootEntry.Children.Remove(siteEntry);
            rootEntry.CommitChanges();
        }
        #endregion

        #region 获取一个网站编号的方法
        /// <summary>
        /// 获取一个网站的编号。根据网站的ServerBindings或者ServerComment来确定网站编号
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns>返回网站的编号</returns>
        public string GetWebSiteNum(string siteName)
        {
            Regex regex = new Regex(siteName);
            string tmpStr;
            string entPath = String.Format("IIS://{0}/w3svc", this._server);
            DirectoryEntry ent = new DirectoryEntry(entPath);
            foreach (DirectoryEntry child in ent.Children)
            {
                if (child.SchemaClassName == "IIsWebServer")
                {
                    if (child.Properties["ServerBindings"].Value != null)
                    {
                        tmpStr = child.Properties["ServerBindings"].Value.ToString();
                        if (regex.Match(tmpStr).Success)
                        {
                            return child.Name;
                        }
                    }
                    if (child.Properties["ServerComment"].Value != null)
                    {
                        tmpStr = child.Properties["ServerComment"].Value.ToString();
                        if (regex.Match(tmpStr).Success)
                        {
                            return child.Name;
                        }
                    }
                }
            }
            return "没有找到要删除的站点";
        }
        #endregion

        #region Start和Stop网站的方法
        public void StartWebSite(string siteName)
        {
            string siteNum = GetWebSiteNum(siteName);
            string siteEntPath = String.Format("IIS://{0}/w3svc/{1}", this._server, siteNum);
            DirectoryEntry siteEntry = new DirectoryEntry(siteEntPath);
            siteEntry.Invoke("Start", new object[] { });
        }



        public void StopWebSite(string siteName)
        {
            string siteNum = GetWebSiteNum(siteName);
            string siteEntPath = String.Format("IIS://{0}/w3svc/{1}", this._server, siteNum);
            DirectoryEntry siteEntry = new DirectoryEntry(siteEntPath);
            siteEntry.Invoke("Stop", new object[] { });
        }
        #endregion

        #region 确认网站是否相同
        public bool EnsureNewSiteEnavaible(string bindStr)
        {
            string entPath = String.Format("IIS://{0}/w3svc", this._server);
            DirectoryEntry ent = new DirectoryEntry(entPath);
            foreach (DirectoryEntry child in ent.Children)
            {
                if (child.SchemaClassName == "IIsWebServer")
                {
                    if (child.Properties["ServerBindings"].Value != null)
                    {
                        if (child.Properties["ServerBindings"].Value.ToString() == bindStr)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 连接服务器
        /// </summary>
        public void Connect()
        {
            ConnectToServer();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="strServer">服务器名称</param>
        public void Connect(string strServer)
        {
            _server = strServer;
            ConnectToServer();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="strServer">服务器名称</param>
        /// <param name="strWebSite">站点，一般来说第一台主机为1,第二台主机为2，依次类推</param>
        public void Connect(string strServer, string strWebSite)
        {
            _server = strServer;
            _website = strWebSite;
            ConnectToServer();
        }

        /// <summary>
        /// 关闭当前对象
        /// </summary>
        public void Close()
        {
            rootfolder.Dispose();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void ConnectToServer()
        {
            string strPath = "IIS://" + _server + "/W3SVC/" + _website +"/ROOT";
            try
            {
                this.rootfolder = new DirectoryEntry(strPath);
            } 
            catch(Exception)
            {
                Console.Write("无法连接到服务器："+_server);
            }
        }
        #endregion

        //private void creatIisWebSite()
        //{
        //    IISManager iis = new IISManager();
        //    iis.Connect();
        //    iis.ServerIP = "192.168.0.177";
        //    iis.DoMain = "demo.caspnet.com.cn";
        //    iis.WebSiteName = "demo.caspnet.com.cn";
        //    iis.Port = "80";
        //    iis.Path = @"e:\zhming\website\";
        //    string result = iis.CreateWebSite();
        //    Response.Write(result);
        //    iis.Close();
        //}
    }
}
