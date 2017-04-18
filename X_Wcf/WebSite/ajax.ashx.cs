using E_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace X_Wcf.WebSite
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler, IRequiresSessionState
    {
        E_BLL.News manage = new E_BLL.News();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["ac"];
            string result = "";
            switch (action)
            {
                case "GetNews":
                    //获取应用
                    result = GetNews(context.Request["pindex"],context.Request["type"]);
                    break;
                
            }
            context.Response.Write(result);
            context.Response.End();
        }


        
        public string GetNews(string pageIndex,string type)
        {
            string sqlWhere = "";
            if (type == "0")
            {
                //清波新闻
                sqlWhere = "  cms_news.channel = '26626986-4ac2-4d85-a09b-4b60c494bc1a' and cms_news.status = '1'";
            }
            if (type == "1")
            {
                //行业动态
                sqlWhere = "  cms_news.channel = 'bd0ea1dc-fcbc-4577-8879-3759840a8596' and cms_news.status = '1'";
            }
            if (type == "2")
            {
                //图片新闻
                sqlWhere = "  cms_news.channel = '10a3e06d-b5e1-45eb-9fe5-83bd06c22e6c' and cms_news.status = '1'";
            }
            if (type == "3")
            {
                //视频
                sqlWhere = "  cms_news.channel = 'b1b4e37c-d6f6-4a1c-9843-211ee92e21ae' and cms_news.status = '1'";
            }
            string RecordCount = "";
            DataSet dtSysApp = new DataSet();

            
            
            dtSysApp = manage.GetDataTableProc(sqlWhere,  "15", pageIndex.ToString(), out RecordCount);
            return JsonHelper.DataTableToJson(dtSysApp.Tables[0], int.Parse(RecordCount));
           
        }

       

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
    }
}