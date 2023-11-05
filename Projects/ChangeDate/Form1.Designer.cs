
namespace ChangeDate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMiDate = new System.Windows.Forms.Label();
            this.lblDayofWeek = new System.Windows.Forms.Label();
            this.lblDayOfYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShDate = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDayOfWeek2 = new System.Windows.Forms.Label();
            this.lblDayOfYear2 = new System.Windows.Forms.Label();
            this.lblDayOfYear3 = new System.Windows.Forms.Label();
            this.lblDayOfYear4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateTimePicker1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(698, 50);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 27);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(930, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "تاریخ شمسی :";
            // 
            // lblMiDate
            // 
            this.lblMiDate.AutoSize = true;
            this.lblMiDate.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMiDate.Location = new System.Drawing.Point(92, 54);
            this.lblMiDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiDate.Name = "lblMiDate";
            this.lblMiDate.Size = new System.Drawing.Size(0, 23);
            this.lblMiDate.TabIndex = 2;
            // 
            // lblDayofWeek
            // 
            this.lblDayofWeek.AutoSize = true;
            this.lblDayofWeek.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDayofWeek.Location = new System.Drawing.Point(304, 54);
            this.lblDayofWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDayofWeek.Name = "lblDayofWeek";
            this.lblDayofWeek.Size = new System.Drawing.Size(0, 23);
            this.lblDayofWeek.TabIndex = 3;
            // 
            // lblDayOfYear
            // 
            this.lblDayOfYear.AutoSize = true;
            this.lblDayOfYear.Location = new System.Drawing.Point(92, 100);
            this.lblDayOfYear.Name = "lblDayOfYear";
            this.lblDayOfYear.Size = new System.Drawing.Size(0, 21);
            this.lblDayOfYear.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(929, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "تاریخ میلادی : ";
            // 
            // lblShDate
            // 
            this.lblShDate.AutoSize = true;
            this.lblShDate.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShDate.Location = new System.Drawing.Point(92, 197);
            this.lblShDate.Name = "lblShDate";
            this.lblShDate.Size = new System.Drawing.Size(0, 23);
            this.lblShDate.TabIndex = 7;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox1.Location = new System.Drawing.Point(698, 193);
            this.maskedTextBox1.Mask = "0000/00/00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBox1.Size = new System.Drawing.Size(197, 29);
            this.maskedTextBox1.TabIndex = 8;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "نمایش تاریخ شمسی";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDayOfWeek2
            // 
            this.lblDayOfWeek2.AutoSize = true;
            this.lblDayOfWeek2.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDayOfWeek2.Location = new System.Drawing.Point(304, 196);
            this.lblDayOfWeek2.Name = "lblDayOfWeek2";
            this.lblDayOfWeek2.Size = new System.Drawing.Size(0, 23);
            this.lblDayOfWeek2.TabIndex = 10;
            // 
            // lblDayOfYear2
            // 
            this.lblDayOfYear2.AutoSize = true;
            this.lblDayOfYear2.Location = new System.Drawing.Point(171, 241);
            this.lblDayOfYear2.Name = "lblDayOfYear2";
            this.lblDayOfYear2.Size = new System.Drawing.Size(0, 21);
            this.lblDayOfYear2.TabIndex = 11;
            // 
            // lblDayOfYear3
            // 
            this.lblDayOfYear3.AutoSize = true;
            this.lblDayOfYear3.ForeColor = System.Drawing.Color.Blue;
            this.lblDayOfYear3.Location = new System.Drawing.Point(698, 100);
            this.lblDayOfYear3.Name = "lblDayOfYear3";
            this.lblDayOfYear3.Size = new System.Drawing.Size(0, 21);
            this.lblDayOfYear3.TabIndex = 12;
            // 
            // lblDayOfYear4
            // 
            this.lblDayOfYear4.AutoSize = true;
            this.lblDayOfYear4.ForeColor = System.Drawing.Color.Blue;
            this.lblDayOfYear4.Location = new System.Drawing.Point(698, 241);
            this.lblDayOfYear4.Name = "lblDayOfYear4";
            this.lblDayOfYear4.Size = new System.Drawing.Size(0, 21);
            this.lblDayOfYear4.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 298);
            this.Controls.Add(this.lblDayOfYear4);
            this.Controls.Add(this.lblDayOfYear3);
            this.Controls.Add(this.lblDayOfYear2);
            this.Controls.Add(this.lblDayOfWeek2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.lblShDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDayOfYear);
            this.Controls.Add(this.lblDayofWeek);
            this.Controls.Add(this.lblMiDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مبدل تاریخ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMiDate;
        private System.Windows.Forms.Label lblDayofWeek;
        private System.Windows.Forms.Label lblDayOfYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDayOfWeek2;
        private System.Windows.Forms.Label lblDayOfYear2;
        private System.Windows.Forms.Label lblDayOfYear3;
        private System.Windows.Forms.Label lblDayOfYear4;
    }
}

