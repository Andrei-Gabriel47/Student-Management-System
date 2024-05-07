using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudManagement
{
    public partial class CourseRegister : Form
    {
        public CourseRegister()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtClassId.Text = "";
            txtCourseId.Text = "";
            txtCourseName.Text = "";
            txtTeacherName.Text = "";
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Insert Into Courses VALUES(@Id,@Coursename,@ClassId,@TeacherName)";
                cmd.Parameters.AddWithValue("@Id", txtCourseId.Text);
                cmd.Parameters.AddWithValue("@Coursename", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@ClassId", txtClassId.Text);
                cmd.Parameters.AddWithValue("@TeacherName", txtTeacherName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("New course added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
    }
}
