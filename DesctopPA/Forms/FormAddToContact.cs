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
    public partial class FormAddToContact : Form
    {
        public Core core;
        public ChatterUser user;
        AgregatorUser SelectedUser;

        public FormAddToContact()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FormAddToContact_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(core.Users.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                core.AddUser(user, SelectedUser);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SelectedUser = comboBox1.SelectedItem as AgregatorUser;
            listBox1.Items.AddRange(SelectedUser.Chatters.ToArray());
        }
    }
}
