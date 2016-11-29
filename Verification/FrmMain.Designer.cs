namespace Verification
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_load_file = new System.Windows.Forms.Button();
            this.lbl_load_file_info = new System.Windows.Forms.Label();
            this.pane = new System.Windows.Forms.Panel();
            this.chk_unlimit_due_date = new System.Windows.Forms.CheckBox();
            this.chk_unlimit_count = new System.Windows.Forms.CheckBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.lst_pid = new System.Windows.Forms.ListBox();
            this.btn_add_pid = new System.Windows.Forms.Button();
            this.edt_pid = new System.Windows.Forms.TextBox();
            this.edt_max_connection = new System.Windows.Forms.NumericUpDown();
            this.dtp_due_date = new System.Windows.Forms.DateTimePicker();
            this.edt_user_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_max_connection)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load_file
            // 
            this.btn_load_file.Location = new System.Drawing.Point(22, 26);
            this.btn_load_file.Name = "btn_load_file";
            this.btn_load_file.Size = new System.Drawing.Size(75, 23);
            this.btn_load_file.TabIndex = 0;
            this.btn_load_file.Text = "加载文件";
            this.btn_load_file.UseVisualStyleBackColor = true;
            this.btn_load_file.Click += new System.EventHandler(this.btn_load_file_Click);
            // 
            // lbl_load_file_info
            // 
            this.lbl_load_file_info.AutoSize = true;
            this.lbl_load_file_info.Location = new System.Drawing.Point(114, 31);
            this.lbl_load_file_info.Name = "lbl_load_file_info";
            this.lbl_load_file_info.Size = new System.Drawing.Size(185, 12);
            this.lbl_load_file_info.TabIndex = 5;
            this.lbl_load_file_info.Text = "设备信息已读取, 请填写附加信息";
            this.lbl_load_file_info.Visible = false;
            // 
            // pane
            // 
            this.pane.Controls.Add(this.chk_unlimit_due_date);
            this.pane.Controls.Add(this.chk_unlimit_count);
            this.pane.Controls.Add(this.btn_generate);
            this.pane.Controls.Add(this.lst_pid);
            this.pane.Controls.Add(this.btn_add_pid);
            this.pane.Controls.Add(this.edt_pid);
            this.pane.Controls.Add(this.edt_max_connection);
            this.pane.Controls.Add(this.dtp_due_date);
            this.pane.Controls.Add(this.edt_user_name);
            this.pane.Controls.Add(this.label4);
            this.pane.Controls.Add(this.label3);
            this.pane.Controls.Add(this.label2);
            this.pane.Controls.Add(this.label1);
            this.pane.Location = new System.Drawing.Point(22, 69);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(300, 425);
            this.pane.TabIndex = 6;
            // 
            // chk_unlimit_due_date
            // 
            this.chk_unlimit_due_date.AutoSize = true;
            this.chk_unlimit_due_date.Location = new System.Drawing.Point(208, 60);
            this.chk_unlimit_due_date.Name = "chk_unlimit_due_date";
            this.chk_unlimit_due_date.Size = new System.Drawing.Size(60, 16);
            this.chk_unlimit_due_date.TabIndex = 17;
            this.chk_unlimit_due_date.Text = "不限制";
            this.chk_unlimit_due_date.UseVisualStyleBackColor = true;
            this.chk_unlimit_due_date.Click += new System.EventHandler(this.chk_unlimit_due_date_Click);
            // 
            // chk_unlimit_count
            // 
            this.chk_unlimit_count.AutoSize = true;
            this.chk_unlimit_count.Location = new System.Drawing.Point(211, 90);
            this.chk_unlimit_count.Name = "chk_unlimit_count";
            this.chk_unlimit_count.Size = new System.Drawing.Size(60, 16);
            this.chk_unlimit_count.TabIndex = 16;
            this.chk_unlimit_count.Text = "不限制";
            this.chk_unlimit_count.UseVisualStyleBackColor = true;
            this.chk_unlimit_count.CheckedChanged += new System.EventHandler(this.chk_unlimit_count_CheckedChanged);
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(92, 378);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(89, 23);
            this.btn_generate.TabIndex = 15;
            this.btn_generate.Text = "生成授权文件";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // lst_pid
            // 
            this.lst_pid.FormattingEnabled = true;
            this.lst_pid.ItemHeight = 12;
            this.lst_pid.Location = new System.Drawing.Point(29, 161);
            this.lst_pid.Name = "lst_pid";
            this.lst_pid.Size = new System.Drawing.Size(242, 196);
            this.lst_pid.TabIndex = 14;
            this.lst_pid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lst_pid_KeyUp);
            // 
            // btn_add_pid
            // 
            this.btn_add_pid.Location = new System.Drawing.Point(211, 121);
            this.btn_add_pid.Name = "btn_add_pid";
            this.btn_add_pid.Size = new System.Drawing.Size(75, 23);
            this.btn_add_pid.TabIndex = 13;
            this.btn_add_pid.Text = "添加";
            this.btn_add_pid.UseVisualStyleBackColor = true;
            this.btn_add_pid.Click += new System.EventHandler(this.btn_add_pid_Click);
            // 
            // edt_pid
            // 
            this.edt_pid.Location = new System.Drawing.Point(92, 123);
            this.edt_pid.Name = "edt_pid";
            this.edt_pid.Size = new System.Drawing.Size(100, 21);
            this.edt_pid.TabIndex = 12;
            // 
            // edt_max_connection
            // 
            this.edt_max_connection.Location = new System.Drawing.Point(94, 89);
            this.edt_max_connection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edt_max_connection.Name = "edt_max_connection";
            this.edt_max_connection.Size = new System.Drawing.Size(109, 21);
            this.edt_max_connection.TabIndex = 11;
            this.edt_max_connection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtp_due_date
            // 
            this.dtp_due_date.Location = new System.Drawing.Point(92, 55);
            this.dtp_due_date.Name = "dtp_due_date";
            this.dtp_due_date.Size = new System.Drawing.Size(111, 21);
            this.dtp_due_date.TabIndex = 10;
            // 
            // edt_user_name
            // 
            this.edt_user_name.Location = new System.Drawing.Point(92, 22);
            this.edt_user_name.Name = "edt_user_name";
            this.edt_user_name.Size = new System.Drawing.Size(179, 21);
            this.edt_user_name.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "序列号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "最大连接数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "失效日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户名称";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 531);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.lbl_load_file_info);
            this.Controls.Add(this.btn_load_file);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权文件生成工具";
            this.pane.ResumeLayout(false);
            this.pane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_max_connection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load_file;
        private System.Windows.Forms.Label lbl_load_file_info;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.ListBox lst_pid;
        private System.Windows.Forms.Button btn_add_pid;
        private System.Windows.Forms.TextBox edt_pid;
        private System.Windows.Forms.NumericUpDown edt_max_connection;
        private System.Windows.Forms.DateTimePicker dtp_due_date;
        private System.Windows.Forms.TextBox edt_user_name;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chk_unlimit_due_date;
        private System.Windows.Forms.CheckBox chk_unlimit_count;
    }
}

