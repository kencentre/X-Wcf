using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HtmlAgilityPack;

namespace E_Common
{
    public class HtmlCode
    {
        StringBuilder strHtml = new StringBuilder();
        public HtmlCode()
        { }

        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
        public string replaceHtml(string path, string brockName)
        {
            htmlDocument.Load(path);
            //HtmlNodeCollection collection = htmlDocument.DocumentNode.SelectSingleNode("div").ChildNodes;
            HtmlNode navNode = htmlDocument.GetElementbyId(brockName);
            strHtml.Append(navNode.InnerHtml);
            return strHtml.ToString();
        }
    }
}
