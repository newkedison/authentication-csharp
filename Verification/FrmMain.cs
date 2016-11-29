using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using Utils;

namespace Verification
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btn_load_file_Click(object sender, EventArgs e)
        {
            if (!File.Exists(CommonData.PRIVATE_KEY_PATH))
            {
                show_warning(@"找不到私钥文件 " + CommonData.PRIVATE_KEY_PATH);
                return;
            }
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var file_name = openFileDialog1.FileName;
            if (file_name == null) return;
            try
            {
                using (var rsa = CommonMethod.get_rsa(
                    CommonMethod.read_key(CommonData.PRIVATE_KEY_PATH)))
                {
                    var cipher = CommonMethod.read_bytes_from_file(file_name);
                    var plain = rsa.Decrypt(cipher, false);
                    _dict = CommonMethod.binary_to_dict(plain);
                }
            }
            catch (CryptographicException ec)
            {
                show_warning(@"解析文件失败: " + ec.Message);
                return;
            }
            lbl_load_file_info.Visible = true;
            pane.Enabled = true;
            dtp_due_date.Value = DateTime.Now.AddYears(20);
        }

        private void show_warning(string msg)
        {
            MessageBox.Show(msg, @"警告",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private Dictionary<string, string> _dict
            = new Dictionary<string, string>();

        private void btn_add_pid_Click(object sender, EventArgs e)
        {
            var pid = edt_pid.Text;
            if (!pid.Any())
            {
                show_warning(@"请输入一个序列号");
                edt_pid.Focus();
                return;
            }
            if (lst_pid.Items.Contains(pid))
            {
                show_warning(@"已存在相同的序列号");
                var index = lst_pid.Items.IndexOf(pid);
                lst_pid.SelectedIndex = index;
                edt_pid.Focus();
                edt_pid.SelectAll();
                return;
            }
            lst_pid.Items.Add(pid);
            edt_pid.Text = "";
            edt_pid.Focus();
        }

        private bool is_empty(string text, Control control,
            string msg)
        {
            if (!text.Any())
            {
                show_warning(msg);
                control.Focus();
                return true;
            }
            return false;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            var user_name = edt_user_name.Text;
            if (is_empty(user_name, edt_user_name, @"请输入客户名称"))
            {
                return;
            }
            var due_date = DateTime.MaxValue;
            if (!chk_unlimit_due_date.Checked)
            {
                due_date = dtp_due_date.Value;
                if (due_date < DateTime.Now)
                {
                    show_warning(@"失效日期不能在当前时间之前");
                    dtp_due_date.Focus();
                    return;
                }
            }
            var max_count = -1;
            if (!chk_unlimit_count.Checked)
            {
                max_count = (int)edt_max_connection.Value;
            }
            if (lst_pid.Items.Count == 0)
            {
                show_warning(@"至少需要添加一个序列号, 如果要授权任意序列号,"
                    + @"请输入*(星号)作为序列号");
                if (!edt_pid.Text.Any())
                {
                    edt_pid.Text = @"*";
                }
                edt_pid.SelectAll();
                edt_pid.Focus();
                return;
            }
            var pids = "";
            foreach (var pid in lst_pid.Items.OfType<string>())
            {
                if (pids.Length == 0)
                {
                    pids += @";";
                }
                pids += pid;
            }
            _dict["user"] = user_name;
            _dict["max"] = max_count.ToString();
            _dict["due"] = due_date.ToString(@"yyyy-MM-dd");
            _dict["pids"] = pids;
            _dict["verify"] = "OK";

            var cert = CommonMethod.dict_to_binary(_dict);
            var rsa = CommonMethod.get_rsa(
                CommonMethod.read_key(CommonData.PRIVATE_KEY_PATH));
            var sign = rsa.SignData(cert, "SHA512");
            var all = new List<byte>();
            all.AddRange(sign);
            all.AddRange(CommonMethod.encrypt_with_tripledes(cert,
                CommonData.TRIPLE_DES_KEY));
            var file_name = user_name + @"-" + due_date.ToString("yyyy-MM-dd")
                            + ".cert";
            CommonMethod.write_bytes_to_file(all.ToArray(), file_name);
            rsa.Dispose();
            MessageBox.Show(@"授权文件已生成: " + file_name);
        }

        private void lst_pid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lst_pid.Items.Count > 0 && lst_pid.SelectedIndex >= 0)
                {
                    lst_pid.Items.RemoveAt(lst_pid.SelectedIndex);
                }
            }
        }

        private void chk_unlimit_due_date_Click(object sender, EventArgs e)
        {
            dtp_due_date.Enabled = !chk_unlimit_due_date.Checked;
        }

        private void chk_unlimit_count_CheckedChanged(
            object sender, EventArgs e)
        {
            edt_max_connection.Enabled = !chk_unlimit_count.Checked;
        }
    }
}
