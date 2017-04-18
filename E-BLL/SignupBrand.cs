using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class SignupBrand
    {
        private readonly ISignupBrand dal = DataAccess.CreateSignupBrand();
        public void Add(E_Model.SignupBrand model)
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
