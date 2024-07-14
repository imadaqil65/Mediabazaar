namespace MediaBazaar
{
    partial class ShiftControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelDays = new System.Windows.Forms.Label();
            this.BtnViewShift = new System.Windows.Forms.Button();
            this.LBAfternoon = new System.Windows.Forms.Label();
            this.LBEvening = new System.Windows.Forms.Label();
            this.LBMorning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelDays
            // 
            this.LabelDays.AutoSize = true;
            this.LabelDays.Location = new System.Drawing.Point(4, 17);
            this.LabelDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDays.Name = "LabelDays";
            this.LabelDays.Size = new System.Drawing.Size(22, 25);
            this.LabelDays.TabIndex = 0;
            this.LabelDays.Text = "0";
            // 
            // BtnViewShift
            // 
            this.BtnViewShift.Location = new System.Drawing.Point(50, 154);
            this.BtnViewShift.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnViewShift.Name = "BtnViewShift";
            this.BtnViewShift.Size = new System.Drawing.Size(123, 42);
            this.BtnViewShift.TabIndex = 1;
            this.BtnViewShift.Text = "View";
            this.BtnViewShift.UseVisualStyleBackColor = true;
            this.BtnViewShift.Click += new System.EventHandler(this.BtnViewShift_Click);
            // 
            // LBAfternoon
            // 
            this.LBAfternoon.AutoSize = true;
            this.LBAfternoon.Location = new System.Drawing.Point(4, 86);
            this.LBAfternoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBAfternoon.Name = "LBAfternoon";
            this.LBAfternoon.Size = new System.Drawing.Size(176, 25);
            this.LBAfternoon.TabIndex = 0;
            this.LBAfternoon.Text = "Afternoon Shift 0/10";
            // 
            // LBEvening
            // 
            this.LBEvening.AutoSize = true;
            this.LBEvening.Location = new System.Drawing.Point(6, 111);
            this.LBEvening.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBEvening.Name = "LBEvening";
            this.LBEvening.Size = new System.Drawing.Size(157, 25);
            this.LBEvening.TabIndex = 0;
            this.LBEvening.Text = "Evening Shift 0/10";
            // 
            // LBMorning
            // 
            this.LBMorning.AutoSize = true;
            this.LBMorning.Location = new System.Drawing.Point(3, 61);
            this.LBMorning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBMorning.Name = "LBMorning";
            this.LBMorning.Size = new System.Drawing.Size(171, 25);
            this.LBMorning.TabIndex = 2;
            this.LBMorning.Text = "Morning Shifts 0/10";
            // 
            // ShiftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.LBMorning);
            this.Controls.Add(this.BtnViewShift);
            this.Controls.Add(this.LBEvening);
            this.Controls.Add(this.LBAfternoon);
            this.Controls.Add(this.LabelDays);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShiftControl";
            this.Size = new System.Drawing.Size(214, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelDays;
        private Button BtnViewShift;
        private Label LBAfternoon;
        private Label LBEvening;
        private Label LBMorning;
    }
}
