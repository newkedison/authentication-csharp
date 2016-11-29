using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class CommonMethod
    {
        public static byte[] dict_to_binary(Dictionary<string, string> dict)
        {
            var s = new byte[10000];
            using (var sw = new BinaryWriter(new MemoryStream(s)))
            {
                foreach (var p in dict)
                {
                    sw.Write(p.Key);
                    sw.Write(p.Value);
                }
                sw.Flush();
                var len = sw.BaseStream.Position;
                return s.Take((int)len).ToArray();
            }
        }

        public static Dictionary<string, string> binary_to_dict(byte[] data)
        {
            var result = new Dictionary<string, string>();
            using (var sr = new BinaryReader(
                new MemoryStream(data, 0, data.Length)))
            {
                while (true)
                {
                    try
                    {
                        var key = sr.ReadString();
                        var value = sr.ReadString();
                        result[key] = value;
                        if (sr.BaseStream.Position >= data.Length)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static string read_key(string file_path)
        {
            using (var sr = new StreamReader(file_path))
            {
                return sr.ReadToEnd();
            }
        }

        public static RSACryptoServiceProvider get_rsa(string key)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(key);
            return rsa;
        }

        public static byte[] read_bytes_from_file(string file_name)
        {
            using (var fs = new FileStream(
                file_name, FileMode.Open, FileAccess.Read))
            {
                var result = new byte[fs.Length];
                fs.Read(result, 0, result.Length);
                return result;
            }
        }

        public static void write_bytes_to_file(byte[] data, string file_name)
        {
            using (var fs = new FileStream(
                file_name, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
        }

        public static byte[] encrypt_with_tripledes(byte[] plain, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                var hash_key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                tdes.Key = hash_key;
                tdes.Padding = PaddingMode.PKCS7;
                tdes.Mode = CipherMode.ECB;
                var transform = tdes.CreateEncryptor();
                var enc = transform.TransformFinalBlock
                        (plain, 0, plain.Length);
                return enc;
            }
        }

        public static byte[] decrypt_with_tripledes(byte[] cipher, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                var hash_key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                tdes.Key = hash_key;
                tdes.Padding = PaddingMode.PKCS7;
                tdes.Mode = CipherMode.ECB;
                var transform = tdes.CreateDecryptor();
                var enc = transform.TransformFinalBlock
                        (cipher, 0, cipher.Length);
                return enc;
            }
        }
    }
}
