namespace MediaBazaar
{
    partial class DeleteConfirmation
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
            this.RTxtBxTerminationReason = new System.Windows.Forms.RichTextBox();
            this.Terminate = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTxtBxTerminationReason
            // 
            this.RTxtBxTerminationReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTxtBxTerminationReason.Location = new System.Drawing.Point(12, 47);
            this.RTxtBxTerminationReason.Name = "RTxtBxTerminationReason";
            this.RTxtBxTerminationReason.Size = new System.Drawing.Size(711, 235);
            this.RTxtBxTerminationReason.TabIndex = 0;
            this.RTxtBxTerminationReason.Text = "";
            // 
            // Terminate
            // 
            this.Terminate.Location = new System.Drawing.Point(12, 288);
            this.Terminate.Name = "Terminate";
            this.Terminate.Size = new System.Drawing.Size(206, 34);
            this.Terminate.TabIndex = 1;
            this.Terminate.Text = "Terminate Employee";
            this.Terminate.UseVisualStyleBackColor = true;
            this.Terminate.Click += new System.EventHandler(this.Terminate_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(517, 288);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(206, 34);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Specify Termination reason:";
            // 
            // DeleteConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Terminate);
            this.Controls.Add(this.RTxtBxTerminationReason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteConfirmation";
            this.Text = "Terminate employee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteConfirmation_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox RTxtBxTerminationReason;
        private Button Terminate;
        private Button Cancel;
        private Label label1;
    }
}