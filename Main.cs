using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STS_Save_Editor
{
    public partial class Main : Form
    {
        string currPath = AppDomain.CurrentDomain.BaseDirectory;
        string configPath;

        string ironcladPath = "\\saves\\IRONCLAD.autosave";
        string silentPath = "\\saves\\THE_SILENT.autosave";
        string defectPath = "\\saves\\DEFECT.autosave";
        string watcherPath = "\\saves\\WATCHER.autosave";

        int choice = 0;

        public Main()
        {
            InitializeComponent();
            if (!File.Exists(currPath + "\\config.ini"))
                File.WriteAllText(configPath + "\\config.ini", "");
            configPath = File.ReadAllText(currPath + "\\config.ini");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 1;

            if(checkBox1.Checked)
                richTextBox1.Text = Methods.Deserialize(configPath + ironcladPath + "BETA");
            else
                richTextBox1.Text = Methods.Deserialize(configPath + ironcladPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 2;

            if (checkBox1.Checked)
                richTextBox1.Text = Methods.Deserialize(configPath + silentPath + "BETA");
            else
                richTextBox1.Text = Methods.Deserialize(configPath + silentPath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choice = 3;

            if (checkBox1.Checked)
                richTextBox1.Text = Methods.Deserialize(configPath + defectPath + "BETA");
            else
                richTextBox1.Text = Methods.Deserialize(configPath + defectPath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice = 4;

            if (checkBox1.Checked)
                richTextBox1.Text = Methods.Deserialize(configPath + watcherPath + "BETA");
            else
                richTextBox1.Text = Methods.Deserialize(configPath + watcherPath);
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                switch (choice)
                {
                    case 1:
                        Methods.Serialize(configPath + ironcladPath + "BETA", richTextBox1.Text);
                        break;
                    case 2:
                        Methods.Serialize(configPath + silentPath + "BETA", richTextBox1.Text);
                        break;
                    case 3:
                        Methods.Serialize(configPath + defectPath + "BETA", richTextBox1.Text);
                        break;
                    case 4:
                        Methods.Serialize(configPath + watcherPath + "BETA", richTextBox1.Text);
                        break;
                    case 5:
                        File.WriteAllText(configPath + "\\config.ini", richTextBox1.Text);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Methods.Serialize(configPath + ironcladPath, richTextBox1.Text);
                        break;
                    case 2:
                        Methods.Serialize(configPath + silentPath, richTextBox1.Text);
                        break;
                    case 3:
                        Methods.Serialize(configPath + defectPath, richTextBox1.Text);
                        break;
                    case 4:
                        Methods.Serialize(configPath + watcherPath, richTextBox1.Text);
                        break;
                    case 5:
                        File.WriteAllText(configPath + "\\config.ini", richTextBox1.Text);
                        break;
                    default:
                        break;
                }
            }
                
            richTextBox1.Text = "File saved!";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            choice = 5;

            richTextBox1.Text = File.ReadAllText(currPath + "\\config.ini");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] words = textBox1.Text.Split(',');
            foreach (string word in words)
            {
                int startindex = 0;
                while (startindex < richTextBox1.TextLength)
                {
                    int wordstartIndex = richTextBox1.Find(word, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        richTextBox1.SelectionStart = wordstartIndex;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = Color.Yellow;
                    }
                    else
                        break;
                    startindex += wordstartIndex + word.Length;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
        }
    }
}
