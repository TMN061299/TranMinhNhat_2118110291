using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEL;

namespace BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
