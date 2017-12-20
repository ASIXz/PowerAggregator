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
    public partial class FormRemoveAccount : Form
    {
        public FormRemoveAccount()
        {
            InitializeComponent();
        }

        public Core core;
        IChatPlugin chatter;

        private void FormRemoveAccount_Shown(object sender, EventArgs e)
        {
            comboAccounts.Items.AddRange(core.Chatters.Select(x => x.Name).ToArray());
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccounts.SelectedIndex >= 0)
            {
                chatter = core.Chatters[comboAccounts.SelectedIndex];
                textId.Text = chatter.Id;
                //textLogin.Text = Cahtter.;
                textPlugin.Text = chatter.GetType().Name;
                listChattersContacts.Clear();
                listChattersContacts.Items.AddRange(core.ChatterUsers.Where(x => x.Chatter == chatter).Select(x => new ListViewItem(x.ToString())).ToArray());
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning! It will remove all reffered contacts and data!", "Delete database", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DBHelper.ClearDatabase();
                core.Chatters.Remove(chatter);
                List<ChatterUser> removalList = core.ChatterUsers.Where(x => x.Chatter == chatter).ToList();

                foreach (ChatterUser chatterUser in removalList)
                {
                    core.ChatterUsers.Remove(chatterUser);
                    chatterUser.Messages = new List<PowerAgregator.Message>();
                    DBHelper.SaveMessages(chatterUser);
                }
                DBHelper.SaveAccountDataToDataBase(core);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }

}
