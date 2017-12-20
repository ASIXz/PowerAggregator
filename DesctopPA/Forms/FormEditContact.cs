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
    public partial class FormEditContact : Form
    {
        public FormEditContact()
        {
            InitializeComponent();
        }

        public AgregatorUser user;
        public Core core;
        public bool changed;

        private void FormEditContact_Shown(object sender, EventArgs e)
        {
            listChattersContacts.Clear();
            foreach (ChatterUser chatterUser in user.Chatters)
            {
                var item = listChattersContacts.Items.Add(chatterUser.ToString());
                item.Tag = chatterUser;
            }
            textBox1.Text = user.Name;
            pictureBox1.Image = ImageHelper.GetImage(user.Name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            var Name = user.Name;
            if (textBox1.Text != user.Name)
                if (core.ChangeUserKey(user, textBox1.Text))
                {
                    changed = true;
                    ImageHelper.RenameImage(Name, textBox1.Text);
                }
                else MessageBox.Show("Incorrect Name");

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                var ImageKey = ImageHelper.AddImage(textBox2.Text, user.Name);
                pictureBox1.Image = ImageHelper.List.Images[ImageKey];
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (changed) DialogResult = DialogResult.OK;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //at lest one contact
            if (user.Chatters.Count > 1 && listChattersContacts.SelectedItems.Count == 1)
            {
                var cUser = listChattersContacts.SelectedItems[0].Tag as ChatterUser;
                cUser.AgregatorUser = null;
                user.Chatters.Remove(cUser);

                listChattersContacts.Clear();
                foreach (ChatterUser chatterUser in user.Chatters)
                {
                    var item = listChattersContacts.Items.Add(chatterUser.ToString());
                    item.Tag = chatterUser;
                }
            }
        }
    }
}
