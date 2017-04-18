using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Common
{
    public class AppDragHelper
    {
        /// <summary>
        /// 判断是否更新应用 (用于用户更新应用时)
        /// </summary>
        /// <param name="AppID"></param>
        /// <param name="OldAppType">原始类型</param>
        /// <param name="AppType">新类型</param>
        /// <param name="CurrentDeskApp"></param>
        /// <param name="NewDeskApp"></param>
        /// <returns></returns>
        public static bool IsUpdateApp(string AppID, string OldAppType, string AppType, string CurrentDeskApp,
            ref string NewDeskApp)
        {
            bool IsUpdate = false;
            if (OldAppType != AppType)
            {
                string[] AppArr = CurrentDeskApp.Split(',');
                foreach (string App in AppArr)
                {
                    if (App == AppID + "_" + OldAppType)
                    {
                        NewDeskApp = CurrentDeskApp.Replace(App, AppID + "_" + AppType);
                        IsUpdate = true;
                        break;
                    }
                }
            }
            return IsUpdate;
        }
        /// <summary>
        /// 移除应用
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="CurrentDeskApp"></param>
        /// <returns></returns>
        public static string RemoveApp(string AppID, string AppType, string CurrentDeskApp)
        {
            List<string> listApp = CurrentDeskApp.Split(',').ToList();
            foreach (string App in listApp)
            {
                if (App == AppID + "_" + AppType)
                {
                    listApp.Remove(AppID + "_" + AppType);
                    break;
                }
            }
            return ListToString(listApp, ',');
        }
        /// <summary>
        /// 移除应用
        /// </summary>
        /// <param name="Index">应用编号</param>
        /// <param name="CurrentDeskApp"></param>
        /// <returns></returns>
        public static string RemoveApp(int Index, string CurrentDeskApp)
        {
            List<string> listApp = CurrentDeskApp.Split(',').ToList();
            listApp.RemoveAt(Index);
            return ListToString(listApp, ',');
        }
        /// <summary>
        /// 同桌面拖动
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="FromIndex"></param>
        /// <param name="ToIndex"></param>
        /// <param name="CurrentDeskApp"></param>
        /// <returns></returns>
        public static string DragSysApp(string  AppID, string AppType, int FromIndex, int ToIndex, string CurrentDeskApp)
        {
            List<string> listApp = CurrentDeskApp.Split(',').ToList();
            listApp.RemoveAt(FromIndex);
            if (listApp.Count() < ToIndex)
                listApp.Add(AppID + "_" + AppType);
            else
                listApp.Insert(ToIndex, AppID + "_" + AppType);
            return ListToString(listApp, ',');
        }
        /// <summary>
        /// 文件夹与桌面拖动
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="ToIndex"></param>
        /// <param name="CurrentDeskApp"></param>
        /// <returns></returns>
        public static string DragSysApp(string AppID, string AppType, int ToIndex, string CurrentDeskApp)
        {
            List<string> listApp = CurrentDeskApp.Split(',').ToList();
            listApp.Insert(ToIndex, AppID + "_" + AppType);
            return ListToString(listApp, ',');
        }
        /// <summary>
        /// 不同桌面拖动
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="FromIndex"></param>
        /// <param name="ToIndex"></param>
        /// <param name="FromDeskApp"></param>
        /// <param name="ToDeskApp"></param>
        /// <returns></returns>
        public static string[] DragSysApp(string AppID, string AppType, int FromIndex, int ToIndex, string FromDeskApp, string ToDeskApp)
        {
            string[] AppArr = new string[2];
            List<string> listApp = FromDeskApp.Split(',').ToList();
            listApp.RemoveAt(FromIndex);
            AppArr[0] = ListToString(listApp, ',');
            listApp = ToDeskApp.Split(',').ToList();
            if (ToIndex > listApp.Count())
                listApp.Add(AppID + "_" + AppType);
            else
                listApp.Insert(ToIndex, AppID + "_" + AppType);
            AppArr[1] = ListToString(listApp, ',');
            return AppArr;
        }
        /// <summary>
        /// 应用移动
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="FromDeskApp"></param>
        /// <param name="ToDeskApp"></param>
        /// <returns></returns>
        public static string[] MoveSysApp(string  AppID, string AppType, string FromDeskApp, string ToDeskApp)
        {
            string[] AppArr = new string[2];
            AppArr[0] = RemoveApp(AppID, AppType, FromDeskApp);
            AppArr[1] = (ToDeskApp.Length > 0 ? ToDeskApp + "," : "") + AppID + "_" + AppType;
            return AppArr;
        }
        /// <summary>
        /// 文件夹应用移动
        /// </summary>
        /// <param name="AppID">应用编号</param>
        /// <param name="AppType">应用类型</param>
        /// <param name="FromDeskApp"></param>
        /// <param name="ToDeskApp"></param>
        /// <returns></returns>
        public static string MoveSysApp(string AppID, string AppType, string ToDeskApp)
        {
            return (ToDeskApp.Length > 0 ? ToDeskApp + "," : "") + AppID + "_" + AppType;
        }
        /// <summary>
        /// 判断指定桌面中是否包含应用
        /// </summary>
        /// <param name="AppID"></param>
        /// <param name="AppType"></param>
        /// <param name="CurrentDeskApp"></param>
        /// <returns></returns>
        public static bool IsContains(string AppID, string AppType, string CurrentDeskApp)
        {
            bool rs = false;
            if (CurrentDeskApp.Contains(','))
            {
                string[] AppArr = CurrentDeskApp.Split(',');
                foreach (string App in AppArr)
                {
                    if (App == AppID + "_" + AppType)
                    {
                        rs =  true;
                    }
                    else
                    {
                        rs =  false;
                    }
                }
            }
            else
            {
                if (CurrentDeskApp == AppID + "_" + AppType)
                { 
                    rs =  true; 
                }
                else
                { 
                    rs =  false;
                }
            }
            return rs;
        }
        /// <summary>
        /// List数组转换成string
        /// </summary>
        /// <param name="list">List数组</param>
        /// <param name="Separator">分割符</param>
        /// <returns>string</returns>
        public static string ListToString(List<string> list, char Separator)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string item in list)
            {
                if (item.Length == 0) continue;
                builder.AppendFormat("{0},", item);
            }
            return builder.Length > 0 ? builder.Remove(builder.Length - 1, 1).ToString() : "";
        }
    }
}
