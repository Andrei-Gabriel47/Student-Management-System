using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.OleDb;

namespace StudManagement
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;

        }
        OleDbConnection conn;
        

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Insert into Students(Firstname,Lastname,Date_of_birth,Gender)  VALUES(@Firstname,@Lastname,@Date_of_birth,@Gender)";
                command.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                command.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                command.Parameters.AddWithValue("@Date_of_birth", dtpBirthdate.Value);
                String gender;
                if (rdbFemale.Checked) gender = "Female";
                else gender = "Male";
                command.Parameters.AddWithValue("@Gender", gender);
                command.Connection = conn;
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student succesfuly added!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstname.Text = "";
            txtLastname.Text = "";
            rdbFemale.Checked=false;
            rdbMale.Checked=false;
        }

     
    }
}
