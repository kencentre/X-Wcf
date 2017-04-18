using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Code
    {
        private readonly ICode dal = DataAccess.CreateCode();

        public bool Add(E_Model.Code model)
        {
            return dal.Add(model);
        }

        public E_Model.Code GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public string CreateCode(int Number)
        {
            return dal.CreateCode(Number);
        }

        public DataSet GetTopId()
        {
            return dal.GetTopId();
        }
    }
}
