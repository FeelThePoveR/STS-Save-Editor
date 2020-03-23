using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STS_Save_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }

    public static class Methods
    {
        public static string Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                return "File doesn't exist";
            }
            string encoded = File.ReadAllText(path);
            string decoded = loadSaveString(encoded);

            return decoded;
        }

        public static void Serialize(string path, string data)
        {
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(xor(data, "key")));
            File.WriteAllText(path, encoded);
        }

        private static string loadSaveString(string data)
        {
            if (isObfuscated(data))
                return decode(data, "key");
            else
                return data;
        }

        private static bool isObfuscated(string data)
        {
            return !data.Contains("{");
        }

        private static string decode(string s, string key)
        {
                return xor(Encoding.UTF8.GetString(Convert.FromBase64String(s)), key);
        }

        private static string xor(string text, string key)
        {
            var result = new StringBuilder();
            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
            return result.ToString();
        }
    }
}
