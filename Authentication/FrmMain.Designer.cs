namespace Authentication
{
    partial class FrmMain
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
            this.edtInfo = new System.Windows.Forms.TextBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // edtInfo
            // 
            this.edtInfo.Location = new System.Drawing.Point(35, 29);
            this.edtInfo.Multiline = true;
            this.edtInfo.Name = "edtInfo";
            this.edtInfo.Size = new System.Drawing.Size(323, 176);
            this.edtInfo.TabIndex = 0;
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(146, 230);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "导入证书";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 280);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.edtInfo);
            this.Name = "FrmMain";
            this.Text = "应用程序";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtInfo;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}