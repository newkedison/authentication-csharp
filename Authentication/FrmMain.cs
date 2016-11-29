using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SystemIdentify;
using Utils;

namespace Authentication
{
    public partial class FrmMain : Form
    {
        private static bool _authenticate_pass;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void add_new_text(string msg)
        {
            edtInfo.Text += '[' + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                            + ']' + msg + Environment.NewLine;
        }

        private void show_warning(string msg)
        {
            MessageBox.Show(msg);
        }

        byte[] get_hardware_identify()
        {
            var dict = new Dictionary<string, string>();
            dict["cpu"] = Identify.CPUIdentify();
            dict["mainboard"] = Identify.MainBoardIdentify();
            dict["mac"] = Identify.MACIdentify();
            return CommonMethod.dict_to_binary(dict);
        }

        bool check_cert(byte[] cert_data)
        {
            var dict = CommonMethod.binary_to_dict(cert_data);
            foreach (var p in dict)
            {
                add_new_text(p.Key + @": " + p.Value);
            }
            try
            {
                if (dict["cpu"] != Identify.CPUIdentify()
                    || dict["mainboard"] != Identify.MainBoardIdentify()
                    || dict["mac"] != Identify.MACIdentify()
                    || dict["verify"] != "OK")
                {
                    show_warning(
                        @"证书无效, 请联系厂家重新获取, 并重新导入"
                        + Environment.NewLine
                        + @"错误代码: 0x0001");
                    return false;
                }
                if (DateTime.Parse(dict["due"]).AddDays(1)
                    < DateTime.Now)
                {
                    show_warning(
                        @"证书无效, 请联系厂家重新获取, 并重新导入"
                        + Environment.NewLine
                        + @"错误代码: 0x0002");
                    return false;
                }
                var max_slave = int.Parse(dict["max"]);
                if (max_slave < -1)
                {
                    show_warning(
                        @"证书无效, 请联系厂家重新获取, 并重新导入"
                        + Environment.NewLine
                        + @"错误代码: 0x0003");
                    return false;
                }
                var pid_list = dict["pids"].Split(';');
                if (!pid_list.Any())
                {
                    show_warning(
                        @"证书无效, 请联系厂家重新获取, 并重新导入"
                        + Environment.NewLine
                        + @"错误代码: 0x0004");
                    return false;
                }
            }
            catch (Exception)
            {
                show_warning(
                    @"证书无效, 请联系厂家重新获取, 并重新导入"
                    + Environment.NewLine
                    + @"错误代码: 0x0010");
                return false;
            }
            return true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(CommonData.PUBLIC_KEY_PATH))
            {
                show_warning(@"软件无法正常运行, 请重新安装."
                             + Environment.NewLine
                             + @"错误信息: 无法找到公钥文件");
                Close();
                return;
            }

            var hardware_id = get_hardware_identify();
            if (hardware_id == null)
            {
                show_warning(@"软件无法正常运行, 请重新安装."
                             + Environment.NewLine
                             + @"错误信息: 无法获取硬件识别码");
                Close();
                return;
            }
            byte[] hardware_id_enc;
            
            using (var rsa_enc = CommonMethod.get_rsa(
                CommonMethod.read_key(CommonData.PRIVATE_KEY_PATH)))
            {
                hardware_id_enc = rsa_enc.Encrypt(hardware_id, false);
            }
            if (hardware_id_enc == null)
            {
                show_warning(@"软件无法正常运行, 请重新安装."
                             + Environment.NewLine
                             + @"错误信息: 计算硬件识别码时发生错误");
                Close();
                return;
            }
            add_new_text(Convert.ToBase64String(
                hardware_id_enc, 0, hardware_id_enc.Length));

            if (!File.Exists(CommonData.CERT_FILE_PATH))
            {
                var file_path = Path.Combine(Environment.CurrentDirectory,
                    CommonData.IDENTIFY_FILE_PATH);
                CommonMethod.write_bytes_to_file(hardware_id_enc, file_path);
                show_warning(@"软件未授权, 请将" + file_path
                    + @"文件发送给厂家, 并索取授权文件. 然后通过导入按钮, "
                    + @"将授权文件导入, 才能正常使用软件的其他功能");
                return;
            }

            try
            {
                var cert = CommonMethod.read_bytes_from_file(
                    CommonData.CERT_FILE_PATH);

                var cert_hash = cert.Take(128).ToArray();
                var cert_data = CommonMethod.decrypt_with_tripledes(
                    cert.Skip(128).ToArray(), CommonData.TRIPLE_DES_KEY);

                var rsa = CommonMethod.get_rsa(CommonMethod.read_key(
                    CommonData.PUBLIC_KEY_PATH));
                if (rsa.VerifyData(cert_data, "SHA512", cert_hash))
                {
                    if (check_cert(cert_data))
                    {
                        _authenticate_pass = true;
                        add_new_text(@"证书校验通过");
                    }
                }
                else
                {
                    show_warning(
                        @"证书无效, 请联系厂家重新获取, 并重新导入"
                        + Environment.NewLine
                        + @"错误代码: 0xF000");
                }
            }
            catch (Exception exception)
            {
                show_warning(
                    @"证书无效, 请联系厂家重新获取, 并重新导入"
                    + Environment.NewLine
                    + @"错误信息: " + exception.Message);

            }

            if (_authenticate_pass)
            {
                Text += @"(已授权)";
            }
            else
            {
                Text += @"(未授权)";
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var file_name = openFileDialog1.FileName;
            if (file_name == null) return;
            try
            {
                File.Copy(file_name,
                    Path.Combine(Environment.CurrentDirectory,
                        CommonData.CERT_FILE_PATH), true);
                MessageBox.Show(@"证书导入成功, 请重启软件",
                    @"", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (UnauthorizedAccessException)
            {
                show_warning(@"导入证书失败, 无法写入当前文件夹");
            }
        }
    }
}
