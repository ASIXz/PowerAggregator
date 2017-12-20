using PowerAgregator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesctopPA
{
    public partial class FormCreateContact : Form
    {
        public PowerAgregator.Core core;
        public PowerAgregator.ChatterUser user;

        public FormCreateContact()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !core.Users.Any(x => x.Name == textBox1.Text))
            {

                core.AddUser(user, textBox1.Text);
                if (!string.IsNullOrWhiteSpace(textBox2.Text)) ImageHelper.AddImage(textBox2.Text, textBox1.Text) ;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                using (var bmpTemp = new Bitmap(openFileDialog1.FileName))
                {
                    pictureBox1.Image = new Bitmap(bmpTemp);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
