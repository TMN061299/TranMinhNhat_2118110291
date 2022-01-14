using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class EmployeBEL
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Gender { get; set; }
        public string PlaceBirth { get; set; }
        public DepartmentBEL Department { get; set; }
        public string DepartmentName
        {
            get
            {
                return Department.Name;
            }
         }
    }
}
