using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudManagement
{
    public partial class ExamForm : Form
    {
        public ExamForm()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;
        OleDbDataReader reader;
        DataTable dataTableGeneral;
        private void ExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn; ;
                command.CommandText = "SELECT Id from Courses";
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                for(int i=0;i<dataTable.Rows.Count;i++)
                {
                    cmbExams.Items.Add(dataTable.Rows[i][0].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare " + ex);
            }
        }

        private void cmbExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Students inner join StudentsCourses on Students.Id=StudentsCourses.StudentId Where CourseId=@CourseId order by Lastname";
                cmd.Parameters.AddWithValue("@CourseId",cmbExams.SelectedItem.ToString());
                reader = cmd.ExecuteReader();
                dataTableGeneral = new DataTable();
                dataTableGeneral.Load(reader);
                dgvPatricipants.DataSource = dataTableGeneral;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void btnPragramExam_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandText = "Select * from Classes inner join Courses on Classes.Id=Courses.ClassId Where Courses.ID=@CourseId";
                command.Parameters.AddWithValue("@CourseId", cmbExams.SelectedItem.ToString());
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                //dgvPatricipants.DataSource= dataTable;
                conn.Close();
                int seatsN = int.Parse( dataTable.Rows[0][2].ToString());
                int rowN = int.Parse(dataTable.Rows[0][3].ToString());
                int studPerRow = seatsN / 2 / rowN;
                int studSeated = 0;
                dataTableGeneral.Columns.Add("ParteAmfiteatru", typeof(String));
                dataTableGeneral.Columns.Add("Rand",typeof(int));
                dataTableGeneral.Columns.Add("Loc",typeof (int));
                String parte = "Stanga";
                int j;
                while (studSeated < dataTableGeneral.Rows.Count - 1) 
                {
                    for(int i=0;i< rowN && studSeated < dataTableGeneral.Rows.Count; i++)
                    {
                        
                        for( j=0;j< studPerRow && studSeated < dataTableGeneral.Rows.Count; j++)
                        {
                            dataTableGeneral.Rows[studSeated]["ParteAmfiteatru"] = parte;
                            dataTableGeneral.Rows[studSeated]["Rand"] = (i + 1);
                            dataTableGeneral.Rows[studSeated]["Loc"] = (j + 1);
                            studSeated++;
                        }
                        if (parte == "Stanga") 
                        {
                            parte = "Dreapta";
                            j--;
                            i--;
                        }
                        else 
                        {
                            parte = "Stanga";
                        }
                    }
                }
                String[] colDorite = { "Id", "Firstname", "Lastname", "ParteAmfiteatru", "Rand", "Loc" };
                foreach (DataColumn column in dataTableGeneral.Columns.Cast<DataColumn>().ToArray())
                {
                    if (!colDorite.Contains(column.ColumnName))
                    {
                        dataTableGeneral.Columns.Remove(column.ColumnName);
                    }
                }
                dgvPatricipants.DataSource = dataTableGeneral;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(" " + ex);
            }
        }
        DGVPrinter printer;
        private void btnExamPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //DVGPrinter class took from web
                printer = new DGVPrinter();
                printer.Title = "A-Academy Students Repartization list";
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
                Console.WriteLine($"DataGridView rows count: {dgvPatricipants.Rows.Count}");
                Console.WriteLine($"DataGridView columns count: {dgvPatricipants.Columns.Count}");
                printer.PrintDataGridView(dgvPatricipants);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }
    }
}
