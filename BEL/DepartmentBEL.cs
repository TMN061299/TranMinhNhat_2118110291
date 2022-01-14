using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class DepartmentBEL
    {
        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public List<EmployeBEL> Employes { get; set; }
    }
}
