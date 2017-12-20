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
    public partial class FormAddAcccount : Form
    {
        public PowerAgregator.Core core;
        PowerAgregator.IChatPlugin SelectedPlugin;
        public FormAddAcccount()
        {
            InitializeComponent();
        }

        private void comboPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectedPlugin = new TelegramPlugin.TelegramPlugin() as PowerAgregator.IChatPlugin; 
            if (PluginHelper.Plugins[comboPlugins.SelectedIndex].Name != "TelegramPlugin")
                SelectedPlugin = Activator.CreateInstance(PluginHelper.Plugins[comboPlugins.SelectedIndex]) as PowerAgregator.IChatPlugin;
            else
                SelectedPlugin = new TelegramPlugin.TelegramPlugin() as PowerAgregator.IChatPlugin;

            labelLogin.Show();
            textLogin.Show();


            if (SelectedPlugin.IsPassword)
            {
                labelPass.Show();
                textPass.Show();
            }
            else
            {
                labelPass.Hide();
                textPass.Hide();
            }

            textVerification.Hide();
            labelVerification.Hide();
        }

        private void FormAddAcccount_Shown(object sender, EventArgs e)
        {
            comboPlugins.Items.Clear();
            foreach (Type plugin in PluginHelper.Plugins)
            {
                comboPlugins.Items.Add(plugin.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedPlugin.Is2StepAuth)
                {
                    if (string.IsNullOrWhiteSpace(textVerification.Text))
                    {
                        core.AddChatter(SelectedPlugin, textBox1.Text, textBox2.Text);
                        if (SelectedPlugin.Login(textLogin.Text, textPass.Text))
                        {
                            textVerification.Show();
                            labelVerification.Show();
                        }
                    }
                    else
                    {
                        if (SelectedPlugin.LoginStep2(textVerification.Text))
                        {
                            core.ChatterUsers.AddRange(SelectedPlugin.GetUsers());
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (core.AddChatter(SelectedPlugin, textBox1.Text, textBox2.Text) != null)
                    {
                        SelectedPlugin.Login(textLogin.Text, textPass.Text);
                        core.ChatterUsers.AddRange(SelectedPlugin.GetUsers());
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
