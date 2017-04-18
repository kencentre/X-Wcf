using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Main
    {
        private readonly IMain dal = DataAccess.CreateMain();

        public bool Add(E_Model.Main model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Main model)
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


        public E_Model.Main GetModel(string ID)
        {
            return dal.GetModel(ID);
        }


        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        public E_Model.Main ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }
    }
}
