using DGVPrinterHelper;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideSubmenus();
            //modify the directory of the cocnnectionString Data Source. Click on Resources -> dataBase and in properties it will show you the oath. Modify it in all Forms to fully work
            conn = new OleDbConnection();
            String conectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Andre\\source\\repos\\StudManagement\\StudManagement\\Resources\\StudentManagement.accdb;Persist Security Info=False;";
            conn.ConnectionString = conectionString;
        }
        OleDbConnection conn;
        OleDbDataReader reader;
        DGVPrinter printer;
        private void hideSubmenus()
        {
            pnlStudent.Visible = false;
            pnlCourses.Visible = false;
            pnlScore.Visible = false;
        }

  
        private void btnStudent_Click(object sender, EventArgs e)
        {
            if (pnlStudent.Visible == true)  pnlStudent.Visible = false;           
            else  pnlStudent.Visible = true;
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            if(pnlCourses.Visible == true)  pnlCourses.Visible=false;
            else    pnlCourses.Visible = true;
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            if(pnlScore.Visible==true) pnlScore.Visible=false;
            else pnlScore.Visible = true;
        }
        Form activeForm = null;
        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            addChildForm(new RegisterForm());
            hideSubmenus();
        }
        private void addChildForm(Form childForm) 
        {
            if (activeForm != null) activeForm = null;
            activeForm = childForm;
           childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
           childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnStudentManage_Click(object sender, EventArgs e)
        {
            addChildForm(new ManageStudentsForm());
            hideSubmenus();
        }

        private void btnCourssAdd_Click(object sender, EventArgs e)
        {
            addChildForm(new CourseRegister());
            hideSubmenus();
        }

        private void btnCoursesManage_Click(object sender, EventArgs e)
        {
            addChildForm(new ManageCourses());
            hideSubmenus();
        }

        private void btnaddStuCourses_Click(object sender, EventArgs e)
        {
            addChildForm(new ParticipantsForm());
            hideSubmenus();
        }

        private void btnProgramExam_Click(object sender, EventArgs e)
        {
            addChildForm(new ExamForm());
            hideSubmenus();
        }
    }
}

