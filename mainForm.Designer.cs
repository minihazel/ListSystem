namespace ListSystem
{
    partial class mainForm
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
            this.list = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.Location = new System.Drawing.Point(191, 13);
            this.list.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.list.Name = "list";
            this.list.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.list.Size = new System.Drawing.Size(327, 452);
            this.list.TabIndex = 0;
            this.list.TabStop = false;
            this.list.Text = " List ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 478);
            this.Controls.Add(this.list);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox list;
    }
}

