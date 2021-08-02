
namespace Task2
{
    partial class Form1
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
            this.tbLink = new System.Windows.Forms.TextBox();
            this.nud1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLink
            // 
            this.tbLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLink.Location = new System.Drawing.Point(308, 26);
            this.tbLink.Name = "tbLink";
            this.tbLink.ReadOnly = true;
            this.tbLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbLink.Size = new System.Drawing.Size(120, 38);
            this.tbLink.TabIndex = 0;
            // 
            // nud1
            // 
            this.nud1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud1.Location = new System.Drawing.Point(31, 26);
            this.nud1.Name = "nud1";
            this.nud1.Size = new System.Drawing.Size(120, 38);
            this.nud1.TabIndex = 1;
            this.nud1.ValueChanged += new System.EventHandler(this.nud1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 100);
            this.Controls.Add(this.nud1);
            this.Controls.Add(this.tbLink);
            this.Name = "Form1";
            this.Text = "Link";
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.NumericUpDown nud1;
    }
}

