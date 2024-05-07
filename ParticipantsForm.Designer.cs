namespace StudManagement
{
    partial class ParticipantsForm
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
            this.dgvStudentsList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCoursesList = new System.Windows.Forms.DataGridView();
            this.btnAddParticipant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoursesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentsList
            // 
            this.dgvStudentsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(201)))), ((int)(((byte)(239)))));
            this.dgvStudentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsList.Location = new System.Drawing.Point(3, 64);
            this.dgvStudentsList.Name = "dgvStudentsList";
            this.dgvStudentsList.RowHeadersWidth = 51;
            this.dgvStudentsList.RowTemplate.Height = 24;
            this.dgvStudentsList.Size = new System.Drawing.Size(440, 327);
            this.dgvStudentsList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Students List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(563, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Courses List";
            // 
            // dgvCoursesList
            // 
            this.dgvCoursesList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(201)))), ((int)(((byte)(239)))));
            this.dgvCoursesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoursesList.Location = new System.Drawing.Point(449, 64);
            this.dgvCoursesList.Name = "dgvCoursesList";
            this.dgvCoursesList.RowHeadersWidth = 51;
            this.dgvCoursesList.RowTemplate.Height = 24;
            this.dgvCoursesList.Size = new System.Drawing.Size(351, 327);
            this.dgvCoursesList.TabIndex = 4;
            // 
            // btnAddParticipant
            // 
            this.btnAddParticipant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(174)))), ((int)(((byte)(224)))));
            this.btnAddParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParticipant.Location = new System.Drawing.Point(479, 397);
            this.btnAddParticipant.Name = "btnAddParticipant";
            this.btnAddParticipant.Size = new System.Drawing.Size(238, 56);
            this.btnAddParticipant.TabIndex = 6;
            this.btnAddParticipant.Text = "Add Participant";
            this.btnAddParticipant.UseVisualStyleBackColor = false;
            this.btnAddParticipant.Click += new System.EventHandler(this.btnAddParticipant_Click);
            // 
            // ParticipantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(812, 453);
            this.Controls.Add(this.btnAddParticipant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCoursesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStudentsList);
            this.Name = "ParticipantsForm";
            this.Text = "ParticipantsForm";
            this.Load += new System.EventHandler(this.ParticipantsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoursesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCoursesList;
        private System.Windows.Forms.Button btnAddParticipant;
    }
}