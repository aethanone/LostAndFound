namespace lostnfound
{
    partial class Home
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
            this.lbnLost = new System.Windows.Forms.Label();
            this.lbnFound = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbnLost
            // 
            this.lbnLost.AutoSize = true;
            this.lbnLost.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnLost.Location = new System.Drawing.Point(49, 72);
            this.lbnLost.Name = "lbnLost";
            this.lbnLost.Size = new System.Drawing.Size(328, 34);
            this.lbnLost.TabIndex = 1;
            this.lbnLost.Text = "Reported Lost no: 0";
            // 
            // lbnFound
            // 
            this.lbnFound.AutoSize = true;
            this.lbnFound.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnFound.Location = new System.Drawing.Point(33, 72);
            this.lbnFound.Name = "lbnFound";
            this.lbnFound.Size = new System.Drawing.Size(358, 34);
            this.lbnFound.TabIndex = 2;
            this.lbnFound.Text = "Reported Found no: 0";
            this.lbnFound.Click += new System.EventHandler(this.lbnFound_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbnLost);
            this.panel1.Location = new System.Drawing.Point(22, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 197);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbnFound);
            this.panel2.Location = new System.Drawing.Point(492, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 197);
            this.panel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::lostnfound.Properties.Resources.refres1;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(886, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 44);
            this.button1.TabIndex = 24;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lostnfound.Properties.Resources.bulsubg2;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(970, 740);
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbnLost;
        private System.Windows.Forms.Label lbnFound;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}
