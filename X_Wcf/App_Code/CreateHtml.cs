using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
namespace X_Wcf.App_Code
{
    public class CreateHtml
    {
        DataSet ds;
        E_BLL.Brock mBrock = new E_BLL.Brock();
        E_BLL.Tag mTag = new E_BLL.Tag();
        E_BLL.PropertyValue mPropertyValue = new E_BLL.PropertyValue();


        public CreateHtml()
        { }

        public string GetHtmlByNodeID(string html,string borck)
        {
            string htmlCode = "";
            ds = new DataSet();
            ds = mBrock.GetList(" status = '1' and brockname = 'borck'");
            return htmlCode;
        }
    }
}