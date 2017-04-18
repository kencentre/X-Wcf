using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections;
using System.Data;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace E_Common
{
    public class JsonHelper
    {
        /// <summary>
        /// DataTable转换成Json格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder("[");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    jsonBuilder.Append("{");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string value = dr[dc.ColumnName.ToString()].ToString();
                        if (dc.DataType.FullName == "System.DateTime")
                            value = value.Length == 0 ? value : Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                        if (PageValidate.NoHTML(value).Length > 150)
                        {
                            value = PageValidate.NoHTML(value).Substring(0, 150) + "...";
                        }
                        else
                        {
                            value = PageValidate.NoHTML(value);
                        }
                        jsonBuilder.AppendFormat("\"{0}\":\"{1}\",",
                             dc.ColumnName, value);
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// DataRow[] 转换成Json格式
        /// </summary>
        /// <param name="drArr"></param>
        /// <returns></returns>
        public static string DataRowToJson(DataRow[] drArr)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            if (drArr.Length > 0)
            {
                foreach (DataRow dr in drArr)
                {
                    jsonBuilder.Append("{");
                    for (int drIndex = 0; drIndex < dr.ItemArray.Length; drIndex++)
                    {
                        jsonBuilder.AppendFormat("\"{0}\":\"{1}\",",
                            dr.Table.Columns[drIndex].ColumnName, dr[drIndex].ToString());
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// DataTable转换成Json格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt, int recordCount)
        {
            string json = "{";
            json += string.Format("\"total\":{0},\"data\":{1}", recordCount, DataTableToJson(dt));
            json += "}";
            return json;
        }

        /// <summary>
        /// DataTable转换成Json格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson2(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dic.Add(col.ColumnName, dr[col.ColumnName]);
                }
                list.Add(dic);
            }
            return new JavaScriptSerializer().Serialize(list);
        }
    }
}
