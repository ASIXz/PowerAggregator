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
    public partial class FormRemovePlugin : Form
    {
        public List<IChatPlugin> Accounts;

        public FormRemovePlugin()
        {
            InitializeComponent();
        }

        private void FormRemovePlugin_Shown(object sender, EventArgs e)
        {
            comboPlugins.Items.Clear();
            foreach (Type plugin in PluginHelper.Plugins)
            {
                comboPlugins.Items.Add(plugin.Name);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var Plugin = PluginHelper.Plugins[comboPlugins.SelectedIndex];
            var UsedAccounts = Accounts.Where(x => x.GetType() == Plugin);

            if (!UsedAccounts.Any())
            {

                var result = PluginHelper.RemovePlugin(Plugin);

                if (result == null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(this, result);
            }
            else
            {
                string UsedAccountsNames = String.Join("\n", UsedAccounts.Select(x => x.Name));
                MessageBox.Show(this, "Plagin already in use!\nFirst remove next account(s):\n" + UsedAccountsNames);
            }
        }
    }
}
