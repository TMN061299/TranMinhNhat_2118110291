using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;

namespace DAL
{
    public class EmployeDAL:DBConnection
    {
        public List<EmployeBEL> ReadEmploye()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employe_MSSV", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeBEL> lstEmploye = new List<EmployeBEL>();
            DepartmentDAL department = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeBEL employe = new EmployeBEL();
                employe.IdEmployee = int.Parse(reader["IdEmployee"].ToString());
                employe.Name = reader["Name"].ToString();
                employe.DateBirth = (DateTime)reader["DateBirth"];
                employe.Gender = bool.Parse(reader["Gender"].ToString());
                employe.PlaceBirth = reader["PlaceBirth"].ToString();
                employe.Department = department.ReadDepartment(int.Parse(reader["IdDepartment"].ToString()));
                lstEmploye.Add(employe);
            }
            conn.Close();
            return lstEmploye;
        }
        public void EditEmploye(EmployeBEL employe)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("update Employe_MSSV set Name = @Name, DateBirth = @DateBirth, Gender = @Gender, PlaceBirth = @PlaceBirth, IdDepartment = @IdDepartment where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", employe.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", employe.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", employe.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", employe.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", employe.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", employe.Department.IdDepartment));
            //cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteEmploye(EmployeBEL employe)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("delete from Employe_MSSV where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", employe.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewEmploye(EmployeBEL employe)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into Employe_MSSV values(@IdEmployee, @Name, @DateBirth, @Gender, @PlaceBirth, @IdDepartment)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", employe.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", employe.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", employe.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", employe.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", employe.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", employe.Department.IdDepartment));
            //cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
