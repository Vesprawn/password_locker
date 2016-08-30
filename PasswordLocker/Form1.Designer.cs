namespace PasswordLocker {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.btnSubmitPassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMainView = new System.Windows.Forms.Panel();
            this.btnHidePasswords = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.pnlAccountInfo = new System.Windows.Forms.Panel();
            this.listAccounts = new System.Windows.Forms.ListBox();
            this.pnlSetupView = new System.Windows.Forms.Panel();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.txtSetPassword = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPassword.SuspendLayout();
            this.pnlMainView.SuspendLayout();
            this.pnlSetupView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPassword
            // 
            this.pnlPassword.Controls.Add(this.btnSubmitPassword);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Controls.Add(this.label2);
            this.pnlPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPassword.Location = new System.Drawing.Point(0, 0);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(625, 316);
            this.pnlPassword.TabIndex = 0;
            // 
            // btnSubmitPassword
            // 
            this.btnSubmitPassword.Location = new System.Drawing.Point(353, 50);
            this.btnSubmitPassword.Name = "btnSubmitPassword";
            this.btnSubmitPassword.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitPassword.TabIndex = 4;
            this.btnSubmitPassword.Text = "Submit";
            this.btnSubmitPassword.UseVisualStyleBackColor = true;
            this.btnSubmitPassword.Click += new System.EventHandler(this.btnSubmitPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(193, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // pnlMainView
            // 
            this.pnlMainView.Controls.Add(this.label1);
            this.pnlMainView.Controls.Add(this.txtSearch);
            this.pnlMainView.Controls.Add(this.btnHidePasswords);
            this.pnlMainView.Controls.Add(this.btnRemove);
            this.pnlMainView.Controls.Add(this.btnAddAccount);
            this.pnlMainView.Controls.Add(this.pnlAccountInfo);
            this.pnlMainView.Controls.Add(this.listAccounts);
            this.pnlMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainView.Location = new System.Drawing.Point(0, 0);
            this.pnlMainView.Name = "pnlMainView";
            this.pnlMainView.Size = new System.Drawing.Size(625, 316);
            this.pnlMainView.TabIndex = 5;
            this.pnlMainView.Visible = false;
            // 
            // btnHidePasswords
            // 
            this.btnHidePasswords.Location = new System.Drawing.Point(462, 274);
            this.btnHidePasswords.Name = "btnHidePasswords";
            this.btnHidePasswords.Size = new System.Drawing.Size(151, 37);
            this.btnHidePasswords.TabIndex = 4;
            this.btnHidePasswords.Text = "Hide";
            this.btnHidePasswords.UseVisualStyleBackColor = true;
            this.btnHidePasswords.Click += new System.EventHandler(this.btnHidePasswords_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(42, 274);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(120, 274);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(43, 23);
            this.btnAddAccount.TabIndex = 2;
            this.btnAddAccount.Text = "Add";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // pnlAccountInfo
            // 
            this.pnlAccountInfo.Location = new System.Drawing.Point(169, 69);
            this.pnlAccountInfo.Name = "pnlAccountInfo";
            this.pnlAccountInfo.Size = new System.Drawing.Size(444, 199);
            this.pnlAccountInfo.TabIndex = 1;
            // 
            // listAccounts
            // 
            this.listAccounts.FormattingEnabled = true;
            this.listAccounts.Location = new System.Drawing.Point(12, 69);
            this.listAccounts.Name = "listAccounts";
            this.listAccounts.Size = new System.Drawing.Size(151, 199);
            this.listAccounts.TabIndex = 0;
            this.listAccounts.SelectedIndexChanged += new System.EventHandler(this.listAccounts_SelectedIndexChanged);
            // 
            // pnlSetupView
            // 
            this.pnlSetupView.Controls.Add(this.btnSetPassword);
            this.pnlSetupView.Controls.Add(this.txtSetPassword);
            this.pnlSetupView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetupView.Location = new System.Drawing.Point(0, 0);
            this.pnlSetupView.Name = "pnlSetupView";
            this.pnlSetupView.Size = new System.Drawing.Size(625, 316);
            this.pnlSetupView.TabIndex = 5;
            this.pnlSetupView.Visible = false;
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Location = new System.Drawing.Point(214, 22);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(114, 23);
            this.btnSetPassword.TabIndex = 1;
            this.btnSetPassword.Text = "Save Password";
            this.btnSetPassword.UseVisualStyleBackColor = true;
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // txtSetPassword
            // 
            this.txtSetPassword.Location = new System.Drawing.Point(12, 24);
            this.txtSetPassword.Name = "txtSetPassword";
            this.txtSetPassword.Size = new System.Drawing.Size(196, 20);
            this.txtSetPassword.TabIndex = 0;
            this.txtSetPassword.UseSystemPasswordChar = true;
            this.txtSetPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSetPassword_KeyUp);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(59, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(104, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 316);
            this.Controls.Add(this.pnlMainView);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.pnlSetupView);
            this.Name = "Form1";
            this.Text = "Password Locker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlMainView.ResumeLayout(false);
            this.pnlMainView.PerformLayout();
            this.pnlSetupView.ResumeLayout(false);
            this.pnlSetupView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmitPassword;
        private System.Windows.Forms.Panel pnlMainView;
        private System.Windows.Forms.ListBox listAccounts;
        private System.Windows.Forms.Panel pnlAccountInfo;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Panel pnlSetupView;
        private System.Windows.Forms.Button btnSetPassword;
        private System.Windows.Forms.TextBox txtSetPassword;
        private System.Windows.Forms.Button btnHidePasswords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

