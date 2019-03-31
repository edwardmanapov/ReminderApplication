using System.Windows.Forms;

namespace Calendar
{
    partial class RecurringAppointmentFrontEnd
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
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.repeaterLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.startTimeComboBox = new System.Windows.Forms.ComboBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.lengthComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.frequencyComboBox = new System.Windows.Forms.ComboBox();
            this.occurenceTextBox = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SuspendLayout();
            // 
            // subjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(34, 65);
            this.SubjectLabel.Name = "subjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(49, 13);
            this.SubjectLabel.TabIndex = 0;
            this.SubjectLabel.Text = "Subject :";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(34, 96);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(54, 13);
            this.locationLabel.TabIndex = 1;
            this.locationLabel.Text = "Location :";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(140, 26);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 13);
            this.dateLabel.TabIndex = 2;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(34, 159);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(46, 13);
            this.lengthLabel.TabIndex = 3;
            this.lengthLabel.Text = "Length :";
            // 
            // repeaterLabel
            // 
            this.repeaterLabel.AutoSize = true;
            this.repeaterLabel.Location = new System.Drawing.Point(34, 223);
            this.repeaterLabel.Name = "repeaterLabel";
            this.repeaterLabel.Size = new System.Drawing.Size(90, 13);
            this.repeaterLabel.TabIndex = 4;
            this.repeaterLabel.Text = "How many times :";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(114, 62);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(197, 20);
            this.subjectTextBox.TabIndex = 5;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(114, 93);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(197, 20);
            this.locationTextBox.TabIndex = 6;
            // 
            // startTimeComboBox
            // 
            this.startTimeComboBox.FormattingEnabled = true;
            this.startTimeComboBox.Location = new System.Drawing.Point(114, 124);
            this.startTimeComboBox.Name = "startTimeComboBox";
            this.startTimeComboBox.Size = new System.Drawing.Size(197, 21);
            this.startTimeComboBox.TabIndex = 7;
            this.startTimeComboBox.SelectedIndexChanged += new System.EventHandler(this.startTimeComboBox_SelectedIndexChanged);
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(34, 191);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(63, 13);
            this.frequencyLabel.TabIndex = 8;
            this.frequencyLabel.Text = "Frequency :";
            // 
            // lengthComboBox
            // 
            this.lengthComboBox.FormattingEnabled = true;
            this.lengthComboBox.Location = new System.Drawing.Point(114, 156);
            this.lengthComboBox.Name = "lengthComboBox";
            this.lengthComboBox.Size = new System.Drawing.Size(197, 21);
            this.lengthComboBox.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(80, 296);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(191, 296);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // frequencyComboBox
            // 
            this.frequencyComboBox.FormattingEnabled = true;
            this.frequencyComboBox.Location = new System.Drawing.Point(114, 188);
            this.frequencyComboBox.Name = "frequencyComboBox";
            this.frequencyComboBox.Size = new System.Drawing.Size(197, 21);
            this.frequencyComboBox.TabIndex = 12;
            // 
            // occurenceTextBox
            // 
            this.occurenceTextBox.Location = new System.Drawing.Point(130, 220);
            this.occurenceTextBox.Name = "occurenceTextBox";
            this.occurenceTextBox.Size = new System.Drawing.Size(180, 20);
            this.occurenceTextBox.TabIndex = 13;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(34, 127);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(61, 13);
            this.startTimeLabel.TabIndex = 14;
            this.startTimeLabel.Text = "Start Time :";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            GetShapes().AddRange(new Microsoft.VisualBasic.PowerPacks.LineShape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(348, 341);
            this.shapeContainer1.TabIndex = 15;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 39;
            this.lineShape1.X2 = 310;
            this.lineShape1.Y1 = 283;
            this.lineShape1.Y2 = 283;
            // 
            // RecurringAppointmentFrontEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 341);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.occurenceTextBox);
            this.Controls.Add(this.frequencyComboBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.lengthComboBox);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.startTimeComboBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.repeaterLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "RecurringAppointmentFrontEnd";
            this.Text = "Recurring Appointment";
            this.Load += new System.EventHandler(this.RecurringAppointmentFrontEnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private object GetShapes()
        {
            return this.shapeContainer1.Shapes;
        }

        #endregion

        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label repeaterLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.ComboBox startTimeComboBox;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.ComboBox lengthComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox frequencyComboBox;
        private System.Windows.Forms.TextBox occurenceTextBox;
        private System.Windows.Forms.Label startTimeLabel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;

        public System.EventHandler locationTextBox_TextChanged { get; set; }
        public Label SubjectLabel { get => subjectLabel; set => subjectLabel = value; }
    }
}