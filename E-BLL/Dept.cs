using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Dept
    {
        private readonly IDept dal = DataAccess.CreateDept();

        public bool Add(E_Model.Dept model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Dept model)
        {
            return dal.Update(model);
        }

        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        public E_Model.Dept GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public E_Model.Dept ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }

        public DataSet GetAccountListByDeptID(string ID)
        {
            return dal.GetAccountListByDeptID(ID);
        }
    }
}
