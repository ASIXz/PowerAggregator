namespace DesctopPA
{
    partial class FormRemoveAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemoveAccount));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textPlugin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listChattersContacts = new System.Windows.Forms.ListView();
            this.comboAccounts = new System.Windows.Forms.ComboBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(135, 374);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textPlugin
            // 
            this.textPlugin.BackColor = System.Drawing.Color.White;
            this.textPlugin.Location = new System.Drawing.Point(12, 100);
            this.textPlugin.Name = "textPlugin";
            this.textPlugin.ReadOnly = true;
            this.textPlugin.Size = new System.Drawing.Size(228, 20);
            this.textPlugin.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            // 
            // textLogin
            // 
            this.textLogin.BackColor = System.Drawing.Color.White;
            this.textLogin.Location = new System.Drawing.Point(73, 61);
            this.textLogin.Name = "textLogin";
            this.textLogin.ReadOnly = true;
            this.textLogin.Size = new System.Drawing.Size(167, 20);
            this.textLogin.TabIndex = 15;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(12, 374);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(105, 23);
            this.buttonRemove.TabIndex = 14;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listChattersContacts
            // 
            this.listChattersContacts.Location = new System.Drawing.Point(12, 139);
            this.listChattersContacts.Name = "listChattersContacts";
            this.listChattersContacts.Size = new System.Drawing.Size(228, 229);
            this.listChattersContacts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listChattersContacts.TabIndex = 13;
            this.listChattersContacts.UseCompatibleStateImageBehavior = false;
            this.listChattersContacts.View = System.Windows.Forms.View.Tile;
            // 
            // comboAccounts
            // 
            this.comboAccounts.FormattingEnabled = true;
            this.comboAccounts.Location = new System.Drawing.Point(12, 21);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Size = new System.Drawing.Size(228, 21);
            this.comboAccounts.TabIndex = 19;
            this.comboAccounts.SelectedIndexChanged += new System.EventHandler(this.comboAccounts_SelectedIndexChanged);
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.Color.White;
            this.textId.Location = new System.Drawing.Point(12, 61);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(55, 20);
            this.textId.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Plugin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Contacts";
            // 
            // FormRemoveAccount
            // 
            this.AcceptButton = this.buttonRemove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(257, 411);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.comboAccounts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textPlugin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listChattersContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRemoveAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove Account";
            this.Shown += new System.EventHandler(this.FormRemoveAccount_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textPlugin;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListView listChattersContacts;
        private System.Windows.Forms.ComboBox comboAccounts;
        public System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}