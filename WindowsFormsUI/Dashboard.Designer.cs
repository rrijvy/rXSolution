namespace WindowsFormsUI
{
    partial class Dashboard
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
            this.textBoxSubtotal = new System.Windows.Forms.TextBox();
            this.textBoxtotal = new System.Windows.Forms.TextBox();
            this.labelSubTotal = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonMessageBoxDemo = new System.Windows.Forms.Button();
            this.buttonTextBoxDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSubtotal
            // 
            this.textBoxSubtotal.Location = new System.Drawing.Point(189, 45);
            this.textBoxSubtotal.Name = "textBoxSubtotal";
            this.textBoxSubtotal.Size = new System.Drawing.Size(128, 20);
            this.textBoxSubtotal.TabIndex = 0;
            // 
            // textBoxtotal
            // 
            this.textBoxtotal.Location = new System.Drawing.Point(189, 116);
            this.textBoxtotal.Name = "textBoxtotal";
            this.textBoxtotal.Size = new System.Drawing.Size(128, 20);
            this.textBoxtotal.TabIndex = 1;
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(186, 29);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(46, 13);
            this.labelSubTotal.TabIndex = 2;
            this.labelSubTotal.Text = "Subtotal";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(186, 100);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(31, 13);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "Total";
            // 
            // buttonMessageBoxDemo
            // 
            this.buttonMessageBoxDemo.Location = new System.Drawing.Point(28, 174);
            this.buttonMessageBoxDemo.Name = "buttonMessageBoxDemo";
            this.buttonMessageBoxDemo.Size = new System.Drawing.Size(121, 35);
            this.buttonMessageBoxDemo.TabIndex = 4;
            this.buttonMessageBoxDemo.Text = "Message Box Demo";
            this.buttonMessageBoxDemo.UseVisualStyleBackColor = true;
            this.buttonMessageBoxDemo.Click += new System.EventHandler(this.buttonMessageBoxDemo_Click);
            // 
            // buttonTextBoxDemo
            // 
            this.buttonTextBoxDemo.Location = new System.Drawing.Point(189, 173);
            this.buttonTextBoxDemo.Name = "buttonTextBoxDemo";
            this.buttonTextBoxDemo.Size = new System.Drawing.Size(128, 36);
            this.buttonTextBoxDemo.TabIndex = 5;
            this.buttonTextBoxDemo.Text = "Text Box Demo";
            this.buttonTextBoxDemo.UseVisualStyleBackColor = true;
            this.buttonTextBoxDemo.Click += new System.EventHandler(this.buttonTextBoxDemo_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 245);
            this.Controls.Add(this.buttonTextBoxDemo);
            this.Controls.Add(this.buttonMessageBoxDemo);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelSubTotal);
            this.Controls.Add(this.textBoxtotal);
            this.Controls.Add(this.textBoxSubtotal);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubtotal;
        private System.Windows.Forms.TextBox textBoxtotal;
        private System.Windows.Forms.Label labelSubTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonMessageBoxDemo;
        private System.Windows.Forms.Button buttonTextBoxDemo;
    }
}