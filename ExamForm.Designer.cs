namespace StudManagement
{
    partial class ExamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbExams = new System.Windows.Forms.ComboBox();
            this.dgvPatricipants = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPragramExam = new System.Windows.Forms.Button();
            this.btnExamPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatricipants)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbExams
            // 
            this.cmbExams.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(24, 71);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(159, 37);
            this.cmbExams.TabIndex = 0;
            this.cmbExams.SelectedIndexChanged += new System.EventHandler(this.cmbExams_SelectedIndexChanged);
            // 
            // dgvPatricipants
            // 
            this.dgvPatricipants.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(201)))), ((int)(((byte)(239)))));
            this.dgvPatricipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatricipants.Location = new System.Drawing.Point(211, 71);
            this.dgvPatricipants.Name = "dgvPatricipants";
            this.dgvPatricipants.RowHeadersWidth = 51;
            this.dgvPatricipants.RowTemplate.Height = 24;
            this.dgvPatricipants.Size = new System.Drawing.Size(566, 361);
            this.dgvPatricipants.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(401, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Students List";
            // 
            // btnPragramExam
            // 
            this.btnPragramExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(174)))), ((int)(((byte)(224)))));
            this.btnPragramExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPragramExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPragramExam.Location = new System.Drawing.Point(20, 198);
            this.btnPragramExam.Name = "btnPragramExam";
            this.btnPragramExam.Size = new System.Drawing.Size(163, 74);
            this.btnPragramExam.TabIndex = 6;
            this.btnPragramExam.Text = "Program Exam";
            this.btnPragramExam.UseVisualStyleBackColor = false;
            this.btnPragramExam.Click += new System.EventHandler(this.btnPragramExam_Click);
            // 
            // btnExamPrint
            // 
            this.btnExamPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(174)))), ((int)(((byte)(224)))));
            this.btnExamPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExamPrint.Location = new System.Drawing.Point(20, 321);
            this.btnExamPrint.Name = "btnExamPrint";
            this.btnExamPrint.Size = new System.Drawing.Size(163, 84);
            this.btnExamPrint.TabIndex = 15;
            this.btnExamPrint.Text = "Print Exam";
            this.btnExamPrint.UseVisualStyleBackColor = false;
            this.btnExamPrint.Click += new System.EventHandler(this.btnExamPrint_Click);
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(812, 453);
            this.Controls.Add(this.btnExamPrint);
            this.Controls.Add(this.btnPragramExam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvPatricipants);
            this.Controls.Add(this.cmbExams);
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            this.Load += new System.EventHandler(this.ExamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatricipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.DataGridView dgvPatricipants;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPragramExam;
        private System.Windows.Forms.Button btnExamPrint;
    }
}