
namespace WF_Udvoitel
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCommandsCount = new System.Windows.Forms.Label();
            this.lblCCText = new System.Windows.Forms.Label();
            this.lblNText = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblGoalText = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommand1.Location = new System.Drawing.Point(223, 13);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(116, 35);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "btnCommand1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommand2.Location = new System.Drawing.Point(223, 54);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(116, 35);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "btnCommand2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Location = new System.Drawing.Point(223, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 35);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(66, 29);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(98, 24);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "lblNumber";
            // 
            // lblCommandsCount
            // 
            this.lblCommandsCount.AutoSize = true;
            this.lblCommandsCount.Location = new System.Drawing.Point(119, 117);
            this.lblCommandsCount.Name = "lblCommandsCount";
            this.lblCommandsCount.Size = new System.Drawing.Size(97, 13);
            this.lblCommandsCount.TabIndex = 4;
            this.lblCommandsCount.Text = "lblCommandsCount";
            this.lblCommandsCount.TextChanged += new System.EventHandler(this.lblCommandsCount_TextChanged);
            // 
            // lblCCText
            // 
            this.lblCCText.AutoSize = true;
            this.lblCCText.Location = new System.Drawing.Point(12, 117);
            this.lblCCText.Name = "lblCCText";
            this.lblCCText.Size = new System.Drawing.Size(101, 13);
            this.lblCCText.TabIndex = 5;
            this.lblCCText.Text = "Количество ходов:";
            // 
            // lblNText
            // 
            this.lblNText.AutoSize = true;
            this.lblNText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNText.Location = new System.Drawing.Point(12, 35);
            this.lblNText.Name = "lblNText";
            this.lblNText.Size = new System.Drawing.Size(48, 16);
            this.lblNText.TabIndex = 6;
            this.lblNText.Text = "Число";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(223, 149);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 35);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblGoalText
            // 
            this.lblGoalText.AutoSize = true;
            this.lblGoalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoalText.Location = new System.Drawing.Point(12, 168);
            this.lblGoalText.Name = "lblGoalText";
            this.lblGoalText.Size = new System.Drawing.Size(48, 16);
            this.lblGoalText.TabIndex = 8;
            this.lblGoalText.Text = "Цель:";
            this.lblGoalText.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoal.Location = new System.Drawing.Point(66, 168);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(92, 16);
            this.lblGoal.TabIndex = 9;
            this.lblGoal.Text = "ывпывпывп";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 203);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.lblGoalText);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNText);
            this.Controls.Add(this.lblCCText);
            this.Controls.Add(this.lblCommandsCount);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.MinimumSize = new System.Drawing.Size(367, 0);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCommandsCount;
        private System.Windows.Forms.Label lblCCText;
        private System.Windows.Forms.Label lblNText;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblGoalText;
        private System.Windows.Forms.Label lblGoal;
    }
}

