using System;
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
    public partial class ParticipantsForm : Form
    {
        public ParticipantsForm()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;
        OleDbDataReader reader;
        private void ParticipantsForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn; ;
                command.CommandText = "SELECT Id,Firstname,Lastname from Students";
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvStudentsList.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn; ;
                command.CommandText = "SELECT Id,Name from Courses";
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvCoursesList.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandText = "Insert INTO StudentsCourses Values(@StudenId,@CourseId)";
                command.Parameters.AddWithValue("@StudentId", dgvStudentsList.SelectedRows[0].Cells["Id"].Value);
                command.Parameters.AddWithValue("@CourseId", dgvCoursesList.SelectedRows[0].Cells["Id"].Value);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Participant added!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
    }
}
