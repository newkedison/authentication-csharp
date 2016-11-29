namespace GenerateRSAKey
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
            this.btn_generate = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.pane_result = new System.Windows.Forms.Panel();
            this.lbl_private_key = new System.Windows.Forms.Label();
            this.lbl_public_key = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pane_result.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_generate.ForeColor = System.Drawing.Color.Purple;
            this.btn_generate.Location = new System.Drawing.Point(105, 25);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(177, 72);
            this.btn_generate.TabIndex = 0;
            this.btn_generate.Text = "生成密钥对";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_info.Location = new System.Drawing.Point(31, 112);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(325, 21);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "点击以上按钮生成一组新的密钥对";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pane_result
            // 
            this.pane_result.Controls.Add(this.lbl_private_key);
            this.pane_result.Controls.Add(this.lbl_public_key);
            this.pane_result.Controls.Add(this.label3);
            this.pane_result.Controls.Add(this.label2);
            this.pane_result.Location = new System.Drawing.Point(105, 137);
            this.pane_result.Name = "pane_result";
            this.pane_result.Size = new System.Drawing.Size(297, 66);
            this.pane_result.TabIndex = 2;
            this.pane_result.Visible = false;
            // 
            // lbl_private_key
            // 
            this.lbl_private_key.AutoSize = true;
            this.lbl_private_key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_private_key.Location = new System.Drawing.Point(94, 38);
            this.lbl_private_key.Name = "lbl_private_key";
            this.lbl_private_key.Size = new System.Drawing.Size(0, 12);
            this.lbl_private_key.TabIndex = 3;
            // 
            // lbl_public_key
            // 
            this.lbl_public_key.AutoSize = true;
            this.lbl_public_key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_public_key.Location = new System.Drawing.Point(94, 16);
            this.lbl_public_key.Name = "lbl_public_key";
            this.lbl_public_key.Size = new System.Drawing.Size(0, 12);
            this.lbl_public_key.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(20, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "私钥文件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "公钥文件:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 215);
            this.Controls.Add(this.pane_result);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密钥对生成工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pane_result.ResumeLayout(false);
            this.pane_result.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Panel pane_result;
        private System.Windows.Forms.Label lbl_private_key;
        private System.Windows.Forms.Label lbl_public_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

