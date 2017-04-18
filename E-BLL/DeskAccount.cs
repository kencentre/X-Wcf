using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class DeskAccount
    {
        private readonly IDeskAccount dal = DataAccess.CreateDeskAccount();
        public void Add(E_Model.DeskAccount model)
        {
            dal.Add(model);
        }

        public void Delete(string ACCOUNTID)
        {
            dal.Delete(ACCOUNTID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetSearchList(string DESKID, string ACCOUNTID)
        {
            return dal.GetSearchList(DESKID, ACCOUNTID);
        }
    }
}
