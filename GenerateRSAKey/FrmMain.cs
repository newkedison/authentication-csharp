using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Utils;

namespace GenerateRSAKey
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static bool check_file_exist()
        {
            if (File.Exists(CommonData.PUBLIC_KEY_PATH))
            {
                if (File.Exists(CommonData.PRIVATE_KEY_PATH))
                {
                    if (MessageBox.Show(@"密钥对文件已存在, 是否替换?",
                        @"警告", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }
                }
                else
                {
                    if (MessageBox.Show(@"公钥文件已存在, 是否替换?",
                        @"警告", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (File.Exists(CommonData.PRIVATE_KEY_PATH))
                {
                    if (MessageBox.Show(@"私钥文件已存在, 是否替换?",
                        @"警告", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static RSACryptoServiceProvider get_rsa_csp(string key_name)
        {
            var cspp = new CspParameters()
            {
                KeyContainerName = key_name
            };
            return new RSACryptoServiceProvider(cspp);
        }

        private static void delete_key()
        {
            var rsa = get_rsa_csp(CommonData.KEY_CONTAINER_NAME);
            rsa.PersistKeyInCsp = false;
            rsa.Clear();
            rsa.Dispose();
        }

        private static void generate_new_key()
        {
            delete_key();
            var rsa = get_rsa_csp(CommonData.KEY_CONTAINER_NAME);
            rsa.Dispose();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            if (check_file_exist())
                return;
            generate_new_key();
            var rsa = get_rsa_csp(CommonData.KEY_CONTAINER_NAME);
            var sw = new StreamWriter(CommonData.PUBLIC_KEY_PATH, false);
            sw.Write(rsa.ToXmlString(false));
            sw.Close();
            sw = new StreamWriter(CommonData.PRIVATE_KEY_PATH, false);
            sw.Write(rsa.ToXmlString(true));
            sw.Close();
            lbl_info.Text = @"密钥对文件已生成";
            lbl_info.Left = (Width - lbl_info.Width)/2;
            pane_result.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lbl_public_key.Text = CommonData.PUBLIC_KEY_PATH;
            lbl_private_key.Text = CommonData.PRIVATE_KEY_PATH;
        }
    }
}
