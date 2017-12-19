using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DesctopPA
{
    public partial class FormAddPludin : Form
    {
        public FormAddPludin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textPath.Text = openFileDialog1.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (File.Exists(textPath.Text))
            {
                var message = PluginHelper.AddPlugin(textPath.Text);
                if (message == null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Can't Load Plugin:\n" + message);
                }
            }
            else
            {
                MessageBox.Show("File Not Exist");
            }
        }
    }
}
