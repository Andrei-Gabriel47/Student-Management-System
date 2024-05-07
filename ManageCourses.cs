using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudManagement
{
    public partial class ManageCourses : Form
    {
        public ManageCourses()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;
        OleDbDataReader reader;
        private void ManageCourses_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn; ;
                command.CommandText = "SELECT * from Courses";
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvCourses.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
        }
        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                try
                {
                    conn.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conn;
                    command.CommandText = "Select * from Courses WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", dgvCourses.SelectedRows[0].Cells["Id"].Value);
                    reader = command.ExecuteReader();
                    DataTable dataTable2 = new DataTable();
                    dataTable2.Load(reader);
                    txtCourseId.Text = dataTable2.Rows[0]["Id"].ToString();
                    txtCourseName.Text = dataTable2.Rows[0]["Name"].ToString();
                    txtClassId.Text = dataTable2.Rows[0]["ClassId"].ToString();
                    txtTeacherName.Text = dataTable2.Rows[0]["Teacher"].ToString();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }
            }
                }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                command.CommandText = "Delete * from Courses Where ID=@Id";
                command.Parameters.AddWithValue("@Id", dgvCourses.SelectedRows[0].Cells["Id"].Value);
                command.ExecuteNonQuery();
                conn.Close();
                ManageCourses_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand com = new OleDbCommand();
                conn.Open();
                com.Connection = conn;
                com.CommandText = "Update Courses set Name=@Name, ClassId=@ClassId, Teacher=@Teacher Where ID=@Id";
                com.Parameters.AddWithValue("@Name", txtCourseName.Text);
                com.Parameters.AddWithValue("@ClassId", txtClassId.Text);
                com.Parameters.AddWithValue("@Teacher", txtTeacherName.Text);            
                com.Parameters.AddWithValue("@Id", txtCourseId.Text);
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Course updated!");
                ManageCourses_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
        DGVPrinter printer;
        private void btnCoursesPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //DVGPrinter class took from web
                printer = new DGVPrinter();
                printer.Title = "A-Academy Courses list";
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
                Console.WriteLine($"DataGridView rows count: {dgvCourses.Rows.Count}");
                Console.WriteLine($"DataGridView columns count: {dgvCourses.Columns.Count}");
                printer.PrintDataGridView(dgvCourses);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }
    }
}
