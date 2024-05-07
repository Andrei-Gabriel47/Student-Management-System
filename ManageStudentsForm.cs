using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using DGVPrinterHelper;

namespace StudManagement
{
    public partial class ManageStudentsForm : Form
    {
        public ManageStudentsForm()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;
        OleDbDataReader reader;

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            
            try 
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn; ;
                command.CommandText = "SELECT * from Students";
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvStudents.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
            finally { conn.Close(); }
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                try
                {
                    conn.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conn;
                    command.CommandText = "Select * from Students WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", dgvStudents.SelectedRows[0].Cells["Id"].Value);
                    reader = command.ExecuteReader();
                    DataTable dataTable2 = new DataTable();
                    dataTable2.Load(reader);
                    txtStudentId.Text = dataTable2.Rows[0]["Id"].ToString();
                    txtFirstname.Text = dataTable2.Rows[0]["Firstname"].ToString();
                    txtLastname.Text = dataTable2.Rows[0]["Lastname"].ToString();
                    dtpBirthdate.Value = DateTime.Parse(dataTable2.Rows[0]["Date_of_birth"].ToString());
                    String gender = dataTable2.Rows[0]["Gender"].ToString();
                    if (gender == "Male")
                    {
                        rdbMale.Checked = true;
                        rdbFemale.Checked = false;
                    }
                    else
                    {
                        rdbMale.Checked = false;
                        rdbFemale.Checked = true;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" " + ex);
                    Console.WriteLine(" " + ex);
                }
                finally 
                {
                    conn.Close(); 
                }
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {              
                OleDbCommand com = new OleDbCommand();
                conn.Open();
                com.Connection = conn;
                com.CommandText = "Update Students set Firstname=@Firstname, Lastname=@Lastname, Date_of_birth=@Date_of_birth, Gender=@Gender Where ID=@Id";
               // com.Parameters.AddWithValue("@Id",txtStudentId.Text);
                com.Parameters.AddWithValue("@Firstname",txtFirstname.Text);
                com.Parameters.AddWithValue("@Lastname",txtLastname.Text);
                com.Parameters.AddWithValue("@Date_of_birth",dtpBirthdate.Value);
                String gender;
                if (rdbFemale.Checked) gender = "Female";
                else gender = "Male";
                com.Parameters.AddWithValue("@Gender", gender);
                com.Parameters.AddWithValue("@Id", txtStudentId.Text);
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student updated!");
                ManageStudentsForm_Load(sender, e);

            }
            catch(Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try 
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                command.CommandText = "Delete * from Students Where ID=@Id";
                command.Parameters.AddWithValue("@Id", dgvStudents.SelectedRows[0].Cells["Id"].Value);
                command.ExecuteNonQuery();
                conn.Close();
                ManageStudentsForm_Load( sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
        DGVPrinter printer;
        private void btnStudentPrint_Click(object sender, EventArgs e)
        {
            try
            {
               //DVGPrinter class took from web
                printer = new DGVPrinter();
                printer.Title = "A-Academy Students list";
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Work in progress...";
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = true;
                // Adăugăm datele din DataGridView în documentul PDF
                Console.WriteLine($"DataGridView rows count: {dgvStudents.Rows.Count}");
                Console.WriteLine($"DataGridView columns count: {dgvStudents.Columns.Count}");
                printer.PrintDataGridView(dgvStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }
    }
}
