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

        private void FormEditContact_Shown(object sender, EventArgs e)
        {
            listChattersContacts.Clear();
            foreach (ChatterUser chatterUser in user.Chatters)
            {
                var item = listChattersContacts.Items.Add(chatterUser.ToString());
                item.Tag = chatterUser;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
