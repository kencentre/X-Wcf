using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class BrandStudent
    {
        private readonly IBrandStudent dal = DataAccess.CreateBrandStudent();
        public void Add(E_Model.BrandStudent model)
        {
            dal.Add(model);
        }

        public void Delete(string ID)
        {
            dal.Delete(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
