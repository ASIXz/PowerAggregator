namespace DesctopPA
{
    partial class FormAddAcccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddAcccount));
            this.comboPlugins = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelPlugin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.labelVerification = new System.Windows.Forms.Label();
            this.textVerification = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboPlugins
            // 
            this.comboPlugins.FormattingEnabled = true;
            this.comboPlugins.Location = new System.Drawing.Point(12, 64);
            this.comboPlugins.Name = "comboPlugins";
            this.comboPlugins.Size = new System.Drawing.Size(309, 21);
            this.comboPlugins.TabIndex = 3;
            this.comboPlugins.SelectedIndexChanged += new System.EventHandler(this.comboPlugins_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(182, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelPlugin
            // 
            this.labelPlugin.AutoSize = true;
            this.labelPlugin.Location = new System.Drawing.Point(12, 48);
            this.labelPlugin.Name = "labelPlugin";
            this.labelPlugin.Size = new System.Drawing.Size(36, 13);
            this.labelPlugin.TabIndex = 4;
            this.labelPlugin.Text = "Plugin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 1;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 88);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(33, 13);
            this.labelLogin.TabIndex = 10;
            this.labelLogin.Text = "Login";
            this.labelLogin.Visible = false;
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(12, 104);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(309, 20);
            this.textLogin.TabIndex = 4;
            this.textLogin.Visible = false;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(12, 127);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(53, 13);
            this.labelPass.TabIndex = 12;
            this.labelPass.Text = "Password";
            this.labelPass.Visible = false;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(12, 143);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(309, 20);
            this.textPass.TabIndex = 5;
            this.textPass.Visible = false;
            // 
            // labelVerification
            // 
            this.labelVerification.AutoSize = true;
            this.labelVerification.Location = new System.Drawing.Point(13, 166);
            this.labelVerification.Name = "labelVerification";
            this.labelVerification.Size = new System.Drawing.Size(84, 13);
            this.labelVerification.TabIndex = 14;
            this.labelVerification.Text = "VerificationCode";
            this.labelVerification.Visible = false;
            // 
            // textVerification
            // 
            this.textVerification.Location = new System.Drawing.Point(13, 182);
            this.textVerification.Name = "textVerification";
            this.textVerification.Size = new System.Drawing.Size(309, 20);
            this.textVerification.TabIndex = 6;
            this.textVerification.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(259, 25);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Preffix";
            // 
            // FormAddAcccount
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(349, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelVerification);
            this.Controls.Add(this.textVerification);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelPlugin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboPlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddAcccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddAcccountForm";
            this.Shown += new System.EventHandler(this.FormAddAcccount_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPlugins;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelPlugin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label labelVerification;
        private System.Windows.Forms.TextBox textVerification;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}