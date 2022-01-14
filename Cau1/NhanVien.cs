using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace Cau1
{
    public partial class NhanVien : Form
    {
        EmployeBAL employeBAL = new EmployeBAL();
        DepartmentBAL departmentBAL = new DepartmentBAL();

        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            List<EmployeBEL> lstEmploye = employeBAL.ReadEmploye();
            foreach(EmployeBEL employe in lstEmploye)
            {
                dataGridView1.Rows.Add(employe.IdEmployee, employe.Name, employe.DateBirth, employe.Gender, employe.PlaceBirth, employe.DepartmentName);
            }
            List<DepartmentBEL> lstDepartment = departmentBAL.ReadDepartmentList();
            foreach(DepartmentBEL department in lstDepartment)
            {
                comboBox1.Items.Add(department);
            }
            comboBox1.DisplayMember = "Name";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];
            if(row.Cells[0].Value != null)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                checkBox1.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                comboBox1.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeBEL employe = new EmployeBEL();
            employe.IdEmployee = int.Parse(textBox1.Text);
            employe.Name = textBox2.Text;
            employe.DateBirth = DateTime.Parse(dateTimePicker1.Text);
            employe.Gender = checkBox1.Checked;
            employe.PlaceBirth = textBox4.Text;
            employe.Department = (DepartmentBEL)comboBox1.SelectedItem;
            employeBAL.NewEmploye(employe);

            dataGridView1.Rows.Add(employe.IdEmployee, employe.Name, employe.DateBirth, employe.Gender, employe.PlaceBirth, employe.Department.Name);

            MessageBox.Show("Đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if(row != null)
            {
                EmployeBEL employe = new EmployeBEL();
                employe.IdEmployee = int.Parse(textBox1.Text);
                employe.Name = textBox2.Text;
                employe.DateBirth = DateTime.Parse(dateTimePicker1.Text);
                employe.Gender = checkBox1.Checked; 
                employe.PlaceBirth = textBox4.Text;
                employe.Department = (DepartmentBEL)comboBox1.SelectedItem;
                employeBAL.EditEmploye(employe);

                row.Cells[0].Value = employe.IdEmployee;
                row.Cells[1].Value = employe.Name;
                row.Cells[2].Value = employe.DateBirth; 
                row.Cells[3].Value = employe.Gender;
                row.Cells[4].Value = employe.PlaceBirth;
                row.Cells[5].Value = employe.Department.Name;

                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EmployeBEL employe = new EmployeBEL();
                employe.IdEmployee = int.Parse(textBox1.Text);
                employe.Name = textBox2.Text;
                employe.DateBirth = DateTime.Parse(dateTimePicker1.Text);
                employe.Gender = checkBox1.Checked;               
                employe.PlaceBirth = textBox4.Text;
                employe.Department = (DepartmentBEL)comboBox1.SelectedItem;
                employeBAL.DeleteEmploye(employe);

                int idx = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(idx);

                MessageBox.Show("Đã xóa thành công !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn có muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    
                }
            }
        }
    }
}
