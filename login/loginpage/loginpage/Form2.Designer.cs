namespace loginpage
{
    partial class Form2
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
            this.Success = new System.Windows.Forms.Label();
            this.Logoff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Success
            // 
            this.Success.AutoSize = true;
            this.Success.Location = new System.Drawing.Point(86, 85);
            this.Success.Name = "Success";
            this.Success.Size = new System.Drawing.Size(88, 13);
            this.Success.TabIndex = 0;
            this.Success.Text = "Login Successful";
            // 
            // Logoff
            // 
            this.Logoff.Location = new System.Drawing.Point(89, 173);
            this.Logoff.Name = "Logoff";
            this.Logoff.Size = new System.Drawing.Size(75, 23);
            this.Logoff.TabIndex = 1;
            this.Logoff.Text = "Log Off";
            this.Logoff.UseVisualStyleBackColor = true;
            this.Logoff.Click += new System.EventHandler(this.logoff);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Logoff);
            this.Controls.Add(this.Success);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Success;
        private System.Windows.Forms.Button Logoff;
    }
}