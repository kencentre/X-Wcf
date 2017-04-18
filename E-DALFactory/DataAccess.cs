using System.Reflection;
using System.Configuration;
namespace E_DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject 

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch(System.Exception ex)
                {
                    string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        //#region CreateSysManage
        //public static E_IDAL.ISysManage CreateSysManage()
        //{
        //    //方式1			
        //    //return (E_IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

        //    //方式2 			
        //    string classNamespace = AssemblyPath + ".SysManage";
        //    object objType = CreateObject(AssemblyPath, classNamespace);
        //    return (E_IDAL.ISysManage)objType;
        //}
        //#endregion



        /// <summary>
        /// 创建ROLE数据层接口。
        /// </summary>
        public static E_IDAL.IRole CreateRole()
        {

            string ClassNamespace = AssemblyPath + ".Role";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IRole)objType;
        }


        /// <summary>
        /// 创建NOTICE数据层接口。
        /// </summary>
        public static E_IDAL.INotice CreateNotice()
        {

            string ClassNamespace = AssemblyPath + ".Notice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.INotice)objType;
        }


        /// <summary>
        /// 创建MAIN_ROLE数据层接口。
        /// </summary>
        public static E_IDAL.IMainRole CreateMainRole()
        {

            string ClassNamespace = AssemblyPath + ".MainRole";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IMainRole)objType;
        }


        /// <summary>
        /// 创建MAIN数据层接口。
        /// </summary>
        public static E_IDAL.IMain CreateMain()
        {

            string ClassNamespace = AssemblyPath + ".Main";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IMain)objType;
        }


        /// <summary>
        /// 创建LOGS数据层接口。
        /// </summary>
        public static E_IDAL.ILogs CreateLogs()
        {

            string ClassNamespace = AssemblyPath + ".Logs";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ILogs)objType;
        }


        /// <summary>
        /// 创建DUTY数据层接口。
        /// </summary>
        public static E_IDAL.IDuty CreateDuty()
        {

            string ClassNamespace = AssemblyPath + ".Duty";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IDuty)objType;
        }


        /// <summary>
        /// 创建DICTIONARY数据层接口。
        /// </summary>
        public static E_IDAL.IDictionary CreateDictionary()
        {

            string ClassNamespace = AssemblyPath + ".Dictionary";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IDictionary)objType;
        }


        /// <summary>
        /// 创建DESK_ACCOUNT数据层接口。
        /// </summary>
        public static E_IDAL.IDeskAccount CreateDeskAccount()
        {

            string ClassNamespace = AssemblyPath + ".DeskAccount";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IDeskAccount)objType;
        }


        /// <summary>
        /// 创建DESK数据层接口。
        /// </summary>
        public static E_IDAL.IDesk CreateDesk()
        {

            string ClassNamespace = AssemblyPath + ".Desk";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IDesk)objType;
        }


        /// <summary>
        /// 创建DEPT数据层接口。
        /// </summary>
        public static E_IDAL.IDept CreateDept()
        {

            string ClassNamespace = AssemblyPath + ".Dept";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IDept)objType;
        }



        /// <summary>
        /// 创建CODE数据层接口。
        /// </summary>
        public static E_IDAL.ICode CreateCode()
        {

            string ClassNamespace = AssemblyPath + ".Code";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ICode)objType;
        }


        /// <summary>
        /// 创建ACCOUNT_ROLE数据层接口。
        /// </summary>
        public static E_IDAL.IAccountRole CreateAccountRole()
        {

            string ClassNamespace = AssemblyPath + ".AccountRole";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IAccountRole)objType;
        }


        /// <summary>
        /// 创建ACCOUNT_DUTY数据层接口。
        /// </summary>
        public static E_IDAL.IAccountDuty CreateAccountDuty()
        {

            string ClassNamespace = AssemblyPath + ".AccountDuty";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IAccountDuty)objType;
        }


        /// <summary>
        /// 创建ACCOUNT数据层接口。
        /// </summary>
        public static E_IDAL.IAccount CreateAccount()
        {

            string ClassNamespace = AssemblyPath + ".Account";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IAccount)objType;
        }

        /// <summary>
		/// 创建NEWSCHANNEL数据层接口。
		/// </summary>
		public static E_IDAL.INewsChannel CreateNewsChannel()
        {

            string ClassNamespace = AssemblyPath + ".NewsChannel";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.INewsChannel)objType;
        }

        /// <summary>
		/// 创建SCHOOL数据层接口。
		/// </summary>
		public static E_IDAL.ISchool CreateSchool()
        {

            string ClassNamespace = AssemblyPath + ".School";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ISchool)objType;
        }

        /// <summary>
		/// 创建BRAND数据层接口。
		/// </summary>
		public static E_IDAL.IBrand CreateBrand()
        {

            string ClassNamespace = AssemblyPath + ".Brand";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IBrand)objType;
        }

        /// <summary>
		/// 创建STUDENT数据层接口。
		/// </summary>
		public static E_IDAL.IStudent CreateStudent()
        {

            string ClassNamespace = AssemblyPath + ".Student";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IStudent)objType;
        }

        /// <summary>
		/// 创建STUDENT数据层接口。
		/// </summary>
		public static E_IDAL.IBrandStudent CreateBrandStudent()
        {

            string ClassNamespace = AssemblyPath + ".BrandStudent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IBrandStudent)objType;
        }

        /// <summary>
		/// 创建Class数据层接口。
		/// </summary>
		public static E_IDAL.IClass CreateClass()
        {

            string ClassNamespace = AssemblyPath + ".Class";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IClass)objType;
        }

        /// <summary>
		/// 创建Teacher数据层接口。
		/// </summary>
		public static E_IDAL.ITeacher CreateTeacher()
        {

            string ClassNamespace = AssemblyPath + ".Teacher";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ITeacher)objType;
        }

        /// <summary>
        /// 创建BrandTeacher数据层接口。
        /// </summary>
        public static E_IDAL.IBrandTeacher CreateBrandTeacher()
        {

            string ClassNamespace = AssemblyPath + ".BrandTeacher";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IBrandTeacher)objType;
        }

        /// <summary>
        /// 创建SchoolTeacher数据层接口。
        /// </summary>
        public static E_IDAL.ISchoolTeacher CreateSchoolTeacher()
        {

            string ClassNamespace = AssemblyPath + ".SchoolTeacher";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ISchoolTeacher)objType;
        }

        /// <summary>
        /// 创建Signup数据层接口。
        /// </summary>
        public static E_IDAL.ISignup CreateSignup()
        {

            string ClassNamespace = AssemblyPath + ".Signup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ISignup)objType;
        }



        /// <summary>
        /// 创建SignupBrand数据层接口。
        /// </summary>
        public static E_IDAL.ISignupBrand CreateSignupBrand()
        {

            string ClassNamespace = AssemblyPath + ".SignupBrand";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ISignupBrand)objType;
        }

        /// <summary>
        /// 创建News数据层接口。
        /// </summary>
        public static E_IDAL.INews CreateNews()
        {

            string ClassNamespace = AssemblyPath + ".News";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.INews)objType;
        }

        /// <summary>
        /// 创建Template数据层接口。
        /// </summary>
        public static E_IDAL.ITemplate CreateTemplate()
        {

            string ClassNamespace = AssemblyPath + ".Template";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ITemplate)objType;
        }

        /// <summary>
        /// 创建WebSite数据层接口。
        /// </summary>
        public static E_IDAL.IWebSite CreateWebSite()
        {

            string ClassNamespace = AssemblyPath + ".WebSite";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IWebSite)objType;
        }

        /// <summary>
        /// 创建Brock数据层接口。
        /// </summary>
        public static E_IDAL.IBrock CreateBrock()
        {

            string ClassNamespace = AssemblyPath + ".Brock";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IBrock)objType;
        }

        /// <summary>
        /// 创建Tag数据层接口。
        /// </summary>
        public static E_IDAL.ITag CreateTag()
        {

            string ClassNamespace = AssemblyPath + ".Tag";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ITag)objType;
        }

        /// <summary>
        /// 创建TagProperty数据层接口。
        /// </summary>
        public static E_IDAL.ITagProperty CreateTagProperty()
        {

            string ClassNamespace = AssemblyPath + ".TagProperty";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ITagProperty)objType;
        }

        /// <summary>
        /// 创建Property数据层接口。
        /// </summary>
        public static E_IDAL.IProperty CreateProperty()
        {

            string ClassNamespace = AssemblyPath + ".Property";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IProperty)objType;
        }

        /// <summary>
        /// 创建PropertyValue数据层接口。
        /// </summary>
        public static E_IDAL.IPropertyValue CreateIPropertyValue()
        {

            string ClassNamespace = AssemblyPath + ".PropertyValue";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IPropertyValue)objType;
        }

        /// <summary>
        /// 创建About数据层接口。
        /// </summary>
        public static E_IDAL.IAbout CreateIAbout()
        {

            string ClassNamespace = AssemblyPath + ".About";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IAbout)objType;
        }

        /// <summary>
        /// 创建About数据层接口。
        /// </summary>
        public static E_IDAL.IECode CreateECode()
        {

            string ClassNamespace = AssemblyPath + ".ECode";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.IECode)objType;
        }

        /// <summary>
        /// 创建Link数据层接口。
        /// </summary>
        public static E_IDAL.ILink CreateLink()
        {

            string ClassNamespace = AssemblyPath + ".Link";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (E_IDAL.ILink)objType;
        }
    }
}
