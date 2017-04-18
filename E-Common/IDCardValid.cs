using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Common
{
    public class IDCardValid
    {
        public IDCardValid()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="Id">身份证号码</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        #region 身份证号码验证

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        #endregion

        /// <summary>
        /// 将15位的身份证号码转换成18位的身份证好码
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns>返回18位身份证号码</returns>
        public static string Convert15to18(string idCard)
        {
            string code = idCard.Trim();//获得身份证号码
            if (code.Length == 15)//如果是15位则转换
            {
                char[] strJY = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
                int[] intJQ = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };
                string strTemp;
                int intTemp = 0;
                strTemp = code.Substring(0, 6) + "19" + code.Substring(6);
                for (int i = 0; i <= strTemp.Length - 1; i++)
                {
                    intTemp = intTemp + int.Parse(strTemp.Substring(i, 1)) * intJQ[i];
                }
                intTemp = intTemp % 11;
                return strTemp + strJY[intTemp];
            }
            else
            {
                if (code.Length == 18)//如果是18位直接返回
                {
                    return code;
                }
                return string.Empty;//如果即不是15位也不是18位则返回空
            }
        }
        /// <summary>
        /// 获得出身年月日
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns>返回出身年月日</returns>
        public static string GetBirth(string idCard)
        {
            string code = Convert15to18(idCard);//获得身份证号码
            if (code != string.Empty)
            {
                string year = code.Substring(6, 4);//获得身份证号码里面的年
                string month = code.Substring(10, 2);//获得身份证号码里面的月
                string day = code.Substring(12, 2);//获得身份证号码里面的日
                return year + "年" + month + "月" + day + "日";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
