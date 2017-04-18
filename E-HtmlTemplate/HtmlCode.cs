using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace E_HtmlTemplate
{
    public class HtmlCode
    {
        DataSet ds = new DataSet();
        E_BLL.Brock mBrock = new E_BLL.Brock();
        E_BLL.Tag mTag = new E_BLL.Tag();
        StringBuilder strHtml = new StringBuilder();
        TagReplace tr = new TagReplace();
        public HtmlCode()
        { }

        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
        public string replaceHtml(string path, string brockID,string brockName)
        {
            string str = "";
            htmlDocument.Load(path);
            //HtmlNodeCollection collection = htmlDocument.DocumentNode.SelectSingleNode("div").ChildNodes;
            HtmlNode navNode = htmlDocument.GetElementbyId(brockName);
            if (navNode.HasAttributes == true)
            {
                //Console.Write(navNode.Attributes[brockName].Value);
                //return navNode.Attributes[brockName].Value;
            }
            //navNode.Attributes[brockName]
            if (navNode.HasAttributes)
            {

            }
            else
            {

            }
            if (brockID == "bb69a885-b33f-4e9d-8a16-34a1e2ae3b74")
            {
                strHtml.Append("<div id='" + navNode.Attributes["id"].Value + "' class='" + navNode.Attributes["class"].Value + "' style='display:none;'> ");
            }
            else
            {
                strHtml.Append("<div id='" + navNode.Attributes["id"].Value + "' class='" + navNode.Attributes["class"].Value + "'>");
            }
            
            str = navNode.InnerHtml;
            ds = mTag.GetList(" status = '1' and brockid = '"+ brockID + "'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str.Contains(ds.Tables[0].Rows[i]["TAGNAEM"].ToString()) == true)
                {
                    str = str.Replace(ds.Tables[0].Rows[i]["TAGNAEM"].ToString(), tr.ChangeReplace(ds.Tables[0].Rows[i]["TAGNAEM"].ToString()));
                }
            }
            strHtml.Append(str);
            strHtml.Append("</div>");
            return strHtml.ToString();
        }

        public void createHtml(string path, string savePath,string saveText,string htmlName)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            String input = sr.ReadToEnd();
            sr.Close();
            if (input.Contains("$temp$"))
            {
                input = input.Replace("$temp$",saveText);
            }

            StreamWriter sw = new StreamWriter(savePath,false);
            sw.Write(input);
            sw.Close();

        }
    }
}
