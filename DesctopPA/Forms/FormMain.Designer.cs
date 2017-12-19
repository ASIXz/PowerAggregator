namespace DesctopPA
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("ввввв");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("ііііі");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("ццццц");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listAgregatorContacts = new System.Windows.Forms.ListView();
            this.contextAgregated = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listChattersContacts = new System.Windows.Forms.ListView();
            this.contextNotAgregeted = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextAgregated.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextNotAgregeted.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contacts";
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(259, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(644, 424);
            this.listBox1.TabIndex = 2;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox1_MeasureItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(484, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Messages";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.accountsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPluginToolStripMenuItem,
            this.removePluginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // addPluginToolStripMenuItem
            // 
            this.addPluginToolStripMenuItem.Name = "addPluginToolStripMenuItem";
            this.addPluginToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addPluginToolStripMenuItem.Text = "Add plugin";
            this.addPluginToolStripMenuItem.Click += new System.EventHandler(this.addPluginToolStripMenuItem_Click);
            // 
            // removePluginToolStripMenuItem
            // 
            this.removePluginToolStripMenuItem.Name = "removePluginToolStripMenuItem";
            this.removePluginToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removePluginToolStripMenuItem.Text = "Remove plugin";
            this.removePluginToolStripMenuItem.Click += new System.EventHandler(this.removePluginToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountToolStripMenuItem,
            this.removeAccountToolStripMenuItem,
            this.reloginToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addAccountToolStripMenuItem.Text = "Add account";
            this.addAccountToolStripMenuItem.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // removeAccountToolStripMenuItem
            // 
            this.removeAccountToolStripMenuItem.Name = "removeAccountToolStripMenuItem";
            this.removeAccountToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeAccountToolStripMenuItem.Text = "Remove account";
            // 
            // reloginToolStripMenuItem
            // 
            this.reloginToolStripMenuItem.Name = "reloginToolStripMenuItem";
            this.reloginToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.reloginToolStripMenuItem.Text = "Relogin";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(241, 485);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listAgregatorContacts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(233, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PA Contacts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listAgregatorContacts
            // 
            this.listAgregatorContacts.ContextMenuStrip = this.contextAgregated;
            this.listAgregatorContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listAgregatorContacts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listAgregatorContacts.Location = new System.Drawing.Point(6, 6);
            this.listAgregatorContacts.Name = "listAgregatorContacts";
            this.listAgregatorContacts.Size = new System.Drawing.Size(221, 447);
            this.listAgregatorContacts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listAgregatorContacts.TabIndex = 1;
            this.listAgregatorContacts.TileSize = new System.Drawing.Size(168, 44);
            this.listAgregatorContacts.UseCompatibleStateImageBehavior = false;
            this.listAgregatorContacts.View = System.Windows.Forms.View.Tile;
            this.listAgregatorContacts.ItemActivate += new System.EventHandler(this.listAgregatorContacts_ItemActivate);
            // 
            // contextAgregated
            // 
            this.contextAgregated.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editContactToolStripMenuItem,
            this.removeContactToolStripMenuItem,
            this.viewInfoToolStripMenuItem1});
            this.contextAgregated.Name = "contextAgregated";
            this.contextAgregated.Size = new System.Drawing.Size(161, 70);
            this.contextAgregated.Opening += new System.ComponentModel.CancelEventHandler(this.contextAgregated_Opening);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.editContactToolStripMenuItem_Click);
            // 
            // removeContactToolStripMenuItem
            // 
            this.removeContactToolStripMenuItem.Name = "removeContactToolStripMenuItem";
            this.removeContactToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.removeContactToolStripMenuItem.Text = "Remove contact";
            // 
            // viewInfoToolStripMenuItem1
            // 
            this.viewInfoToolStripMenuItem1.Name = "viewInfoToolStripMenuItem1";
            this.viewInfoToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.viewInfoToolStripMenuItem1.Text = "View info";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listChattersContacts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(233, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Not Agregated";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listChattersContacts
            // 
            this.listChattersContacts.ContextMenuStrip = this.contextNotAgregeted;
            this.listChattersContacts.Location = new System.Drawing.Point(19, 23);
            this.listChattersContacts.Name = "listChattersContacts";
            this.listChattersContacts.Size = new System.Drawing.Size(190, 430);
            this.listChattersContacts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listChattersContacts.TabIndex = 2;
            this.listChattersContacts.UseCompatibleStateImageBehavior = false;
            this.listChattersContacts.View = System.Windows.Forms.View.Tile;
            this.listChattersContacts.ItemActivate += new System.EventHandler(this.listChattersContacts_ItemActivate);
            // 
            // contextNotAgregeted
            // 
            this.contextNotAgregeted.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createContactToolStripMenuItem,
            this.addToContactToolStripMenuItem,
            this.viewInfoToolStripMenuItem});
            this.contextNotAgregeted.Name = "contextNotAgregeted";
            this.contextNotAgregeted.Size = new System.Drawing.Size(154, 70);
            this.contextNotAgregeted.Opening += new System.ComponentModel.CancelEventHandler(this.contextNotAgregeted_Opening);
            // 
            // createContactToolStripMenuItem
            // 
            this.createContactToolStripMenuItem.Name = "createContactToolStripMenuItem";
            this.createContactToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.createContactToolStripMenuItem.Text = "Create contact";
            this.createContactToolStripMenuItem.Click += new System.EventHandler(this.createContactToolStripMenuItem_Click);
            // 
            // addToContactToolStripMenuItem
            // 
            this.addToContactToolStripMenuItem.Name = "addToContactToolStripMenuItem";
            this.addToContactToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addToContactToolStripMenuItem.Text = "Add to contact";
            this.addToContactToolStripMenuItem.Click += new System.EventHandler(this.addToContactToolStripMenuItem_Click);
            // 
            // viewInfoToolStripMenuItem
            // 
            this.viewInfoToolStripMenuItem.Name = "viewInfoToolStripMenuItem";
            this.viewInfoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.viewInfoToolStripMenuItem.Text = "View info";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(259, 488);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 52);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(826, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "DesktopPA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextAgregated.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextNotAgregeted.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAccountToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listAgregatorContacts;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listChattersContacts;
        private System.Windows.Forms.ContextMenuStrip contextAgregated;
        private System.Windows.Forms.ContextMenuStrip contextNotAgregeted;
        private System.Windows.Forms.ToolStripMenuItem createContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem removeContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloginToolStripMenuItem;
    }
}

