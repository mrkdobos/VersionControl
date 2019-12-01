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

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName; // label1
                                              // textBox2.Text = Resource1.FirstName; // label2
            label2.Visible = false;
            textBox2.Visible = false;
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.File; // button2

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                //FirstName = textBox2.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.DefaultExt = "*.txt";
            saveFile.Filter = "TXT Files|*.txt";

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                            {
                            sw.WriteLine(listBox1.Items[i]);
                            }
                }
            }
        }
    }
}
