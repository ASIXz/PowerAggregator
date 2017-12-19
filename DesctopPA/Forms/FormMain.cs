using PowerAgregator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesctopPA
{
    public partial class FormMain : Form
    {
        Core Core = new Core();
        object CurrentUser = null;

        public FormMain()
        {
            InitializeComponent();
            listAgregatorContacts.Dock = DockStyle.Fill;
            listChattersContacts.Dock = DockStyle.Fill;
            Core.MessageAdded += (x) => { MessageBox.Show(x.ToString()); };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //CoreSaveHelper.ClearDatabase();
            CoreSaveHelper.RestoreAccountDataFromDataBase(Core);
            LoadContacts();
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(44, 44);
            var dir = Directory.GetFiles(@"G:\Документы\Магистр\img");
            foreach (var item in dir)
            {
                imgs.Images.Add(Image.FromFile(item));
            }
            listAgregatorContacts.LargeImageList = imgs;
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddAcccount formAddAccount = new FormAddAcccount();
            formAddAccount.core = Core;
            var c = formAddAccount.ShowDialog();
            if (c == DialogResult.OK)
            {
                LoadContacts();
            }
        }

        private void listAgregatorContacts_ItemActivate(object sender, EventArgs e)
        {
            var user = listAgregatorContacts.SelectedItems[0].Tag as AgregatorUser;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Core.GetChatMessages(user, CoreSaveHelper.LoadMessages).ToArray());
            label2.Text = "Messages - " + user.ToString();
            CurrentUser = user;
        }

        private void listChattersContacts_ItemActivate(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var user = listChattersContacts.SelectedItems[0].Tag as ChatterUser;
            if (user.Messages == null) CoreSaveHelper.LoadMessages(user);
            listBox1.Items.AddRange(Core.GetChatMessages(user).ToArray());
            CoreSaveHelper.SaveMessages(user);
            label2.Text = "Messages - " + user.ToString();
            CurrentUser = user;
        }

        private void LoadContacts()
        {
            listAgregatorContacts.Clear();
            int i = 0;
            foreach (AgregatorUser user in Core.Users)
            {
                var item = listAgregatorContacts.Items.Add(user.ToString(), i++);
                item.Tag = user;
            }
            listChattersContacts.Clear();
            foreach (ChatterUser user in Core.ChatterUsers)
            {
                if (user.AgregatorUser == null)
                {
                    var item = listChattersContacts.Items.Add(user.ToString());
                    item.Tag = user;
                }
            }
        }

        private void contextNotAgregeted_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listChattersContacts.SelectedItems.Count != 1;
        }

        private void contextAgregated_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listAgregatorContacts.SelectedItems.Count != 1;
        }

        private void createContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateContact formCreateContact = new FormCreateContact();
            formCreateContact.user = listChattersContacts.SelectedItems[0].Tag as ChatterUser;
            formCreateContact.core = Core;
            var c = formCreateContact.ShowDialog();
            if (c == DialogResult.OK)
            {
                LoadContacts();
            }
        }

        private void addToContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddToContact formAddToContact = new FormAddToContact();
            formAddToContact.user = listChattersContacts.SelectedItems[0].Tag as ChatterUser;
            formAddToContact.core = Core;
            var c = formAddToContact.ShowDialog();
            if (c == DialogResult.OK)
            {
                LoadContacts();
            }
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditContact formEditContact = new FormEditContact();
            formEditContact.user = listAgregatorContacts.SelectedItems[0].Tag as AgregatorUser;
            formEditContact.ShowDialog();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && listBox1.Items[e.Index] is PowerAgregator.Message)
            {
                e.DrawBackground();
                var msg = listBox1.Items[e.Index] as PowerAgregator.Message;
                var color = msg.Recived ? Brushes.Black : Brushes.DarkCyan;
                e.Graphics.DrawString(msg.ToString(), listBox1.Font, color, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            string s = listBox1.Items[e.Index].ToString();
            SizeF sf = e.Graphics.MeasureString(s, listBox1.Font, listBox1.Width);
            int htex = (e.Index == 0) ? 15 : 10;
            e.ItemHeight = (int)(sf.Height) + 1;
            e.ItemWidth = listBox1.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    MessageBox.Show("Empty message is not allowed!");
                else
                if (CurrentUser is ChatterUser)
                    Core.SendMessage(CurrentUser as ChatterUser, textBox1.Text);
                else
                    Core.SendMessage(CurrentUser as AgregatorUser, textBox1.Text);
            }
            else
            {
                MessageBox.Show("Select user first");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CoreSaveHelper.SaveAccountDataToDataBase(Core);
        }

        private void addPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddPludin formAddPlugin = new FormAddPludin();
            formAddPlugin.ShowDialog();
        }

        private void removePluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRemovePlugin formRemovePlugin = new FormRemovePlugin();
            formRemovePlugin.Accounts = Core.Chatters;
            formRemovePlugin.ShowDialog();
        }
    }
}
