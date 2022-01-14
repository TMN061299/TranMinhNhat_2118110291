using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEL;

namespace BAL
{
    public class EmployeBAL
    {
        EmployeDAL dal = new EmployeDAL();
        public List<EmployeBEL> ReadEmploye()
        {
            List<EmployeBEL> lstEmploye = dal.ReadEmploye();
            return lstEmploye;
        }
        public void NewEmploye(EmployeBEL employe)
        {
            dal.NewEmploye(employe);
        }
        public void DeleteEmploye(EmployeBEL employe)
        {
            dal.DeleteEmploye(employe);
        }
        public void EditEmploye(EmployeBEL employe)
        {
            dal.EditEmploye(employe);
        }
    }
}
