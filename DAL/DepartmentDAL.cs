using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;

namespace DAL
{
    public class DepartmentDAL:DBConnection
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_MSSV", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentBEL> lstDepartment = new List<DepartmentBEL>();
            while(reader.Read())
            {
                DepartmentBEL department = new DepartmentBEL();
                department.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                department.Name = reader["Name"].ToString();
                lstDepartment.Add(department);
            }
            conn.Close();
            return lstDepartment;
        }
        public DepartmentBEL ReadDepartment(int IdDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from Department_MSSV where IdDepartment = " + IdDepartment.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DepartmentBEL department = new DepartmentBEL();
            if(reader.HasRows && reader.Read())
            {
                department.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                department.Name = reader["Name"].ToString();
            }
            conn.Close();
            return department;
        }
    }
}
