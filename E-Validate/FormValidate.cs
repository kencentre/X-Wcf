using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Validate
{
    public class FormValidate
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegIP = new Regex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}");
        private static Regex RegPhone = new Regex("(\\d{3}-|\\d{4}-)?\\d{7}|\\d{8}");
        private static Regex RegQQ = new Regex("^[1-9]*[1-9][0-9]");
        private static Regex RegURL = new Regex("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
        //private static Regex RegDate = new Regex("^(((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/])(10|12|0?[13578])([-\\/])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/])(11|0?[469])([-\\/])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/])(0?2)([-\\/])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\\/])(0?2)([-\\/])(29)$)|(^([3579][26]00)([-\\/])(0?2)([-\\/])(29)$)|(^([1][89][0][48])([-\\/])(0?2)([-\\/])(29)$)|(^([2-9][0-9][0][48])([-\\/])(0?2)([-\\/])(29)$)|(^([1][89][2468][048])([-\\/])(0?2)([-\\/])(29)$)|(^([2-9][0-9][2468][048])([-\\/])(0?2)([-\\/])(29)$)|(^([1][89][13579][26])([-\\/])(0?2)([-\\/])(29)$)|(^([2-9][0-9][13579][26])([-\\/])(0?2)([-\\/])(29))|(((((0[13578])|([13578])|(1[02]))[\\-\\/\\s]?((0[1-9])|([1-9])|([1-2][0-9])|(3[01])))|((([469])|(11))[\\-\\/\\s]?((0[1-9])|([1-9])|([1-2][0-9])|(30)))|((02|2)[\\-\\/\\s]?((0[1-9])|([1-9])|([1-2][0-9]))))[\\-\\/\\s]?\\d{4})(\\s(((0[1-9])|([1-9])|(1[0-2]))\\:([0-5][0-9])((\\s)|(\\:([0-5][0-9])\\s))([AM|PM|am|pm]{2,2})))?$");
        private static Regex RegDate = new Regex("(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)");

        private static Regex RegRequest = new Regex("(?:')|(?:--)|(/\\*(?:.|[\\n\\r])*?\\*/)|(\\b(select|update|and|or|delete|insert|trancate|char|into|substr|ascii|declare|exec|count|master|into|drop|execute)\\b)");

        public FormValidate()
        { }

        #region 数字字符串检查
        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 邮件地址
        /// <summary>
        /// 是否是邮件地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region IP地址
        /// <summary>
        /// 是否是ip地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsIP(string inputData)
        {
            Match m = RegIP.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 电话
        /// <summary>
        /// 是否是电话
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }
        #endregion

        #region QQ
        /// <summary>
        /// 是否是QQ
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsQQ(string inputData)
        {
            Match m = RegQQ.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 网址
        /// <summary>
        /// 是否是网址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsURL(string inputData)
        {
            Match m = RegURL.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 日期
        /// <summary>
        /// 是否是日期YYYY-MM-DD
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDate(string inputData)
        {
            Match m = RegDate.Match(inputData);
            return m.Success;
        }
        #endregion


        #region 日期
        /// <summary>
        /// 是否是日期YYYY-MM-DD
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool HasSql(string inputData)
        {
            Match m = RegRequest.Match(inputData);
            return m.Success;
        }
        #endregion
    }
}
